namespace Neuron.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AnimationEngine : IDisposable
    {
        private readonly List<Animation> animations = new List<Animation>();
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly Thread worker;

        private bool disposed;
        private volatile bool stopping;

        public AnimationEngine()
        {
            this.worker = new Thread(this.WorkerRoutine) { IsBackground = true };
            this.worker.Start(SynchronizationContext.Current);
        }

        ~AnimationEngine()
        {
            this.Dispose(false);
        }

        public void Execute(Animation animation)
        {
            lock (this.animations)
            {
                this.animations.Add(animation);
            }
        }

        public void ExecuteExclusive(Animation animation)
        {
            lock (this.animations)
            {
                this.animations.RemoveAll(a => a.Target == animation.Target);
                this.animations.Add(animation);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.cancellationTokenSource.Cancel();
            if (this.disposed || !disposing)
            {
                return;
            }

            this.worker.Join();
            this.disposed = true;
        }

        private void WorkerRoutine(object synchronizationContext)
        {
            SynchronizationContext.SetSynchronizationContext((SynchronizationContext)synchronizationContext);
            var cancellationToken = this.cancellationTokenSource.Token;
            while (!cancellationToken.IsCancellationRequested)
            {
                var completed = new List<Animation>();
                lock (this.animations)
                {
                    var now = DateTime.Now;
                    foreach (var a in this.animations.TakeWhile(x => !cancellationToken.IsCancellationRequested))
                    {
                        a.Tick(now);
                        if (a.EndTime >= now)
                        {
                            continue;
                        }

                        if (cancellationToken.IsCancellationRequested)
                        {
                            return;
                        }

                        a.Tick(a.EndTime);
                        completed.Add(a);
                    }

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    this.animations.RemoveAll(a => a.EndTime < now);
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                foreach (var a in completed.TakeWhile(a => !cancellationToken.IsCancellationRequested))
                {
                    a.FireCompleted();
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                Thread.Sleep(25);
            }
        }
    }
}
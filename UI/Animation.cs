using System;
using System.Threading;

namespace Neuron.UI
{
    public abstract class Animation
    {
        protected Animation(object target, TimeSpan duration)
        {
            StartTime = DateTime.Now;
            Duration = duration;
            Target = target;
        }

        protected Animation(object target, DateTime startTime, TimeSpan duration)
        {
            StartTime = startTime;
            Duration = duration;
            Target = target;
        }

        public bool Ease
        {
            get;
            set;
        }

        public DateTime StartTime
        {
            get;
            private set;
        }

        public TimeSpan Duration
        {
            get;
            private set;
        }

        public object Target
        {
            get;
            private set;
        }

        public DateTime EndTime
        {
            get
            {
                return StartTime + Duration;
            }
        }

        internal void Tick(DateTime now)
        {
            var offset = now - StartTime;
            if (offset <= TimeSpan.Zero || offset > this.Duration)
            {
                return;
            }

            var easeOutStart = TimeSpan.FromMilliseconds(this.Duration.TotalMilliseconds * .1);
            var easeOutDuration = (this.Duration - easeOutStart);
            if (offset > easeOutStart)
            {
                var tMax = easeOutDuration.TotalMilliseconds;
                var d = easeOutDuration.TotalMilliseconds;
                var r = (2*d / Math.Pow(tMax, 2));
                var t = offset.TotalMilliseconds - easeOutStart.TotalMilliseconds;
                d = 2 * t - .5 * r * Math.Pow(t, 2);
                this.OnTick(easeOutStart + TimeSpan.FromMilliseconds(d));
            }
            else
            {
                this.OnTick(offset);
            }

            this.FireUpdated();
        }

        protected abstract void OnTick(TimeSpan offset);

        public event EventHandler Updated;

        public event EventHandler Completed;

        protected internal void FireCompleted()
        {
            if (SynchronizationContext.Current == null)
            {
                var evt = Completed;
                if (evt != null)
                {
                    evt(this, EventArgs.Empty);
                }
            }
            else
            {
                SynchronizationContext.Current.Post(
                    d =>
                        {
                            var evt = Completed;
                            if (evt != null)
                            {
                                evt(this, EventArgs.Empty);
                            }
                        },
                    null);
            }
        }

        protected void FireUpdated()
        {            
            if (SynchronizationContext.Current == null)
            {
                var evt = Updated;
                if (evt != null)
                {
                    evt(this, EventArgs.Empty);
                }
            }
            else
            {
                SynchronizationContext.Current.Post(
                    d =>
                        {
                            var evt = Updated;

                            if (evt != null)
                            {
                                evt(this, EventArgs.Empty);
                            }
                        },
                    null);
            }
        }
        
    }
}

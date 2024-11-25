namespace Neuron.UI
{
    using System;

    public class DoubleAnimation : Animation
    {
        public DoubleAnimation(object target, TimeSpan duration, double start, double end) : base(target, duration)
        {
            this.Start = start;
            this.End = end;
            this.Current = start;
        }

        public DoubleAnimation(object target, DateTime startTime, TimeSpan duration, double start, double end)
            : base(target, startTime, duration)
        {
            this.Start = start;
            this.End = end;
            this.Current = start;
        }

        public Double Start
        {
            get;
            private set;
        }

        public Double End
        {
            get;
            private set;
        }

        public Double Current
        {
            get;
            private set;
        }

        protected override void OnTick(TimeSpan offset)
        {
            this.Current = this.Start + (this.End - this.Start) * offset.TotalMilliseconds / this.Duration.TotalMilliseconds;
        }

    }
}
namespace Neuron.UI
{
    using System;
    using System.Drawing;

    public class RectangleAnimation : Animation
    {
        public RectangleAnimation(object target, TimeSpan duration, Rectangle start, Rectangle end) : base(target, duration)
        {
            this.Start = start;
            this.End = end;
            this.Current = start;
        }

        public RectangleAnimation(object target, DateTime startTime, TimeSpan duration, Rectangle start, Rectangle end) : base(target, startTime, duration)
        {
            this.Start = start;
            this.End = end;
            this.Current = start;
        }

        public Rectangle Start
        {
            get;
            private set;
        }

        public Rectangle End
        {
            get;
            private set;
        }

        public Rectangle Current
        {
            get;
            private set;
        }

        protected override void OnTick(TimeSpan offset)
        {
            double percent = offset.TotalMilliseconds / this.Duration.TotalMilliseconds;

            int dx = (int)((this.End.X - this.Start.X) * percent);
            int dy = (int)((this.End.Y - this.Start.Y) * percent);

            int dw = (int)((this.End.Width - this.Start.Width) * percent);
            int dh = (int)((this.End.Height - this.Start.Height) * percent);

            this.Current = new Rectangle(this.Start.X + dx, this.Start.Y + dy, this.Start.Width+ dw, this.Start.Height+dh);
        }
    }
}
namespace Neuron.UI
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class AttachPoints
    {
        public static Point[] DetermineBezierPoints(Rectangle left, Rectangle right, double tension)
        {
            return DetermineBezierPoints(left, right, tension, Attachment.Any, Attachment.Any);
        }

        public static Point[] DetermineBezierPoints(Rectangle left, Rectangle right, double tension, Attachment leftOptions, Attachment rightOptions)
        {
            int tensionFactor = (int)(1 / tension);

            Point[] points = new Point[4];

            AttachPoints ap = DetermineAttachPoints(left, right, leftOptions, rightOptions);
            points[0] = ap.Left;
            if (ap.Left.Y != left.GetCenter().Y) // attach horiz
            {
                points[1] = new Point(ap.Left.X, ap.Left.Y + (ap.Right.Y - ap.Left.Y) / tensionFactor);
            }
            else // attach vert
            {
                points[1] = new Point(ap.Left.X + (ap.Right.X - ap.Left.X) / tensionFactor, ap.Left.Y);
            }

            if (ap.Right.Y != right.GetCenter().Y) // attach horiz
            {
                points[2] = new Point(ap.Right.X, ap.Right.Y + (ap.Left.Y - ap.Right.Y) / tensionFactor);
            }
            else // attach vert
            {
                points[2] = new Point(ap.Right.X + (ap.Left.X - ap.Right.X) / tensionFactor, ap.Right.Y);
            }
            points[3] = ap.Right;
            return points;
        }

        public AttachPoints(Point left, Point right)
        {
            this.Left = left;
            this.Right = right;
        }

        public Point Left
        {
            get;
            set;
        }
        public Point Right
        {
            get;
            set;
        }

        public static AttachPoints DetermineAttachPoints(Rectangle left, Rectangle right)
        {
            return DetermineAttachPoints(left, right, Attachment.Any);
        }

        class Connection
        {
            public Connection(Point left, Point right)
            {
                this.Left = left;
                this.Right = right;

                this.Distance = Math.Sqrt((left.X - right.X) * (left.X - right.X) + (left.Y - right.Y) * (left.Y - right.Y));
            }

            public Point Left;
            public Point Right;

            public double Distance;
        }

        public static AttachPoints DetermineAttachPoints(Rectangle left, Rectangle right, Attachment options)
        {
            return DetermineAttachPoints(left, right, options, options);
        }
        public static AttachPoints DetermineAttachPoints(Rectangle left, Rectangle right, Attachment leftOpt, Attachment rightOpt)
        {
            List<Point> leftOptions = new List<Point>();

            if ((leftOpt & Attachment.Horizontal) != Attachment.None) leftOptions.Add(new Point(left.Left, left.GetCenter().Y));
            if ((leftOpt & Attachment.Horizontal) != Attachment.None) leftOptions.Add(new Point(left.Right, left.GetCenter().Y));
            if ((leftOpt & Attachment.Vertical) != Attachment.None) leftOptions.Add(new Point(left.GetCenter().X, left.Top));
            if ((leftOpt & Attachment.Vertical) != Attachment.None) leftOptions.Add(new Point(left.GetCenter().X, left.Bottom));

            List<Point> rightOptions = new List<Point>();

            if ((rightOpt & Attachment.Horizontal) != Attachment.None) rightOptions.Add(new Point(right.Left, right.GetCenter().Y));
            if ((rightOpt & Attachment.Horizontal) != Attachment.None) rightOptions.Add(new Point(right.Right, right.GetCenter().Y));
            if ((rightOpt & Attachment.Vertical) != Attachment.None) rightOptions.Add(new Point(right.GetCenter().X, right.Top));
            if ((rightOpt & Attachment.Vertical) != Attachment.None) rightOptions.Add(new Point(right.GetCenter().X, right.Bottom));

            Connection smallest = null;
            foreach (var p1 in leftOptions)
            {
                foreach (var p2 in rightOptions)
                {
                    Connection connection = new Connection(p1, p2);
                    if (smallest == null)
                    {
                        smallest = connection;
                    }
                    else if (smallest.Distance > connection.Distance)
                    {
                        smallest = connection;
                    }
                }
            }

            return new AttachPoints(smallest.Left, smallest.Right);

        }
    }
}
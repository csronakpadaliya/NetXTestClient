namespace Neuron.UI
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class BezierUIElementAttachment : UIElementAttachment
    {
        public BezierUIElementAttachment()
        {
            this.Color = Color.Gray;
            this.Style = DashStyle.Solid;
            this.Width = 1;
            this.Tension = .5F;
        }

        public Color Color
        {
            get;
            set;
        }

        public DashStyle Style
        {
            get;
            set;
        }

        public float Width
        {
            get;
            set;
        }

        public float Tension
        {
            get;
            set;
        }

        internal override void Draw(PaintEventArgs e)
        {
            Point[] bezierPoints = AttachPoints.DetermineBezierPoints(this.LeftElement.Bounds, this.RightElement.Bounds, this.Tension, this.LeftOption, this.RightOption);    
            using(Pen pen = new Pen(this.Color, this.Width))
            {
                pen.DashStyle = this.Style;
                if(this.LeftCap != null) pen.CustomStartCap = this.LeftCap;
                if(this.RightCap != null) pen.CustomEndCap = this.RightCap;
                e.Graphics.DrawBezierSafe(pen, bezierPoints[0], bezierPoints[1], bezierPoints[2], bezierPoints[3]);
            }
        }
    }
}
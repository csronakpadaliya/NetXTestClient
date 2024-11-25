namespace Neuron.UI
{
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public abstract class UIElementAttachment
    {
        public UIElementAttachment()
        {
            this.LeftOption = Attachment.Any;
            this.RightOption = Attachment.Any;
        }
        public Attachment LeftOption
        {
            get;
            set;
        }

        public Attachment RightOption
        {
            get;
            set;
        }


        public UIElement LeftElement
        {
            get;
            set;
        }

        public UIElement RightElement
        {
            get;
            set;
        }

        public CustomLineCap LeftCap
        {
            get;
            set;
        }

        public CustomLineCap RightCap
        {
            get;
            set;
        }
        
        internal abstract void Draw(PaintEventArgs e); 

    }
}
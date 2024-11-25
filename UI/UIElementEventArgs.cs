namespace Neuron.UI
{
    using System;

    public class UIElementEventArgs : EventArgs
    {
        public UIElementEventArgs(UIElement element)
        {
            this.Element = element;
        }

        public UIElement Element
        {
            get;
            private set;
        }
    }
}
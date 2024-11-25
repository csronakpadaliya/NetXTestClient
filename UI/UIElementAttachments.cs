namespace Neuron.UI
{
    using System.Collections.ObjectModel;

    public class UIElementAttachments : Collection<UIElementAttachment>
    {
        public void RemoveLeft(UIElement element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                UIElementAttachment a = this[i];
                if (a.LeftElement == element)
                {
                    this.Remove(a);
                    i--;
                }
            }
        }

        public void RemoveRight(UIElement element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                UIElementAttachment a = this[i];
                if (a.RightElement == element)
                {
                    this.Remove(a);
                    i--;
                }
            }
        }

        public void Remove(UIElement element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                UIElementAttachment a = this[i];
                if (a.RightElement == element || a.LeftElement == element)
                {
                    this.Remove(a);
                    i--;
                }
            }
        }
    }
}
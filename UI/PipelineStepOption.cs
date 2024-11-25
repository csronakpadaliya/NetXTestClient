namespace Neuron.Pipelines.Design
{
    using System;
    using System.Drawing;

    using Neuron.NetX;
    using Neuron.NetX.Pipelines;
    using Neuron.UI;

    [Serializable]
    public class PipelineStepOption
    {
        public PipelineStepOption()
        {
            this.DisplayInToolbox = true;
        }

        public Type PipelineStep
        {
            get;
            set;
        }

        public Type UIElementType
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Path { get; set; }
        public string Description
        {
            get;
            set;
        }

        public Image Image
        {
            get;
            set;
        }

        public bool DisplayInToolbox { get; set; }

        public virtual IPipelineStep CreateStep()
        {
            return (IPipelineStep)Activator.CreateInstance(this.PipelineStep);
        }

        public UIElement CreateElement(Pipeline<ESBMessage> pipeline)
        {
            var element = (UIElement)Activator.CreateInstance(this.UIElementType, pipeline);
            var c = element as UIElementContainer;
            if (c == null || c.Layout is ManualLayout)
            {
                element.Bounds = new Rectangle(0, 0, 64, 64);
            }

            return element;
        }
    }
}
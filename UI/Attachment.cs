namespace Neuron.UI
{
    using System;

    [Flags]
    public enum Attachment
    {
        None,
        Any = -1,
        Horizontal = 2,
        Vertical = 8
    }
}
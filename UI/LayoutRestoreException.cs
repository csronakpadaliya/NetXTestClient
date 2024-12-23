namespace Neuron.UI
{
    using System;

    [Serializable]
    public class LayoutRestoreException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public LayoutRestoreException() { }
        public LayoutRestoreException(string message) : base(message) { }
        public LayoutRestoreException(string message, Exception inner) : base(message, inner) { }
        protected LayoutRestoreException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuron.UI
{
    [global::System.Serializable]
    public class CancelClickException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CancelClickException() { }
        public CancelClickException(string message) : base(message) { }
        public CancelClickException(string message, Exception inner) : base(message, inner) { }
        protected CancelClickException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

}

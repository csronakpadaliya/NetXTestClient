using System;
using System.Collections.Generic;
using System.Text;

namespace Neuron.TestClient
{
    public class ErrorListBoxItem
    {
        public Exception Exception;
        public String Detail;

        public override String ToString()
        {
            return Detail;
        }
    }
}

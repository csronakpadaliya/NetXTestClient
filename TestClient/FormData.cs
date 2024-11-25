using System;
using System.Collections.Generic;
using System.Text;
using Neuron.NetX;

namespace Neuron.TestClient
{
    public class FormData
    {
        public String MessageText = "";
        public String ActionText = "";
        public String SemanticText = "";
        public String PriorityText = "";
        public String SendTopicText = "";
        public String SendDestText = "";

        public int messageCount = 0;
        public int messageSize = 0;
        public int sendDelay = 0;
        public int sendInterval = 0;

        public bool SendObject { get; set; }
        public bool SendString { get; set; }
        public bool SendXml { get; set; }
        public bool SendBinary { get; set; }

        public bool NonRepeatingMessage { get; set; }
        public SendOptions SendOptions { get; set; }

    }
}

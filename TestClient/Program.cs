using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Windows.Forms;
using System.IO;
using Neuron.NetX;

namespace Neuron.TestClient
{
    using log4net.Config;
    using System.Net;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            //System.Diagnostics.Debugger.Launch();
            XmlConfigurator.Configure();
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
            //                                       SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; // | SecurityProtocolType.Tls13;

            CommandArguments arguments = new CommandArguments();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("/p:"))
                {
                    arguments.PartyId = args[i].Substring(3).Trim();
                }

                if (args[i].StartsWith("/m:"))
                {
                    arguments.FileName = args[i].Substring(3).Trim();
                }
            }

            FormTestClient testClient = new FormTestClient(arguments);
            Application.Run(testClient);
        }
    }
}
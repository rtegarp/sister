using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RMIServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RMI Server started");

            TcpChannel tcpChannel = new TcpChannel(9999);
            ChannelServices.RegisterChannel(tcpChannel, true);

            Type commonInterfaceType = Type.GetType("RMIServer.XmlReader");

            RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType,
            "XMLReader", WellKnownObjectMode.SingleCall);

            System.Console.WriteLine("Press ENTER to quit");
            System.Console.ReadLine();
        }
    }
}

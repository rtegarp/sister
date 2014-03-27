using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Server;

namespace Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            TcpChannel tcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(tcpChannel);
 
            Type requiredType = typeof(MovieTicketInterface);
 
            MovieTicketInterface remoteObject = (MovieTicketInterface)Activator.GetObject(requiredType,
            "tcp://localhost:9998/MovieTicketBooking");
 
            Console.WriteLine(remoteObject.GetTicketStatus("Ticket No: 3344"));
        }
    }
}

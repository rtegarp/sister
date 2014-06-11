using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketServer();
        }
        static void TicketServer()
        {
            Console.WriteLine("Ticket Server started...");

            TcpChannel tcpChannel = new TcpChannel(9998);
            ChannelServices.RegisterChannel(tcpChannel, false);

            Type commonInterfaceType = Type.GetType("Server.MovieTicket");

            RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType,"MovieTicketBooking", WellKnownObjectMode.SingleCall);

            System.Console.WriteLine("Press ENTER to quit");
            System.Console.ReadLine();

        }

    }

    public interface MovieTicketInterface
    {
         string GetTicketStatus(string stringToPrint);
    }

    public class MovieTicket : MarshalByRefObject, MovieTicketInterface
    {
        public string GetTicketStatus(string stringToPrint)
        {
            string returnStatus = "Ticket Confirmed";
            Console.WriteLine("Enquiry for {0}", stringToPrint);
            Console.WriteLine("Sending back status: {0}", returnStatus);
            return returnStatus;
        }
    }
}


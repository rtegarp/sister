using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SerializableData;

namespace Server
{
    public partial class SGSserverForm : Form
    {
        struct ClientInfo
        {
            public EndPoint endpoint;
            public string strName;
        }

        ArrayList clientList;

        Socket serverSocket;

        byte[] byteData = new byte[1024];

        public SGSserverForm()
        {
            clientList = new ArrayList();
            InitializeComponent();
        }

        public Dictionary<string, string> cuaca;

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();
            try
            {
	        CheckForIllegalCrossThreadCalls = false;

                serverSocket = new Socket(AddressFamily.InterNetwork, 
                    SocketType.Dgram, ProtocolType.Udp);

                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 1000);

                serverSocket.Bind(ipEndPoint);
            
                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint epSender = (EndPoint) ipeSender;

                serverSocket.BeginReceiveFrom (byteData, 0, byteData.Length, 
                    SocketFlags.None, ref epSender, new AsyncCallback(OnReceive), epSender);                
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "SGSServerUDP", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }            
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint epSender = (EndPoint)ipeSender;

                serverSocket.EndReceiveFrom (ar, ref epSender);
                
                MemoryStream ms = new MemoryStream(byteData);
                BinaryFormatter formatter = new BinaryFormatter();
                Data msgReceived = (Data)formatter.Deserialize(ms);

                Data msgToSend = new Data();

                byte [] message;
                
                msgToSend.cmdCommand = msgReceived.cmdCommand;
                msgToSend.strName = msgReceived.strName;

                switch (msgReceived.cmdCommand)
                {
                    case SerializableData.Data.Command.Login:

                        ClientInfo clientInfo = new ClientInfo();
                        clientInfo.endpoint = epSender;      
                        clientInfo.strName = msgReceived.strName;                 
                        clientList.Add(clientInfo);
                        /*listPlayer.Items.Clear();
                        foreach (ClientInfo client in clientList)
                        {
                            //To keep things simple we use asterisk as the marker to separate the user names
                            listPlayer.Items.Add(client.strName);
                        }*/
                        msgToSend.strMessage = "<<<" + msgReceived.strName + " telah terhubung dengan server>>>";
                        MemoryStream fslogin = new MemoryStream();
                        formatter = new BinaryFormatter();
                        formatter.Serialize(fslogin, msgToSend);
                        message = fslogin.ToArray();

                        serverSocket.BeginSendTo (message, 0, message.Length, SocketFlags.None, epSender, 
                                new AsyncCallback(OnSend), epSender);
                        break;

                    case SerializableData.Data.Command.Logout:                    
                                                
                        int nIndex = 0;
                        foreach (ClientInfo client in clientList)
                        {
                            if (client.endpoint == epSender)
                            {
                                clientList.RemoveAt(nIndex);
                                MessageBox.Show("ada yg keluar nih");
                                break;
                            }
                            ++nIndex;
                        }
                        /*listPlayer.Items.Clear();
                        foreach (ClientInfo client in clientList)
                        {
                            listPlayer.Items.Add(client.strName);
                        }*/                    
                        
                        break;

                    case SerializableData.Data.Command.Message:

                        string perkiraanCuaca;
                        cuaca.TryGetValue(msgReceived.strMessage, out perkiraanCuaca);
                        if(msgReceived.strMessage == "Semua Hari")
                            msgToSend.strMessage = perkiraanCuaca;
                        else
                            msgToSend.strMessage = msgReceived.strMessage + " - " + perkiraanCuaca;
                        break;                    
                }
                
                MemoryStream fs = new MemoryStream();
                formatter = new BinaryFormatter();
                formatter.Serialize(fs, msgToSend);
                message = fs.ToArray();
                                        
                if (msgToSend.cmdCommand != SerializableData.Data.Command.Login)
                {
                    serverSocket.BeginSendTo (message, 0, message.Length, SocketFlags.None, epSender, 
                        new AsyncCallback(OnSend), epSender);                           
                }

                txtLog.Text += msgToSend.strMessage + "\r\n";

                if (msgReceived.cmdCommand != SerializableData.Data.Command.Logout)
                {
                    serverSocket.BeginReceiveFrom (byteData, 0, byteData.Length, SocketFlags.None, ref epSender, 
                        new AsyncCallback(OnReceive), epSender);
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "SGSServerUDP", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        public void OnSend(IAsyncResult ar)
        {
            try
            {                
                serverSocket.EndSend(ar);
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "SGSServerUDP", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void ReadFile()
        {
            cuaca = new Dictionary<string,string>();
            string allText = System.IO.File.ReadAllText(@"C:\Users\Chank\Documents\GitHub\sister\sistem terdistribusi\Perkiraan Cuaca\SGSserverUDP\Server\cuaca.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Chank\Documents\GitHub\sister\sistem terdistribusi\Perkiraan Cuaca\SGSserverUDP\Server\cuaca.txt");
            foreach (var line in lines)
            {
                string[] temp = line.Split('-');
                cuaca.Add(temp[0].Remove(temp[0].Length - 1, 1), temp[1].Remove(0, 1));
            }
            cuaca.Add("Semua Hari", allText);            
        }
    }      
}
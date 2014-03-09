using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SGSclient
{
    
    enum Command
    {
        Login,     
        Logout,    
        Message,    
        List,       
        Null        
    }

    public partial class SGSClient : Form
    {
        public Socket clientSocket; 
        public string strName;      
        public EndPoint epServer;   

        byte []byteData = new byte[1024];

        public SGSClient()
        {
            InitializeComponent();
            pilihComboBox.Items.Add("Senin, 11 Maret 2014");
            pilihComboBox.Items.Add("Selasa, 12 Maret 2014");
            pilihComboBox.Items.Add("Rabu, 13 Maret 2014");
            pilihComboBox.Items.Add("Kamis, 15 Maret 2014");
            pilihComboBox.Items.Add("Jumat, 16 Maret 2014");
            pilihComboBox.Items.Add("Semua Hari");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {		
                Data msgToSend = new Data();
                List<Data> coba = new List<Data>();
              
                msgToSend.strName = strName;
                msgToSend.strMessage = pilihComboBox.Text;
                msgToSend.cmdCommand = Command.Message;
                coba.Add(msgToSend);
                coba.Add(msgToSend);

                
               byte[] byteData = msgToSend.ToByte();

                clientSocket.BeginSendTo (byteData, 0, byteData.Length, SocketFlags.None, epServer, new AsyncCallback(OnSend), null);

                //txtMessage.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Tidak dapat menjangkau server", "SGSclientUDP: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }
        
        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SGSclient: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {            
            try
            {                
                clientSocket.EndReceive(ar);

                Data msgReceived = new Data(byteData);

                switch (msgReceived.cmdCommand)
                {
                    case Command.Login:
                        //lstChatters.Items.Add(msgReceived.strName);
                        break;

                    case Command.Logout:
                        lstChatters.Items.Remove(msgReceived.strName);
                        break;

                    case Command.Message:
                        break;

                    case Command.List:
                        lstChatters.Items.AddRange(msgReceived.strMessage.Split('*'));
                        lstChatters.Items.RemoveAt(lstChatters.Items.Count - 1);
                        txtChatBox.Text += "<<<" + strName + " Telah masuk ke dalam aplikasi cuaca>>>\r\n";
                        break;
                }

                if (msgReceived.strMessage != null && msgReceived.cmdCommand != Command.List)
                    txtChatBox.Text += msgReceived.strMessage + "\r\n";

                byteData = new byte[1024];                

                clientSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epServer,
                                           new AsyncCallback(OnReceive), null);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SGSclient: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
	    CheckForIllegalCrossThreadCalls = false;

            this.Text = "SGSclient: " + strName;
            
            Data msgToSend = new Data ();
            msgToSend.cmdCommand = Command.List;
            msgToSend.strName = strName;
            msgToSend.strMessage = null;

            byteData = msgToSend.ToByte();

            clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer, 
                new AsyncCallback(OnSend), null);

            byteData = new byte[1024];
            clientSocket.BeginReceiveFrom (byteData,
                                       0, byteData.Length,
                                       SocketFlags.None,
                                       ref epServer,
                                       new AsyncCallback(OnReceive),
                                       null);
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (pilihComboBox.Text.Length == 0)
                btnSend.Enabled = false;
            else
                btnSend.Enabled = true;
        }

        private void SGSClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Apakah anda ingin keluar dari aplikasi?", "SGSclient: " + strName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                //Send a message to logout of the server
                Data msgToSend = new Data ();
                msgToSend.cmdCommand = Command.Logout;
                msgToSend.strName = strName;
                msgToSend.strMessage = null;

                byte[] b = msgToSend.ToByte ();
                clientSocket.SendTo(b, 0, b.Length, SocketFlags.None, epServer);
                clientSocket.Close();
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SGSclient: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, null);
            }
        }
    }
    
    class Data
    {
        public Data()
        {
            this.cmdCommand = Command.Null;
            this.strMessage = null;
            this.strName = null;
        }

        public Data(byte[] data)
        {
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);

            int nameLen = BitConverter.ToInt32(data, 4);

            int msgLen = BitConverter.ToInt32(data, 8);

            if (nameLen > 0)
                this.strName = Encoding.UTF8.GetString(data, 12, nameLen);
            else
                this.strName = null;

            if (msgLen > 0)
                this.strMessage = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
            else
                this.strMessage = null;
        }

        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            if (strName != null)
                result.AddRange(BitConverter.GetBytes(strName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (strMessage != null)
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (strName != null)
                result.AddRange(Encoding.UTF8.GetBytes(strName));

            if (strMessage != null)
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));

            return result.ToArray();
        }

        public string strName;      
        public string strMessage;   
        public Command cmdCommand;  
    }
}
using System;
using System.Collections.Generic;
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

namespace SGSclient
{
    public partial class SGSClient : Form
    {
        public Socket clientSocket; 
        public string strName;      
        public EndPoint epServer;
        public DateTime time1, time2;
        byte []byteData = new byte[1024];

        public SGSClient()
        {
            InitializeComponent();
            pilihComboBox.Items.Add("Senin, 11 Maret 2014");
            pilihComboBox.Items.Add("Selasa, 12 Maret 2014");
            pilihComboBox.Items.Add("Rabu, 13 Maret 2014");
            pilihComboBox.Items.Add("Kamis, 14 Maret 2014");
            pilihComboBox.Items.Add("Jumat, 15 Maret 2014");
            pilihComboBox.Items.Add("Semua Hari");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
          
            try
            {		
                Data msgToSend = new Data();
                //List<Data> coba = new List<Data>();
              
                msgToSend.strName = strName;
                msgToSend.strMessage = pilihComboBox.Text;
                msgToSend.cmdCommand = SerializableData.Data.Command.Message;
                //coba.Add(msgToSend);
                //coba.Add(msgToSend);

                MemoryStream fs = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, msgToSend);
                
                byte[] byteData = fs.ToArray();

                clientSocket.BeginSendTo (byteData, 0, byteData.Length, SocketFlags.None, epServer, new AsyncCallback(OnSend), null);
                //txtMessage.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Tidak dapat menjangkau server", "Perkiraan Cuaca - client: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Perkiraan Cuaca - client: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            //if ((DateTime.Now - time1).TotalSeconds > 2) Close();
            try
            {                
                clientSocket.EndReceive(ar);

                MemoryStream ms = new MemoryStream(byteData);
                BinaryFormatter formatter = new BinaryFormatter();
                Data msgReceived = (Data)formatter.Deserialize(ms);

                switch (msgReceived.cmdCommand)
                {
                    case SerializableData.Data.Command.Login:
                        //lstChatters.Items.Add(msgReceived.strName);
                        break;

                    case SerializableData.Data.Command.Logout:
                        break;

                    case SerializableData.Data.Command.Message:
                        break;
                }

                if (msgReceived.strMessage != null)
                {
                    txtChatBox.Text = "";
                    txtChatBox.Text += msgReceived.strMessage + "\r\n";
                }
                byteData = new byte[1024];                

                clientSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epServer,
                                           new AsyncCallback(OnReceive), null);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Perkiraan Cuaca - client: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time1 = DateTime.Now;
	        CheckForIllegalCrossThreadCalls = false;
            this.Text = "Perkiraan Cuaca: " + strName;

            byteData = new byte[1024];
            clientSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epServer,
                                           new AsyncCallback(OnReceive), null);
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            /*if (pilihComboBox.Text == "")
                btnSend.Enabled = false;
            else
                btnSend.Enabled = true;*/
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
                msgToSend.cmdCommand = SerializableData.Data.Command.Logout;
                msgToSend.strName = strName;
                msgToSend.strMessage = null;

                MemoryStream fs = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, msgToSend);

                byte[] b = fs.ToArray();
                clientSocket.SendTo(b, 0, b.Length, SocketFlags.None, epServer);
                clientSocket.Close();
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Perkiraan Cuaca - client: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}
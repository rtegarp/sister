using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SerializableData;

namespace SGSclient
{
    public partial class LoginForm : Form
    {
        public Socket clientSocket;
        public EndPoint epServer;
        public string strName;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            strName = txtName.Text;
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, 
                    SocketType.Dgram, ProtocolType.Udp);

                IPAddress ipAddress = IPAddress.Parse(txtServerIP.Text);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 1000);

                epServer = (EndPoint)ipEndPoint;
                
                Data msgToSend = new Data ();
                msgToSend.cmdCommand = SerializableData.Data.Command.Login;
                msgToSend.strMessage = null;
                msgToSend.strName = strName;

                MemoryStream fs = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, msgToSend);

                byte[] byteData = fs.ToArray();
                //MessageBox.Show(byteData[2].ToString());
                
                clientSocket.BeginSendTo(byteData, 0, byteData.Length, 
                    SocketFlags.None, epServer, new AsyncCallback(OnSend), null);
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "SGSclient", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
            } 
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);                
                strName = txtName.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SGSclient", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0 && txtServerIP.Text.Length > 0)
                btnOK.Enabled = true;
            else
                btnOK.Enabled = false;
        }

        private void txtServerIP_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0 && txtServerIP.Text.Length > 0)
                btnOK.Enabled = true;
            else
                btnOK.Enabled = false;
        }
    }
}
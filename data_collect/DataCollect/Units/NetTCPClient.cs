using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DataCollect.Lib;
using System.Net;
using System.Net.Sockets;

namespace DataCollect.Units
{
    public partial class NetTCPClient :UserControl,ICommunication
    {
        /// <summary>
        /// 当前已连接客户端集合
        /// </summary>
        public BindingList<CollectTCPClient> lstClient = new BindingList<CollectTCPClient>();

        public event Lib.CollectEvent.DataReceivedHandler DataReceived;
        
        public NetTCPClient()
        {
            InitializeComponent();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in ipHostEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {//筛选IPV4
                   // txtServerIP.Text = ip.ToString();
                }
            }
        }

        /// <summary>
        /// 绑定客户端列表
        /// </summary>
        private void BindLstClient()
        {
            lstConn.Invoke(new MethodInvoker(delegate
            {
                lstConn.DataSource = null;
                lstConn.DataSource = lstClient;
                lstConn.DisplayMember = "Name";
            }));
        }

        /// <summary>
        /// 连接新的服务端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public CollectTCPClient Client = new CollectTCPClient();
        public void StartClient(string ipaddr,int portvalue)
        {
           
            try
            {
                Client.NetWork = new TcpClientWithTimeout(ipaddr, portvalue,2000).Connect();
              //  Client.NetWork.Connect(ipaddr,portvalue);//连接服务端
                Client.SetName();
                Client.NetWork.GetStream().BeginRead(Client.buffer, 0, Client.buffer.Length, new AsyncCallback(TCPCallBack), Client);
                lstClient.Add(Client);
                BindLstClient();
            }
            catch (Exception ex)
            {
                Client.DisConnect();
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void TCPCallBack(IAsyncResult ar)
        {
            CollectTCPClient client = (CollectTCPClient)ar.AsyncState;
            try
            {
                if (client.NetWork.Connected)
                {

                    NetworkStream ns = client.NetWork.GetStream();
                    byte[] recdata = new byte[ns.EndRead(ar)];
                    Array.Copy(client.buffer, recdata, recdata.Length);
                    if (recdata.Length > 0)
                    {
                        if (DataReceived != null)
                        {
                            DataReceived.BeginInvoke(client.Name, recdata, null, null);//异步输出数据
                        }
                        ns.BeginRead(client.buffer, 0, client.buffer.Length, new AsyncCallback(TCPCallBack), client);
                    }
                    else
                    {
                        client.DisConnect();
                        lstClient.Remove(client);
                        BindLstClient();
                    }
                }
            }
            catch (ObjectDisposedException ex)
            { //监听被关闭
                MessageBox.Show(ex.Message, "监听被关闭", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                client.DisConnect();
                lstClient.Remove(client);
                BindLstClient();
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        public bool SendData(byte[] data)
        {
            if (lstConn.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lstConn.SelectedItems.Count; i++)
                {
                    CollectTCPClient selClient = (CollectTCPClient)lstConn.SelectedItems[i];
                    try
                    {
                        selClient.NetWork.GetStream().Write(data, 0, data.Length);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(selClient.Name + ":" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("无可用连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void MS_Delete_Click(object sender, EventArgs e)
        {
            if (lstConn.SelectedItems.Count > 0)
            {
                List<CollectTCPClient> WaitRemove = new List<CollectTCPClient>();
                for (int i = 0; i < lstConn.SelectedItems.Count; i++)
                {
                    WaitRemove.Add((CollectTCPClient)lstConn.SelectedItems[i]);
                }
                foreach (CollectTCPClient client in WaitRemove)
                {
                    client.DisConnect();
                    lstClient.Remove(client);
                }
            }
        }

        /// <summary>
        /// 关闭所有连接
        /// </summary>
        public void ClearSelf()
        {
            foreach (CollectTCPClient client in lstClient)
            {
                client.DisConnect();
            }
            lstClient.Clear();
            BindLstClient();
        }

        private void lstConn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtServerIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void nmServerPort_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

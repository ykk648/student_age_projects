using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using DataCollect.Lib;

namespace DataCollect.Units
{
    public partial class NetTCPServer :UserControl, ICommunication
    {
        /// <summary>
        /// TCP服务端监听
        /// </summary>
        TcpListener tcpsever = null;
      
        public event Lib.CollectEvent.DataReceivedHandler DataReceived;

        /// <summary>
        /// 当前已连接客户端集合
        /// </summary>
        public BindingList<CollectTCPClient> lstClient = new BindingList<CollectTCPClient>();

        public NetTCPServer()
        {
            InitializeComponent();
            cbxServerIP.SelectedIndex = 0;
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in ipHostEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {//筛选IPV4
                    cbxServerIP.Items.Add(ip.ToString());
                }
            }
        }

        /// <summary>
        /// 绑定客户端列表
        /// </summary>
        private void BindLstClient()
        {
            lstConn.Invoke(new MethodInvoker(delegate{
                lstConn.DataSource = null;
                lstConn.DataSource = lstClient;
                lstConn.DisplayMember = "Name";
            }));
        }

        /// <summary>
        /// 开启TCP监听
        /// </summary>
        /// <returns></returns>
        public void StartTCPServer()
        {
            try
            {
                if (cbxServerIP.SelectedIndex == 0)
                {
                    tcpsever = new TcpListener(IPAddress.Any, (int)nmServerPort.Value);
                }
                else
                {
                    tcpsever = new TcpListener(IPAddress.Parse(cbxServerIP.SelectedItem.ToString()), (int)nmServerPort.Value);
                }
                tcpsever.Start();
                tcpsever.BeginAcceptTcpClient(new AsyncCallback(Acceptor), tcpsever);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 停止TCP监听
        /// </summary>
        /// <returns></returns>
        public void StopTCPServer()
        {
            tcpsever.Stop();
            
        }

        /// <summary>
        /// 客户端连接初始化
        /// </summary>
        /// <param name="o"></param>
        private void Acceptor(IAsyncResult o)
        {
            TcpListener server = o.AsyncState as TcpListener;
            try
            { 

                    //初始化连接的客户端
                    CollectTCPClient newClient = new CollectTCPClient();
                    newClient.NetWork = server.EndAcceptTcpClient(o);
                    lstClient.Add(newClient);
                    BindLstClient();
                    newClient.NetWork.GetStream().BeginRead(newClient.buffer, 0, newClient.buffer.Length, new AsyncCallback(TCPCallBack), newClient);
                    server.BeginAcceptTcpClient(new AsyncCallback(Acceptor), server);//继续监听客户端连接
                          
             }
            catch (ObjectDisposedException ex)
            { //监听被关闭
               // MessageBox.Show(ex.Message, "监听关闭", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }          

        
        /// <summary>
        /// 对当前选中的客户端发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
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
                MessageBox.Show("无可用客户端", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 客户端通讯回调函数
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

                    if (recdata.Length > 0)
                    {
                        Array.Copy(client.buffer, recdata, recdata.Length);

                        if (DataReceived != null)
                        {

                            DataReceived.BeginInvoke(client.Name, recdata, null, null);//异步输出数据触发了接收事件

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

        private void MS_Delete_Click(object sender, EventArgs e)
        {
            if (lstConn.SelectedItems.Count > 0)
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
        }

        public void client_clear()
        {
            if (lstConn.SelectedItems.Count > 0)
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


        }

        /// <summary>
        /// 清理
        /// </summary>
        public void ClearSelf()
        {
            foreach (CollectTCPClient client in lstClient)
            {
                client.DisConnect();
            }
            lstClient.Clear();
            if (tcpsever != null)
            {
                tcpsever.Stop();
            }
        }


        private void nmServerPort_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbxServerIP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstConn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

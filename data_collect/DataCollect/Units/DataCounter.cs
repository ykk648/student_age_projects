using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DataCollect.Units
{

    public partial class DataCounter : UserControl
    {
        public DataCounter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 清空计数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblSendCount.Text = "0";
            lblReceiveCount.Text = "0";
        }

        /// <summary>
        /// 累计发送字节数
        /// </summary>
        /// <param name="count">累加数</param>
        public void PlusSend(int count)
        {
            lblSendCount.Invoke(new MethodInvoker(delegate
            {
                lblSendCount.Text = (int.Parse(lblSendCount.Text) + count).ToString();
            }));
        }

        /// <summary>
        /// 累计接收字节数
        /// </summary>
        /// <param name="count">累加数</param>
        public void PlusReceive(int count)
        {
            lblReceiveCount.Invoke(new MethodInvoker(delegate
            {
                lblReceiveCount.Text = (int.Parse(lblReceiveCount.Text) + count).ToString();
            }));
        }

        private void DataCounter_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

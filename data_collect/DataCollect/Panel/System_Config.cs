using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataCollect.Lib;
namespace DataCollect.Panel
{
    public partial class System_Config : UserControl
    {
        public event CollectEvent.DownLAN dlan;
        public event CollectEvent.DownPort dport;
        public event CollectEvent.Downserver dser;
     
        public System_Config()
        {
            InitializeComponent();
            comboBox_COMMPORT0.SelectedIndex = 0;
            comboBox_COMMPORT1.SelectedIndex = 0;
            comboBox_COMMPORT2.SelectedIndex = 0;
            comboBox_BYTS0.SelectedIndex = 0;
            comboBox_BYTS1.SelectedIndex = 0;
            comboBox_BYTS2.SelectedIndex = 0;
            comboBox_BYTS3.SelectedIndex = 0;
            comboBox_BYTS0.SelectedIndex = 0;
            comboBox_BYTS1.SelectedIndex = 0;
            comboBox_BYTS2.SelectedIndex = 0;
            comboBox_BYTS3.SelectedIndex = 0;
            comboBox_DataW0.SelectedIndex = 0;
            comboBox_DataW1.SelectedIndex = 0;
            comboBox_DataW2.SelectedIndex = 0;
            comboBox_DataW3.SelectedIndex = 0;
            comboBox_PARITY0.SelectedIndex = 0;
            comboBox_PARITY1.SelectedIndex = 0;
            comboBox_PARITY2.SelectedIndex = 0;
            comboBox_PARITY3.SelectedIndex = 0;
            comboBox_Stop0.SelectedIndex = 0;
            comboBox_Stop1.SelectedIndex = 0;
            comboBox_Stop2.SelectedIndex = 0;
            comboBox_Stop3.SelectedIndex = 0;
        }

        private void button_disdata_Click(object sender, EventArgs e)
        {

        }

        private void textBox_xml_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_COMMPORT0_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_default_Click(object sender, EventArgs e)
        {
            AES_Helper aes = new AES_Helper();
            string str;
            textBox_ipaddress.Clear();
            textBox_submask.Clear();
            textBox_defaultgate.Clear();
            textBox_TCPort.Clear();
            textBox_ipaddress.AppendText("192.168.1.64");
            textBox_submask.AppendText("255.255.0.0");
            textBox_defaultgate.AppendText("192.168.1.1");
            textBox_TCPort.AppendText("6060");
        }

        private void button_downlanconfig_Click(object sender, EventArgs e)
        {
            byte[] lan = new byte[28];
            int i,port;
            lan[0] = 0x03;
            lan[1] = 0x01;
            try
            {
                string[] ip = textBox_ipaddress.Text.Split('.');
                for (i = 0; i < 4; i++)
                    lan[i + 2] = (byte)Convert.ToInt32(ip[i]);
                string[] mask = textBox_submask.Text.Split('.');
                for (i = 0; i < 4; i++)
                    lan[6 + i] = (byte)Convert.ToInt32(mask[i]);
                string[] def = textBox_defaultgate.Text.Split('.');
                for (i = 0; i < 4; i++)
                    lan[10 + i] = (byte)Convert.ToInt32(def[i]);
                port = Convert.ToInt32(textBox_TCPort.Text);
                lan[14] = (byte)(port / 256);
                lan[15] = (byte)(port % 256);
                string[] mac =  textBox_MAC.Text.Split('-');
                for (i = 0; i < 6; i++)
                    lan[16 + i] = (byte)Convert.ToInt32(mac[i],16);

               
           //     string[] dns1 = textBox_DNS1.Text.Split('.');
           //     for (i = 0; i < 4; i++)
              //      lan[13 + i] = (byte)Convert.ToInt32(dns1[i]);
            //   string[] dns2 = textBox_DNS2.Text.Split('.');
               // for (i = 0; i < 4; i++)
              //      lan[17 + i] = (byte)Convert.ToInt32(dns2[i]);
            }
            catch { }
            dlan(lan);
        }

        private void textBox_ipaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void System_Config_Load(object sender, EventArgs e)
        {

        }

        private void button_downportconfig_Click(object sender, EventArgs e)
        {
            byte[] port= new byte[22];
            port[0] = 0x03;
            port[1] = 0x00;
            port[2] = (byte)comboBox_COMMPORT0.SelectedIndex;
            port[3] = (byte)comboBox_BYTS0.SelectedIndex;
            port[4] = (byte)comboBox_PARITY0.SelectedIndex;
            port[5] = (byte)comboBox_Stop0.SelectedIndex;
            port[6] = (byte)comboBox_DataW0.SelectedIndex;
            port[7] = (byte)comboBox_COMMPORT1.SelectedIndex;
            port[8] = (byte)comboBox_BYTS1.SelectedIndex;
            port[9] = (byte)comboBox_PARITY1.SelectedIndex;
            port[10] = (byte)comboBox_Stop1.SelectedIndex;
            port[11] = (byte)comboBox_DataW1.SelectedIndex;
            port[12] = (byte)comboBox_COMMPORT2.SelectedIndex;
            port[13] = (byte)comboBox_BYTS2.SelectedIndex;
            port[14] = (byte)comboBox_PARITY2.SelectedIndex;
            port[15] = (byte)comboBox_Stop2.SelectedIndex;
            port[16] = (byte)comboBox_DataW2.SelectedIndex;
           //port[17] = (byte)comboBox_COMMPORT2.SelectedIndex;
            port[18] = (byte)comboBox_BYTS3.SelectedIndex;
            port[19] = (byte)comboBox_PARITY3.SelectedIndex;
            port[20] = (byte)comboBox_Stop3.SelectedIndex;
            port[21] = (byte)comboBox_DataW3.SelectedIndex;
            dport(port);
        }

        private void button_downserver_Click(object sender, EventArgs e)
        {
            byte[] ser = new byte[28];
            int i, sport1,sport2;
            ser[0] = 0x03;
            ser[1] = 0x02;
            try
            {
                string[] sip = textBox_sever1ip.Text.Split('.');
                for (i = 0; i < 4; i++)
                    ser[i + 2] = (byte)Convert.ToInt32(sip[i]);
                sport1 = Convert.ToInt32(textBox_sever1port.Text);
                ser[6] = (byte)(sport1 / 256);
                ser[7] = (byte)(sport1% 256);
                string[] sip2 = textBox_sever2ip.Text.Split('.');
                for (i = 0; i < 4; i++)
                    ser[i + 8] = (byte)Convert.ToInt32(sip2[i]);
                sport2 = Convert.ToInt32(textBox_sever2port.Text);
                ser[12] = (byte)(sport2 / 256);
                ser[13] = (byte)(sport2 % 256);


            }
            catch { }
            dser(ser);
        }
    }
}

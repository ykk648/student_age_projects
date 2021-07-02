using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataCollect.Lib;
using DataCollect.Units;
using System.Threading;
using System.Xml;
using System.IO;
namespace DataCollect.Panel
{

    public partial class BasePanel : UserControl
    {
        Datadisplay datadis = new Datadisplay();
        public  string ranseq,md5cr;
        public event CollectEvent.SendRandomSequence Sequence;
        public event CollectEvent.Md5check md5check;
        public event CollectEvent.report report;
        public event CollectEvent.Config_ack config_per;
       
        bool begin = false;//连接/中断标志

        bool pass = false;  //客户端验证成功标志

        bool heartflag = false;

        bool cilentheart = false;

        bool collp_send = true;
        AutoResetEvent autoEvent = new AutoResetEvent(false);
        public BasePanel()
        {
            InitializeComponent();
            Sequence += new Lib.CollectEvent.SendRandomSequence(BasePanel_Sequence);
            md5check += new Lib.CollectEvent.Md5check(BasePanel_md5check);
            report+=new CollectEvent.report(BasePanel_report);
            config_per+=new CollectEvent.Config_ack(BasePanel_config_per);
            comboBox_commselect.SelectedIndex = 0;

        }
        private bool DataSender_EventDataSend(byte[] data)
        {


            //if (devTCPServer.SendData(data) == true)
            //{
            //    MDataCounter.PlusSend(data.Length);
            //    return true;
            //}
            byte[] sendata = new byte[data.Length+3];
            int i;
            sendata[0] = 0x07;
            sendata[1] = (byte)comboBox_commselect.SelectedIndex;
            sendata[2] = (byte)data.Length;
            for (i = 0; i < data.Length; i++)
            {
                sendata[3 + i] = data[i];
            
            }
            if (netTCPClient1.SendData(sendata) == true)
            {
                    //MDataCounter.PlusSend(sendata.Length);
                    return true;

             }
            return false;
        }
        private void netTCPClient1_DataReceived(object sender, byte[] data)
        {
            // if(data[0]==0x03)
            tabDataReceiver.AddData(sender.ToString(), data);
            // //if (data[0] == 0x02&&data[1]==0x07)
            // //{
            // //    int i;
            // //    for (i = 0; i < (data.Length-2); i++)
            // //    {
            // //        data[i] = data[i + 2];
            // //    }
            // //        tabDataReceiver.AddData(sender.ToString(), data);
            // //}
            ////  MDataCounter.PlusReceive(data.Length);
            if (data[0] == '0' && data[1] == '0')
                cilentheart = true;
            if (data[0] == 0xaa && data[1] == 0xbb)
                collp_send = true;
            config_data(data);
            //System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
            //AES_Helper aes = new AES_Helper();
            //this.Invoke(new MethodInvoker(delegate
            //{
            //    for (int i=0; i < data.Length;i++ )
            //        textBox_clientlst.AppendText(data[i].ToString("X2")+" ");
            //    textBox_clientlst.AppendText("\r\n");
            //    textBox_clientlst.AppendText(aes.Decrypt(data));

            //}));
            



        }
        private void devTCPServer_DataReceived(object sender, byte[] data)
        {
            string data_rec = null;
            byte[] xdata = new byte[4096];
            uint i,len;
           // tabDataReceiver.AddData(sender.ToString(), data);
            if ((data[0]==0x68)&& (data[1] == 0x68)&& (data[2] == 0x16)&& (data[3] == 0x16))
            {
                len = (uint)data[4] | ((uint)data[5] << 8) | ((uint)data[6] << 16) | ((uint)data[7] << 24);
                try
                {
                    for (i = 0; i < (len - 4); i++)
                    {
                        xdata[i] = data[12 + i];
                    }
                }
                catch { }
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
                data_rec = ASCII.GetString(xdata);
                //下面让文本框显示收到的数据做调试用
                tabDataReceiver.AddData("123", xdata);
                //  MDataCounter.PlusReceive(data.Length);
                Data_deal(data_rec);
            }
 
        }
        /// <summary>
        /// 配置信息接收处理函数
        /// </summary>
        /// <param name="config_data"></param>
        public void config_data(byte[] config_data)
        {
            if ((config_data[0] == 0x02) && (config_data[1] == 0x01))
            {
                int i;
                byte[] gen = new byte[12], addn = new byte[14];
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
                this.Invoke(new MethodInvoker(delegate
                {
                   system_config1.textBox_ipaddress.Clear();
                   system_config1.textBox_submask.Clear();
                   system_config1.textBox_defaultgate.Clear();
                   system_config1.textBox_TCPort.Clear();
                   system_config1.textBox_MAC.Clear();
                   system_config1.textBox_sever1port.Clear();
                   system_config1.textBox_sever1ip.Clear();
                   system_config1.textBox_sever1port.Clear();
                   system_config1.textBox_sever1ip.Clear();
                   system_config1.textBox_sever2ip.Clear();
                   system_config1.textBox_sever2port.Clear();
                   general_Config1.textBox_collectpoint_id.Clear();

                    for (i = 0; i < 4; i++)
                    {   
                        if(i<3)
                            system_config1.textBox_ipaddress.AppendText(config_data[i + 2].ToString() + ".");
                        else
                            system_config1.textBox_ipaddress.AppendText(config_data[i + 2].ToString());
                    }
                    for (i = 0; i < 4; i++)
                    {
                        if (i < 3)
                            system_config1.textBox_submask.AppendText(config_data[i + 6].ToString() + ".");
                        else
                            system_config1.textBox_submask.AppendText(config_data[i + 6].ToString());
                    }
                    for (i = 0; i < 4; i++)
                    {
                        if (i < 3)
                            system_config1.textBox_defaultgate.AppendText(config_data[i + 10].ToString() + ".");
                        else
                            system_config1.textBox_defaultgate.AppendText(config_data[i + 10].ToString());
                    }
                    system_config1.textBox_TCPort.AppendText((config_data[14]*256+config_data[15]).ToString());
                    for (i = 0; i < 6; i++)
                    {
                        if (i < 5)
                            system_config1.textBox_MAC.AppendText(config_data[i + 16].ToString("X") + "-");
                        else
                            system_config1.textBox_MAC.AppendText(config_data[i + 16].ToString("X"));
                    }
                    for (i = 0; i < 4; i++)
                    {
                        if (i < 3)
                            system_config1.textBox_sever1ip.AppendText(config_data[i + 22].ToString() + ".");
                        else
                            system_config1.textBox_sever1ip.AppendText(config_data[i + 22].ToString());
                    }
                    system_config1.textBox_sever1port.AppendText((config_data[26] * 256 + config_data[27]).ToString());
                    for (i = 0; i < 4; i++)
                    {
                        if (i < 3)
                            system_config1.textBox_sever2ip.AppendText(config_data[i + 28].ToString() + ".");
                        else
                            system_config1.textBox_sever2ip.AppendText(config_data[i + 28].ToString());
                    }
                    system_config1.textBox_sever2port.AppendText((config_data[32] * 256 + config_data[33]).ToString());
                    textBox_clientlst.AppendText("->读取网口配置成功\r\n");
                    system_config1.comboBox_COMMPORT0.SelectedIndex = config_data[34];
                    system_config1.comboBox_BYTS0.SelectedIndex = config_data[35];
                    system_config1.comboBox_PARITY0.SelectedIndex = config_data[36];
                    system_config1.comboBox_Stop0.SelectedIndex = config_data[37];
                    system_config1.comboBox_DataW0.SelectedIndex = config_data[38];
                    system_config1.comboBox_COMMPORT1.SelectedIndex = config_data[39];
                    system_config1.comboBox_BYTS1.SelectedIndex = config_data[40];
                    system_config1.comboBox_PARITY1.SelectedIndex = config_data[41];
                    system_config1.comboBox_Stop1.SelectedIndex = config_data[42];
                    system_config1.comboBox_DataW1.SelectedIndex = config_data[43];
                    system_config1.comboBox_COMMPORT2.SelectedIndex = config_data[44];
                    system_config1.comboBox_BYTS2.SelectedIndex = config_data[45];
                    system_config1.comboBox_PARITY2.SelectedIndex = config_data[46];
                    system_config1.comboBox_Stop2.SelectedIndex = config_data[47];
                    system_config1.comboBox_DataW2.SelectedIndex = config_data[48];
                   // system_config1.comboBox_COMMPORT3.SelectedIndex = config_data[49];
                    system_config1.comboBox_BYTS3.SelectedIndex = config_data[50];
                    system_config1.comboBox_PARITY3.SelectedIndex = config_data[51];
                    system_config1.comboBox_Stop3.SelectedIndex = config_data[52];
                    system_config1.comboBox_DataW3.SelectedIndex = config_data[53];
                    textBox_clientlst.AppendText("->读取串口配置成功\r\n");
                    for (i = 0; i < 12; i++)
                    {
                        gen[i] = config_data[54 + i];
                        //general_Config1.testdisp.AppendText(gen[i].ToString("X2"));
                    }
                    general_Config1.textBox_collectpoint_id.AppendText(ASCII.GetString(gen));
                    
                }));
            }
            if ((config_data[0] == 0x02) && (config_data[1] == 0x02))
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    general_Config1.textBox_building_id.Clear();
                    general_Config1.textBox_collectpoint_id.Clear();
                    general_Config1.textBox_getaway_id.Clear();
                    System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
                    string str = ASCII.GetString(config_data);
                    general_Config1.textBox_collectpoint_id.AppendText(str.Remove(0,2));
                    general_Config1.comboBox_buildingtype.SelectedIndex = config_data[8] - 'A';
                    general_Config1.textBox_building_id.AppendText(str.Substring(9,3));
                    general_Config1.textBox_getaway_id.AppendText(str.Substring(12,2));

                }));
            
            }
            if ((config_data[0] == 0x03) &&( config_data[1] == 0x03))
            {
                int i, j;
                byte[] addn = new byte[14];
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
                this.Invoke(new MethodInvoker(delegate
                {
                    general_Config1.childcount[config_data[2]]++;
                    for (i = 0; i < 14; i++)
                        general_Config1.colle[config_data[2], config_data[3]].addr[i] = config_data[4+ i];
                    string tab_type = null;

                    switch (config_data[19])
                    {
                        case 64: tab_type = "电能表"; break;
                        case 48: tab_type = "燃气表"; break;
                        case 33: tab_type = "热能表(冷)"; break;
                        case 32: tab_type = "热能表(热)"; break;
                        case 19: tab_type = "中水水表"; break;
                        case 18: tab_type = "直饮水水表"; break;
                        case 17: tab_type = "生活热水水表"; break;
                        case 16: tab_type = "冷水水表"; break;
                        case 129: tab_type = "温控器"; break;
                        case 25: tab_type = "大水表"; break;
                        default: break;
                    }
                    general_Config1.treeView1.Nodes[config_data[2]].Nodes.Add("[" + config_data[2] + "-" + config_data[3].ToString("00") + "]" +
                      "[" + ASCII.GetString(general_Config1.colle[config_data[2], config_data[3]].addr) + "号]" + tab_type);
                    general_Config1.colle[config_data[2], config_data[3]].maddr = config_data[18];
                    general_Config1.colle[config_data[2], config_data[3]].tab_type = config_data[19];
                    general_Config1.colle[config_data[2], config_data[3]].tab_state = config_data[20];
                    general_Config1.colle[config_data[2], config_data[3]].funcode = config_data[21];
                    for (i = 0; i < 5; i++)
                    {
                        general_Config1.colle[config_data[2], config_data[3]].enercode[i] = config_data[22+ i];
                    }
                    general_Config1.colle[config_data[2], config_data[3]].item_count = config_data[27];
                    for (j = 0; j < 20; j++)
                    {
                        byte[] bu = new byte[4];
                        float h = 0;
                        general_Config1.colle[config_data[2], config_data[3]].reg_len[j] = config_data[28+j];
                        general_Config1.colle[config_data[2], config_data[3]].commaddr[j] = (byte)(config_data[48 + j*2] | config_data[49 + j*2]);
                        bu[0] = config_data[90 + j*4];
                        bu[1] = config_data[91 + j*4];
                        bu[2] = config_data[92 + j*4];
                        bu[3] = config_data[93 + j*4];
                        h=BitConverter.ToSingle(bu, 0);
                        general_Config1.colle[config_data[2], config_data[3]].mul[j] =h ;
                    }
                      
                 
                }));
            }
        
        }
        string type = null, buding_id = null, gateway_id = null;
        /// <summary>
        /// 处理收到的数据包
        /// </summary>
        /// <param name="recdata"></param>
        public void Data_deal(string data_rec)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {

                xmlDoc.LoadXml(data_rec);
                XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/root");
                type = (xmlNodeList[0].SelectSingleNode("//type")).InnerText;
                buding_id = (xmlNodeList[0].SelectSingleNode("//building_id")).InnerText;
                gateway_id = (xmlNodeList[0].SelectSingleNode("//gateway_id")).InnerText;
            }
            catch
            {

               // type = null; buding_id = null; gateway_id = null;

            }
            switch (type)
            {
                case "notify": heartflag = true; break;
                case "request": Sequence(); break;
                case "md5":
                    try
                    {
                        XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/root");
                        md5check((xmlNodeList[0].SelectSingleNode("//md5")).InnerText);
                        
                    }
                    catch { }
                    break;
                case "report": report(data_rec); break;
                case "continuous": report(data_rec); break;
                case "query": report(data_rec); break;
                case "period_ack": config_per(data_rec); break;
                default: break;
            }
        }
        /// <summary>
        /// 发送查询数据请求
        /// </summary>
        public void datadisplay1_query()
        {
            XML_Beat xml = new XML_Beat();
            if (pass==true)
            this.Invoke(new MethodInvoker(delegate
            {
                //try
                //{
                //    datadisplay1.xml_dis(reportstr);
                //}
                //catch { }
                devTCPServer.SendData(Encoding.Default.GetBytes(xml.query_xml(buding_id, gateway_id)));
               // datadisplay1.button_disdata.Enabled = true;
                
            }));
        }
        /// <summary>
        /// 发送查询数据间隔
        /// </summary>
        /// <param name="per"></param>
        public void datadisplay1_period(string per)
        {
            XML_Beat xml = new XML_Beat();
            
            this.Invoke(new MethodInvoker(delegate
            {
                
                devTCPServer.SendData(Encoding.Default.GetBytes( xml.period_xml(buding_id,gateway_id,per)));

            }));
        
        }
        /// <summary>
        /// 发送验证序列
        /// </summary>
        public void BasePanel_Sequence()
        {
            ranseq = new MD5_Check().Randomstr(36);
            md5cr = new MD5_Check().md5creat("1234567890abcdefghijklmnopqrstuvwxyz");

            this.Invoke(new MethodInvoker(delegate
            {
                datadisplay1.textBox_heartb.AppendText(ranseq+"   "+md5cr+"\r\n");
              //  Thread.Sleep(2000);
                devTCPServer.SendData(Encoding.Default.GetBytes(new XML_Beat().sequence_xml(buding_id, gateway_id, "1234567890abcdefghijklmnopqrstuvwxyz")));
                ranseq = null;
            }));
        }
        /// <summary>
        /// 校验MD5，通过身份验证
        /// </summary>
        /// <param name="md5"></param>
        public void BasePanel_md5check(string md5)
        {

            if (md5 == md5cr)
            {
                this.Invoke(new MethodInvoker(delegate
                {

                    pass = devTCPServer.SendData(Encoding.Default.GetBytes(new XML_Beat().result_xml(buding_id, gateway_id)));
                    Thread ThTestL = new Thread(new ParameterizedThreadStart(heart));
                    ThTestL.IsBackground = true;
                    ThTestL.Start(2000);
     
                }));
                pass = true;
                md5cr = null;
            }
        }
        /// <summary>
        /// 收到数据包并且显示
        /// </summary>
        /// <param name="report_xml"></param>
        public void BasePanel_report(string report_xml)
        {

            datadisplay1.xml_dis(report_xml);
            button_led_data.BackColor = Color.Lime;

        }
        /// <summary>
        /// 下载LAN口配置
        /// </summary>
        /// <param name="lan"></param>
        public void system_config1_dlan(byte[] lan)
        {
          //  System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
            //int i;
            this.Invoke(new MethodInvoker(delegate
            {
                //for (i = 0; i < lan.Length;i++ )
                //    datadisplay1.textBox_heartb.AppendText(lan[i].ToString("X")+" ");

                if (netTCPClient1.SendData(lan))
                {
                    textBox_clientlst.AppendText("->下载LAN口配置成功");
                }
                    button_led_comm.BackColor = Color.Lime;
            }));
        
        }
        /// <summary>
        /// 下载串口信息配置
        /// </summary>
        /// <param name="port"></param>
        public void system_config1_dport(byte[] port)
        {
            //int i;
            this.Invoke(new MethodInvoker(delegate
            {
                //for (i = 0; i < port.Length; i++)
                //    datadisplay1.textBox_heartb.AppendText(port[i].ToString("X") + " ");

                if (netTCPClient1.SendData(port))
                {

                    textBox_clientlst.AppendText("->下载串口信息成功");
                }
                button_led_comm.BackColor = Color.Lime;
            }));
        
        }
        /// <summary>
        /// 下载远程服务器配置
        /// </summary>
        /// <param name="server"></param>
        public void system_config1_dser(byte[] server)
        {
            //int i;
            this.Invoke(new MethodInvoker(delegate
            {
                //for (i = 0; i < server.Length; i++)
                //    datadisplay1.textBox_heartb.AppendText(server[i].ToString("X") + " ");

                if (netTCPClient1.SendData(server))
                {

                    textBox_clientlst.AppendText("->下载服务器配置成功");
                }
                button_led_comm.BackColor = Color.Lime;
            }));
        }
        /// <summary>
        /// 下载采集点配置
        /// </summary>
        /// <param name="port"></param>
        public void general_Config1_collp(byte[] collpoint)
        {
            int i=0;
            this.Invoke(new MethodInvoker(delegate
            {

                while (!collp_send)
                {
                    i++;
                    Thread.Sleep(100);
                    if (i == 10)
                        break;
                }
                if (netTCPClient1.SendData(collpoint) == true)
                {
                    general_Config1.textBox_opdis.AppendText("->采集点通用配置下载成功\r\n");
                    general_Config1.button_downdevconfig.Enabled = false;
                    button_led_comm.BackColor = Color.Lime;
                    
                }
                collp_send = false;
               
            }));
           
        
        }
        public void send_coll(object Interval)
        { 
        
        
        }
        /// <summary>
        /// 下载通用信息配置
        /// </summary>
        /// <param name="collgener"></param>
        public void general_Config1_collg(byte[] collgener)
        {
            //int i;
            this.Invoke(new MethodInvoker(delegate
            {
                //for (i = 0; i < collgener.Length; i++)
                //    datadisplay1.textBox_heartb.AppendText(collgener[i].ToString("X") + " ");

                if (netTCPClient1.SendData(collgener) == true)
                {
                    button_led_comm.BackColor = Color.Lime;
                    general_Config1.textBox_opdis.AppendText("->采集器通用信息下载成功\r\n");
                }


            }));

        }
        /// <summary>
        /// 查询通用信息
        /// </summary>
        public void general_Config1_check()
        {
            byte[] check = new byte[]{0x01,0x04};
            this.Invoke(new MethodInvoker(delegate
            {
               netTCPClient1.SendData(check);

            })); 
        
        }
        /// <summary>
        /// 历史记录查询
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void datadisplay1_history(string start, string end)
        {
            XML_Beat xml = new XML_Beat();
            this.Invoke(new MethodInvoker(delegate
            {
                devTCPServer.SendData(Encoding.Default.GetBytes(xml.history_xml(buding_id, gateway_id, start,end)));

            }));
        
        }
        /// <summary>
        /// 采集间隔设置成功显示
        /// </summary>
        /// <param name="xml_per"></param>
        public void BasePanel_config_per(string xml_per)
        {
            datadisplay1.xml_dis(xml_per);
            button_led_data.BackColor = Color.Lime;
        }
       
        private void dataSender_Load(object sender, EventArgs e)
        {

        }

        private void tabDataReceiver_Load(object sender, EventArgs e)
        {

        }

        private void devTCPServer_Load(object sender, EventArgs e)
        {

        }

        private void DevConfigPanel_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 连接/断开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_begin_Click(object sender, EventArgs e)
        {
            int port=0;
            try
            {
                port = Convert.ToInt32(system_config1.textBox_TCPort.Text);
                textBox_clientlst.AppendText("->正在连接" + system_config1.textBox_ipaddress.Text+":"+port.ToString()+"\r\n");
                netTCPClient1.Client.DisConnect();
                netTCPClient1.StartClient(system_config1.textBox_ipaddress.Text, port);
                if (netTCPClient1.Client.NetWork.Connected == true)
                {
                    textBox_clientlst.AppendText("->连接到" + system_config1.textBox_ipaddress.Text + ":" + port.ToString() + "\r\n");
                    button_readconfig.Enabled = true;
                    button_saveconfig.Enabled = true;
                    system_config1.button_downlanconfig.Enabled = true;
                    system_config1.button_downportconfig.Enabled = true;
                    system_config1.button_downserver.Enabled = true;
                    //general_Config1.button_adddev.Enabled = true;
                    //general_Config1.button_modifydev.Enabled = true;
                    //general_Config1.button_deleteall.Enabled = true;
                    //general_Config1.button_downdevconfig.Enabled = true;
                    //general_Config1.button_readmessage.Enabled = true;
                    //general_Config1.button_downmessage.Enabled = true;
                    button_led_config.BackColor = Color.Lime;
                    Thread ThTestLc = new Thread(new ParameterizedThreadStart(Clientcheck));
                    ThTestLc.IsBackground = true;
                    ThTestLc.Start(1000);    
                }
            }
            catch 
            {
              
            }


        }
        public void Clientcheck(object Interval)
        {
            int SendInterval = Convert.ToInt32(Interval);
            int count = 0;
            while (true)
            {
                if (netTCPClient1.Client.NetWork.Connected == false)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                       textBox_clientlst.AppendText("->断开连接" + system_config1.textBox_ipaddress.Text + ":" + system_config1.textBox_TCPort.Text + "\r\n");
                        button_readconfig.Enabled = false;
                        button_saveconfig.Enabled = false;
                        button_led_config.BackColor = Color.Empty;
                        netTCPClient1.Client.DisConnect();
                    }));
                    break;
                }
                if (cilentheart == true)
                {
                    cilentheart = false;
                    count = 0;
                }
                else
                {
                    
                    if (count == 3)
                    {
                        count = 0;
                        this.Invoke(new MethodInvoker(delegate
                        {
                            textBox_clientlst.AppendText("->断开连接" + system_config1.textBox_ipaddress.Text + ":" + system_config1.textBox_TCPort.Text + "\r\n");
                            button_readconfig.Enabled = false;
                            button_saveconfig.Enabled = false;
                            button_led_config.BackColor = Color.Empty;
                            netTCPClient1.Client.DisConnect();
                        }));
                        break;

                    
                    }
                
                }

                button_led_comm.BackColor = Color.Empty;
                Thread.Sleep(SendInterval);
             }
        
        
        }
        private void tabPage_devconfig_Click(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// 点击退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_EXIT_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void listView_history_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_xml_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox_portselect_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 心跳授时线程
        /// </summary>
        /// <param name="Interval"></param>
        public void heart(object Interval)
        {
            int SendInterval = Convert.ToInt32(Interval);
            int count = 0;

            while (true)
            {

                if (pass == true)
                {
                    string heart_beat = new XML_Beat().heart_xml(buding_id, gateway_id);
                    button_led_data.BackColor = Color.Empty;
                    //this.Invoke(new MethodInvoker(delegate
                    //{
                     
                        
                            
                    //}));
                  
                    if (heartflag == true)
                    {
                        count = 0;
                        heartflag = false;
                        this.Invoke(new MethodInvoker(delegate
                        {
                            devTCPServer.SendData(Encoding.Default.GetBytes(heart_beat));
                            datadisplay1.heart_dis(heart_beat); 

                        }));
                        
                       
                    }
                    //else
                    //{
                    //    count++;
                    //    if (count ==20)
                    //    {
                    //        count = 0;
                    //      //  pass = false;
                          
                    //        MessageBox.Show("未检测到心跳包", "客户端连接可能出现故障", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 
                    //        break;
                    //    }

                    //}
                }
                Thread.Sleep(SendInterval);

            }


        }
/// <summary>
/// 保存配置信息到本地
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void button_localsave_Click(object sender, EventArgs e)
        {
            byte[] infbytes = new byte[4096];
            int i,port,sport1,sport2;
                
                string[] ip = system_config1.textBox_ipaddress.Text.Split('.');
                for (i = 0; i<ip.Length; i++)
                    infbytes[i] = (byte)Convert.ToInt32("0"+ip[i]);

                string[] mask = system_config1.textBox_submask.Text.Split('.');
                for (i = 0; i < mask.Length; i++)
                    infbytes[4 + i] = (byte)Convert.ToInt32("0"+mask[i]);

                string[] def = system_config1.textBox_defaultgate.Text.Split('.');
                for (i = 0; i < def.Length; i++)
                    infbytes[8 + i] = (byte)Convert.ToInt32("0"+def[i]);

                port = Convert.ToInt32("0"+system_config1.textBox_TCPort.Text);
                infbytes[12] = (byte)(port / 256);
                infbytes[13] = (byte)(port % 256);
            
                string[] mac = system_config1.textBox_MAC.Text.Split('-');
                for (i = 0; i < mac.Length; i++)
                    infbytes[14 + i] = (byte)Convert.ToInt32("0"+mac[i], 16);

                string[] sip = system_config1.textBox_sever1ip.Text.Split('.');
                for (i = 0; i < sip.Length; i++)
                    infbytes[i + 20] = (byte)Convert.ToInt32("0"+sip[i]);

                sport1 = Convert.ToInt32("0"+system_config1.textBox_sever1port.Text);
                infbytes[24] = (byte)(sport1 / 256);
                infbytes[25] = (byte)(sport1 % 256);

                string[] sip2 = system_config1.textBox_sever2ip.Text.Split('.');
                for (i = 0; i < sip2.Length; i++)
                    infbytes[i + 26] = (byte)Convert.ToInt32("0"+sip2[i]);

                sport2 = Convert.ToInt32("0"+system_config1.textBox_sever2port.Text);
                infbytes[30] = (byte)(sport2 / 256);
                infbytes[31] = (byte)(sport2 % 256);

                infbytes[32] = (byte)system_config1.comboBox_COMMPORT0.SelectedIndex;
                infbytes[33] = (byte)system_config1.comboBox_BYTS0.SelectedIndex;
                infbytes[34] = (byte)system_config1.comboBox_PARITY0.SelectedIndex;
                infbytes[35] = (byte)system_config1.comboBox_Stop0.SelectedIndex;
                infbytes[36] = (byte)system_config1.comboBox_DataW0.SelectedIndex;
                infbytes[37] = (byte)system_config1.comboBox_COMMPORT1.SelectedIndex;
                infbytes[38] = (byte)system_config1.comboBox_BYTS1.SelectedIndex;
                infbytes[39] = (byte)system_config1.comboBox_PARITY1.SelectedIndex;
                infbytes[40] = (byte)system_config1.comboBox_Stop1.SelectedIndex;
                infbytes[41] = (byte)system_config1.comboBox_DataW1.SelectedIndex;
                infbytes[42] = (byte)system_config1.comboBox_COMMPORT2.SelectedIndex;
                infbytes[43] = (byte)system_config1.comboBox_BYTS2.SelectedIndex;
                infbytes[44] = (byte)system_config1.comboBox_PARITY2.SelectedIndex;
                infbytes[45] = (byte)system_config1.comboBox_Stop2.SelectedIndex;
                infbytes[46] = (byte)system_config1.comboBox_DataW2.SelectedIndex;
                // port[47] = (byte)comboBox_COMMPORT2.SelectedIndex;
                infbytes[48] = (byte)system_config1.comboBox_BYTS3.SelectedIndex;
                infbytes[49] = (byte)system_config1.comboBox_PARITY3.SelectedIndex;
                infbytes[50] = (byte)system_config1.comboBox_Stop3.SelectedIndex;
                infbytes[51] = (byte)system_config1.comboBox_DataW3.SelectedIndex;
                byte[] coll_id = new byte[12];
                coll_id = Encoding.Default.GetBytes(general_Config1.textBox_collectpoint_id.Text);
                for (i = 0; i < 12; i++)
                {
                    infbytes[52 + i] = coll_id[i];
                }
                int p, s, count=0;
                infbytes[64] = (byte)(general_Config1.childcount[0] + general_Config1.childcount[1] + general_Config1.childcount[2]);/////////////////////////////
                try
                {
                    for (p = 0; p < 3; p++)
                        for (s = 0; s < general_Config1.childcount[p]; s++)
                        {
                            if (count < (general_Config1.childcount[0] + general_Config1.childcount[1] + general_Config1.childcount[2]))
                            {
                                infbytes[65 + 60 * count] = general_Config1.colle[p, s].t_p;
                                infbytes[66 + 60 * count] = general_Config1.colle[p, s].t_s;
                                for (i = 0; i < 14; i++)
                                {
                                    infbytes[67 + i + 60 * count] = general_Config1.colle[p, s].addr[i];//表号即地址
                                }
                                infbytes[81 + 60 * count] = general_Config1.colle[p, s].tab_type;
                                infbytes[82 + 60 * count] = general_Config1.colle[p, s].tab_state;
                                infbytes[83 + 60 * count] = general_Config1.colle[p, s].funcode;
                                //for (i = 0; i < 5; i++)
                                //{
                                //    infbytes[84 + i + 60 * count] = general_Config1.colle[p, s].commcode[i];         //读的寄存器起始地址

                                //}
                                //for (i = 0; i < 10; i++)
                                //{
                                //    infbytes[89 + i + 60 * count] = general_Config1.colle[p, s].fn[i];

                                //}
                                //for (i = 0; i < 20; i++)
                                //{
                                //    infbytes[99 + i + 60 * count] = general_Config1.colle[p, s].fmt[i];

                                //}
                                for (i = 0; i < 5; i++)
                                {
                                    infbytes[119 + i + 60 * count] = general_Config1.colle[p, s].enercode[i];
                                }
                                infbytes[124 + 60 * count] = general_Config1.colle[p, s].item_count;
                                count++;
                            }
                            else
                            {
                                count = 0;

                            }

                        }
                }
                catch
                {


                }    
            SaveFileDialog savfile = new SaveFileDialog();
            savfile.Filter = "dlv文件|*.dlv";
            if (savfile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(savfile.FileName, FileMode.Create, FileAccess.Write); 
                 fs.Write(infbytes, 0, infbytes.Length); 
                 fs.Close();
             //   xml.Save(savfile.FileName);
            }

        }
/// <summary>
/// 读取配置信息到本地
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        
        private void button_localread_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "dlv文件|*.dlv";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                byte[] config_data = new byte[fs.Length];
                byte[] gen = new byte[]{};
                int i,j,count;
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
                fs.Read(config_data, 0, config_data.Length);
                fs.Close();
                system_config1.textBox_ipaddress.Clear();
                system_config1.textBox_submask.Clear();
                system_config1.textBox_defaultgate.Clear();
                system_config1.textBox_TCPort.Clear();
                system_config1.textBox_MAC.Clear();
                system_config1.textBox_sever1port.Clear();
                system_config1.textBox_sever1ip.Clear();
                system_config1.textBox_sever1port.Clear();
                system_config1.textBox_sever1ip.Clear();
                system_config1.textBox_sever2ip.Clear();
                system_config1.textBox_sever2port.Clear();
                general_Config1.textBox_collectpoint_id.Clear();
                for (i = 0; i < 4; i++)
                {
                    if (i < 3)
                        system_config1.textBox_ipaddress.AppendText(config_data[i].ToString() + ".");
                    else
                        system_config1.textBox_ipaddress.AppendText(config_data[i].ToString());
                }
                for (i = 0; i < 4; i++)
                {
                    if (i < 3)
                        system_config1.textBox_submask.AppendText(config_data[i + 4].ToString() + ".");
                    else
                        system_config1.textBox_submask.AppendText(config_data[i + 4].ToString());
                }
                for (i = 0; i < 4; i++)
                {
                    if (i < 3)
                        system_config1.textBox_defaultgate.AppendText(config_data[i + 8].ToString() + ".");
                    else
                        system_config1.textBox_defaultgate.AppendText(config_data[i + 8].ToString());
                }
                system_config1.textBox_TCPort.AppendText((config_data[12] * 256 + config_data[13]).ToString());
                for (i = 0; i < 6; i++)
                {
                    if (i < 5)
                        system_config1.textBox_MAC.AppendText(config_data[i + 14].ToString("X") + "-");
                    else
                        system_config1.textBox_MAC.AppendText(config_data[i + 14].ToString("X"));
                }
                for (i = 0; i < 4; i++)
                {
                    if (i < 3)
                        system_config1.textBox_sever1ip.AppendText(config_data[i + 20].ToString() + ".");
                    else
                        system_config1.textBox_sever1ip.AppendText(config_data[i + 20].ToString());
                }
                system_config1.textBox_sever1port.AppendText((config_data[24] * 256 + config_data[25]).ToString());
                for (i = 0; i < 4; i++)
                {
                    if (i < 3)
                        system_config1.textBox_sever2ip.AppendText(config_data[i + 26].ToString() + ".");
                    else
                        system_config1.textBox_sever2ip.AppendText(config_data[i + 26].ToString());
                }
                system_config1.textBox_sever2port.AppendText((config_data[30] * 256 + config_data[31]).ToString());
                system_config1.comboBox_COMMPORT0.SelectedIndex = config_data[32];
                system_config1.comboBox_BYTS0.SelectedIndex = config_data[33];
                system_config1.comboBox_PARITY0.SelectedIndex = config_data[34];
                system_config1.comboBox_Stop0.SelectedIndex = config_data[35];
                system_config1.comboBox_DataW0.SelectedIndex = config_data[36];
                system_config1.comboBox_COMMPORT1.SelectedIndex = config_data[37];
                system_config1.comboBox_BYTS1.SelectedIndex = config_data[38];
                system_config1.comboBox_PARITY1.SelectedIndex = config_data[39];
                system_config1.comboBox_Stop1.SelectedIndex = config_data[40];
                system_config1.comboBox_DataW1.SelectedIndex = config_data[41];
                system_config1.comboBox_COMMPORT2.SelectedIndex = config_data[42];
                system_config1.comboBox_BYTS2.SelectedIndex = config_data[43];
                system_config1.comboBox_PARITY2.SelectedIndex = config_data[44];
                system_config1.comboBox_Stop2.SelectedIndex = config_data[45];
                system_config1.comboBox_DataW2.SelectedIndex = config_data[46];
                // system_config1.comboBox_COMMPORT3.SelectedIndex = config_data[47];
                system_config1.comboBox_BYTS3.SelectedIndex = config_data[48];
                system_config1.comboBox_PARITY3.SelectedIndex = config_data[49];
                system_config1.comboBox_Stop3.SelectedIndex = config_data[50];
                system_config1.comboBox_DataW3.SelectedIndex = config_data[51];
                //try
                //{
                //    for (i = 0; i < 12; i++)
                //    {
                //        gen[i] = config_data[52 + i];
                //        //general_Config1.testdisp.AppendText(gen[i].ToString("X2"));
                //    }
                //}
                //catch { }
                general_Config1.textBox_collectpoint_id.AppendText(ASCII.GetString(gen));
                count = config_data[64];
                general_Config1.treeView1.Nodes[0].Nodes.Clear();
                general_Config1.treeView1.Nodes[1].Nodes.Clear();
                general_Config1.treeView1.Nodes[2].Nodes.Clear();
                general_Config1.childcount[0] = 0;
                general_Config1.childcount[1] = 0;
                general_Config1.childcount[2] = 0;
                for (j = 0; j < count; j++)
                {
                    general_Config1.childcount[config_data[65 + j * 60]]++;
                    for (i = 0; i < 14; i++)
                        general_Config1.colle[config_data[65 + j * 60], config_data[66 + j * 60]].addr[i] = config_data[67 + j * 60 + i];
                    // general_Config1.comboBox_tabetype.SelectedIndex = config_data[83 + j * 60];
                    string tab_type = null;
                    switch (config_data[81 + j * 60])
                    {
                        case 64: tab_type = "电能表"; break;
                        case 48: tab_type = "燃气表"; break;
                        case 33: tab_type = "热能表(冷)"; break;
                        case 32: tab_type = "热能表(热)"; break;
                        case 19: tab_type = "中水水表"; break;
                        case 18: tab_type = "直饮水水表"; break;
                        case 17: tab_type = "生活热水水表"; break;
                        case 16: tab_type = "冷水水表"; break;
                        case 129: tab_type = "温控器"; break;
                        case 25: tab_type = "大水表"; break;
                        default: break;


                    }
                    general_Config1.treeView1.Nodes[config_data[65 + j * 60]].Nodes.Add("[" + config_data[65 + j * 60] + "-" + config_data[66 + j * 60].ToString("00") + "]" +
                        "[" + ASCII.GetString(general_Config1.colle[config_data[65 + j * 60], config_data[66 + j * 60]].addr) + "号]" + tab_type);
                    general_Config1.colle[config_data[65 + j * 60], config_data[66 + j * 60]].tab_type = config_data[81 + j * 60];
                    general_Config1.colle[config_data[65 + j * 60], config_data[66 + j * 60]].tab_state = config_data[82 + j * 60];
                    general_Config1.colle[config_data[65 + j * 60], config_data[66 + j * 60]].funcode = config_data[83 + j * 60];
                    //for (i = 0; i < 5; i++)
                    //{
                    //    general_Config1.colle[config_data[65 + j * 60], config_data[66 + j * 60]].commcode[i] = config_data[84 + j * 60 + i];
                    //}
                    //for (i = 0; i < 10; i++)
                    //{
                    //    general_Config1.colle[config_data[65 + j * 60], config_data[66 + j * 60]].fn[i] = config_data[89 + j * 60 + i];
                    //}
                    //for (i = 0; i < 20; i++)
                    //{
                    //    general_Config1.colle[config_data[65 + j * 60], config_data[66 + j * 60]].fmt[i] = config_data[99 + j * 60 + i];
                    //}
                    for (i = 0; i < 5; i++)
                        general_Config1.colle[config_data[65 + j * 60], config_data[66 + j * 60]].enercode[i] = config_data[119 + j * 60 + i];
                    general_Config1.colle[config_data[65 + j * 60], config_data[66 + j * 60]].item_count = config_data[124 + j * 60];
                }
            }
        }

        private void button_readconfig_Click(object sender, EventArgs e)
        {
            textBox_clientlst.AppendText("->读取基本配置...\r\n");
            byte[] read_comm = new byte[]{0x01,0x01};
            this.Invoke(new MethodInvoker(delegate
            {
                netTCPClient1.SendData(read_comm);

            }));
            general_Config1.treeView1.Nodes[0].Nodes.Clear();
            general_Config1.treeView1.Nodes[1].Nodes.Clear();
            general_Config1.treeView1.Nodes[2].Nodes.Clear();
            general_Config1.childcount[0] = 0;
            general_Config1.childcount[1] = 0;
            general_Config1.childcount[2] = 0;

        }

        private void button_led_config_Click(object sender, EventArgs e)
        {

        }

        private void datadisplay1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 服务区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
           
             if (begin == false)
             {
                 
                 devTCPServer.StartTCPServer();
                 begin = true;
             }
             else
             {//监听已开启
                 devTCPServer.StopTCPServer();
                 devTCPServer.ClearSelf();
                 begin = false;
                 pass = false;

             }
    
             if (begin)
             {
                 button_server.Text = "关闭监听";
             }
             else
             {
                 button_server.Text = "开启监听";
                // button_led_config.BackColor = Color.Empty;
             }
        }

        private void textBox_clientlst_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_cleardatadis_Click(object sender, EventArgs e)
        {
            textBox_clientlst.Clear();
        }

        private void button_saveconfig_Click(object sender, EventArgs e)
        {
            byte[] save = new byte[] { 0x01, 0x02 };
            this.Invoke(new MethodInvoker(delegate
            {
                if (netTCPClient1.SendData(save))
                {
                    textBox_clientlst.AppendText("->保存配置到采集器");
                }

            })); 
        }

        private void system_config1_Load(object sender, EventArgs e)
        {

        }

        private void general_Config1_Load(object sender, EventArgs e)
        {

        }
        bool debug = false;
        private void button_debug_Click(object sender, EventArgs e)
        {  
            byte[] debug_common = new byte[]{0x01,0x06};
            byte[] debug_commoff = new byte[] { 0x01, 0x07 };
            if (debug == false)
                this.Invoke(new MethodInvoker(delegate
                {
                    netTCPClient1.SendData(debug_common);
                    button_debug.Text = "关闭调试";
                    debug = true;

                }));
            else
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    netTCPClient1.SendData(debug_commoff);
                    button_debug.Text = "开启调试";
                    debug = false;
                }));  
            }
          
        }

  }
}

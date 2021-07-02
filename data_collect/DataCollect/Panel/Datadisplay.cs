using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataCollect.Units;
using System.Threading;
using System.Xml;
namespace DataCollect.Panel
{
    public partial class Datadisplay : UserControl
    {
        bool AutoCheck = false;
        public event Lib.CollectEvent.Send_query query;
        public event Lib.CollectEvent.Period period;
        public event Lib.CollectEvent.History history;
        string key = "abcdefghijklmnopqrstuvwxyz123456";
        public Datadisplay()
        {
            InitializeComponent();
         }
        public void heart_dis(string heart)
        {
                textBox_heartb.Clear();
                textBox_heartb.AppendText(heart);
        }
        int it_count = 0;
        public void xml_dis(string xml_data)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                int i,k;
                //listView_history.Items.Clear(); ;
                textBox_xml.Clear();
                textBox_xml.AppendText(xml_data);
               
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml_data);
                    AES_Helper aes = new AES_Helper();
                    XmlNode xn2 = xmlDoc.SelectSingleNode("root/data/time");
                    XmlNode xn3 = xmlDoc.SelectSingleNode("root/data/total");
                    XmlNode xl  =  xmlDoc.SelectSingleNode("root/data/meter");
                    //for (k = 0;xl[k] != null; k++)
                    //{ 
                       string s1 = xl.Attributes["id"].Value;
                       XmlNodeList xmlNodeList = xl.ChildNodes;
                        for (i = 0; xmlNodeList[i] != null; i++)
                        {
                            string s2 = xmlNodeList[i].Attributes["id"].Value;
                            switch (s2)
                            {
                                case "64": s2 = "电能表"; break;
                                case "48": s2 = "燃气表"; break;
                                case "33": s2 = "热能表(冷)"; break;
                                case "32": s2 = "热能表(热)"; break;
                                case "19": s2 = "中水水表"; break;
                                case "18": s2 = "直饮水水表"; break;
                                case "17": s2 = "生活热水水表"; break;
                                case "16": s2 = "冷水水表"; break;
                                case "129": s2 = "温控器"; break;
                                case "25": s2 = "大水表"; break;
                                default: break;

                            }
                            string s3 = xmlNodeList[i].Attributes["coding"].Value;
                            string s4 = xmlNodeList[i].Attributes["error"].Value;
                            string s5 = xmlNodeList[i].InnerText;
                            string s6 = " ";
                            string s7 = xn2.InnerText;
                            string s8 = xn3.InnerText;
                            string[] list = new string[] { s1, s2, s3, s4,s5=aes.Decrypt(s5,key), s6, s7, s8 };
                            ListViewItem item = new ListViewItem((i+1).ToString());
                            item.SubItems.AddRange(list);
                            listView_history.Items.Add(item);
                            it_count++;
                            if (it_count == 200)
                            {
                                it_count = 0;
                                listView_history.Items.Clear();
                            }
                        } 
                    //}
                }
                catch { }
            }));
            
  
        }

        private void textBox_xml_TextChanged(object sender, EventArgs e)
        {

        }
 
        private void button_disdata_Click_1(object sender, EventArgs e)
        {
             query();//发送查询事件触发
        }

        private void textBox_heartb_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button_clearall_Click(object sender, EventArgs e)
        {
            textBox_xml.Clear();
            textBox_heartb.Clear();
            listView_history.Items.Clear();
        }

        private void button_autocheck_Click(object sender, EventArgs e)
        {
            if (AutoCheck == false)
            {
                button_autocheck.Text = "取消自动查询";
                button_disdata.Enabled = false;
                Updown_checktime.Enabled = false;
                AutoCheck = true;
                Thread Thcheck = new Thread(new ParameterizedThreadStart(TAutoCheck));
                Thcheck.IsBackground = true;
                Thcheck.Start(Updown_checktime.Value);

            }
            else
            {
                AutoCheck = false;
                button_autocheck.Text = "自动查询";
                button_disdata.Enabled = true;
                Updown_checktime.Enabled = true;
            
            
            }
        }
        public void TAutoCheck(object Interval)
        {
            int checktime = Convert.ToInt32(Interval);
            while (AutoCheck)
            {
                query();
                Thread.Sleep(checktime*1000);
            }
        
        }

        private void Updown_checktime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox_xml_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Datadisplay_Load(object sender, EventArgs e)
        {
            
        }

        private void button_setcollect_Click(object sender, EventArgs e)
        {
            string per = numericUpDown_period.Value.ToString();
            period(per);
        }

        private void button_historycheck_Click(object sender, EventArgs e)
        {
            history(dateTimePicker_historystart.Text+" "+dateTimePicker_timestart.Text,dateTimePicker_hisotoryend.Text+" "+dateTimePicker_timeend.Text);
        }
    }
}

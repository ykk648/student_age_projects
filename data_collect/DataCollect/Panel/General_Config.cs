using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataCollect.Lib;
using System.Threading;
namespace DataCollect.Panel
{
    public partial class General_Config : UserControl
    {
        public event CollectEvent.Downcollpoint collp;
        public event CollectEvent.Downcollgen collg;
        public event CollectEvent.Checkgm check;
        int treeindex;
        public CollectPoints[,] colle = new CollectPoints[3, 32];
        public FMT[] fmt = new FMT[20];
        //public Collpoint[,] colle = new Collpoint[3,32];
        public General_Config()
        {
            int i,j;
            InitializeComponent();
            comboBox_buildingtype.SelectedIndex = 0;
            comboBox_tabetype.SelectedIndex = 0;
            comboBox_tabestate.SelectedIndex = 0;
            comboBox_1.SelectedIndex = 0;
            comboBox_2.SelectedIndex = 0;
            comboBox_3.SelectedIndex = 0;
            comboBox_4.SelectedIndex = 0;
            for (i = 0; i < 3; i++)
                for (j = 0; j < 32; j++)
                    colle[i, j] = new CollectPoints();
            for (i = 0; i < 20; i++)
            {
                fmt[i] = new FMT();
             }
                     
        }
        private void treeView_code_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string s1 = null, s2 = null,s3=null,s4=null,s5=null,s6=null,s7=null;
            textBox_currentdev.Clear();
            textBox_collectpoint_id.Clear();
            treeView_code.SelectedNode = e.Node;
            if (treeView_code.SelectedNode.Parent != null)
            {
                s1 = treeView_code.SelectedNode.Text.Remove(0, 6);
                s2 = treeView_code.SelectedNode.Parent.Text.Remove(0, 6);
           
            }
            s6 = treeView_code.SelectedNode.Text.Substring(0, 6);
            s7 = comboBox_buildingtype.Text.Substring(0, 1);
            s3 = Convert.ToInt32("0"+textBox_building_id.Text).ToString("000");
            s4 = comboBox_buildingtype.Text.Remove(0,1);
            s5 =Convert.ToInt16( "0"+textBox_getaway_id.Text).ToString("00");
            //treeView_code.SelectedNode = null;
            textBox_currentdev.AppendText(s2+s1+s3+"号"+s4+s5+"号采集器");
            textBox_collectpoint_id.AppendText(s6+s7+s3+s5);

        }

        private void comboBox_buildingtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_building_id_TextChanged(object sender, EventArgs e)
        {

        }
        public byte[] childcount = new byte[3];                      //=0, childcount1=0, childcount2=0;
        long  table_No=0;
        int tab_p, tab_s;
        private void button_adddev_Click(object sender, EventArgs e)
        {

            if ((childcount[0] <= 31) && (childcount[1] <= 31) && (childcount[2] <= 31))
            {
                table_No = Convert.ToInt64("0" + textBox_tabeaddr.Text);

                if ((treeindex == 0) && (comboBox_tabestate.SelectedIndex == 0))//正常则添加
                {
                    textBox_tabeaddr2.Clear();
                    textBox_tabeaddr2.AppendText(childcount[0].ToString("000"));
                    treeView1.Nodes[treeindex].Nodes.Add("[" + treeindex + "-" + childcount[0].ToString("00") + "]" + "[" + table_No.ToString("00000000000000") + "号]" + comboBox_tabetype.Text);
               //    colle[0, childcount[0]].tab_type = (byte)Convert.ToInt32("0" + textBox_tabetype.Text);
                    colle[treeindex, childcount[0]].t_p = (byte)treeindex;
                    colle[treeindex, childcount[0]].t_s = (byte)childcount[0];
                    
                    childcount[0]++;

                    textBox_opdis.AppendText( "添加" + comboBox_tabetype.Text + "成功\r\n");
                }

                if ((treeindex == 1) && (comboBox_tabestate.SelectedIndex == 0))
                {
                    textBox_tabeaddr2.Clear();
                    textBox_tabeaddr2.AppendText(childcount[1].ToString("000"));
                    treeView1.Nodes[treeindex].Nodes.Add("[" + treeindex + "-" + childcount[1].ToString("00") + "]" + "[" + table_No.ToString("00000000000000") + "号]" + comboBox_tabetype.Text);
                 //   colle[1, childcount[1]].tab_type = (byte)Convert.ToInt32("0" + textBox_tabetype.Text);
                    colle[treeindex, childcount[1]].t_p = (byte)treeindex;
                    colle[treeindex, childcount[1]].t_s = (byte)childcount[2];
                    childcount[1]++;
                    textBox_opdis.AppendText( "添加" + comboBox_tabetype.Text + "成功\r\n");
                }

                if ((treeindex == 2) && (comboBox_tabestate.SelectedIndex == 0))
                {
                    textBox_tabeaddr2.Clear();
                    textBox_tabeaddr2.AppendText(childcount[2].ToString("000"));
                    treeView1.Nodes[treeindex].Nodes.Add("[" + treeindex + "-" + childcount[2].ToString("00") + "]" + "[" + table_No.ToString("00000000000000") + "号]" + comboBox_tabetype.Text);
                   // colle[2, childcount[2]].tab_type = (byte)Convert.ToInt32("0" + textBox_tabetype.Text);
                    colle[treeindex, childcount[2]].t_p = (byte)treeindex;
                    colle[treeindex, childcount[2]].t_s = (byte)childcount[2];
                    childcount[2]++;
                    textBox_opdis.AppendText("添加" + comboBox_tabetype.Text + "成功\r\n");
                }
                treeView1.Nodes[treeindex].ExpandAll();
            }
            else 
            {
               
                MessageBox.Show("端口列表已注册满", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            table_No = 0;
                
        }
      
        public void treeView1_MouseClick(object sender, TreeNodeMouseClickEventArgs e)
        { 
             treeView1.SelectedNode=e.Node;
             if (treeView1.SelectedNode.Parent != null)
             {
                 tab_p = treeView1.SelectedNode.Parent.Index;
                 tab_s = treeView1.SelectedNode.Index;
                 button_modifydev.Enabled = true;
                 if (colle[tab_p, tab_s] != null)
                 {
                     int i;
                     System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
                     textBox_funcode.Text = colle[tab_p, tab_s].funcode.ToString();
                     textBox_energycode.Clear();
                     if (colle[tab_p, tab_s].enercode != null)
                         textBox_energycode.AppendText(ASCII.GetString(colle[tab_p, tab_s].enercode));
                     else
                         textBox_energycode.AppendText("00000");
                     //textBox_commandcode.Clear();

                     textBox_tabeaddr.Clear();
                     textBox_tabeaddr.AppendText(ASCII.GetString(colle[tab_p, tab_s].addr));
                     textBox_tabetype.Clear();
                     textBox_tabetype.AppendText(colle[tab_p, tab_s].tab_type.ToString());
                     bool[] cf = new bool[20];
                     string[] str_rl = new string[20];
                     for (i = 0; i < 20; i++)
                     {
                         if (colle[tab_p, tab_s].reg_len[i] != 0 && colle[tab_p, tab_s].commaddr[i] != 0
                             && colle[tab_p, tab_s].mul[i] != 0)
                         {
                             cf[i] = true;
                             str_rl[i] = (colle[tab_p, tab_s].reg_len[i] & 0x0F).ToString();
                             fmt[i].textBox_commaddr.Text = colle[tab_p, tab_s].commaddr[i].ToString("X");
                             fmt[i].textBox_mul.Text = colle[tab_p, tab_s].mul[i].ToString();
                             fmt[i].numericUpDown_f.Value = (colle[tab_p, tab_s].reg_len[i] >> 4) & 0x0F;
                         }
                         else
                         {
                             cf[i] = false;
                         }

                     }
                     textBox_1.Text = str_rl[0];
                     textBox_2.Text = str_rl[1];
                     textBox_3.Text = str_rl[2];
                     textBox_4.Text = str_rl[3];
                     textBox_5.Text = str_rl[4];
                     textBox_6.Text = str_rl[5];
                     textBox_7.Text = str_rl[6];
                     textBox_8.Text = str_rl[7];
                     textBox_9.Text = str_rl[8];
                     textBox_10.Text = str_rl[9];
                     textBox_11.Text = str_rl[10];
                     textBox_12.Text = str_rl[11];
                     textBox_13.Text = str_rl[12];
                     textBox_14.Text = str_rl[13];
                     textBox_15.Text = str_rl[14];
                     textBox_16.Text = str_rl[15];
                     textBox_17.Text = str_rl[16];
                     textBox_18.Text = str_rl[17];
                     textBox_19.Text = str_rl[18];
                     textBox_20.Text = str_rl[19];
                     checkBox_1.Checked = cf[0];
                     checkBox_2.Checked = cf[1];
                     checkBox_3.Checked = cf[2];
                     checkBox_4.Checked = cf[3];
                     checkBox_5.Checked = cf[4];
                     checkBox_6.Checked = cf[5];
                     checkBox_7.Checked = cf[6];
                     checkBox_8.Checked = cf[7];
                     checkBox_9.Checked = cf[8];
                     checkBox_10.Checked = cf[9];
                     checkBox_11.Checked = cf[10];
                     checkBox_12.Checked = cf[11];
                     checkBox_13.Checked = cf[12];
                     checkBox_14.Checked = cf[13];
                     checkBox_15.Checked = cf[14];
                     checkBox_16.Checked = cf[15];
                     checkBox_17.Checked = cf[16];
                     checkBox_18.Checked = cf[17];
                     checkBox_19.Checked = cf[18];
                     checkBox_20.Checked = cf[19];

                 }
             }
            
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Parent == null)
            {
                treeindex = treeView1.SelectedNode.Index;
                comboBox_selectport.SelectedIndex = treeindex;
            }
            
           
        }

        private void General_Config_Load(object sender, EventArgs e)
        {
            textBox_opdis.AppendText("采集器通用信息配置\r\n");
        }

        private void comboBox_tabetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            index=comboBox_tabetype.SelectedIndex;
            textBox_tabetype.Clear();
            switch (index)
            {
                case 0: textBox_tabetype.AppendText("64"); break;
                case 1: textBox_tabetype.AppendText("48"); break;
                case 2: textBox_tabetype.AppendText("33"); break;
                case 3: textBox_tabetype.AppendText("32"); break;
                case 4: textBox_tabetype.AppendText("19"); break;
                case 5: textBox_tabetype.AppendText("18"); break;
                case 6: textBox_tabetype.AppendText("17"); break;
                case 7: textBox_tabetype.AppendText("16"); break;
                case 8: textBox_tabetype.AppendText("129"); break;
                case 9: textBox_tabetype.AppendText("25"); break;
                default: break;
            
            }
        }
        
        private void button_deleteall_Click(object sender, EventArgs e)
        {
            int i,j;
            Warning warn = new Warning();
            warn.ShowDialog();
      
            if (warn.ok==true)
            {
                for (i = 0; i < 3; i++)
                    for (j = 0; j < 32; j++)
                        colle[i, j] = new CollectPoints();
                for (i = 0; i < 20; i++)
                {
                    fmt[i] = new FMT();

                }
                treeView1.Nodes[0].Nodes.Clear();
                treeView1.Nodes[1].Nodes.Clear();
                treeView1.Nodes[2].Nodes.Clear();
                childcount[0] = 0;
                childcount[1] = 0;
                childcount[2] = 0;
                textBox_opdis.AppendText("全部设备已删除！\r\n");
            }


        }

        private void checkBox_n1_CheckedChanged(object sender, EventArgs e)
        {
           
            button_1.Enabled = !button_1.Enabled;
        }

        private void checkBox_n2_CheckedChanged(object sender, EventArgs e)
        {
            button_2.Enabled = !button_2.Enabled;
        }

        private void checkBox_n3_CheckedChanged(object sender, EventArgs e)
        {
            button_3.Enabled = !button_3.Enabled;
        }

        private void checkBox_n4_CheckedChanged(object sender, EventArgs e)
        {
            button_4.Enabled = !button_4.Enabled;
        }

        private void checkBox_n5_CheckedChanged(object sender, EventArgs e)
        {
            button_5.Enabled = !button_5.Enabled;
        }

        private void checkBox_n6_CheckedChanged(object sender, EventArgs e)
        {
            button_6.Enabled = !button_6.Enabled;
        }

        private void checkBox_n7_CheckedChanged(object sender, EventArgs e)
        {
            button_7.Enabled = !button_7.Enabled;
        }

        private void checkBox_n8_CheckedChanged(object sender, EventArgs e)
        {
            button_8.Enabled = !button_8.Enabled;
        }

        private void checkBox_n9_CheckedChanged(object sender, EventArgs e)
        {
            button_9.Enabled = !button_9.Enabled;
        }

        private void checkBox_n10_CheckedChanged(object sender, EventArgs e)
        {
            button_10.Enabled = !button_10.Enabled;
        }
        private void checkBox_11_CheckedChanged(object sender, EventArgs e)
        {
            button_10.Enabled = !button_10.Enabled;
        }

        private void checkBox_12_CheckedChanged(object sender, EventArgs e)
        {
            button_12.Enabled = !button_12.Enabled;
        }

        private void checkBox_13_CheckedChanged(object sender, EventArgs e)
        {
            button_13.Enabled = !button_13.Enabled;
        }

        private void checkBox_14_CheckedChanged(object sender, EventArgs e)
        {
            button_14.Enabled = !button_14.Enabled;
        }

        private void checkBox_15_CheckedChanged(object sender, EventArgs e)
        {
            button_15.Enabled = !button_15.Enabled;
        }

        private void checkBox_16_CheckedChanged(object sender, EventArgs e)
        {
            button_16.Enabled = !button_16.Enabled;
        }

        private void checkBox_17_CheckedChanged(object sender, EventArgs e)
        {
            button_17.Enabled = !button_17.Enabled;
        }

        private void checkBox_18_CheckedChanged(object sender, EventArgs e)
        {
            button_18.Enabled = !button_18.Enabled;
        }

        private void checkBox_19_CheckedChanged(object sender, EventArgs e)
        {
            button_19.Enabled = !button_19.Enabled;
        }

        private void checkBox_20_CheckedChanged(object sender, EventArgs e)
        {
            button_20.Enabled = !button_20.Enabled;
        }
        public void button_modifydev_Click(object sender, EventArgs e)
        {
            int i;
            byte itemcount=0;
            byte[] table=new byte[14];
            byte[] ener_code = new byte[5];
            bool[] checkbox = new bool[20];
            string[] textb = new string[20];
            checkbox[0] = checkBox_1.Checked;
            checkbox[1] = checkBox_2.Checked;
            checkbox[2] = checkBox_3.Checked;
            checkbox[3] = checkBox_4.Checked;
            checkbox[4] = checkBox_5.Checked;
            checkbox[5] = checkBox_6.Checked;
            checkbox[6] = checkBox_7.Checked;
            checkbox[7] = checkBox_8.Checked;
            checkbox[8] = checkBox_9.Checked;
            checkbox[9] = checkBox_10.Checked;
            checkbox[10] = checkBox_11.Checked;
            checkbox[11] = checkBox_12.Checked;
            checkbox[12] = checkBox_13.Checked;
            checkbox[13] = checkBox_14.Checked;
            checkbox[14] = checkBox_15.Checked;
            checkbox[15] = checkBox_16.Checked;
            checkbox[16] = checkBox_17.Checked;
            checkbox[17] = checkBox_18.Checked;
            checkbox[18] = checkBox_19.Checked;
            checkbox[19] = checkBox_20.Checked;

            textb[0] = textBox_1.Text;
            textb[1] = textBox_2.Text;
            textb[2] = textBox_3.Text;
            textb[3] = textBox_4.Text;
            textb[4] = textBox_5.Text;
            textb[5] = textBox_6.Text;
            textb[6] = textBox_7.Text;
            textb[7] = textBox_8.Text;
            textb[8] = textBox_9.Text;
            textb[9] = textBox_10.Text;
            textb[10] = textBox_11.Text;
            textb[11] = textBox_12.Text;
            textb[12] = textBox_13.Text;
            textb[13] = textBox_14.Text;
            textb[14] = textBox_15.Text;
            textb[15] = textBox_16.Text;
            textb[16] = textBox_17.Text;
            textb[17] = textBox_18.Text;
            textb[18] = textBox_19.Text;
            textb[19] = textBox_20.Text;
        //  colle[tab_p, tab_s] = new CollectPoints();
            table_No = Convert.ToInt64("0"+textBox_tabeaddr.Text);
            colle[tab_p, tab_s].maddr = (byte)table_No;
            treeView1.Nodes[tab_p].Nodes[tab_s].Text = ("[" + tab_p + "-" + tab_s.ToString("00") + "]" + "[" + table_No.ToString("00000000000000") + "号]" + comboBox_tabetype.Text);
                colle[tab_p, tab_s].t_p = (byte)tab_p;
                colle[tab_p, tab_s].t_s = (byte)tab_s;
                table = Encoding.Default.GetBytes(table_No.ToString("00000000000000"));
                for (i = 0; i < 14; i++)
                    colle[tab_p, tab_s].addr[i] = table[i];
                colle[tab_p, tab_s].tab_type = (byte)Convert.ToInt32("0"+textBox_tabetype.Text);
                colle[tab_p, tab_s].tab_state = (byte)comboBox_tabestate.SelectedIndex;         //表状态
                colle[tab_p, tab_s].funcode = (byte)Convert.ToInt32("0"+textBox_funcode.Text);
                ener_code = Encoding.Default.GetBytes(textBox_energycode.Text);
                for (i = 0; i < 5; i++)
                {
                    colle[tab_p, tab_s].enercode[i] = ener_code[i];
                
                }
                for (int j = 0; j < 20; j++)
                {
                    // colle[tab_p, tab_s].enercode = Convert.ToByte("0"+textBox_energycode.Text);
                    if (checkbox[j] == true)
                    {
                        byte h, l;
                        colle[tab_p, tab_s].commaddr[j] = Convert.ToInt16("0" + fmt[j].textBox_commaddr.Text, 16);
                        l = Convert.ToByte("0" + textb[j]);
                        h = (byte)fmt[j].numericUpDown_f.Value;
                        colle[tab_p, tab_s].reg_len[j] =(byte) (h<<4|l);
                        colle[tab_p, tab_s].mul[j] = (float)Convert.ToDouble("0" + fmt[j].textBox_mul.Text);
                        itemcount++;
                    }
                }
               colle[tab_p, tab_s].item_count = itemcount;
               textBox_opdis.AppendText("通用信息保存到采集点成功\r\n");
               button_downdevconfig.Enabled = true;
        }

        private void button_downdevconfig_Click(object sender, EventArgs e)
        {
            byte[] collpoint = new byte[256];
            byte i,p,s,count=0;
            collpoint[0] = 0x03;
            collpoint[1] = 0x03;
            collpoint[2] = (byte)(childcount[0] + childcount[1] + childcount[2]);/////////////////////////////
            try
            {
                for (p = 0; p < 3; p++)
                    for (s = 0; s < childcount[p]; s++)
                    {
                        if (count < (childcount[0] + childcount[1] + childcount[2]))
                        {
                            collpoint[3] = count;
                            collpoint[4] = colle[p, s].t_p;
                            collpoint[5] = colle[p, s].t_s;
                            for (i = 0; i < 14; i++)
                            {
                                collpoint[6+i] = colle[p, s].addr[i];//表号即地址
                            }
                            collpoint[20] = colle[p, s].maddr;
                            collpoint[21] = colle[p, s].tab_type;
                            collpoint[22] = colle[p, s].tab_state;
                            collpoint[23] = colle[p, s].funcode;
                            for (i = 0; i < 5; i++)
                            {
                                collpoint[24 + i] = colle[p, s].enercode[i];         //读的寄存器起始地址

                            }
                            //collpoint[29] = 0x00;
                            collpoint[29] = colle[p, s].item_count;
                            for (i = 0; i < 20; i++)
                            {
                                collpoint[30 + i] = colle[p, s].reg_len[i];
       
                            }
                            //collpoint[51] = 0x00;
                            for (i = 0; i < 20; i++)
                            {
                                collpoint[50 + i*2 ] = (byte)(colle[p, s].commaddr[i] % 256);
                                collpoint[51 + i*2 ] = (byte)(colle[p, s].commaddr[i] / 256);
                            }
                            //collpoint[90] = 0;?
                            //collpoint[91] = 0;?
                            for (i = 0; i < 20; i++)
                            {
                                byte[] buf = BitConverter.GetBytes(colle[p, s].mul[i]);
                                collpoint[92 + i*4] = buf[0];
                                collpoint[93 + i*4] = buf[1];
                                collpoint[94 + i*4] = buf[2];
                                collpoint[95 + i*4] = buf[3];
                            }
                            collp(collpoint);
                           
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
            
         }

        private void button_readmessage_Click(object sender, EventArgs e)
        {
            check();
        }

        private void button_downmessage_Click(object sender, EventArgs e)
        {
            byte[] coll_id = new byte[12];
           
            byte[] down_id = new byte[14];

            int i;
            down_id[0] = 0x03;
            down_id[1] = 0x04;
            coll_id = Encoding.Default.GetBytes(textBox_collectpoint_id.Text);
            for (i = 0; i < 12; i++)
            {
                down_id[2 + i] = coll_id[i];
            }
            collg(down_id);
        }

        private void textBox_currentdev_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_delectdev_Click(object sender, EventArgs e)
        {
                
        
        }

        private void button_delectdev_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.Parent != null)
                {
                    treeView1.Nodes.Remove(treeView1.SelectedNode);
                    colle[tab_p, tab_s] = new CollectPoints();
                    childcount[tab_p]--;
                    textBox_opdis.AppendText("删除设备成功\r\n");
                }
                else
                    textBox_opdis.AppendText("请单击以选中要删除的设备\r\n");
            }
            catch { }
        }
        private void button_n1_Click(object sender, EventArgs e)
        {

            fmt[0].ShowDialog();
            if (fmt[0].enfmt == true)
            {
                button_1.Text = "FMT";

            }
        }
        private void button_n2_Click(object sender, EventArgs e)
        {
            fmt[1].ShowDialog();
            if (fmt[1].enfmt == true)
            {
                button_2.Text = "FMT";

            }
        }

        private void button_n3_Click(object sender, EventArgs e)
        {
            fmt[2].ShowDialog();
            if (fmt[2].enfmt == true)
            {
                button_3.Text = "FMT";

            }
        }

        private void button_n4_Click(object sender, EventArgs e)
        {
            fmt[3].ShowDialog();
            if (fmt[3].enfmt == true)
            {
                button_4.Text = "FMT";

            }
        }

        private void button_n5_Click(object sender, EventArgs e)
        {
            fmt[4].ShowDialog();
            if (fmt[4].enfmt == true)
            {
                button_5.Text = "FMT";

            }
        }

        private void button_n6_Click(object sender, EventArgs e)
        {
            fmt[5].ShowDialog();
            if (fmt[5].enfmt == true)
            {
                button_6.Text = "FMT";

            }
        }

        private void button_n7_Click(object sender, EventArgs e)
        {
            fmt[6].ShowDialog();
            if (fmt[6].enfmt == true)
            {
                button_7.Text = "FMT";

            }
        }

        private void button_n8_Click(object sender, EventArgs e)
        {
            fmt[7].ShowDialog();
            if (fmt[7].enfmt == true)
            {
                button_8.Text = "FMT";

            }
        }

        private void button_n9_Click(object sender, EventArgs e)
        {
            fmt[8].ShowDialog();
            if (fmt[8].enfmt == true)
            {
                button_9.Text = "FMT";

            }
        }

        private void button_n10_Click(object sender, EventArgs e)
        {
            fmt[9].ShowDialog();
            if (fmt[9].enfmt == true)
            {
                button_10.Text = "FMT";

            }
        }
        private void button_11_Click(object sender, EventArgs e)
        {
            fmt[10].ShowDialog();
            if (fmt[10].enfmt == true)
            {
                button_11.Text = "FMT";

            }
        }

        private void button_12_Click(object sender, EventArgs e)
        {
            fmt[11].ShowDialog();
            if (fmt[11].enfmt == true)
            {
                button_12.Text = "FMT";

            }
        }

        private void button_13_Click(object sender, EventArgs e)
        {
            fmt[12].ShowDialog();
            if (fmt[12].enfmt == true)
            {
                button_13.Text = "FMT";

            }
        }

        private void button_14_Click(object sender, EventArgs e)
        {
            fmt[13].ShowDialog();
            if (fmt[13].enfmt == true)
            {
                button_14.Text = "FMT";

            }
        }

        private void button_15_Click(object sender, EventArgs e)
        {
            fmt[14].ShowDialog();
            if (fmt[14].enfmt == true)
            {
                button_15.Text = "FMT";

            }
        }

        private void button_16_Click(object sender, EventArgs e)
        {
            fmt[15].ShowDialog();
            if (fmt[15].enfmt == true)
            {
                button_16.Text = "FMT";

            }
        }

        private void button_17_Click(object sender, EventArgs e)
        {
            fmt[16].ShowDialog();
            if (fmt[16].enfmt == true)
            {
                button_17.Text = "FMT";

            }
        }

        private void button_18_Click(object sender, EventArgs e)
        {
            fmt[17].ShowDialog();
            if (fmt[17].enfmt == true)
            {
                button_18.Text = "FMT";

            }
        }

        private void button_19_Click(object sender, EventArgs e)
        {
            fmt[18].ShowDialog();
            if (fmt[18].enfmt == true)
            {
                button_19.Text = "FMT";

            }
        }

        private void button_20_Click(object sender, EventArgs e)
        {
            fmt[19].ShowDialog();
            if (fmt[19].enfmt == true)
            {
                button_20.Text = "FMT";

            }
        }
        private void comboBox_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_energycode.Clear();
            string str1, str2;
            if (comboBox_2.SelectedIndex <= 0)
                str1 = "0";
            else
                str1 = comboBox_2.Text.Substring(0,1);
            if (comboBox_4.SelectedIndex <= 0)
                str2 = "0";
            else
                str2 = comboBox_4.Text.Substring(0, 1);
            textBox_energycode.AppendText(comboBox_1.SelectedIndex.ToString("00") +
               str1 + comboBox_3.SelectedIndex.ToString() + str2);
            switch(comboBox_2.SelectedIndex)
            {
                case 0:
                       comboBox_3.Items.Clear();
                       comboBox_3.Items.Add("未定义");
                       comboBox_3.SelectedIndex = 0;
                       break;
                case 1:
                       comboBox_3.Items.Clear();
                       
                       comboBox_3.Items.Add("未定义");
                       comboBox_3.Items.Add("1照明与插座");
                       comboBox_3.Items.Add("2走廊与应急");
                       comboBox_3.Items.Add("3室外景观照明");
                       comboBox_3.SelectedIndex = 0;
                       break;
                case 2:
                       comboBox_3.Items.Clear();
                       
                       comboBox_3.Items.Add("未定义");
                       comboBox_3.Items.Add("1冷热站");
                       comboBox_3.Items.Add("2空调末端");
                       comboBox_3.SelectedIndex = 0;
                       break;
                case 3: 
                       comboBox_3.Items.Clear();
                     
                       comboBox_3.Items.Add("未定义");
                       comboBox_3.Items.Add("1电梯");
                       comboBox_3.Items.Add("2水泵");
                       comboBox_3.Items.Add("3通风机");
                       comboBox_3.SelectedIndex = 0;
                       break;
                 case 4:
                       comboBox_3.Items.Clear();
                       
                       comboBox_3.Items.Add("未定义");
                       comboBox_3.Items.Add("1信息中心");
                       comboBox_3.Items.Add("2洗衣房");
                       comboBox_3.Items.Add("3厨房餐厅");
                       comboBox_3.Items.Add("4游泳池");
                       comboBox_3.Items.Add("5健身房");
                       comboBox_3.Items.Add("6其它");
                       comboBox_3.SelectedIndex = 0;
                       break;
                 default: break;     
                 
             }
        }
        private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_energycode.Clear();
            string str1, str2;
            if (comboBox_2.SelectedIndex <= 0)
                str1 = "0";
            else
                str1 = comboBox_2.Text.Substring(0, 1);
            if (comboBox_4.SelectedIndex <= 0)
                str2 = "0";
            else
                str2 = comboBox_4.Text.Substring(0, 1);
            textBox_energycode.AppendText(comboBox_1.SelectedIndex.ToString("00") +
               str1 + comboBox_3.SelectedIndex.ToString() + str2);
        }

        private void comboBox_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_energycode.Clear();
            string str1, str2;
            if (comboBox_2.SelectedIndex <= 0)
                str1 = "0";
            else
                str1 = comboBox_2.Text.Substring(0, 1);
            if (comboBox_4.SelectedIndex <= 0)
                str2 = "0";
            else
                str2 = comboBox_4.Text.Substring(0, 1);
            textBox_energycode.AppendText(comboBox_1.SelectedIndex.ToString("00") +
               str1 + comboBox_3.SelectedIndex.ToString() + str2);
        }

        private void comboBox_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_energycode.Clear();
            string str1, str2;
            if (comboBox_2.SelectedIndex <= 0)
                str1 = "0";
            else
                str1 = comboBox_2.Text.Substring(0, 1);
            if (comboBox_4.SelectedIndex <= 0)
                str2 = "0";
            else
                str2 = comboBox_4.Text.Substring(0, 1);
            textBox_energycode.AppendText(comboBox_1.SelectedIndex.ToString("00") +
               str1 + comboBox_3.SelectedIndex.ToString() + str2);
        }

        private void textBox_tabetype_TextChanged(object sender, EventArgs e)
        {       
            switch (textBox_tabetype.Text)
            {
                case "64": comboBox_tabetype.SelectedIndex = 0; break;
                case "48": comboBox_tabetype.SelectedIndex = 1; break;
                case "33": comboBox_tabetype.SelectedIndex = 2; break;
                case "32": comboBox_tabetype.SelectedIndex = 3; break;
                case "19": comboBox_tabetype.SelectedIndex = 4; break;
                case "18": comboBox_tabetype.SelectedIndex = 5; break;
                case "17": comboBox_tabetype.SelectedIndex = 6; break;
                case "16": comboBox_tabetype.SelectedIndex = 7; break;
                case "129": comboBox_tabetype.SelectedIndex = 8; break;
                case "25": comboBox_tabetype.SelectedIndex = 9; break;
                default: break;
             }
        }

        private void groupBox_Collectpoint_Enter(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

       

 



    }
}

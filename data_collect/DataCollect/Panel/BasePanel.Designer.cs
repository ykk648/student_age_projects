namespace DataCollect.Panel
{
    partial class BasePanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_begin = new System.Windows.Forms.Button();
            this.button_EXIT = new System.Windows.Forms.Button();
            this.button_led_config = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_led_comm = new System.Windows.Forms.Button();
            this.button_led_data = new System.Windows.Forms.Button();
            this.labelconfig = new System.Windows.Forms.Label();
            this.tabPage_devdebug = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_debug = new System.Windows.Forms.Button();
            this.groupBox_portselect = new System.Windows.Forms.GroupBox();
            this.comboBox_commselect = new System.Windows.Forms.ComboBox();
            this.button_server = new System.Windows.Forms.Button();
            this.tabControl_base = new System.Windows.Forms.TabControl();
            this.tabPage_sys = new System.Windows.Forms.TabPage();
            this.button_cleardatadis = new System.Windows.Forms.Button();
            this.textBox_clientlst = new System.Windows.Forms.TextBox();
            this.tabPage_General = new System.Windows.Forms.TabPage();
            this.tabPage_datadis = new System.Windows.Forms.TabPage();
            this.button_readconfig = new System.Windows.Forms.Button();
            this.button_saveconfig = new System.Windows.Forms.Button();
            this.button_localsave = new System.Windows.Forms.Button();
            this.button_localread = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.netTCPClient1 = new DataCollect.Units.NetTCPClient();
            this.system_config1 = new DataCollect.Panel.System_Config();
            this.general_Config1 = new DataCollect.Panel.General_Config();
            this.datadisplay1 = new DataCollect.Panel.Datadisplay();
            this.devTCPServer = new DataCollect.Units.NetTCPServer();
            this.tabDataReceiver = new DataCollect.Units.TabDataReceive();
            this.dataSender = new DataCollect.Units.DataSend();
            this.panel1.SuspendLayout();
            this.tabPage_devdebug.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_portselect.SuspendLayout();
            this.tabControl_base.SuspendLayout();
            this.tabPage_sys.SuspendLayout();
            this.tabPage_General.SuspendLayout();
            this.tabPage_datadis.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_begin
            // 
            this.button_begin.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_begin.Location = new System.Drawing.Point(4, 0);
            this.button_begin.Name = "button_begin";
            this.button_begin.Size = new System.Drawing.Size(100, 47);
            this.button_begin.TabIndex = 5;
            this.button_begin.Text = "连接";
            this.button_begin.UseVisualStyleBackColor = true;
            this.button_begin.Click += new System.EventHandler(this.button_begin_Click);
            // 
            // button_EXIT
            // 
            this.button_EXIT.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_EXIT.Location = new System.Drawing.Point(640, 0);
            this.button_EXIT.Name = "button_EXIT";
            this.button_EXIT.Size = new System.Drawing.Size(75, 47);
            this.button_EXIT.TabIndex = 6;
            this.button_EXIT.Text = "退出";
            this.button_EXIT.UseVisualStyleBackColor = true;
            this.button_EXIT.Click += new System.EventHandler(this.button_EXIT_Click);
            // 
            // button_led_config
            // 
            this.button_led_config.BackColor = System.Drawing.SystemColors.Control;
            this.button_led_config.Enabled = false;
            this.button_led_config.Location = new System.Drawing.Point(0, 3);
            this.button_led_config.Name = "button_led_config";
            this.button_led_config.Size = new System.Drawing.Size(40, 23);
            this.button_led_config.TabIndex = 7;
            this.button_led_config.UseVisualStyleBackColor = false;
            this.button_led_config.Click += new System.EventHandler(this.button_led_config_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_led_comm);
            this.panel1.Controls.Add(this.button_led_data);
            this.panel1.Controls.Add(this.labelconfig);
            this.panel1.Controls.Add(this.button_led_config);
            this.panel1.Location = new System.Drawing.Point(775, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 47);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "通信";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "数据";
            // 
            // button_led_comm
            // 
            this.button_led_comm.BackColor = System.Drawing.SystemColors.Control;
            this.button_led_comm.Enabled = false;
            this.button_led_comm.Location = new System.Drawing.Point(127, 3);
            this.button_led_comm.Name = "button_led_comm";
            this.button_led_comm.Size = new System.Drawing.Size(40, 23);
            this.button_led_comm.TabIndex = 10;
            this.button_led_comm.UseVisualStyleBackColor = false;
            // 
            // button_led_data
            // 
            this.button_led_data.BackColor = System.Drawing.SystemColors.Control;
            this.button_led_data.Enabled = false;
            this.button_led_data.Location = new System.Drawing.Point(66, 3);
            this.button_led_data.Name = "button_led_data";
            this.button_led_data.Size = new System.Drawing.Size(40, 23);
            this.button_led_data.TabIndex = 9;
            this.button_led_data.UseVisualStyleBackColor = false;
            // 
            // labelconfig
            // 
            this.labelconfig.AutoSize = true;
            this.labelconfig.Location = new System.Drawing.Point(5, 29);
            this.labelconfig.Name = "labelconfig";
            this.labelconfig.Size = new System.Drawing.Size(29, 12);
            this.labelconfig.TabIndex = 8;
            this.labelconfig.Text = "配置";
            // 
            // tabPage_devdebug
            // 
            this.tabPage_devdebug.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_devdebug.Controls.Add(this.groupBox1);
            this.tabPage_devdebug.Controls.Add(this.button_debug);
            this.tabPage_devdebug.Controls.Add(this.groupBox_portselect);
            this.tabPage_devdebug.Controls.Add(this.tabDataReceiver);
            this.tabPage_devdebug.Controls.Add(this.dataSender);
            this.tabPage_devdebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage_devdebug.Location = new System.Drawing.Point(4, 34);
            this.tabPage_devdebug.Name = "tabPage_devdebug";
            this.tabPage_devdebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_devdebug.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage_devdebug.Size = new System.Drawing.Size(942, 540);
            this.tabPage_devdebug.TabIndex = 0;
            this.tabPage_devdebug.Text = "设备调试";
            this.tabPage_devdebug.Click += new System.EventHandler(this.tabPage_devconfig_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.devTCPServer);
            this.groupBox1.Location = new System.Drawing.Point(6, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 143);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本地服务器信息";
            // 
            // button_debug
            // 
            this.button_debug.Location = new System.Drawing.Point(260, 13);
            this.button_debug.Name = "button_debug";
            this.button_debug.Size = new System.Drawing.Size(75, 38);
            this.button_debug.TabIndex = 5;
            this.button_debug.Text = "开启调试";
            this.button_debug.UseVisualStyleBackColor = true;
            this.button_debug.Click += new System.EventHandler(this.button_debug_Click);
            // 
            // groupBox_portselect
            // 
            this.groupBox_portselect.Controls.Add(this.comboBox_commselect);
            this.groupBox_portselect.Location = new System.Drawing.Point(6, 13);
            this.groupBox_portselect.Name = "groupBox_portselect";
            this.groupBox_portselect.Size = new System.Drawing.Size(248, 53);
            this.groupBox_portselect.TabIndex = 4;
            this.groupBox_portselect.TabStop = false;
            this.groupBox_portselect.Text = "通讯端口与协议选择";
            this.groupBox_portselect.Enter += new System.EventHandler(this.groupBox_portselect_Enter);
            // 
            // comboBox_commselect
            // 
            this.comboBox_commselect.FormattingEnabled = true;
            this.comboBox_commselect.Items.AddRange(new object[] {
            "0号[A2 B2]采集端口-RS485接口00-GB/T19582-2008   ModBus通信协议",
            "1号[A1 B1]采集端口-RS485接口00-GB/T19582-2008   ModBus通信协议",
            "2号[M+ M-]采集端口--MBUS接口00-GB/T19582-2008   ModBus通信协议"});
            this.comboBox_commselect.Location = new System.Drawing.Point(6, 20);
            this.comboBox_commselect.Name = "comboBox_commselect";
            this.comboBox_commselect.Size = new System.Drawing.Size(236, 20);
            this.comboBox_commselect.TabIndex = 0;
            // 
            // button_server
            // 
            this.button_server.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_server.Location = new System.Drawing.Point(534, 0);
            this.button_server.Name = "button_server";
            this.button_server.Size = new System.Drawing.Size(100, 47);
            this.button_server.TabIndex = 5;
            this.button_server.Text = "开启监听";
            this.button_server.UseVisualStyleBackColor = true;
            this.button_server.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl_base
            // 
            this.tabControl_base.Controls.Add(this.tabPage_sys);
            this.tabControl_base.Controls.Add(this.tabPage_General);
            this.tabControl_base.Controls.Add(this.tabPage_datadis);
            this.tabControl_base.Controls.Add(this.tabPage_devdebug);
            this.tabControl_base.ItemSize = new System.Drawing.Size(96, 30);
            this.tabControl_base.Location = new System.Drawing.Point(0, 56);
            this.tabControl_base.Name = "tabControl_base";
            this.tabControl_base.SelectedIndex = 0;
            this.tabControl_base.Size = new System.Drawing.Size(950, 578);
            this.tabControl_base.TabIndex = 4;
            // 
            // tabPage_sys
            // 
            this.tabPage_sys.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_sys.Controls.Add(this.button_cleardatadis);
            this.tabPage_sys.Controls.Add(this.textBox_clientlst);
            this.tabPage_sys.Controls.Add(this.netTCPClient1);
            this.tabPage_sys.Controls.Add(this.system_config1);
            this.tabPage_sys.Location = new System.Drawing.Point(4, 34);
            this.tabPage_sys.Name = "tabPage_sys";
            this.tabPage_sys.Size = new System.Drawing.Size(942, 540);
            this.tabPage_sys.TabIndex = 2;
            this.tabPage_sys.Text = "采集器系统配置";
            // 
            // button_cleardatadis
            // 
            this.button_cleardatadis.Location = new System.Drawing.Point(659, 41);
            this.button_cleardatadis.Name = "button_cleardatadis";
            this.button_cleardatadis.Size = new System.Drawing.Size(114, 27);
            this.button_cleardatadis.TabIndex = 5;
            this.button_cleardatadis.Text = "清空显示";
            this.button_cleardatadis.UseVisualStyleBackColor = true;
            this.button_cleardatadis.Click += new System.EventHandler(this.button_cleardatadis_Click);
            // 
            // textBox_clientlst
            // 
            this.textBox_clientlst.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_clientlst.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_clientlst.Location = new System.Drawing.Point(659, 74);
            this.textBox_clientlst.Multiline = true;
            this.textBox_clientlst.Name = "textBox_clientlst";
            this.textBox_clientlst.ReadOnly = true;
            this.textBox_clientlst.Size = new System.Drawing.Size(272, 447);
            this.textBox_clientlst.TabIndex = 4;
            this.textBox_clientlst.TextChanged += new System.EventHandler(this.textBox_clientlst_TextChanged);
            // 
            // tabPage_General
            // 
            this.tabPage_General.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_General.Controls.Add(this.general_Config1);
            this.tabPage_General.Location = new System.Drawing.Point(4, 34);
            this.tabPage_General.Name = "tabPage_General";
            this.tabPage_General.Size = new System.Drawing.Size(942, 540);
            this.tabPage_General.TabIndex = 4;
            this.tabPage_General.Text = "采集器通用信息配置";
            // 
            // tabPage_datadis
            // 
            this.tabPage_datadis.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_datadis.Controls.Add(this.datadisplay1);
            this.tabPage_datadis.Location = new System.Drawing.Point(4, 34);
            this.tabPage_datadis.Name = "tabPage_datadis";
            this.tabPage_datadis.Size = new System.Drawing.Size(942, 540);
            this.tabPage_datadis.TabIndex = 3;
            this.tabPage_datadis.Text = "数据采集显示";
            // 
            // button_readconfig
            // 
            this.button_readconfig.Enabled = false;
            this.button_readconfig.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_readconfig.Location = new System.Drawing.Point(110, 0);
            this.button_readconfig.Name = "button_readconfig";
            this.button_readconfig.Size = new System.Drawing.Size(100, 47);
            this.button_readconfig.TabIndex = 9;
            this.button_readconfig.Text = "读取配置";
            this.button_readconfig.UseVisualStyleBackColor = true;
            this.button_readconfig.Click += new System.EventHandler(this.button_readconfig_Click);
            // 
            // button_saveconfig
            // 
            this.button_saveconfig.Enabled = false;
            this.button_saveconfig.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_saveconfig.Location = new System.Drawing.Point(216, 0);
            this.button_saveconfig.Name = "button_saveconfig";
            this.button_saveconfig.Size = new System.Drawing.Size(100, 47);
            this.button_saveconfig.TabIndex = 10;
            this.button_saveconfig.Text = "保存配置";
            this.button_saveconfig.UseVisualStyleBackColor = true;
            this.button_saveconfig.Click += new System.EventHandler(this.button_saveconfig_Click);
            // 
            // button_localsave
            // 
            this.button_localsave.Enabled = false;
            this.button_localsave.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_localsave.Location = new System.Drawing.Point(322, 0);
            this.button_localsave.Name = "button_localsave";
            this.button_localsave.Size = new System.Drawing.Size(100, 47);
            this.button_localsave.TabIndex = 11;
            this.button_localsave.Text = "本地保存";
            this.button_localsave.UseVisualStyleBackColor = true;
            this.button_localsave.Click += new System.EventHandler(this.button_localsave_Click);
            // 
            // button_localread
            // 
            this.button_localread.Enabled = false;
            this.button_localread.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_localread.Location = new System.Drawing.Point(428, 0);
            this.button_localread.Name = "button_localread";
            this.button_localread.Size = new System.Drawing.Size(100, 47);
            this.button_localread.TabIndex = 12;
            this.button_localread.Text = "本地读取";
            this.button_localread.UseVisualStyleBackColor = true;
            this.button_localread.Click += new System.EventHandler(this.button_localread_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // netTCPClient1
            // 
            this.netTCPClient1.Location = new System.Drawing.Point(589, 511);
            this.netTCPClient1.Name = "netTCPClient1";
            this.netTCPClient1.Size = new System.Drawing.Size(260, 10);
            this.netTCPClient1.TabIndex = 3;
            this.netTCPClient1.DataReceived += new DataCollect.Lib.CollectEvent.DataReceivedHandler(this.netTCPClient1_DataReceived);
            // 
            // system_config1
            // 
            this.system_config1.Location = new System.Drawing.Point(0, 4);
            this.system_config1.Name = "system_config1";
            this.system_config1.Size = new System.Drawing.Size(939, 521);
            this.system_config1.TabIndex = 2;
            this.system_config1.dlan += new DataCollect.Lib.CollectEvent.DownLAN(this.system_config1_dlan);
            this.system_config1.dport += new DataCollect.Lib.CollectEvent.DownPort(this.system_config1_dport);
            this.system_config1.dser += new DataCollect.Lib.CollectEvent.Downserver(this.system_config1_dser);
            this.system_config1.Load += new System.EventHandler(this.system_config1_Load);
            // 
            // general_Config1
            // 
            this.general_Config1.BackColor = System.Drawing.SystemColors.Control;
            this.general_Config1.Location = new System.Drawing.Point(0, 0);
            this.general_Config1.Name = "general_Config1";
            this.general_Config1.Size = new System.Drawing.Size(935, 521);
            this.general_Config1.TabIndex = 0;
            this.general_Config1.collp += new DataCollect.Lib.CollectEvent.Downcollpoint(this.general_Config1_collp);
            this.general_Config1.collg += new DataCollect.Lib.CollectEvent.Downcollgen(this.general_Config1_collg);
            this.general_Config1.check += new DataCollect.Lib.CollectEvent.Checkgm(this.general_Config1_check);
            this.general_Config1.Load += new System.EventHandler(this.general_Config1_Load);
            // 
            // datadisplay1
            // 
            this.datadisplay1.Location = new System.Drawing.Point(0, 0);
            this.datadisplay1.Name = "datadisplay1";
            this.datadisplay1.Size = new System.Drawing.Size(936, 521);
            this.datadisplay1.TabIndex = 0;
            this.datadisplay1.query += new DataCollect.Lib.CollectEvent.Send_query(this.datadisplay1_query);
            this.datadisplay1.period += new DataCollect.Lib.CollectEvent.Period(this.datadisplay1_period);
            this.datadisplay1.history += new DataCollect.Lib.CollectEvent.History(this.datadisplay1_history);
            this.datadisplay1.Load += new System.EventHandler(this.datadisplay1_Load);
            // 
            // devTCPServer
            // 
            this.devTCPServer.Location = new System.Drawing.Point(6, 20);
            this.devTCPServer.Name = "devTCPServer";
            this.devTCPServer.Size = new System.Drawing.Size(236, 117);
            this.devTCPServer.TabIndex = 1;
            this.devTCPServer.DataReceived += new DataCollect.Lib.CollectEvent.DataReceivedHandler(this.devTCPServer_DataReceived);
            this.devTCPServer.Load += new System.EventHandler(this.devTCPServer_Load);
            // 
            // tabDataReceiver
            // 
            this.tabDataReceiver.Location = new System.Drawing.Point(6, 221);
            this.tabDataReceiver.Name = "tabDataReceiver";
            this.tabDataReceiver.Size = new System.Drawing.Size(925, 300);
            this.tabDataReceiver.TabIndex = 2;
            this.tabDataReceiver.Load += new System.EventHandler(this.tabDataReceiver_Load);
            // 
            // dataSender
            // 
            this.dataSender.Location = new System.Drawing.Point(260, 57);
            this.dataSender.Name = "dataSender";
            this.dataSender.Size = new System.Drawing.Size(671, 158);
            this.dataSender.TabIndex = 3;
            this.dataSender.EventDataSend += new DataCollect.Lib.CollectEvent.DataSendHandler(this.DataSender_EventDataSend);
            this.dataSender.Load += new System.EventHandler(this.dataSender_Load);
            // 
            // BasePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_server);
            this.Controls.Add(this.button_localread);
            this.Controls.Add(this.button_localsave);
            this.Controls.Add(this.button_saveconfig);
            this.Controls.Add(this.button_readconfig);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_EXIT);
            this.Controls.Add(this.button_begin);
            this.Controls.Add(this.tabControl_base);
            this.Name = "BasePanel";
            this.Size = new System.Drawing.Size(950, 614);
            this.Load += new System.EventHandler(this.DevConfigPanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage_devdebug.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox_portselect.ResumeLayout(false);
            this.tabControl_base.ResumeLayout(false);
            this.tabPage_sys.ResumeLayout(false);
            this.tabPage_sys.PerformLayout();
            this.tabPage_General.ResumeLayout(false);
            this.tabPage_datadis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // private Panel.DataDisPanel dispanel = new DataDisPanel();
        private System.Windows.Forms.Button button_begin;
        private System.Windows.Forms.Button button_EXIT;
        private System.Windows.Forms.Button button_led_config;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelconfig;
        private System.Windows.Forms.TabPage tabPage_devdebug;
        private System.Windows.Forms.GroupBox groupBox_portselect;
        public Units.NetTCPServer devTCPServer;
        private Units.TabDataReceive tabDataReceiver;
        private Units.DataSend dataSender;
        private System.Windows.Forms.TabControl tabControl_base;
        private System.Windows.Forms.TabPage tabPage_sys;
        private System.Windows.Forms.Button button_readconfig;
        private System.Windows.Forms.Button button_saveconfig;
        private System.Windows.Forms.Button button_localsave;
        private System.Windows.Forms.Button button_localread;
        private System.Windows.Forms.TabPage tabPage_datadis;
        private Datadisplay datadisplay1;
        private System_Config system_config1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage_General;
        private General_Config general_Config1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_led_comm;
        private System.Windows.Forms.Button button_led_data;
        private System.Windows.Forms.Label label2;
        private Units.NetTCPClient netTCPClient1;
        private System.Windows.Forms.Button button_server;
        private System.Windows.Forms.TextBox textBox_clientlst;
        private System.Windows.Forms.Button button_cleardatadis;
        private System.Windows.Forms.ComboBox comboBox_commselect;
        private System.Windows.Forms.Button button_debug;
        private System.Windows.Forms.GroupBox groupBox1;
       
     

    }
}

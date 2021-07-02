namespace DataCollect.Panel
{
    partial class Datadisplay
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
            this.button_dispose = new System.Windows.Forms.Button();
            this.button_historycheck = new System.Windows.Forms.Button();
            this.button_disdata = new System.Windows.Forms.Button();
            this.listView_history = new System.Windows.Forms.ListView();
            this.columnHeader_serial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_tablen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_datatype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_energy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_tablestate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_paravalue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_note = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_collecttime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_beatcount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_beatNO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_xml = new System.Windows.Forms.TextBox();
            this.textBox_heartb = new System.Windows.Forms.TextBox();
            this.button_autocheck = new System.Windows.Forms.Button();
            this.label_check = new System.Windows.Forms.Label();
            this.Updown_checktime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button_setcollect = new System.Windows.Forms.Button();
            this.numericUpDown_period = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_clearall = new System.Windows.Forms.Button();
            this.dateTimePicker_historystart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_timestart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_hisotoryend = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_timeend = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.Updown_checktime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_period)).BeginInit();
            this.SuspendLayout();
            // 
            // button_dispose
            // 
            this.button_dispose.Location = new System.Drawing.Point(384, 30);
            this.button_dispose.Name = "button_dispose";
            this.button_dispose.Size = new System.Drawing.Size(91, 27);
            this.button_dispose.TabIndex = 18;
            this.button_dispose.Text = "取消当前传输";
            this.button_dispose.UseVisualStyleBackColor = true;
            // 
            // button_historycheck
            // 
            this.button_historycheck.Location = new System.Drawing.Point(384, 1);
            this.button_historycheck.Name = "button_historycheck";
            this.button_historycheck.Size = new System.Drawing.Size(91, 26);
            this.button_historycheck.TabIndex = 17;
            this.button_historycheck.Text = "历史记录查询";
            this.button_historycheck.UseVisualStyleBackColor = true;
            this.button_historycheck.Click += new System.EventHandler(this.button_historycheck_Click);
            // 
            // button_disdata
            // 
            this.button_disdata.Location = new System.Drawing.Point(528, 0);
            this.button_disdata.Name = "button_disdata";
            this.button_disdata.Size = new System.Drawing.Size(91, 28);
            this.button_disdata.TabIndex = 12;
            this.button_disdata.Text = "查询采集";
            this.button_disdata.UseVisualStyleBackColor = true;
            this.button_disdata.Click += new System.EventHandler(this.button_disdata_Click_1);
            // 
            // listView_history
            // 
            this.listView_history.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_serial,
            this.columnHeader_tablen,
            this.columnHeader_datatype,
            this.columnHeader_energy,
            this.columnHeader_tablestate,
            this.columnHeader_paravalue,
            this.columnHeader_note,
            this.columnHeader_collecttime,
            this.columnHeader_beatcount,
            this.columnHeader_beatNO});
            this.listView_history.GridLines = true;
            this.listView_history.Location = new System.Drawing.Point(0, 61);
            this.listView_history.Name = "listView_history";
            this.listView_history.Size = new System.Drawing.Size(522, 453);
            this.listView_history.TabIndex = 11;
            this.listView_history.UseCompatibleStateImageBehavior = false;
            this.listView_history.View = System.Windows.Forms.View.Details;
            this.listView_history.VirtualListSize = 1;
            // 
            // columnHeader_serial
            // 
            this.columnHeader_serial.Text = "序号";
            this.columnHeader_serial.Width = 40;
            // 
            // columnHeader_tablen
            // 
            this.columnHeader_tablen.Text = "表号";
            this.columnHeader_tablen.Width = 102;
            // 
            // columnHeader_datatype
            // 
            this.columnHeader_datatype.Text = "参数类型";
            // 
            // columnHeader_energy
            // 
            this.columnHeader_energy.Text = "能耗编码";
            this.columnHeader_energy.Width = 61;
            // 
            // columnHeader_tablestate
            // 
            this.columnHeader_tablestate.Text = "表状态";
            this.columnHeader_tablestate.Width = 50;
            // 
            // columnHeader_paravalue
            // 
            this.columnHeader_paravalue.Text = "参数值";
            this.columnHeader_paravalue.Width = 50;
            // 
            // columnHeader_note
            // 
            this.columnHeader_note.Text = "注释";
            this.columnHeader_note.Width = 40;
            // 
            // columnHeader_collecttime
            // 
            this.columnHeader_collecttime.Text = "采集时间";
            this.columnHeader_collecttime.Width = 150;
            // 
            // columnHeader_beatcount
            // 
            this.columnHeader_beatcount.Text = "包数";
            this.columnHeader_beatcount.Width = 40;
            // 
            // columnHeader_beatNO
            // 
            this.columnHeader_beatNO.Text = "包号";
            this.columnHeader_beatNO.Width = 40;
            // 
            // textBox_xml
            // 
            this.textBox_xml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_xml.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_xml.Location = new System.Drawing.Point(528, 63);
            this.textBox_xml.Multiline = true;
            this.textBox_xml.Name = "textBox_xml";
            this.textBox_xml.ReadOnly = true;
            this.textBox_xml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_xml.Size = new System.Drawing.Size(414, 283);
            this.textBox_xml.TabIndex = 10;
            this.textBox_xml.TextChanged += new System.EventHandler(this.textBox_xml_TextChanged_1);
            // 
            // textBox_heartb
            // 
            this.textBox_heartb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_heartb.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_heartb.Location = new System.Drawing.Point(528, 374);
            this.textBox_heartb.Multiline = true;
            this.textBox_heartb.Name = "textBox_heartb";
            this.textBox_heartb.ReadOnly = true;
            this.textBox_heartb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_heartb.Size = new System.Drawing.Size(414, 142);
            this.textBox_heartb.TabIndex = 19;
            this.textBox_heartb.TextChanged += new System.EventHandler(this.textBox_heartb_TextChanged);
            // 
            // button_autocheck
            // 
            this.button_autocheck.Location = new System.Drawing.Point(528, 30);
            this.button_autocheck.Name = "button_autocheck";
            this.button_autocheck.Size = new System.Drawing.Size(91, 27);
            this.button_autocheck.TabIndex = 20;
            this.button_autocheck.Text = "自动查询";
            this.button_autocheck.UseVisualStyleBackColor = true;
            this.button_autocheck.Click += new System.EventHandler(this.button_autocheck_Click);
            // 
            // label_check
            // 
            this.label_check.AutoSize = true;
            this.label_check.Location = new System.Drawing.Point(625, 37);
            this.label_check.Name = "label_check";
            this.label_check.Size = new System.Drawing.Size(29, 12);
            this.label_check.TabIndex = 21;
            this.label_check.Text = "周期";
            // 
            // Updown_checktime
            // 
            this.Updown_checktime.Location = new System.Drawing.Point(660, 34);
            this.Updown_checktime.Name = "Updown_checktime";
            this.Updown_checktime.Size = new System.Drawing.Size(49, 21);
            this.Updown_checktime.TabIndex = 22;
            this.Updown_checktime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Updown_checktime.ValueChanged += new System.EventHandler(this.Updown_checktime_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(715, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "s";
            // 
            // button_setcollect
            // 
            this.button_setcollect.Location = new System.Drawing.Point(827, 3);
            this.button_setcollect.Name = "button_setcollect";
            this.button_setcollect.Size = new System.Drawing.Size(90, 29);
            this.button_setcollect.TabIndex = 24;
            this.button_setcollect.Text = "设置采集间隔";
            this.button_setcollect.UseVisualStyleBackColor = true;
            this.button_setcollect.Click += new System.EventHandler(this.button_setcollect_Click);
            // 
            // numericUpDown_period
            // 
            this.numericUpDown_period.Location = new System.Drawing.Point(834, 34);
            this.numericUpDown_period.Name = "numericUpDown_period";
            this.numericUpDown_period.Size = new System.Drawing.Size(66, 21);
            this.numericUpDown_period.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(906, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "s";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "开始";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "结束";
            // 
            // button_clearall
            // 
            this.button_clearall.Location = new System.Drawing.Point(528, 352);
            this.button_clearall.Name = "button_clearall";
            this.button_clearall.Size = new System.Drawing.Size(91, 25);
            this.button_clearall.TabIndex = 29;
            this.button_clearall.Text = "清空显示";
            this.button_clearall.UseVisualStyleBackColor = true;
            this.button_clearall.Click += new System.EventHandler(this.button_clearall_Click);
            // 
            // dateTimePicker_historystart
            // 
            this.dateTimePicker_historystart.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker_historystart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_historystart.Location = new System.Drawing.Point(75, 6);
            this.dateTimePicker_historystart.Name = "dateTimePicker_historystart";
            this.dateTimePicker_historystart.Size = new System.Drawing.Size(120, 21);
            this.dateTimePicker_historystart.TabIndex = 30;
            // 
            // dateTimePicker_timestart
            // 
            this.dateTimePicker_timestart.Checked = false;
            this.dateTimePicker_timestart.CustomFormat = "HH:mm:ss";
            this.dateTimePicker_timestart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_timestart.Location = new System.Drawing.Point(75, 34);
            this.dateTimePicker_timestart.Name = "dateTimePicker_timestart";
            this.dateTimePicker_timestart.ShowUpDown = true;
            this.dateTimePicker_timestart.Size = new System.Drawing.Size(120, 21);
            this.dateTimePicker_timestart.TabIndex = 31;
            // 
            // dateTimePicker_hisotoryend
            // 
            this.dateTimePicker_hisotoryend.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker_hisotoryend.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_hisotoryend.Location = new System.Drawing.Point(258, 3);
            this.dateTimePicker_hisotoryend.Name = "dateTimePicker_hisotoryend";
            this.dateTimePicker_hisotoryend.Size = new System.Drawing.Size(120, 21);
            this.dateTimePicker_hisotoryend.TabIndex = 32;
            // 
            // dateTimePicker_timeend
            // 
            this.dateTimePicker_timeend.CustomFormat = "HH:mm:ss";
            this.dateTimePicker_timeend.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_timeend.Location = new System.Drawing.Point(258, 34);
            this.dateTimePicker_timeend.Name = "dateTimePicker_timeend";
            this.dateTimePicker_timeend.ShowUpDown = true;
            this.dateTimePicker_timeend.Size = new System.Drawing.Size(120, 21);
            this.dateTimePicker_timeend.TabIndex = 33;
            // 
            // Datadisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePicker_timeend);
            this.Controls.Add(this.dateTimePicker_hisotoryend);
            this.Controls.Add(this.dateTimePicker_timestart);
            this.Controls.Add(this.dateTimePicker_historystart);
            this.Controls.Add(this.button_clearall);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_period);
            this.Controls.Add(this.button_setcollect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Updown_checktime);
            this.Controls.Add(this.label_check);
            this.Controls.Add(this.button_autocheck);
            this.Controls.Add(this.textBox_heartb);
            this.Controls.Add(this.button_dispose);
            this.Controls.Add(this.button_historycheck);
            this.Controls.Add(this.button_disdata);
            this.Controls.Add(this.listView_history);
            this.Controls.Add(this.textBox_xml);
            this.Name = "Datadisplay";
            this.Size = new System.Drawing.Size(945, 521);
            this.Load += new System.EventHandler(this.Datadisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Updown_checktime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_period)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_dispose;
        private System.Windows.Forms.Button button_historycheck;
        private System.Windows.Forms.ListView listView_history;
        private System.Windows.Forms.ColumnHeader columnHeader_serial;
        private System.Windows.Forms.ColumnHeader columnHeader_tablen;
        private System.Windows.Forms.ColumnHeader columnHeader_datatype;
        private System.Windows.Forms.ColumnHeader columnHeader_energy;
        private System.Windows.Forms.ColumnHeader columnHeader_tablestate;
        private System.Windows.Forms.ColumnHeader columnHeader_paravalue;
        private System.Windows.Forms.TextBox textBox_xml;
        public System.Windows.Forms.TextBox textBox_heartb;
        private System.Windows.Forms.Button button_autocheck;
        private System.Windows.Forms.Label label_check;
        private System.Windows.Forms.NumericUpDown Updown_checktime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_setcollect;
        private System.Windows.Forms.NumericUpDown numericUpDown_period;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_clearall;
        private System.Windows.Forms.ColumnHeader columnHeader_note;
        private System.Windows.Forms.ColumnHeader columnHeader_collecttime;
        private System.Windows.Forms.ColumnHeader columnHeader_beatcount;
        private System.Windows.Forms.ColumnHeader columnHeader_beatNO;
        private System.Windows.Forms.DateTimePicker dateTimePicker_historystart;
        private System.Windows.Forms.DateTimePicker dateTimePicker_hisotoryend;
        private System.Windows.Forms.DateTimePicker dateTimePicker_timeend;
        public System.Windows.Forms.Button button_disdata;
        private System.Windows.Forms.DateTimePicker dateTimePicker_timestart;
       // private BasePanel basepanel;

    }
}

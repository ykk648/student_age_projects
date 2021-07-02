namespace DataCollect
{
    partial class Form_Collect
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Collect));
            this.basePanel1 = new DataCollect.Panel.BasePanel();
            this.SuspendLayout();
            // 
            // basePanel1
            // 
            this.basePanel1.Location = new System.Drawing.Point(0, 3);
            this.basePanel1.Name = "basePanel1";
            this.basePanel1.Size = new System.Drawing.Size(946, 628);
            this.basePanel1.TabIndex = 2;
            // 
            // Form_Collect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 632);
            this.Controls.Add(this.basePanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(960, 670);
            this.MinimumSize = new System.Drawing.Size(960, 670);
            this.Name = "Form_Collect";
            this.Text = "数据采集配置工具";
            this.Load += new System.EventHandler(this.Form_Collect_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel.BasePanel basePanel1;



    }
}


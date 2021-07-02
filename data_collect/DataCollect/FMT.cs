using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCollect.Panel
{
    public partial class FMT : Form
    {
        public byte fmtf;
        public byte fmtd;
        public bool enfmt;
        public FMT()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_yes_Click(object sender, EventArgs e)
        {
            if (textBox_commaddr.Text.Length != 0 && textBox_mul.Text.Length != 0)
                enfmt = true;
            else
                enfmt = false;
            //fmtf = (byte)comboBox_FMT.SelectedIndex;
            //fmtd = (byte)comboBox_FMTB.SelectedIndex;
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

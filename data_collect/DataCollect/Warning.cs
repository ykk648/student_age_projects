using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCollect
{
    public partial class Warning : Form
    {
        public bool ok = false;
        public Warning()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            ok = true;
            this.Close();
        }

        private void button_no_Click(object sender, EventArgs e)
        {
            ok = false;
            this.Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lbCode.Text = Form1.code;
            lbName.Text = Form1.name;
            lbGroup.Text = Form1.group;
            lbDetail.Text = Form1.detailChecked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

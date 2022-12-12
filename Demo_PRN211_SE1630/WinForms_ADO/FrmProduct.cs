using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms_ADO;

namespace WinForms_ADO
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }
        public FrmProduct(string text)
        {
            InitializeComponent();
            Text = "Hello " + text;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        DataProvider d = new DataProvider();
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            try
            {
                string strSelect = "SELECT * FROM [dbo].[Products] ";
                DataTable dt = d.executeQuery(strSelect);
                dgvProduct.DataSource = dt;
                //cbCID.DataSource = dt;
                //cbCID.DisplayMember = "CustomerID";
                //cbCID.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error:" + ex.Message);
            }
        }

        private void FrmProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtProductName.Text = "";
            txtUnitPrice.Text = "";
            txtUnitInStock.Text = "";
            cbbCID.Text = dgvProduct.Rows[0].Cells[5].Value.ToString();
            cbbPID.Text = dgvProduct.Rows[0].Cells[0].Value.ToString();
            cbDiscontinued.Checked = false;
        }
    }
}

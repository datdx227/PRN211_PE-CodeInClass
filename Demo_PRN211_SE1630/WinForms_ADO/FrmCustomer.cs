using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms_ADO;

namespace WinForms_ADO
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        public FrmCustomer(string text)
        { 
            InitializeComponent();
            Text = "Hello " + text;
        }

        DataProvider d = new DataProvider();
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ShowData()
        {
            dgvCustomer.DataSource = d.executeQuery("SELECT * FROM [dbo].[Customers] ");
            cbCID.DataSource = d.executeQuery("SELECT [CustomerId] FROM [dbo].[Customers] ");
            cbCID.DisplayMember = "CustomerID";
            cbCID.ValueMember = "CustomerID";
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            //ShowData();
            try
            {
                string strSelect = "SELECT * FROM [dbo].[Customers] ";
                DataTable dt = d.executeQuery(strSelect);
                dgvCustomer.DataSource = dt;
                cbCID.DataSource = dt;
                cbCID.DisplayMember = "CustomerID";
                cbCID.ValueMember = "CustomerID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtBirth.Text = "";
            txtCName.Text = "";
            cbCID.Text = dgvCustomer.Rows[0].Cells[0].FormattedValue.ToString();
            rbMale.Checked = true;
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbCID.Text = dgvCustomer.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            txtBirth.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            string gender = dgvCustomer.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            if (gender.Equals("True"))
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }
            txtAddress.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            //MessageBox.Show(cbCID.Text);
            //int gender1 = 1;
            //if (rbFemale.Checked)
            //{
            //    gender1 = 0;
            //}
           // MessageBox.Show(txtBirth.Text);
        }

        private void FrmCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string strDelete = "DELETE FROM [dbo].[Customers]"+
                    "WHERE customerid = '" +cbCID.Text + "'";
                if (d.executeNonQuery(strDelete))
                {
                    MessageBox.Show("Delete success");
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool gender = true;
                if (rbFemale.Checked)
                {
                    gender = false;
                }
                string strUpdate = "UPDATE [dbo].[Customers] SET CustomerName = N'" +
                    txtCName.Text +"', Birthdate = '" + txtBirth.Text +"', Gender = '" + gender + "', Address = N'" + txtAddress.Text + "' WHERE CustomerId = '"+cbCID.Text + "'";
                if (d.executeNonQuery(strUpdate))
                {
                    MessageBox.Show("Update success");
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strInsert = "INSERT INTO [dbo].[Customers]" +
                    "([CustomerName], [Birthdate], [Gender], [Address])" +
                    "VALUES (@name,@dob,@gender,@address)";
                bool gender = true;
                if (rbFemale.Checked)
                {
                    gender = false;
                }
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@name", txtCName.Text),
                    new SqlParameter("@dob", txtBirth.Text),
                    new SqlParameter("@gender", gender),
                    new SqlParameter("@address", txtAddress.Text),
                };
                if (d.executeNonQuery(strInsert, param))
                {
                    MessageBox.Show("Add success");
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message);
            }
        }
    }
}

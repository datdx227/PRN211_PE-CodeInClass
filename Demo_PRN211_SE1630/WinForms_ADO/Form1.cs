using System.Data;
using System.Data.SqlClient;
using WinForms_ADO;

namespace WinForms_ADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Tao doi tuong DataProvider
        DataProvider d = new DataProvider();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string strSelect = "select * from Users " +
            //        "where account = '" + txtUsername.Text+"' and " +
            //        "password='" + txtPassword.Text + "'";
            //    DataTable dt = d.executeQuery(strSelect);
            //    if(dt.Rows.Count > 0)
            //    {
            //        //MessageBox.Show("Login success");
            //        FrmCustomer f = new FrmCustomer(txtUsername.Text);
            //        //FrmProduct f = new FrmProduct(txtUsername.Text);
            //        f.Show();
            //        this.Hide();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Login fail");
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Login error:" + ex.Message);
            //}

            //Cách 2:
            try
            {
                string strSelect = "select * from Users " +
                "where account = @acc and password= @pass";
                SqlParameter[] param = new SqlParameter[]
                    {
                    new SqlParameter("@acc", txtUsername.Text),
                    new SqlParameter("@pass", txtPassword.Text)
                    };
                IDataReader dr = d.executeQuery2(strSelect, param);
                if (dr.Read())
                {
                    MessageBox.Show("Login success");
                    FrmCustomer f = new FrmCustomer(txtUsername.Text);
                    //FrmProduct f = new FrmProduct(txtUsername.Text);
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login fail");
                }
                dr.Close();
            }
            catch (Exception)
            {

                throw;
            }

            
        }

            private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
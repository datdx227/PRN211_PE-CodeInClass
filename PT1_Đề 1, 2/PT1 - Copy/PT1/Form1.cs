using System.Data.SqlClient;
using System.Xml.Linq;
using WinForm_ADO;

namespace PT1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataProvider d = new DataProvider();
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            cbbGroup.DataSource = d.executeQuery("SELECT * FROM [dbo].[MaterialGroups] ORDER BY GroupName");
            cbbGroup.DisplayMember = "MaterialGroups";
            cbbGroup.ValueMember = "GroupName";
        }
        public static string code = "";
        public static string name = "";
        public static string group = "";
        public static string detailChecked = "";
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text == "")
                {
                    MessageBox.Show("Please enter Material Type Code");
                    return;
                }
                if (txtName.Text == "")
                {
                    MessageBox.Show("Please enter Material Type Name");
                    return;
                }
                if (txtCode.Text != "" || txtName.Text != "")
                {   
                    int ischecked = 0;
                    if (check1.Checked)
                    {
                        ischecked = 1;
                    }
                    string strInsert = "INSERT INTO [dbo].[MaterialTypes]" +
                    "([MaterialTypeCode], [MaterialTypeName], [MaterialGroupID], [IsDetail])" +
                    "SELECT '"+ txtCode.Text+"',N'"+ txtName.Text+"',[MaterialGroupID],"+ ischecked + " FROM MaterialGroups Where GroupName = '"+ cbbGroup.Text + "'";
                   
                    if (d.executeNonQuery(strInsert))
                    {
                        //MessageBox.Show("Add success");
                        //ShowData();
                        code = "Material Type Code: " + txtCode.Text;
                        name = "Material Type Name: " + txtName.Text;
                        group = "Material Type Group: " + cbbGroup.Text;
                        if (check1.Checked)
                        {
                            detailChecked = "Is Detail";
                        }
                        else
                        {
                            detailChecked = "Is not Detail";
                        }
                        Form2 frm = new Form2();
                        frm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message);
            }
        }
    }
}
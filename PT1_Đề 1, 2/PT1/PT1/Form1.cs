using PT1.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace PT1
{
    
    public partial class Form1 : Form
    {   
        PT11Context context = new PT11Context();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            try
            {
                var data = context.AssetTypeGroups
                    .OrderBy(s => s.GroupName)
                    .ToList();
                cbbGroup.DataSource = data;
                cbbGroup.DisplayMember = "GroupName";
                cbbGroup.ValueMember = "AssetTypeGroupID";

                cbbGroup.DataBindings.Clear();
                cbbGroup.DataBindings.Add("Text", data, "GroupName");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }
        public static string code = "";
        public static string name = "";
        public static string group = "";
        public static string ischecked = "";
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text == "")
                {
                    MessageBox.Show("Please enter Asset Type Code");
                    return;
                }
                if (txtName.Text == "")
                {
                    MessageBox.Show("Please enter Asset Type Name");
                    return;
                }
                if(txtCode.Text != "" || txtName.Text != "")
                {
                    AssetTypeGroup a = context.AssetTypeGroups.FirstOrDefault(s => s.GroupName == cbbGroup.Text);
                    var id = a.AssetTypeGroupId;
                    AssetType assetType = new AssetType {
                        AssetTypeCode = txtCode.Text,
                        AssetTypeName = txtName.Text,
                        AssetTypeGroupId = id,
                        IsDetail = check1.Checked
                    };
                    //Add vao DB
                    context.AssetTypes.Add(assetType);
                    if (context.SaveChanges() > 0)
                    {
                        code = txtCode.Text;
                        name = txtName.Text;
                        group = cbbGroup.Text;
                        if (check1.Checked)
                        {
                            ischecked = "Is Detail";
                        }
                        else
                        {
                            ischecked = "Is not Detail";
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
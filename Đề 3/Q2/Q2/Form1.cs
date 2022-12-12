using Q2.Models;

namespace Q2
{
    public partial class Form1 : Form
    {
        PE_Spr22B5Context context = new PE_Spr22B5Context();
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
                var data = context.Employees
                    .Select(item => new
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Sex = item.Sex,
                        DoB = item.Dob,
                        Position = item.Position,

                    })
                    .ToList();
                dgvEmployee.DataSource = data;
                var data2 = context.Employees
                    .Select(m => new { m.Position})
                    .Distinct()
                    .ToList();
                cbPosition.DataSource = data2;
                cbPosition.DisplayMember = "Position";

                txtID.DataBindings.Clear();
                txtID.DataBindings.Add("Text", data, "Id");

                txtName.DataBindings.Clear();
                txtName.DataBindings.Add("Text", data, "Name");

                

                dateTimePicker1.DataBindings.Clear();
                dateTimePicker1.DataBindings.Add("Text", data, "DoB");

                cbPosition.DataBindings.Clear();
                cbPosition.DataBindings.Add("Text", data2, "Position");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string gender = dgvEmployee.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            if (gender.Equals("True"))
            {
                rdMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            dateTimePicker1.DataBindings.Clear();
            cbPosition.DataSource = new[]
            {
                "Developer",
            "Leader",
            "Manager",
            "Tester"};
            rdFemale.Checked = false;
            rdMale.Checked = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = "";
                if(rdFemale.Checked == true)
                {
                    gender = "Female";
                }
                if (rdMale.Checked == true)
                {
                    gender = "Male";
                }
                //tao doi tuong de add
                Employee p = new Employee
                {
                    Name = txtName.Text,
                    Sex = gender,
                    Dob = dateTimePicker1.Value,
                    Position = cbPosition.Text
                };

                //Add vao DB
                context.Employees.Add(p);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Add success!");
                    ShowData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = "";
                if (rdFemale.Checked == true)
                {
                    gender = "Female";
                }
                if (rdMale.Checked == true)
                {
                    gender = "Male";
                }
                //Tim doi tuong de update
                Employee p = context.Employees.FirstOrDefault(x => x.Id == Int32.Parse(txtID.Text));
                if (p == null)
                {
                    MessageBox.Show("Id không tìm thấy");
                    return;
                }
                //Update vao DB
                p.Name = txtName.Text;
                p.Sex = gender;
                p.Dob = dateTimePicker1.Value;
                p.Position = cbPosition.Text;

                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Update success!");
                    ShowData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }
    }
}
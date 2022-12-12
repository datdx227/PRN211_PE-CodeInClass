using Q2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }
        PE_PRN_Sum21Context context = new PE_PRN_Sum21Context();
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            var data = context.Employees.Select(item => new
            {
                EmployeeId = item.EmployeeId,
                EmployeeName = item.EmployeeName,
                Gender = item.Male,
                Salary = item.Salary,
                Phone = item.Phone
            }).ToList();
            dgvEmployee.DataSource = data;
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add("Text", data, "EmployeeName");

            numericUpDown1.DataBindings.Clear();
            numericUpDown1.DataBindings.Add("Text", data, "Salary");

            txtPhone.DataBindings.Clear();
            txtPhone.DataBindings.Add("Text", data, "Phone");
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvEmployee.Rows[e.RowIndex].Cells[2].FormattedValue.ToString().Equals("True"))
                {
                    rdMale.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show ("Click cell below!", ex.Message);
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool gender = true;
                if (radioButton1.Checked)
                {
                    gender = false;
                }
                //Tạo đối tượng sẽ add
                Employee p = new Employee
                {
                    EmployeeName = txtName.Text,
                    Male = gender,
                    Salary = (float)numericUpDown1.Value,
                    Phone = txtPhone.Text
                };

                //Add nó và context và save
                context.Employees.Add(p);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Add successs");
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error:" + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool gender = true;
                if (radioButton1.Checked)
                {
                    gender = false;
                }
                Employee p = context.Employees
                    .FirstOrDefault(item => item.EmployeeName == txtName.Text);

                    p.EmployeeName = txtName.Text;
                    p.Male = gender;
                    p.Salary = (float)numericUpDown1.Value;
                    p.Phone = txtPhone.Text;


                
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Update success!");
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error:" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Tìm đối tượng sẽ delete
                Employee p = context.Employees
                    .SingleOrDefault(item => item.EmployeeName == txtName.Text);
                if (p != null)
                {
                    context.Employees.Remove(p);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Delete successs");
                        ShowData();
                    }
                }
                else
                {
                    MessageBox.Show("Delete fail");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error:" + ex.Message);
            }
        }
    }
}

using System.Collections.Generic;

namespace DemoForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Đây là nơi sẽ viết code để xử lý việc sẽ xảy ra 
            //khi nhấn nút RESET
            txtCode.Text = "";
            txtName.Text = "";
            cboSubject.Text = "";
            numMark.Value = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to exit?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }


        }
        List<Student> data = new List<Student>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            string name = txtName.Text;
            string subject = cboSubject.SelectedItem.ToString();
            int mark = (int)numMark.Value;
            Student student = new Student(code, name, subject, mark);
            data.Add(student);
            lstStudent.Items.Add(student);
        }
        //private void checkCode()
        //{
        //    string code = txtCode.Text;
        //    foreach (var item in data)
        //    {
        //        if(code == data.)
        //    }
        //}

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Student item = (Student)lstStudent.SelectedItem;
            data.Remove(item);
            lstStudent.Items.Remove(item);
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtCode.BackColor = Color.Pink;
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtName.BackColor = Color.Pink;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtName.BackColor = Color.White;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtCode.BackColor = Color.White;
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            //Tìm xem có SV nào có mã bằng txtCode hay không?
            Student sv = findSV(txtCode.Text);
            if(sv != null)
            {
                txtName.Text = sv.Name;
                cboSubject.Text = sv.Subject;
                numMark.Value = sv.Mark;
            }
            else
            {
                txtName.Text = "";
                cboSubject.Text = "";
                numMark.Value = 0;
            }
        }

        private Student findSV(string text)
        {
            foreach(Student item in data)
            {
                if (item.Code.Equals(text))
                {
                    return item;
                }
            }
            return null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = @"..\\..\\..\\data.txt";
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    foreach (Student item in data)
                        sw.WriteLine(item);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Save error:" + ex.Message);
            }
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = @"..\\..\\..\\data.txt";
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] s = line.Split("\t");
                        string code = s[0];
                        string name = s[1];
                        string subject = s[2];
                        int mark = Convert.ToInt32(s[3]);
                        Student student = new Student(code, name, subject, mark);
                        if (findSV(code) == null)
                        {
                            data.Add(student);
                        }
                        lstStudent.Items.Add(student);
                        line = sr.ReadLine();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Load error:" + ex.Message);
            }
        }
    }
}
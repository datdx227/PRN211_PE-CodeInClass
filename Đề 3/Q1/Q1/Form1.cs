namespace Q1
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
            dgvEmployee.DataSource = d.executeQuery("SELECT * FROM [dbo].[Employee] ");
            
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbPosition.Text = dgvEmployee.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            txtName.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            string gender = dgvEmployee.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            if (gender.Equals("True"))
            {
                rdMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }
        }
    }
}
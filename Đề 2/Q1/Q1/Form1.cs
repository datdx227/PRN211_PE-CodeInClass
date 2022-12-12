using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;

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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strInsert = "INSERT INTO [dbo].[Rooms]" +
                    "([Title], [Square], [Floor], [Description], [Comment])" +
                    "VALUES (N'"+ txtRoom.Text + "',"+ Convert.ToInt32(comboBox1.SelectedItem.ToString())+","+ Convert.ToInt32(numericUpDown1.Value) + ",N'"+ rtxtDesc.Text + "', N'"+ rtxtCmt.Text + "')";
                
                if (d.executeNonQuery(strInsert))
                {
                    MessageBox.Show("Add success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message);
            }
        }
    }
}
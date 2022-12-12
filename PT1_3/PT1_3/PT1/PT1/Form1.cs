using PT1.Models;

namespace PT1
{
    public partial class Form1 : Form
    {
        PT1Context context = new PT1Context();
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
            //try
            //{
            //    var data = context.Products                    
            //        .ToList();
            //    dgvProduct.DataSource = data;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Load error: " + ex.Message);
            //}
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                var data = context.Products
                    .Select(item => new
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        Price = item.UnitPrice,
                        Stock = item.UnitsInStock
                    })
                    .Where(item => item.ProductName.Contains(txtName.Text))
                    .ToList();
                dgvProduct.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.Text == "Ascending") 
                { 
                    var data = context.Products
                    .Select(item => new
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        Price = item.UnitPrice,
                        Stock = item.UnitsInStock
                    })
                    .Where(item => item.ProductName.Contains(txtName.Text))
                    .OrderBy(item => item.Price)
                    .ToList();
                    dgvProduct.DataSource = data;
                }
                if (comboBox1.Text == "Descending")
                {
                    var data = context.Products
                    .Select(item => new
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        Price = item.UnitPrice,
                        Stock = item.UnitsInStock
                    })
                    .Where(item => item.ProductName.Contains(txtName.Text))
                    .OrderByDescending(item => item.Price)
                    .ToList();
                    dgvProduct.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }
    }
}
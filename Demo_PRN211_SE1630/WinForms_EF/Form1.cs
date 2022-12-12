using WinForms_EF.Models;

namespace WinForms_EF
{
    public partial class Form1 : Form
    {
        MySaleDBContext context = new MySaleDBContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowData();
            //them cot select
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "Select";
            chk.Name = "Select";           
            dgvProduct.Columns.Add(chk);
        }

        private void ShowData()
        {
            try
            {
                var data = context.Products
                    .Select(item => new
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        UnitPrice = item.UnitPrice,
                        UnitsInStock = item.UnitsInStock,
                        CategoryName = item.Category.CategoryName,
                        Image = item.Image
                    })
                    .ToList();
                dgvProduct.DataSource = data;
                var data2 = context.Categories.ToList();
                cbbCategory.DataSource = data2;
                cbbCategory.DisplayMember = "CategoryName";
                cbbCategory.ValueMember = "CategoryId";

                txtID.DataBindings.Clear();
                txtID.DataBindings.Add("Text", data, "ProductId");

                txtName.DataBindings.Clear();
                txtName.DataBindings.Add("Text", data, "ProductName");

                txtUnitprice.DataBindings.Clear();
                txtUnitprice.DataBindings.Add("Text", data, "UnitPrice");

                txtUnitsInStock.DataBindings.Clear();
                txtUnitsInStock.DataBindings.Add("Text", data, "UnitsInStock");

                txtImage.DataBindings.Clear();
                txtImage.DataBindings.Add("Text", data, "Image");

                cbbCategory.DataBindings.Clear();
                cbbCategory.DataBindings.Add("Text", data, "CategoryName");

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //cbbID.Text = dgvProduct.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                //txtName.Text = dgvProduct.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                //txtUnitprice.Text = dgvProduct.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                //txtUnitsInStock.Text = dgvProduct.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                //txtImage.Text = dgvProduct.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                //cbbCategory.Text = dgvProduct.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Click cell in row below!!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //tao doi tuong de add
                Product p = new Product { 
                    ProductName = txtName.Text,
                    UnitPrice = decimal.Parse(txtUnitprice.Text),
                    UnitsInStock = Int32.Parse(txtUnitsInStock.Text),
                    Image = txtImage.Text
                };

                //Add vao DB
                context.Products.Add(p);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Tim doi tuong de delete
                Product p = context.Products.FirstOrDefault(x=> x.ProductId == Int32.Parse(txtID.Text));
                if(p == null)
                {
                    MessageBox.Show("Id không tìm thấy");
                    return;
                }
                //Xoas khoi  DB
                context.Products.Remove(p);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Delete success!");
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
                //Tim doi tuong de update
                Product p = context.Products.FirstOrDefault(x => x.ProductId == Int32.Parse(txtID.Text));
                if (p == null)
                {
                    MessageBox.Show("Id không tìm thấy");
                    return;
                }
                //Update vao DB
                p.ProductName = txtName.Text;
                p.UnitPrice = decimal.Parse(txtUnitprice.Text);
                p.UnitsInStock = Int32.Parse(txtUnitsInStock.Text);
                p.CategoryId = (int)cbbCategory.SelectedValue;
                p.Image = txtImage.Text;
                
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var data = context.Products
                    .Select(item => new
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        Price = item.UnitPrice,
                        Stock = item.UnitsInStock,
                        Category = item.Category.CategoryName,
                        Image = item.Image
                    }).Where(item => item.ProductName.Contains(txtName.Text))
                    .OrderBy(item => item.ProductName)
                    .ToList();
            dgvProduct.DataSource = data;
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvProduct.Columns[e.ColumnIndex].Name.Equals("Delete") && !dgvProduct.Columns[e.ColumnIndex].Name.Equals("Edit") && !dgvProduct.Columns[e.ColumnIndex].Name.Equals("Select"))
            {
                return;
            }

            try
            {
                //Tìm đối tượng để delete
                if (dgvProduct.Columns[e.ColumnIndex].Name.Equals("Delete"))
                {
                    string code = dgvProduct.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    Product p = context.Products.FirstOrDefault(item => item.ProductId == Int32.Parse(code));
                    if (p == null)
                    {
                        MessageBox.Show("ID không tìm thấy");
                        return;
                    }
                    //Xóa từ DB
                    context.Products.Remove(p);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Delete success");
                        ShowData();
                    }
                }
                if (dgvProduct.Columns[e.ColumnIndex].Name.Equals("Edit"))
                {
                    //Tim doi tuong de update
                    Product p = context.Products.FirstOrDefault(x => x.ProductId == Int32.Parse(txtID.Text));
                    if (p == null)
                    {
                        MessageBox.Show("Id không tìm thấy");
                        return;
                    }
                    //Update vao DB
                    p.ProductName = txtName.Text;
                    p.UnitPrice = decimal.Parse(txtUnitprice.Text);
                    p.UnitsInStock = Int32.Parse(txtUnitsInStock.Text);
                    p.CategoryId = (int)cbbCategory.SelectedValue;
                    p.Image = txtImage.Text;

                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Update success!");
                        ShowData();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error:" + ex.Message);
            }
        }

        private void btnDeleteChecked_Click(object sender, EventArgs e)
        {

            for(int i = 0; i< dgvProduct.Rows.Count; i++)
            {
                bool isCellChecked = (bool)dgvProduct.Rows[i].Cells[9].Value;
                if(isCellChecked == true)
                {
                    MessageBox.Show("SSSS");
                    //try
                    //{
                    //    //Tim doi tuong de delete
                    //    Product p = context.Products.FirstOrDefault(x => x.ProductId == Convert.ToInt32(dgvProduct.Rows[i].Cells[3].Value.ToString()));
                    //    if (p == null)
                    //    {
                    //        MessageBox.Show("Id không tìm thấy");
                    //        return;
                    //    }
                    //    //Xoas khoi  DB
                    //    context.Products.Remove(p);
                    //    if (context.SaveChanges() > 0)
                    //    {
                    //        MessageBox.Show("Delete success!");
                    //        ShowData();
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show("Delete error: " + ex.Message);
                    //}
                }
                else
                {
                    return;
                }
            }
        }
    }
}
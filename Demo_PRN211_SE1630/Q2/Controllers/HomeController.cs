using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Q2.Models;
using System.Data;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Q2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = getListProduct();
            ViewBag.Categories = getListCategory();

            return View(products);
        }

        private List<Product> getListProduct()
        {
            List<Product> data = new List<Product>();
            try
            {
                string strSelect = "select * from Products";
                IDataReader reader = (new DataProvider()).executeQuery2(strSelect);
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.UnitPrice = reader.GetDecimal(2);
                    product.UnitsInstock = reader.GetInt32(3);
                    product.Image = reader.GetString(4);
                    data.Add(product);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return data;
        }

        private List<Category> getListCategory()
        {
            List<Category> data = new List<Category>();

            try
            {
                string strSelect = "select * from Categories";
                IDataReader reader = (new DataProvider()).executeQuery2(strSelect);
                while (reader.Read())
                {
                    Category cate = new Category();
                    cate.CategoryId = reader.GetInt32(0);
                    cate.CategoryName = reader.GetString(1);
                    data.Add(cate);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return data;
        }

        [HttpPost]
        public IActionResult Index(int cateId)
        {
            var products = getListProduct(cateId);
            if (cateId == 0)
            {
                products = getListProduct();
            }
            ViewBag.Categories = getListCategory();
            ViewBag.selectedid = cateId;

            return View(products);

        }

        private List<Product> getListProduct(int cateId)
        {
            List<Product> data = new List<Product>();
            try
            {
                string strSelect = "select * from Products where ProductId=@id";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@id",cateId)
                 };
                IDataReader reader = (new DataProvider()).executeQuery2(strSelect, param);
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.UnitPrice = reader.GetDecimal(2);
                    product.UnitsInstock = reader.GetInt32(3);
                    product.Image = reader.GetString(4);
                    data.Add(product);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return data;
        }

        public IActionResult Delete(int id)
        {
            try
            {
                string strDelete = "delete from Products where ProductId=@id";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@id",id)
                 };
                (new DataProvider()).executeNonQuery(strDelete, param);
                return RedirectToAction("Index");
            }

            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Detail(int id)
        {
            try
            {
                string strSelect = "SELECT [ProductID],[ProductName],[UnitPrice],[UnitsInStock] ,[Image]  FROM [MySaleDB].[dbo].[Products]  where ProductId=@id";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@id",id)
                 };
                (new DataProvider()).executeNonQuery(strSelect, param);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool AddProduct(Product product)
        {
            string strInsert = "INSERT INTO [dbo].[Products]" +
                "([ProductName], [UnitPrice], [UnitsInStock], [Image],[CategoryID])" +
                "VALUES (@name,@unitprice,@unitstock,@image,@cateid)";
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@name", product.ProductName),
                    new SqlParameter("@unitprice", product.UnitPrice),
                    new SqlParameter("@unitstock", product.UnitsInstock),
                    new SqlParameter("@image", product.Image),
                    new SqlParameter("@cateid", 1)
            };
            if ((new DataProvider()).executeNonQuery(strInsert, param))
            {
                return true;
            } else
                return false;
        }
    

    [HttpPost]
    public IActionResult Add(Product product)
    {
        try
        {
            if (ModelState.IsValid)//tao model thanh cong
            {
                if (AddProduct(product))
                {
                    ViewBag.Message = "Student Details Added Successfully";
                    ModelState.Clear();
                }
            }
            return View();

        }
        catch
        {

            return View();
        }

    }
    //public IActionResult Update(int id)
    //{
    //    try
    //    {
    //        string strUpdate = "UPDATE [dbo].[Customers] SET ";
    //        SqlParameter[] param = new SqlParameter[]
    //         {
    //            new SqlParameter("@id",id)
    //         };
    //        (new DataProvider()).executeNonQuery(strDelete, param);
    //        return RedirectToAction("Index");
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}
    } 
}

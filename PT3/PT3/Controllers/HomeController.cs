using Microsoft.AspNetCore.Mvc;
using PT3.Models;

namespace PT3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (MyDB3Context context = new MyDB3Context())
            {
                var products = context.Products.ToList();
                ViewBag.Products = products;

                products = context.Products.ToList();
                return View(products);
            }
        }
        [HttpPost]
        public IActionResult Index(string pcode, string pname, int oldprice, int newprice, string image)
        {
            using (MyDB3Context context = new MyDB3Context())
            {
                var products = context.Products.ToList();
                ViewBag.Products = products;

                products = context.Products.ToList();
                if (!String.IsNullOrEmpty(pcode)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
                {
                    products = context.Products.Where(s => s.ProductCode.Contains(pcode)).ToList(); //lọc theo chuỗi tìm kiếm
                }
                ViewBag.pcode = pcode;
                if (!String.IsNullOrEmpty(pname)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
                {
                    products = context.Products.Where(s => s.ProductName.Contains(pname)).ToList(); //lọc theo chuỗi tìm kiếm
                }
                ViewBag.pname = pname;
                if (oldprice != 0 ) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
                {
                    products = context.Products.Where(s => s.Price == oldprice).ToList(); //lọc theo chuỗi tìm kiếm
                }
                ViewBag.price = oldprice;
                if (!String.IsNullOrEmpty(image)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
                {
                    products = context.Products.Where(s => s.Image.Contains(image)).ToList(); //lọc theo chuỗi tìm kiếm
                }
                ViewBag.image = image;
                //ViewBag.selectedid = cateid;
                //else if (cateid == "0")  products = context.Products.ToList();
                return View(products);
            }
        }
    }
}

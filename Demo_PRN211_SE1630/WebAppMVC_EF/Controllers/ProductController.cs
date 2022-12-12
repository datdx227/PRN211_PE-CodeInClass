using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAppMVC_EF.Models;

namespace WebAppMVC_EF.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                var categories = context.Categories.ToList();
                ViewBag.Categories = categories;

                var products = context.Products.ToList();
                return View(products);
            }

        }
        [HttpPost]
        public IActionResult Index(int cateid)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                var categories = context.Categories.ToList();
                ViewBag.Categories = categories;

                var products = context.Products.ToList();
                if (cateid != 0)
                {
                    products = context.Products
                        .Where(p => p.CategoryId == cateid)
                        .ToList();
                }
                ViewBag.selectedid = cateid;
                //else if (cateid == "0")  products = context.Products.ToList();
                return View(products);
            }

        }


            public IActionResult Add()
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                var data1 = context.Categories.ToList();
                ViewBag.Categories = data1;

                return View();
            }

        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {               
                if (ModelState.IsValid)//tao model thanh cong
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                    return RedirectToAction("Index"); ;
                }
                else
                    return View();
            }
        }
        public IActionResult Update(int id)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                var data1 = context.Categories.ToList();
                ViewBag.Categories = data1;
                var product = context.Products.Find(id);
                return View(product);
            }
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                if (ModelState.IsValid)
                {
                    context.Products.Update(product);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    var data1 = context.Categories.ToList();
                    ViewBag.Categories = data1;
                    return View(product);
                }
            }
        }
        public IActionResult Detail(int id)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == id);

                return View(product);
            }

        }
        public IActionResult Delete(int id)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {                
                Product product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
               
        }
    }
}

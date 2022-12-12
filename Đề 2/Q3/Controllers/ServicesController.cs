using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q3.Models;

namespace Q3.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Search()
        {
            using (PRN211_Spr22Context context = new PRN211_Spr22Context())
            {
                var services = context.Services.ToList();
                ViewBag.services = services;

                services = context.Services.Include(x => x.EmployeeNavigation).ToList();
                return View(services);
            }
        }
    
        [HttpPost]
        public IActionResult Search(string pcode, int month)
        {
            using (PRN211_Spr22Context context = new PRN211_Spr22Context())
            {
                var services = context.Services.ToList();
                ViewBag.services = services;

                services = context.Services.ToList();
                if (!String.IsNullOrEmpty(pcode)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
                {
                    services = context.Services.Include(x => x.EmployeeNavigation).Where(s => s.RoomTitle.Contains(pcode)).ToList(); //lọc theo chuỗi tìm kiếm
                }
                ViewBag.pcode = pcode;
                if (month != 0) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
                {
                    services = services.Where(s => s.Month == month).ToList(); //lọc theo chuỗi tìm kiếm
                    
                }
                ViewBag.month = month;
                //ViewBag.selectedid = cateid;
                //else if (cateid == "0")  products = context.Products.ToList();
                return View(services);
            }
        }
    }
}

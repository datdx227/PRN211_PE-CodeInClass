using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        //Day la 1 action cua controller
        public IActionResult Index(Student student)
        {
            //Truyen du lieu sang view
            //C1: ViewData
            ViewData["Message"] = "Đây là cách sử dụng ViewData:";
            ViewData["Data"] = new Student
                {
                    Code = "SV01",
                    Name = "Nguyễn Văn A",
                    Mark = 6
                };

            //C2 - ViewBag

            ViewBag.Message2= "Đây là cách sử dụng ViewData:";
            ViewBag.Data2 = new Student( "SV02", "Nguyễn Văn B", 7);

            //C3: model
            if (!String.IsNullOrEmpty(student.Code))
            {
                return View(student);
            }
            else
            {
                student = new Student();
                student.Code = "SV03";
                student.Name = "Nguyen Van C";
                student.Mark = 9;
                return View(student);
            }           
        }

        public IActionResult Add()
        {
            return View();
        }
        static List<Student> list = new List<Student>();
        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid)//tao model thanh cong
            {
                list.Add(student);
                ViewBag.Data = list;
                return View("ListStudent", (student));
            }
            else
                return View();
            
        }

        public IActionResult Detail(string id)
        {
            Student student = list.FirstOrDefault(item => item.Code == id);
            //return View(student);
            return RedirectToAction("Index",student);
        }
    }
}

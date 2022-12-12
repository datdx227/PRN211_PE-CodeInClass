using Microsoft.AspNetCore.Mvc;
using Q3.Models;

namespace Q3.Controllers
{
    //[Route("Employee/[List]")]
    public class EmployeeController : Controller
    {
        public IActionResult List()
        {
            using (PE_Spr22B5Context context = new PE_Spr22B5Context())
            {
                var employees = context.Employees.ToList();
                ViewBag.employees = employees;

                employees = context.Employees.ToList();
                return View(employees);
            }
        }
        public IActionResult Delete(int id)
        {
            using (PE_Spr22B5Context context = new PE_Spr22B5Context())
            {
                Employee employee = context.Employees.Find(id);
                context.Employees.Remove(employee);
                context.SaveChanges();
                return RedirectToAction("List");
            }

        }
    }
}

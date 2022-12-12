using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q3.Models;
using System;
using System.Linq;

namespace Q3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (PE_PRN_Sum21Context context = new PE_PRN_Sum21Context())
            {
                var data1 = context.Customers.ToList();
                ViewBag.Customers = data1;

                var contracts = context.Contracts.Include(x => x.Employee).ToList();

                return View(contracts);
            }
        }

        [HttpPost]
        public IActionResult Index(string cusid)
        {
            using (PE_PRN_Sum21Context context = new PE_PRN_Sum21Context())
            {
                ViewBag.selectedid = Int32.Parse(cusid);
                var data1 = context.Customers.ToList();
                ViewBag.Customers = data1;
                var contracts = context.Contracts.Include(x => x.Employee).ToList();
                var data2 = context.Employees.ToList();
                ViewBag.Employees = data2;
                if (cusid != "0")
                {                   
                    contracts = context.Contracts.Include(x => x.Employee)                        
                        .Where(p => p.CustomerId == Int32.Parse(cusid))
                        .ToList();
                    
                }

                return View(contracts);
                //             (from t1 in context.Contracts
                //              join t2 in context.Employees on
                //t1.EmployeeId equals t2.EmployeeId
                //              orderby t1.Id
                //              select new
                //              {
                //                  t1.Code,
                //                  t1.CustomerId,
                //                  t2.EmployeeName,
                //                  t1.Type,
                //                  t1.SignedDate
                //              })
   //             (from t1 in context.Contracts
   //              join
   //t2 in context.Employees on
   //t1.EmployeeId equals t2.EmployeeId
   //              orderby t1.Id
   //              select new
   //              {
   //                  t1.Code,
   //                  t1.CustomerId,
   //                  t2.EmployeeName,
   //                  t1.Type,
   //                  t1.SignedDate
   //              })
            }


        }
    }
}

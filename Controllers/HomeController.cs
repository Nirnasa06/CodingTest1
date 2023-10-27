using CodingTest1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodingTest1.Controllers
{
    public class HomeController : Controller
    {
        // This is a mock data store since no database is required.
        private static List<Employee> Employees = new List<Employee>();

        // Populate the list with 10 instances of each employee type on startup
        static HomeController()
        {
            for (int i = 0; i < 10; i++)
            {
                Employees.Add(new HourlyEmployee());
                Employees.Add(new SalariedEmployee());
                Employees.Add(new Manager());
            }
        }

        public ActionResult Index()
        {
            return View(Employees);
        }

        [HttpPost]
        public ActionResult Work(int employeeIndex, int daysWorked)
        {
            Employees[employeeIndex].Work(daysWorked);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult TakeVacation(int employeeIndex, float days)
        {
            Employees[employeeIndex].TakeVacation(days);
            return RedirectToAction("Index");
        }
    }
}
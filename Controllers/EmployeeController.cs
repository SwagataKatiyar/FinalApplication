using FinalApplication.Data;
using FinalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FinalApplication.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly myDbContext etx;

        public EmployeeController(myDbContext context)
        {
            etx = context;
        }
        public IActionResult ShowAllEmployees()
        {

            var employees = etx.EmployeesDetails.ToList();
            return View(employees);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                etx.EmployeesDetails.Add(model);
                await etx.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("msg", "Data not Saved");
            }
            return RedirectToAction("ShowAllEmployees");
        }

        public IActionResult EditEmployee(int id)
        {
            var employee = etx.EmployeesDetails.Find(id);
            return View(employee);
        }


        [HttpPost]

        public async Task<IActionResult> EditEmployee(EmployeeModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                etx.Entry(model).State = EntityState.Modified;

                await etx.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("msg", "Error on Updation");
                return View();
            }
            return RedirectToAction("ShowAllEmployees");


        }

        public IActionResult DeleteEmployee(int id)
        {

            try
            {
                var employee = etx.EmployeesDetails.Find(id);
                if (employee != null)
                {
                    etx.EmployeesDetails.Remove(employee);
                    etx.SaveChanges();
                }
            }
            catch (Exception ex)
            {


            }
            return RedirectToAction("ShowAllEmployees");

        }

    }
}
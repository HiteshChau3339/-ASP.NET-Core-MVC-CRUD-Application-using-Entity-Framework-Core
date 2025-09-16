using Microsoft.AspNetCore.Mvc;
using MVCWithEF.Models;
using System.Data.SqlTypes;

namespace MVCWithEF.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext context;
        public EmployeeController(AppDbContext _context)
        {
            context = _context; 
        }

        public IActionResult EmployeeList()
        {
            var EmployeeList = context.Employees.ToList();
            return View(EmployeeList);
        }

        public IActionResult DeleteEmp(int EmpID)
        {
            var Employee = context.Employees.Find(EmpID);
            if(Employee == null)
            {
                ViewBag.error = "Employee NotFound";
            }
            else
            {
                context.Employees.Remove(Employee);
                context.SaveChanges();
            }
            return RedirectToAction("EmployeeList");
        }

        public IActionResult Save(Employee newemp)
        {

            if (newemp.EmpID != 0)
            {
                return RedirectToAction("EditSave", newemp);
            }
            else
            {
                Employee emp = new Employee()
                {
                    EmpName = newemp.EmpName,
                    Phone = newemp.Phone,
                    EmpGender = newemp.EmpGender,
                    Email = newemp.Email
                };

                context.Employees.Add(emp);
                context.SaveChanges();
            }
              
            return RedirectToAction("EmployeeList");
        }

        public IActionResult EditSave(Employee newemp)
        {

            var emp = context.Employees.Find(newemp.EmpID);
            if (emp == null )
            {
                ViewBag.error = "Not Found";
                
            }
            else
            {
                emp.EmpName = newemp.EmpName;
                emp.EmpGender = newemp.EmpGender;
                emp.Phone = newemp.Phone;
                emp.Email = newemp.Email;
                context.Employees.Update(emp);
                context.SaveChanges();
            }
            return RedirectToAction("EmployeeList");
        }

        public IActionResult AddEditEmp(int EmpID)
        {
            if (EmpID == 0 || EmpID == null)
            {
                return View();
            }
            else
            {
                Employee myemp = new Employee();

                var emp = context.Employees.Find(EmpID);
                
                myemp.EmpName = emp.EmpName;
                myemp.Phone = emp.Phone;
                myemp.Email = emp.Email;
                myemp.EmpGender = emp.EmpGender;
                myemp.EmpID = emp.EmpID;
            
                return View(myemp);
            
            }
        }
    }
}
using EmployeeApp.Models;
using EmployeeApp.Repositories.Implemetation;
using EmployeeApp.Repositories.Interaces;
using EmployeeApp.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: Employee
        public ActionResult Index()
        {
            
            return View(_employeeService.GetAllEmployees());
        }

        // GET: Employee/Create
        [Route("Employee/Create")]
        public ActionResult CreateEmployee()
        {
            //Employee employee = new Employee();
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                
                return View(employee); // Return the view with validation errors
            }
            _employeeService.AddEmployee(employee);
            //employee.Id = employees.Id + 1;
           // employees.Add(employee);
            return RedirectToAction("Index");
        }

        // GET: Employee/Edit/5
        [Route("Employee/Edit/{id?}")]
        public ActionResult EditEmployee(int id)
        {
            var employee = _employeeService.GetAllEmployees().Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost,ActionName("EditEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(Employee employee)
        {
            
            var existingEmployee = _employeeService.GetAllEmployees().Find(e => e.Id == employee.Id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Address = employee.Address;
            existingEmployee.Mobile = employee.Mobile;
            existingEmployee.DOB = employee.DOB;
            existingEmployee.Id = employee.Id;
            _employeeService.UpdateEmployee(existingEmployee);
            return RedirectToAction("Index");
        }

        // GET: Employee/Delete/5

        [Route("Employee/Delete/{id?}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.GetAllEmployees().Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = _employeeService.GetAllEmployees().Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}

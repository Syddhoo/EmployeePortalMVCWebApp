using EmployeePortalMVCWebApp.Data;
using EmployeePortalMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortalMVCWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext employeeDbContext;

        public EmployeeController(EmployeeContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await employeeDbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                DateOfJoining = addEmployeeRequest.DateOfJoining,
                Designation = addEmployeeRequest.Designation,
                PhoneNumber = addEmployeeRequest.PhoneNumber,
                Address = addEmployeeRequest.Address,
                Gender = addEmployeeRequest.Gender,
                Grade = addEmployeeRequest.Grade,
                City = addEmployeeRequest.City,
                Country = addEmployeeRequest.Country
            };
            await employeeDbContext.Employees.AddAsync(employee);
            await employeeDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var employee = await employeeDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == Id);
            
            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    EmployeeId = employee.EmployeeId,
                    Name = employee.Name,
                    Email = employee.Email,
                    DateOfJoining = employee.DateOfJoining,
                    Designation = employee.Designation,
                    PhoneNumber = employee.PhoneNumber,
                    Address = employee.Address,
                    Gender = employee.Gender,
                    Grade = employee.Grade,
                    City = employee.City,
                    Country = employee.Country
                };
                return await Task.Run(()=>View("View",viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View (UpdateEmployeeViewModel model)
        {
            var employee = await employeeDbContext.Employees.FirstAsync(model.EmployeeId);
            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.DateOfJoining = model.DateOfJoining;
                employee.Designation = model.Designation;
                employee.PhoneNumber = model.PhoneNumber;
                employee.Address = model.Address;
                employee.Gender = model.Gender; 
                employee.Grade = model.Grade;
                employee.City = model.City;
                employee.Country = model.Country;

                await employeeDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = employeeDbContext.Employees.FindAsync(model.EmployeeId);
            if (employee != null)
            {
                employeeDbContext.Employees.Remove(employee);
                await employeeDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

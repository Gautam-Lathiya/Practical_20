using GenericRepositoryPattern.Data.Interfaces;
using GenericRepositoryPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPattern.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Employee/Index
        public async Task<IActionResult> Index()
        {
            var employeeRepository = _unitOfWork.GetRepository<Employee>();
            var employees = await employeeRepository.GetAllAsync();
            return View(employees);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var employeeRepository = _unitOfWork.GetRepository<Employee>();
                await employeeRepository.AddAsync(employee);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var employeeRepository = _unitOfWork.GetRepository<Employee>();
            var employee = await employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var employeeRepository = _unitOfWork.GetRepository<Employee>();
                employeeRepository.Update(employee);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var employeeRepository = _unitOfWork.GetRepository<Employee>();
            var employee = await employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeRepository = _unitOfWork.GetRepository<Employee>();
            var employee = await employeeRepository.GetByIdAsync(id);
            if (employee != null)
            {
                employeeRepository.Delete(employee);
                await _unitOfWork.SaveAsync();
            }

            return RedirectToAction("Index");
        }
    }

}

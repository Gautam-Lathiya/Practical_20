﻿using GenericRepositoryPattern.Data.Interfaces;
using GenericRepositoryPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPattern.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Department/Index
        public async Task<IActionResult> Index()
        {
            var departmentRepository = _unitOfWork.GetRepository<Department>();
            var departments = await departmentRepository.GetAllAsync();
            return View(departments);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var departmentRepository = _unitOfWork.GetRepository<Department>();
                await departmentRepository.AddAsync(department);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var departmentRepository = _unitOfWork.GetRepository<Department>();
            var department = await departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var departmentRepository = _unitOfWork.GetRepository<Department>();
                departmentRepository.Update(department);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var departmentRepository = _unitOfWork.GetRepository<Department>();
            var department = await departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentRepository = _unitOfWork.GetRepository<Department>();
            var department = await departmentRepository.GetByIdAsync(id);
            if (department != null)
            {
                departmentRepository.Delete(department);
                await _unitOfWork.SaveAsync();
            }

            return RedirectToAction("Index");
        }
    }

}

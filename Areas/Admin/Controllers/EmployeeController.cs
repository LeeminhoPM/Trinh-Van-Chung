using ChungTrinhj.Models;
using ChungTrinhj.Models.ViewModels;
using ChungTrinhj.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ChungTrinhj.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll().ToList();
            return View(objEmployeeList);
        }

        public IActionResult Create()
        {
            EmployeeVM employeeVM = new()
            {
                employee = new Employee(),
                employeeList = _unitOfWork.Employee.GetAll().Select(u => new SelectListItem
                {
                    Text = u.FullName,
                    Value = u.Id.ToString(),
                })
            };
            return View(employeeVM);
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Add(obj.employee);
                _unitOfWork.Save();
                TempData["Success"] = "Employee added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                obj.employeeList = _unitOfWork.Employee.GetAll().Select(u => new SelectListItem
                {
                    Text = u.FullName,
                    Value = u.Id.ToString(),
                });
                return View(obj);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Employee? employeeFromDb = _unitOfWork.Employee.Get(u => u.Id == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }

            return View(employeeFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Employee updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Employee? employeeFromDb = _unitOfWork.Employee.Get(u => u.Id == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }

            return View(employeeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Employee? obj = _unitOfWork.Employee.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Employee.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

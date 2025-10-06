using ChungTrinhj.Models;
using ChungTrinhj.Models.ViewModels;
using ChungTrinhj.Repository.IRepository;
using ChungTrinhj.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Collections.Generic;

namespace ChungTrinhj.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll().ToList();
            return View(objEmployeeList);
        }

        public IActionResult Upsert(int? id)
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

            if (id == null || id == 0)
            {
                // Create
                return View(employeeVM);
            }
            else
            {
                // Update
                employeeVM.employee = _unitOfWork.Employee.Get(u => u.Id == id);
                return View(employeeVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(EmployeeVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string employeePath = Path.Combine(wwwRootPath, @"images\employee");

                    // Xóa file ảnh nếu có khi thêm ảnh mới
                    if (!string.IsNullOrEmpty(obj.employee.imageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.employee.imageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(employeePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.employee.imageUrl = @"\images\employee\" + fileName;
                }
                if (obj.employee.Id == 0)
                {
                    _unitOfWork.Employee.Add(obj.employee);
                }
                else
                {
                    _unitOfWork.Employee.Update(obj.employee);
                }
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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll().ToList();
            return Json(new { data = objEmployeeList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var employeeToBeDeleted = _unitOfWork.Employee.Get(u => u.Id == id);
            if (employeeToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, employeeToBeDeleted.imageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Employee.Remove(employeeToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}

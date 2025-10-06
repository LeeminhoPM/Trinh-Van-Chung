using System.Diagnostics;
using ChungTrinhj.Models;
using ChungTrinhj.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ChungTrinhj.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employeeList = _unitOfWork.Employee.GetAll();
            return View(employeeList);
        }

        public IActionResult Details(int id)
        {
            Employee employee = _unitOfWork.Employee.Get(u => u.Id == id);
            return View(employee);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

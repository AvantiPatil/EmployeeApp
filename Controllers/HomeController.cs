using EmployeeApp.Models;
using EmployeeApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _IEmployeeService;

        public HomeController(ILogger<HomeController> logger, IEmployeeService IEmployeeService)
        {
            _logger = logger;
            _IEmployeeService = IEmployeeService;
        }

        public IActionResult Index()
        {
            _IEmployeeService.GetAllEmployees();
            return View();
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
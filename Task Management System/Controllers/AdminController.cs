using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Task_Management_System.Models;
using Task_Management_System.Service;

namespace demo3.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult AllTaskTable()
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

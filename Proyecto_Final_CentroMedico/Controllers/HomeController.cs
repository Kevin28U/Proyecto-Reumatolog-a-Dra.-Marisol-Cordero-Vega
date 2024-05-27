using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_CentroMedico.Models;
using System.Diagnostics;

namespace Proyecto_Final_CentroMedico.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.ShowNavbar = true;
            ViewBag.ShowFooter = true;
            return View();
        }

        public IActionResult SeccionInformativa()
        {
            ViewBag.ShowNavbar = true;
            ViewBag.ShowFooter = true;
            return View();
        }

        public IActionResult Login() {
            ViewBag.ShowNavbar = false;
            ViewBag.ShowFooter = false; // Mostrar el footer en esta pantalla
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

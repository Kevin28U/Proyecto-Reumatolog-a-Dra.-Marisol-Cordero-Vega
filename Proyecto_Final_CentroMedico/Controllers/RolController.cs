using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final_CentroMedico.Controllers
{
	public class RolController : Controller
	{
        public IActionResult Index()
        {
            ViewBag.ShowNavbar = true;
            ViewBag.ShowFooter = false;
            return View();

        }

        public IActionResult Crear()
        {
            ViewBag.ShowNavbar = true;
            ViewBag.ShowFooter = true;
            return View();

        }

        public IActionResult Editar()
        {
            ViewBag.ShowNavbar = true;
            ViewBag.ShowFooter = true;
            return View();

        }
    }
}

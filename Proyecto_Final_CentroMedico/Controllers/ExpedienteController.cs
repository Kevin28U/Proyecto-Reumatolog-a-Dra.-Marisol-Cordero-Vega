using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final_CentroMedico.Controllers
{
	public class ExpedienteController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult Dashboard()
        {
            return View();
        }

		public IActionResult Detalle()
		{
			return View();
		}

        public ActionResult Editar()
        {
            return View();
        }

		public ActionResult Crear() { 
			
			return View();

		}

    }

}


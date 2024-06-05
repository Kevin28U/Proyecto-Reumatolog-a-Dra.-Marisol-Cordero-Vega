using Microsoft.AspNetCore.Mvc;


namespace Proyecto_Final_CentroMedico.Controllers
{
	public class ExpedienteController : Controller
	{

		private readonly ClinicaReumatologiaContext _context;

		public ExpedienteController(ClinicaReumatologiaContext context) {
			_context = context;

        }
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
			var provincias = _context.obtenerProvincia();
			ViewData["Provincias"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList((System.Collections.IEnumerable)provincias,"IdProvincia","NombreProvincia");
            var cantones = _context.Cantons.ToList();
            ViewData["Cantones"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cantones, "IdCanton", "NombreProvincia");
            var sexos = _context.Sexos.ToList();
            ViewData["Sexos"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(sexos, "IdSexo", "Sexo1");
            var ocupaciones = _context.Ocupacions.ToList();
            ViewData["Ocupaciones"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(ocupaciones, "IdOcupacion", "Ocupacion1");

            return View();

		}

    }

}


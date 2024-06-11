using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




namespace Proyecto_Final_CentroMedico.Controllers
{
    public class ExpedienteController : Controller
    {

        private readonly ClinicaReumatologiaContext _context;

        public ExpedienteController(ClinicaReumatologiaContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index(string cedulaBuscar)
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Detalle(string id)
        {
            if (!string.IsNullOrEmpty(id)) {
                var paciente = _context.Pacientes.Where(p => p.CedulaPaciente.Equals(id)).FirstOrDefault();
                var expediente = _context.Expedientes.Where(e => e.CedulaPaciente.Equals(id)).FirstOrDefault();
                var antecedentes = _context.Antecedentes.Where(a => a.IdAntecedentes.Equals(expediente.IdAntecedentes)).FirstOrDefault();
                var ocupacion = _context.Ocupacions.Where(o => o.IdOcupacion.Equals(paciente.IdOcupacion)).FirstOrDefault();
                var sexo = _context.Sexos.Where(s => s.IdSexo.Equals(paciente.IdSexo)).FirstOrDefault();
                var direccion = _context.Direccions.Where(d => d.IdDireccion.Equals(paciente.IdDireccion)).FirstOrDefault();
                var provincia = _context.Provincia.Where(p => p.IdProvincia.Equals(direccion.IdProvincia)).FirstOrDefault();
                var canton = _context.Cantons.Where(p => p.IdCanton.Equals(direccion.IdCanton)).FirstOrDefault();
                if (paciente != null && expediente != null && antecedentes != null && direccion !=null && provincia !=null && canton != null) {


        VerExpedienteViewModel VMVerExpediente = new
                        (
                            paciente.CedulaPaciente,
                            paciente.Nombre,
                            paciente.PrimerApellido,
                            paciente.SegundoApellido,
                            paciente.FechaNacimiento ?? default(DateOnly),
                            paciente.Edad ?? 0,
                            sexo.Sexo1,
                            ocupacion.Ocupacion1,
                            provincia.NombreProvincia,
                            canton.NombreProvincia,
                            direccion.Direccion1,
                            antecedentes.Ago,
                            antecedentes.ApnoP,
                            antecedentes.App,
                            antecedentes.Ahf,antecedentes.Aqtx
                        );
                    return View(VMVerExpediente);
                }

            }


            return View();
        }

        public ActionResult Editar()
        {
            return View();
        }

        public ActionResult Crear()
        {
            ViewBag.cedulaOK = false;
            var provincias = _context.obtenerProvincia();
            ViewData["Provincias"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList((System.Collections.IEnumerable)provincias, "IdProvincia", "NombreProvincia");
            var cantones = _context.Cantons.ToList();
            ViewData["Cantones"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cantones, "IdCanton", "NombreProvincia");
            var sexos = _context.Sexos.ToList();
            ViewData["Sexos"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(sexos, "IdSexo", "Sexo1");
            var ocupaciones = _context.Ocupacions.ToList();
            ViewData["Ocupaciones"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(ocupaciones, "IdOcupacion", "Ocupacion1");

            return View();

        }

        [HttpPost]

        /*
        public ActionResult Crear(Antecedente Item1, Direccion Item3, Paciente Item4) {
            var provincias = _context.obtenerProvincia();
            ViewData["Provincias"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList((System.Collections.IEnumerable)provincias, "IdProvincia", "NombreProvincia");
            var cantones = _context.Cantons.ToList();
            ViewData["Cantones"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cantones, "IdCanton", "NombreProvincia");
            var sexos = _context.Sexos.ToList();
            ViewData["Sexos"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(sexos, "IdSexo", "Sexo1");
            var ocupaciones = _context.Ocupacions.ToList();
            ViewData["Ocupaciones"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(ocupaciones, "IdOcupacion", "Ocupacion1");
            if (ModelState.IsValid) {
                _context.crearAntecedentes(
                    Item1.Ago,
                    Item1.ApnoP,
                    Item1.App,
                    Item1.Ahf,
                    Item1.Aqtx
                 );

                _context.crearDireccion(
                    Item3.IdProvincia ?? 0,
                    Item3.IdCanton ?? 0,
                    Item3.Direccion1
                );
                int idDireccion = _context.Direccions.OrderByDescending(p => p.IdDireccion).Select(p => p.IdDireccion).FirstOrDefault();

                _context.crearPaciente(
                    Item4.CedulaPaciente,
                    Item4.Nombre,
                    Item4.PrimerApellido,
                    Item4.SegundoApellido,
                    Item4.Edad ?? 0,  
                    Item4.IdSexo ?? 0,
                    Item4.IdOcupacion ?? 0,
                    idDireccion,
                    Item4.FechaNacimiento ?? default(DateOnly)
                );

                int idAntecedente = _context.Antecedentes.OrderByDescending(p => p.IdAntecedentes).Select(p => p.IdAntecedentes).FirstOrDefault();
                _context.crearExpediente(
                    Item4.CedulaPaciente,
                    idAntecedente
                    
                 );



                return View("Index");

                



            }

            return View();
            
            
        }

        */

        public ActionResult Crear(Antecedente Item1, Direccion Item3, Paciente Item4)
        {
            ViewBag.cedulaOK = "SI";
            try
            {
                var provincias = _context.obtenerProvincia();
                ViewData["Provincias"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList((System.Collections.IEnumerable)provincias, "IdProvincia", "NombreProvincia");
                var cantones = _context.Cantons.ToList();
                ViewData["Cantones"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cantones, "IdCanton", "NombreProvincia");
                var sexos = _context.Sexos.ToList();
                ViewData["Sexos"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(sexos, "IdSexo", "Sexo1");
                var ocupaciones = _context.Ocupacions.ToList();
                ViewData["Ocupaciones"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(ocupaciones, "IdOcupacion", "Ocupacion1");

                if (ModelState.IsValid)
                {
                    _context.crearAntecedentes(
                        Item1.Ago,
                        Item1.ApnoP,
                        Item1.App,
                        Item1.Ahf,
                        Item1.Aqtx
                     );

                    _context.crearDireccion(
                        Item3.IdProvincia ?? 0,
                        Item3.IdCanton ?? 0,
                        Item3.Direccion1
                    );
                    int idDireccion = _context.Direccions.OrderByDescending(p => p.IdDireccion).Select(p => p.IdDireccion).FirstOrDefault();

                    _context.crearPaciente(
                        Item4.CedulaPaciente,
                        Item4.Nombre,
                        Item4.PrimerApellido,
                        Item4.SegundoApellido,
                        Item4.Edad ?? 0,
                        Item4.IdSexo ?? 0,
                        Item4.IdOcupacion ?? 0,
                        idDireccion,
                        Item4.FechaNacimiento ?? default(DateOnly)
                    );

                    int idAntecedente = _context.Antecedentes.OrderByDescending(p => p.IdAntecedentes).Select(p => p.IdAntecedentes).FirstOrDefault();
                    _context.crearExpediente(
                        Item4.CedulaPaciente,
                        idAntecedente
                     );

                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción aquí
                ViewBag.cedulaOK = "NO";
                return View();
            }

            return View();
        }


        public ActionResult Eliminar(string id) {
            if (!string.IsNullOrEmpty(id)) {
                //Buscar las llaves primarias de las tablas
                var idExpediente = _context.Expedientes.Where(e => e.CedulaPaciente.Equals(id)).Select(e => e.IdExpediente).FirstOrDefault();
                var idDireccion = _context.Pacientes.Where(p => p.CedulaPaciente.Equals(id)).Select(p => p.IdDireccion).FirstOrDefault();
                var idAntecedentes = _context.Expedientes.Where(e => e.IdExpediente.Equals(idExpediente)).Select(e => e.IdAntecedentes).FirstOrDefault();

                if (idExpediente !=null && idDireccion != null && idAntecedentes != null) {

                    //Buscar las entidades a borrar
                    var expediente = _context.Expedientes.Find(idExpediente);
                    var paciente = _context.Pacientes.Find(id);
                    var direccion = _context.Direccions.Find(idDireccion);
                    var antecedentes = _context.Antecedentes.Find(idAntecedentes);

                    if (expediente != null &&  paciente != null && direccion != null && antecedentes != null) {

                        //Borrar los elementos de las tablas
                        _context.Expedientes.Remove(expediente);
                        _context.Pacientes.Remove(paciente);
                        _context.Antecedentes.Remove(antecedentes);
                        _context.Direccions.Remove(direccion);
                        _context.SaveChanges();
                        ViewBag.Mensaje = true;
                    }
                }
            }

                return View("Index");
        
        }

        public async Task<IActionResult> Buscar(string cedulaBuscar) {

            ViewBag.datosEncontrados = false;

            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.CedulaPaciente.Equals(cedulaBuscar));
            var expediente = await _context.Expedientes.FirstOrDefaultAsync(e => e.CedulaPaciente.Equals(cedulaBuscar));

            if (paciente != null && expediente != null)
            {
                var VMExpediente = new ExpedienteViewModel(
                    expediente.IdExpediente,
                    paciente.CedulaPaciente,
                    paciente.Nombre,
                    paciente.PrimerApellido,
                    paciente.SegundoApellido
                );

                ViewBag.datosEncontrados = true;

                return View("Index",VMExpediente);
            }
            return View("Index");
        }
           

    

        
       

    }

}


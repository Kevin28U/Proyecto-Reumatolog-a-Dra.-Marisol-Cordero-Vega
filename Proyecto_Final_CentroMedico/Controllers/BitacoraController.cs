using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_CentroMedico;
using DAL.ViewModels;


namespace Proyecto_Final_CentroMedico.Controllers
{
    public class BitacoraController : Controller
    {
        private readonly ClinicaReumatologiaContext _context;

        public BitacoraController(ClinicaReumatologiaContext context)
        {
            _context = context;
        }

        // GET: Bitacora
        public async Task<IActionResult> Index()
        {
            var bitacoras = await _context.Bitacoras
                .Include(b => b.IdExpedienteNavigation)
                .ToListAsync();

            return View(bitacoras);
        }

        // GET: Bitacora/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bitacora = await _context.Bitacoras
                .Include(b => b.IdExpedienteNavigation)
                .FirstOrDefaultAsync(m => m.IdBitacora == id);
            if (bitacora == null)
            {
                return NotFound();
            }

            return View(bitacora);
        }

        // GET: Bitacora/Crear
        public IActionResult Crear()
        {
            ViewData["IdExpediente"] = new SelectList(_context.Expedientes, "IdExpediente", "CedulaPaciente");
            return View();
        }

        // POST: Bitacora/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdBitacora,IdExpediente,Sintomatologia,Evolucion,CambiosTratamiento")] Bitacora bitacora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bitacora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdExpediente"] = new SelectList(_context.Expedientes, "IdExpediente", "CedulaPaciente", bitacora.IdExpediente);
            return View(bitacora);
        }

        // GET: Bitacora/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bitacora = await _context.Bitacoras.FindAsync(id);
            if (bitacora == null)
            {
                return NotFound();
            }
            return View(bitacora);
        }

        // POST: Bitacora/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdBitacora,Sintomatologia,Evolucion,CambiosTratamiento,IdExpediente")] Bitacora bitacora)
        {
            if (id != bitacora.IdBitacora)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bitacora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BitacoraExists(bitacora.IdBitacora))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bitacora);
        }

        // GET: Bitacora/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bitacora = await _context.Bitacoras
                .FirstOrDefaultAsync(m => m.IdBitacora == id);
            if (bitacora == null)
            {
                return NotFound();
            }

            return View(bitacora);
        }

        // POST: Bitacora/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var bitacora = await _context.Bitacoras.FindAsync(id);
            if (bitacora != null)
            {
                _context.Bitacoras.Remove(bitacora);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BitacoraExists(int id)
        {
            return _context.Bitacoras.Any(e => e.IdBitacora == id);
        }

        [HttpPost]
        public async Task<IActionResult> Buscar(string cedulaBuscar)
        {
            if (string.IsNullOrEmpty(cedulaBuscar))
            {
                return RedirectToAction("Index");
            }

            // Buscar el expediente por la cédula del paciente
            var expediente = await _context.Expedientes
                .Include(e => e.Bitacoras)
                .FirstOrDefaultAsync(e => e.CedulaPaciente == cedulaBuscar);

            if (expediente == null)
            {
                ViewBag.datosEncontrados = false;
                return View("Index", Enumerable.Empty<Bitacora>());
            }

            ViewBag.datosEncontrados = true;
            return View("Index", expediente.Bitacoras);
        }



    }
}

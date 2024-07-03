using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_CentroMedico;

namespace Proyecto_Final_CentroMedico.Controllers
{
    public class PagosController : Controller
    {
        private readonly ClinicaReumatologiaContext _context;

        public PagosController(ClinicaReumatologiaContext context)
        {
            _context = context;
        }

        // GET: Pagos
        public async Task<IActionResult> Index()
        {
            var clinicaReumatologiaContext = _context.Pagos.Include(p => p.IdUsuarioNavigation);
            return View(await clinicaReumatologiaContext.ToListAsync());
        }

        // GET: Pagos/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // GET: Pagos/Create
        public IActionResult Crear()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Pagos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdPago,IdUsuario,TotalPagar,Detalle")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", pago.IdUsuario);
            return View(pago);
        }

        // GET: Pagos/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", pago.IdUsuario);
            return View(pago);
        }

        // POST: Pagos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdPago,IdUsuario,TotalPagar,Detalle")] Pago pago)
        {
            if (id != pago.IdPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.IdPago))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", pago.IdUsuario);
            return View(pago);
        }

        // GET: Pagos/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago != null)
            {
                _context.Pagos.Remove(pago);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        // POST: Pagos/Buscar
        [HttpPost]
        public async Task<IActionResult> Buscar(int? idBuscar)
        {
            if (idBuscar == null)
            {
                return View("Index", await _context.Pagos.Include(p => p.IdUsuarioNavigation).ToListAsync());
            }

            var pagos = await _context.Pagos
                .Include(p => p.IdUsuarioNavigation)
                .Where(p => p.IdPago == idBuscar)
                .ToListAsync();

            if (pagos.Any())
            {
                return View("Index", pagos);
            }

            ViewBag.Message = "No se encontraron resultados";
            return View("Index", await _context.Pagos.Include(p => p.IdUsuarioNavigation).ToListAsync());
        }

        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.IdPago == id);
        }
    }
}


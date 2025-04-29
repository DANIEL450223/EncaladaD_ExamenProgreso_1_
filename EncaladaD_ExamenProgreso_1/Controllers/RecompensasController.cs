using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EncaladaD_ExamenProgreso_1.Models;

namespace EncaladaD_ExamenProgreso_1.Controllers
{
    public class RecompensasController : Controller
    {
        private readonly DBSqlSERVER_Demo01 _context;

        public RecompensasController(DBSqlSERVER_Demo01 context)
        {
            _context = context;
        }

        // GET: Recompensas
        public async Task<IActionResult> Index()
        {
            var dBSqlSERVER_Demo01 = _context.PlanRecompensasCliente.Include(r => r.Cliente);
            return View(await dBSqlSERVER_Demo01.ToListAsync());
        }

        // GET: Recompensas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recompensas = await _context.PlanRecompensasCliente
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.recompensasId == id);
            if (recompensas == null)
            {
                return NotFound();
            }

            return View(recompensas);
        }

        // GET: Recompensas/Create
        public IActionResult Create()
        {
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId");
            return View();
        }

        // POST: Recompensas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("recompensasId,nombre,FechaInicio,puntosAcumulados,clienteId")] Recompensas recompensas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recompensas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId", recompensas.clienteId);
            return View(recompensas);
        }

        // GET: Recompensas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recompensas = await _context.PlanRecompensasCliente.FindAsync(id);
            if (recompensas == null)
            {
                return NotFound();
            }
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId", recompensas.clienteId);
            return View(recompensas);
        }

        // POST: Recompensas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("recompensasId,nombre,FechaInicio,puntosAcumulados,clienteId")] Recompensas recompensas)
        {
            if (id != recompensas.recompensasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recompensas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecompensasExists(recompensas.recompensasId))
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
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId", recompensas.clienteId);
            return View(recompensas);
        }

        // GET: Recompensas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recompensas = await _context.PlanRecompensasCliente
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.recompensasId == id);
            if (recompensas == null)
            {
                return NotFound();
            }

            return View(recompensas);
        }

        // POST: Recompensas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recompensas = await _context.PlanRecompensasCliente.FindAsync(id);
            if (recompensas != null)
            {
                _context.PlanRecompensasCliente.Remove(recompensas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecompensasExists(int id)
        {
            return _context.PlanRecompensasCliente.Any(e => e.recompensasId == id);
        }
    }
}

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
    public class Recompensas : Controller
    {
        private readonly DBSqlSERVER_Demo01 _context;

        public Recompensas(DBSqlSERVER_Demo01 context)
        {
            _context = context;
        }

        // GET: PlanRecompensasClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlanRecompensasCliente.ToListAsync());
        }

        // GET: PlanRecompensasClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planRecompensasCliente = await _context.PlanRecompensasCliente
                .FirstOrDefaultAsync(m => m.recompensasId == id);
            if (planRecompensasCliente == null)
            {
                return NotFound();
            }

            return View(planRecompensasCliente);
        }

        // GET: PlanRecompensasClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanRecompensasClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("recompensasId,nombre,FechaInicio,puntosAcumulados")] Models.Recompensas planRecompensasCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planRecompensasCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planRecompensasCliente);
        }

        // GET: PlanRecompensasClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planRecompensasCliente = await _context.PlanRecompensasCliente.FindAsync(id);
            if (planRecompensasCliente == null)
            {
                return NotFound();
            }
            return View(planRecompensasCliente);
        }

        // POST: PlanRecompensasClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("recompensasId,nombre,FechaInicio,puntosAcumulados")] Models.Recompensas planRecompensasCliente)
        {
            if (id != planRecompensasCliente.recompensasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planRecompensasCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanRecompensasClienteExists(planRecompensasCliente.recompensasId))
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
            return View(planRecompensasCliente);
        }

        // GET: PlanRecompensasClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planRecompensasCliente = await _context.PlanRecompensasCliente
                .FirstOrDefaultAsync(m => m.recompensasId == id);
            if (planRecompensasCliente == null)
            {
                return NotFound();
            }

            return View(planRecompensasCliente);
        }

        // POST: PlanRecompensasClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planRecompensasCliente = await _context.PlanRecompensasCliente.FindAsync(id);
            if (planRecompensasCliente != null)
            {
                _context.PlanRecompensasCliente.Remove(planRecompensasCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanRecompensasClienteExists(int id)
        {
            return _context.PlanRecompensasCliente.Any(e => e.recompensasId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sge.Entities;
using sge.Services;

namespace sge.Controllers
{
    public class ViaturaController : Controller
    {
        private readonly DataBaseContext _context;

        public ViaturaController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Viatura
        public async Task<IActionResult> Index()
        {
              return _context.Viaturas != null ? 
                          View(await _context.Viaturas.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.Viaturas'  is null.");
        }

        // GET: Viatura/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Viaturas == null)
            {
                return NotFound();
            }

            var viatura = await _context.Viaturas
                .FirstOrDefaultAsync(m => m.placa == id);
            if (viatura == null)
            {
                return NotFound();
            }

            return View(viatura);
        }

        // GET: Viatura/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Viatura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("placa,ordem,situacaoViatura")] Viatura viatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viatura);
        }

        // GET: Viatura/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Viaturas == null)
            {
                return NotFound();
            }

            var viatura = await _context.Viaturas.FindAsync(id);
            if (viatura == null)
            {
                return NotFound();
            }
            return View(viatura);
        }

        // POST: Viatura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("placa,ordem,situacaoViatura")] Viatura viatura)
        {
            if (id != viatura.placa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViaturaExists(viatura.placa))
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
            return View(viatura);
        }

        // GET: Viatura/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Viaturas == null)
            {
                return NotFound();
            }

            var viatura = await _context.Viaturas
                .FirstOrDefaultAsync(m => m.placa == id);
            if (viatura == null)
            {
                return NotFound();
            }

            return View(viatura);
        }

        // POST: Viatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Viaturas == null)
            {
                return Problem("Entity set 'DataBaseContext.Viaturas'  is null.");
            }
            var viatura = await _context.Viaturas.FindAsync(id);
            if (viatura != null)
            {
                _context.Viaturas.Remove(viatura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViaturaExists(string id)
        {
          return (_context.Viaturas?.Any(e => e.placa == id)).GetValueOrDefault();
        }
    }
}

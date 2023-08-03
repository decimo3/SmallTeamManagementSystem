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
    [Authorize]
    public class FuncionarioController : Controller
    {
        private readonly DataBaseContext _context;

        public FuncionarioController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Funcionario")]
        public async Task<IActionResult> Index()
        {
            if(_context.Funcionarios != null)
            {
                return View(await _context.Funcionarios.ToListAsync());
            }
            return Problem("Entity set 'DataBaseContext.Funcionarios'  is null.");
        }

        [HttpGet]
        [Route("Funcionario/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.re == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpGet]
        [Route("Funcionario/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Funcionario/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cpf,re,matricula,nome,sobrenome,apelido,senha,funcao,situacaoFuncionario,escala")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }
        [HttpGet]
        [Route("Funcionario/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        [Route("Funcionario/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cpf,re,matricula,nome,sobrenome,apelido,senha,funcao,situacaoFuncionario,escala")] Funcionario funcionario)
        {
            if (id != funcionario.re)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.re))
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
            return View(funcionario);
        }

        [HttpGet]
        [Route("Funcionario/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.re == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost]
        [Route("Funcionario/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcionarios == null)
            {
                return Problem("Entity set 'DataBaseContext.Funcionarios'  is null.");
            }
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
          return (_context.Funcionarios?.Any(e => e.re == id)).GetValueOrDefault();
        }
    }
}

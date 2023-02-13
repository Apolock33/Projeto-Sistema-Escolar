using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoSistemaEscolarAPI.Models;
using ProjetoSistemaEscolarAPI.Models.Context;

namespace ProjetoSistemaEscolarAPI.Controllers
{
    public class EscolasController : Controller
    {
        private readonly AppDbContext _context;

        public EscolasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Escolas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Escolas.ToListAsync());
        }

        // GET: Escolas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Escolas == null)
            {
                return NotFound();
            }

            var escolas = await _context.Escolas
                .FirstOrDefaultAsync(m => m.EscolaId == id);
            if (escolas == null)
            {
                return NotFound();
            }

            return View(escolas);
        }

        // GET: Escolas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escolas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EscolaId,CodigoUnidade,Endereco,QtdAlunos,QtdTurmas")] Escolas escolas)
        {
            if (ModelState.IsValid)
            {
                escolas.EscolaId = Guid.NewGuid();
                _context.Add(escolas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escolas);
        }

        // GET: Escolas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Escolas == null)
            {
                return NotFound();
            }

            var escolas = await _context.Escolas.FindAsync(id);
            if (escolas == null)
            {
                return NotFound();
            }
            return View(escolas);
        }

        // POST: Escolas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EscolaId,CodigoUnidade,Endereco,QtdAlunos,QtdTurmas")] Escolas escolas)
        {
            if (id != escolas.EscolaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escolas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolasExists(escolas.EscolaId))
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
            return View(escolas);
        }

        // GET: Escolas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Escolas == null)
            {
                return NotFound();
            }

            var escolas = await _context.Escolas
                .FirstOrDefaultAsync(m => m.EscolaId == id);
            if (escolas == null)
            {
                return NotFound();
            }

            return View(escolas);
        }

        // POST: Escolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Escolas == null)
            {
                return Problem("Entity set 'AppDbContext.Escolas'  is null.");
            }
            var escolas = await _context.Escolas.FindAsync(id);
            if (escolas != null)
            {
                _context.Escolas.Remove(escolas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolasExists(Guid id)
        {
          return _context.Escolas.Any(e => e.EscolaId == id);
        }
    }
}

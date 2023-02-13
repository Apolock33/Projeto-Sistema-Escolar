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
    public class TurmasController : Controller
    {
        private readonly AppDbContext _context;

        public TurmasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Turmas.ToListAsync());
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turmas == null)
            {
                return NotFound();
            }

            return View(turmas);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TurmaId,CodigoTurma,QtdAlunos")] Turmas turmas)
        {
            if (ModelState.IsValid)
            {
                turmas.TurmaId = Guid.NewGuid();
                _context.Add(turmas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turmas);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas.FindAsync(id);
            if (turmas == null)
            {
                return NotFound();
            }
            return View(turmas);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TurmaId,CodigoTurma,QtdAlunos")] Turmas turmas)
        {
            if (id != turmas.TurmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turmas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmasExists(turmas.TurmaId))
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
            return View(turmas);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turmas == null)
            {
                return NotFound();
            }

            return View(turmas);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Turmas == null)
            {
                return Problem("Entity set 'AppDbContext.Turmas'  is null.");
            }
            var turmas = await _context.Turmas.FindAsync(id);
            if (turmas != null)
            {
                _context.Turmas.Remove(turmas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmasExists(Guid id)
        {
          return _context.Turmas.Any(e => e.TurmaId == id);
        }
    }
}

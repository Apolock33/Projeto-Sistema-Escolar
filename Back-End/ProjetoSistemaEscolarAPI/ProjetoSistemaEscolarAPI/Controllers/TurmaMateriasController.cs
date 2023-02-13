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
    public class TurmaMateriasController : Controller
    {
        private readonly AppDbContext _context;

        public TurmaMateriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TurmaMaterias
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TurmaMateria.Include(t => t.Materias).Include(t => t.Turmas);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TurmaMaterias/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TurmaMateria == null)
            {
                return NotFound();
            }

            var turmaMateria = await _context.TurmaMateria
                .Include(t => t.Materias)
                .Include(t => t.Turmas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turmaMateria == null)
            {
                return NotFound();
            }

            return View(turmaMateria);
        }

        // GET: TurmaMaterias/Create
        public IActionResult Create()
        {
            ViewData["MateriaId"] = new SelectList(_context.Materias, "MateriaId", "NomeDaMateria");
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId");
            return View();
        }

        // POST: TurmaMaterias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TurmaId,MateriaId")] TurmaMateria turmaMateria)
        {
            if (ModelState.IsValid)
            {
                turmaMateria.Id = Guid.NewGuid();
                _context.Add(turmaMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MateriaId"] = new SelectList(_context.Materias, "MateriaId", "NomeDaMateria", turmaMateria.MateriaId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", turmaMateria.TurmaId);
            return View(turmaMateria);
        }

        // GET: TurmaMaterias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TurmaMateria == null)
            {
                return NotFound();
            }

            var turmaMateria = await _context.TurmaMateria.FindAsync(id);
            if (turmaMateria == null)
            {
                return NotFound();
            }
            ViewData["MateriaId"] = new SelectList(_context.Materias, "MateriaId", "NomeDaMateria", turmaMateria.MateriaId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", turmaMateria.TurmaId);
            return View(turmaMateria);
        }

        // POST: TurmaMaterias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TurmaId,MateriaId")] TurmaMateria turmaMateria)
        {
            if (id != turmaMateria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turmaMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaMateriaExists(turmaMateria.Id))
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
            ViewData["MateriaId"] = new SelectList(_context.Materias, "MateriaId", "NomeDaMateria", turmaMateria.MateriaId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", turmaMateria.TurmaId);
            return View(turmaMateria);
        }

        // GET: TurmaMaterias/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TurmaMateria == null)
            {
                return NotFound();
            }

            var turmaMateria = await _context.TurmaMateria
                .Include(t => t.Materias)
                .Include(t => t.Turmas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turmaMateria == null)
            {
                return NotFound();
            }

            return View(turmaMateria);
        }

        // POST: TurmaMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TurmaMateria == null)
            {
                return Problem("Entity set 'AppDbContext.TurmaMateria'  is null.");
            }
            var turmaMateria = await _context.TurmaMateria.FindAsync(id);
            if (turmaMateria != null)
            {
                _context.TurmaMateria.Remove(turmaMateria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaMateriaExists(Guid id)
        {
          return _context.TurmaMateria.Any(e => e.Id == id);
        }
    }
}

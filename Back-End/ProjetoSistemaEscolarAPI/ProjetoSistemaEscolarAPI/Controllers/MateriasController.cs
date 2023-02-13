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
    public class MateriasController : Controller
    {
        private readonly AppDbContext _context;

        public MateriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Materias
        public async Task<IActionResult> Index()
        {
              return View(await _context.Materias.ToListAsync());
        }

        // GET: Materias/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Materias == null)
            {
                return NotFound();
            }

            var materias = await _context.Materias
                .FirstOrDefaultAsync(m => m.MateriaId == id);
            if (materias == null)
            {
                return NotFound();
            }

            return View(materias);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MateriaId,NomeDaMateria,ProfessorDaMateria,QtdTurmasMatriculadas")] Materias materias)
        {
            if (ModelState.IsValid)
            {
                materias.MateriaId = Guid.NewGuid();
                _context.Add(materias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materias);
        }

        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Materias == null)
            {
                return NotFound();
            }

            var materias = await _context.Materias.FindAsync(id);
            if (materias == null)
            {
                return NotFound();
            }
            return View(materias);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MateriaId,NomeDaMateria,ProfessorDaMateria,QtdTurmasMatriculadas")] Materias materias)
        {
            if (id != materias.MateriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriasExists(materias.MateriaId))
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
            return View(materias);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Materias == null)
            {
                return NotFound();
            }

            var materias = await _context.Materias
                .FirstOrDefaultAsync(m => m.MateriaId == id);
            if (materias == null)
            {
                return NotFound();
            }

            return View(materias);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Materias == null)
            {
                return Problem("Entity set 'AppDbContext.Materias'  is null.");
            }
            var materias = await _context.Materias.FindAsync(id);
            if (materias != null)
            {
                _context.Materias.Remove(materias);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriasExists(Guid id)
        {
          return _context.Materias.Any(e => e.MateriaId == id);
        }
    }
}

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
    public class AlunosController : Controller
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Alunos.Include(a => a.Escolas).Include(a => a.Turma);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var alunos = await _context.Alunos
                .Include(a => a.Escolas)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (alunos == null)
            {
                return NotFound();
            }

            return View(alunos);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            ViewData["EscolaId"] = new SelectList(_context.Escolas, "EscolaId", "EscolaId");
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId");
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlunoId,Matricula,NomeCompleto,CPF,DataNascimento,TurmaId,EscolaId")] Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                alunos.AlunoId = Guid.NewGuid();
                _context.Add(alunos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscolaId"] = new SelectList(_context.Escolas, "EscolaId", "EscolaId", alunos.EscolaId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", alunos.TurmaId);
            return View(alunos);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var alunos = await _context.Alunos.FindAsync(id);
            if (alunos == null)
            {
                return NotFound();
            }
            ViewData["EscolaId"] = new SelectList(_context.Escolas, "EscolaId", "EscolaId", alunos.EscolaId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", alunos.TurmaId);
            return View(alunos);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AlunoId,Matricula,NomeCompleto,CPF,DataNascimento,TurmaId,EscolaId")] Alunos alunos)
        {
            if (id != alunos.AlunoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunosExists(alunos.AlunoId))
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
            ViewData["EscolaId"] = new SelectList(_context.Escolas, "EscolaId", "EscolaId", alunos.EscolaId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "TurmaId", alunos.TurmaId);
            return View(alunos);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var alunos = await _context.Alunos
                .Include(a => a.Escolas)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (alunos == null)
            {
                return NotFound();
            }

            return View(alunos);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Alunos == null)
            {
                return Problem("Entity set 'AppDbContext.Alunos'  is null.");
            }
            var alunos = await _context.Alunos.FindAsync(id);
            if (alunos != null)
            {
                _context.Alunos.Remove(alunos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunosExists(Guid id)
        {
          return _context.Alunos.Any(e => e.AlunoId == id);
        }
    }
}

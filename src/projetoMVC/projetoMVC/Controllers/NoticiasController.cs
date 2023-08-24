using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetoMVC.Data;
using projetoMVC.Models;

namespace projetoMVC.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly projetoMVCContext _context;

        public NoticiasController(projetoMVCContext context)
        {
            _context = context;
        }

        // GET: Noticias
        public async Task<IActionResult> Index()
        {
              return _context.NoticiasModel != null ? 
                          View(await _context.NoticiasModel.ToListAsync()) :
                          Problem("Entity set 'projetoMVCContext.NoticiasModel'  is null.");
        }

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NoticiasModel == null)
            {
                return NotFound();
            }

            var noticiasModel = await _context.NoticiasModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticiasModel == null)
            {
                return NotFound();
            }

            return View(noticiasModel);
        }

        // GET: Noticias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,SubTitulo,Manchete,Texto,Data,Contador")] NoticiasModel noticiasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticiasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticiasModel);
        }

        // GET: Noticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NoticiasModel == null)
            {
                return NotFound();
            }

            var noticiasModel = await _context.NoticiasModel.FindAsync(id);
            if (noticiasModel == null)
            {
                return NotFound();
            }
            return View(noticiasModel);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,SubTitulo,Manchete,Texto,Data,Contador")] NoticiasModel noticiasModel)
        {
            if (id != noticiasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticiasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiasModelExists(noticiasModel.Id))
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
            return View(noticiasModel);
        }

        // GET: Noticias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NoticiasModel == null)
            {
                return NotFound();
            }

            var noticiasModel = await _context.NoticiasModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticiasModel == null)
            {
                return NotFound();
            }

            return View(noticiasModel);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NoticiasModel == null)
            {
                return Problem("Entity set 'projetoMVCContext.NoticiasModel'  is null.");
            }
            var noticiasModel = await _context.NoticiasModel.FindAsync(id);
            if (noticiasModel != null)
            {
                _context.NoticiasModel.Remove(noticiasModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiasModelExists(int id)
        {
          return (_context.NoticiasModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

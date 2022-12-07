using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieTime.Data;
using MovieTime.Models;

namespace MovieTime.Controllers
{
    public class DocumentalesController : Controller
    {
        private readonly MovieTimeContext _context;

        public DocumentalesController(MovieTimeContext context)
        {
            _context = context;
        }

        // GET: Documentales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documentales.ToListAsync());
        }

        // GET: Documentales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentales = await _context.Documentales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentales == null)
            {
                return NotFound();
            }

            return View(documentales);
        }

        // GET: Documentales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documentales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Fecha,Genero,Precio")] Documentales documentales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentales);
        }

        // GET: Documentales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentales = await _context.Documentales.FindAsync(id);
            if (documentales == null)
            {
                return NotFound();
            }
            return View(documentales);
        }

        // POST: Documentales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Fecha,Genero,Precio")] Documentales documentales)
        {
            if (id != documentales.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentalesExists(documentales.Id))
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
            return View(documentales);
        }

        // GET: Documentales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentales = await _context.Documentales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentales == null)
            {
                return NotFound();
            }

            return View(documentales);
        }

        // POST: Documentales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentales = await _context.Documentales.FindAsync(id);
            _context.Documentales.Remove(documentales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentalesExists(int id)
        {
            return _context.Documentales.Any(e => e.Id == id);
        }
    }
}

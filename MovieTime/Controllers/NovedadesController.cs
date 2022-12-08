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
    public class NovedadesController : Controller
    {
        private readonly MovieTimeContext _context;

        public NovedadesController(MovieTimeContext context)
        {
            _context = context;
        }

        // GET: Novedades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Novedades.ToListAsync());
        }

        // GET: Novedades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novedades = await _context.Novedades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (novedades == null)
            {
                return NotFound();
            }

            return View(novedades);
        }

        // GET: Novedades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Novedades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Fecha,Genero,Parrafo")] Novedades novedades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novedades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(novedades);
        }

        // GET: Novedades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novedades = await _context.Novedades.FindAsync(id);
            if (novedades == null)
            {
                return NotFound();
            }
            return View(novedades);
        }

        // POST: Novedades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Fecha,Genero,Parrafo")] Novedades novedades)
        {
            if (id != novedades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novedades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovedadesExists(novedades.Id))
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
            return View(novedades);
        }

        // GET: Novedades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novedades = await _context.Novedades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (novedades == null)
            {
                return NotFound();
            }

            return View(novedades);
        }

        // POST: Novedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var novedades = await _context.Novedades.FindAsync(id);
            _context.Novedades.Remove(novedades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovedadesExists(int id)
        {
            return _context.Novedades.Any(e => e.Id == id);
        }
    }
}

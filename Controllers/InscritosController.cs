using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeShare.Web.Data;

namespace WeShare.Web.Controllers
{
    public class InscritosController : Controller
    {
        private readonly WSContext _context;

        public InscritosController(WSContext context)
        {
            _context = context;
        }

        // GET: Inscritos
        public async Task<IActionResult> Index()
        {
            var wSContext = _context.InscritosCanal.Include(i => i.CanalNavigation).Include(i => i.UserNavigation);
            return View(await wSContext.ToListAsync());
        }

        // GET: Inscritos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscritosCanal = await _context.InscritosCanal
                .Include(i => i.CanalNavigation)
                .Include(i => i.UserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscritosCanal == null)
            {
                return NotFound();
            }

            return View(inscritosCanal);
        }

        // GET: Inscritos/Create
        public IActionResult Create()
        {
            ViewData["Canal"] = new SelectList(_context.Canal, "Id", "Id");
            ViewData["User"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Inscritos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Canal,User,Notificar")] InscritosCanal inscritosCanal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscritosCanal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Canal"] = new SelectList(_context.Canal, "Id", "Id", inscritosCanal.Canal);
            ViewData["User"] = new SelectList(_context.User, "Id", "Id", inscritosCanal.User);
            return View(inscritosCanal);
        }

        // GET: Inscritos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscritosCanal = await _context.InscritosCanal.FindAsync(id);
            if (inscritosCanal == null)
            {
                return NotFound();
            }
            ViewData["Canal"] = new SelectList(_context.Canal, "Id", "Id", inscritosCanal.Canal);
            ViewData["User"] = new SelectList(_context.User, "Id", "Id", inscritosCanal.User);
            return View(inscritosCanal);
        }

        // POST: Inscritos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Canal,User,Notificar")] InscritosCanal inscritosCanal)
        {
            if (id != inscritosCanal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscritosCanal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscritosCanalExists(inscritosCanal.Id))
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
            ViewData["Canal"] = new SelectList(_context.Canal, "Id", "Id", inscritosCanal.Canal);
            ViewData["User"] = new SelectList(_context.User, "Id", "Id", inscritosCanal.User);
            return View(inscritosCanal);
        }

        // GET: Inscritos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscritosCanal = await _context.InscritosCanal
                .Include(i => i.CanalNavigation)
                .Include(i => i.UserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscritosCanal == null)
            {
                return NotFound();
            }

            return View(inscritosCanal);
        }

        // POST: Inscritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscritosCanal = await _context.InscritosCanal.FindAsync(id);
            _context.InscritosCanal.Remove(inscritosCanal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscritosCanalExists(int id)
        {
            return _context.InscritosCanal.Any(e => e.Id == id);
        }
    }
}

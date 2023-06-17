using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectDRXTransports.Data;
using ProiectDRXTransports.Models;

namespace ProiectDRXTransports.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GatesController : Controller
    {
        private readonly ProiectDRXTransportsContext _context;

        public GatesController(ProiectDRXTransportsContext context)
        {
            _context = context;
        }

        // GET: Gates
        public async Task<IActionResult> Index()
        {
            var proiectDRXTransportsContext = _context.GateModel.Include(g => g.LocationModel);
            return View(await proiectDRXTransportsContext.ToListAsync());
        }

        // GET: Gates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GateModel == null)
            {
                return NotFound();
            }

            var gateModel = await _context.GateModel
                .Include(g => g.LocationModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gateModel == null)
            {
                return NotFound();
            }

            return View(gateModel);
        }

        // GET: Gates/Create
        public IActionResult Create()
        {
            ViewData["LocationModelId"] = new SelectList(_context.LocationModel, "Id", "Id");
            return View();
        }

        // POST: Gates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LocationModelId")] GateModel gateModel)
        {
            if (true)
            {
                _context.Add(gateModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationModelId"] = new SelectList(_context.LocationModel, "Id", "Id", gateModel.LocationModelId);
            return View(gateModel);
        }

        // GET: Gates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GateModel == null)
            {
                return NotFound();
            }

            var gateModel = await _context.GateModel.FindAsync(id);
            if (gateModel == null)
            {
                return NotFound();
            }
            ViewData["LocationModelId"] = new SelectList(_context.LocationModel, "Id", "Id", gateModel.LocationModelId);
            return View(gateModel);
        }

        // POST: Gates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocationModelId")] GateModel gateModel)
        {
            if (id != gateModel.Id)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(gateModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GateModelExists(gateModel.Id))
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
            ViewData["LocationModelId"] = new SelectList(_context.LocationModel, "Id", "Id", gateModel.LocationModelId);
            return View(gateModel);
        }

        // GET: Gates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GateModel == null)
            {
                return NotFound();
            }

            var gateModel = await _context.GateModel
                .Include(g => g.LocationModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gateModel == null)
            {
                return NotFound();
            }

            return View(gateModel);
        }

        // POST: Gates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GateModel == null)
            {
                return Problem("Entity set 'ProiectDRXTransportsContext.GateModel'  is null.");
            }
            var gateModel = await _context.GateModel.FindAsync(id);
            if (gateModel != null)
            {
                _context.GateModel.Remove(gateModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GateModelExists(int id)
        {
          return (_context.GateModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

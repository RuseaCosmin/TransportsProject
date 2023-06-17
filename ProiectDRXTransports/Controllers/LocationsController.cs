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
    public class LocationsController : Controller
    {
        private readonly ProiectDRXTransportsContext _context;

        public LocationsController(ProiectDRXTransportsContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
              return _context.LocationModel != null ? 
                          View(await _context.LocationModel.ToListAsync()) :
                          Problem("Entity set 'ProiectDRXTransportsContext.LocationModel'  is null.");
        }
        public List<LocationModel> GetLocations()
        {
            return _context.LocationModel.ToList();
        }
        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LocationModel == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationModel == null)
            {
                return NotFound();
            }

            return View(locationModel);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adress")] LocationModel locationModel)
        {
            if (ModelState.IsValid)
            {

                _context.Add(locationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationModel);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LocationModel == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel.FindAsync(id);
            if (locationModel == null)
            {
                return NotFound();
            }
            return View(locationModel);
        }

        // POST: Locations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adress")] LocationModel locationModel)
        {
            if (id != locationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationModelExists(locationModel.Id))
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
            return View(locationModel);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LocationModel == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationModel == null)
            {
                return NotFound();
            }

            return View(locationModel);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LocationModel == null)
            {
                return Problem("Entity set 'ProiectDRXTransportsContext.LocationModel'  is null.");
            }
            var locationModel = await _context.LocationModel.FindAsync(id);
            if (locationModel != null)
            {
                _context.LocationModel.Remove(locationModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationModelExists(int id)
        {
          return (_context.LocationModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

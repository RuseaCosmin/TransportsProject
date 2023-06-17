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
    public class DriversController : Controller
    {
        private readonly ProiectDRXTransportsContext _context;

        public DriversController(ProiectDRXTransportsContext context)
        {
            _context = context;
        }

        // GET: Drivers
        public async Task<IActionResult> Index()
        {
              return _context.DriverModel != null ? 
                          View(await _context.DriverModel.ToListAsync()) :
                          Problem("Entity set 'ProiectDRXTransportsContext.DriverModel'  is null.");
        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DriverModel == null)
            {
                return NotFound();
            }

            var driverModel = await _context.DriverModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverModel == null)
            {
                return NotFound();
            }

            return View(driverModel);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,PhoneNr")] DriverModel driverModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driverModel);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DriverModel == null)
            {
                return NotFound();
            }

            var driverModel = await _context.DriverModel.FindAsync(id);
            if (driverModel == null)
            {
                return NotFound();
            }
            return View(driverModel);
        }

        // POST: Drivers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,PhoneNr")] DriverModel driverModel)
        {
            if (id != driverModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverModelExists(driverModel.Id))
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
            return View(driverModel);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DriverModel == null)
            {
                return NotFound();
            }

            var driverModel = await _context.DriverModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverModel == null)
            {
                return NotFound();
            }

            return View(driverModel);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DriverModel == null)
            {
                return Problem("Entity set 'ProiectDRXTransportsContext.DriverModel'  is null.");
            }
            var driverModel = await _context.DriverModel.FindAsync(id);
            if (driverModel != null)
            {
                try
                {
                    _context.DriverModel.Remove(driverModel);
                }
                catch (DbUpdateException e)
                {
                    TempData["DeleteError"] = e.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverModelExists(int id)
        {
          return (_context.DriverModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

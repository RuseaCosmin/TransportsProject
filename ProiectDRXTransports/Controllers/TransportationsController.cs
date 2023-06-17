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
    
    public class TransportationsController : Controller
    {
        private readonly ProiectDRXTransportsContext _context;

        public TransportationsController(ProiectDRXTransportsContext context)
        {
            _context = context;
        }

        // GET: Transportations
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var proiectDRXTransportsContext = _context.TransportationModel.Include(t => t.DriverModel).Include(t => t.LocationModel);
            return View(await proiectDRXTransportsContext.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DisplayLocationsDrivers()
        {
            TransportationDriverLocationModel transportationDriverLocationModel = new TransportationDriverLocationModel();
            transportationDriverLocationModel.transportationModels = _context.TransportationModel.Include(t => t.DriverModel).Include(t => t.LocationModel);
            transportationDriverLocationModel.locationModels = _context.LocationModel;
            transportationDriverLocationModel.driverModels = _context.DriverModel;
            return View(transportationDriverLocationModel);
        }
        // GET: Transportations/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransportationModel == null)
            {
                return NotFound();
            }

            var transportationModel = await _context.TransportationModel
                .Include(t => t.DriverModel)
                .Include(t => t.LocationModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationModel == null)
            {
                return NotFound();
            }

            return View(transportationModel);
        }
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DetailsUser(int? id)
        {
            if (id == null || _context.TransportationModel == null)
            {
                return NotFound();
            }

            var transportationModel = await _context.TransportationModel
                .Include(t => t.DriverModel)
                .Include(t => t.LocationModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationModel == null)
            {
                return NotFound();
            }

            return View(transportationModel);
        }
        // GET: Transportations/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["DriverModelId"] = new SelectList(_context.DriverModel, "Id", "Id");
            ViewData["LocationModelId"] = new SelectList(_context.LocationModel, "Id", "Id");
            var reference = new TransportationLocationDriverModel();
            reference.driverModels = _context.DriverModel;
            reference.locationModels = _context.LocationModel;
            return View(reference);
        }

        // POST: Transportations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,StatusTransport,SentDate,ArrivalDate,DriverModelId,LocationModelId")] TransportationModel transportationModel)
        {
            
            if (transportationModel.SentDate.CompareTo(transportationModel.ArrivalDate)<=0)
            {
                _context.Add(transportationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DateError"] = "Sent Date Is Greater Than The Arrival Date";
            ViewData["DriverModelId"] = new SelectList(_context.DriverModel, "Id", "Id", transportationModel.DriverModelId);
            ViewData["LocationModelId"] = new SelectList(_context.LocationModel, "Id", "Id", transportationModel.LocationModelId);
            TransportationLocationDriverModel model = new TransportationLocationDriverModel() { transportationModel=transportationModel, driverModels=_context.DriverModel, locationModels=_context.LocationModel};
            return View(model);
        }

        // GET: Transportations/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransportationModel == null)
            {
                return NotFound();
            }

            var transportationModel = await _context.TransportationModel.FindAsync(id);
            if (transportationModel == null)
            {
                return NotFound();
            }
            ViewData["DriverModelId"] = new SelectList(_context.DriverModel, "Id", "Id", transportationModel.DriverModelId);
            ViewData["LocationModelId"] = new SelectList(_context.LocationModel, "Id", "Id", transportationModel.LocationModelId);
            return View(transportationModel);
        }

        // POST: Transportations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusTransport,SentDate,ArrivalDate,DriverModelId,LocationModelId")] TransportationModel transportationModel)
        {
            if (id != transportationModel.Id)
            {
                return NotFound();
            }

            if (transportationModel.SentDate.CompareTo(transportationModel.ArrivalDate) <= 0)
            {
                try
                {
                    _context.Update(transportationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationModelExists(transportationModel.Id))
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
            ViewData["DateError"] = "Sent Date Is Greater Than The Arrival Date";
            ViewData["DriverModelId"] = new SelectList(_context.DriverModel, "Id", "Id", transportationModel.DriverModelId);
            ViewData["LocationModelId"] = new SelectList(_context.LocationModel, "Id", "Id", transportationModel.LocationModelId);
            return View(transportationModel);
        }

        // GET: Transportations/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransportationModel == null)
            {
                return NotFound();
            }

            var transportationModel = await _context.TransportationModel
                .Include(t => t.DriverModel)
                .Include(t => t.LocationModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationModel == null)
            {
                return NotFound();
            }

            return View(transportationModel);
        }

        // POST: Transportations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransportationModel == null)
            {
                return Problem("Entity set 'ProiectDRXTransportsContext.TransportationModel'  is null.");
            }
            var transportationModel = await _context.TransportationModel.FindAsync(id);
            if (transportationModel != null)
            {
                _context.TransportationModel.Remove(transportationModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportationModelExists(int id)
        {
          return (_context.TransportationModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

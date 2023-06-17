using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Html2pdf;
using iText.IO.Source;
using iText.Kernel;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectDRXTransports.Data;
using ProiectDRXTransports.Models;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using iText.Kernel.Font;
using iText.IO.Font;

namespace ProiectDRXTransports.Controllers
{
    [Authorize(Roles = "User")]
    public class TransportationSchedulesController : Controller
    {
        private readonly ProiectDRXTransportsContext _context;
        private readonly UserManager<TransportationUser> _userManager;
        public TransportationSchedulesController(ProiectDRXTransportsContext context, UserManager<TransportationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        [HttpPost]
        public ActionResult ToPDF()
        {

            var proiectDRXTransportsContext = _context.TransportationScheduleModel.Include(t => t.GateModel).
                                                Include(t => t.TransportationModel).
                                                Include(t => t.TransportationModel.DriverModel).
                                                Include(t => t.TransportationModel.LocationModel).
                                                    Where(t => t.TransportationModel.LocationModelId == _userManager.
                                                        GetUserAsync(HttpContext.User).Result.LocationId).ToArray();
            StringBuilder sb = new StringBuilder();

            //Table start.
            sb.Append("<table border='1' cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-family: Arial; font-size: 14pt;'>");

            //Building the Header row.
            sb.Append("<tr>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Delivery Time</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Gate ID</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Adress</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Driver Last Name</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Driver First Name</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Phone Number</th>");

            sb.Append("</tr>");

            //Building the Data rows.
            for (int i = 0; i < proiectDRXTransportsContext.Count(); i++)
            {
                
                sb.Append("<tr>");
                
                
                    //Append data.
                    sb.Append("<td style='border: 1px solid #ccc'>");
                    sb.Append(proiectDRXTransportsContext[i].DeliveryTime);
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(proiectDRXTransportsContext[i].GateModelId);
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(proiectDRXTransportsContext[i].TransportationModel.LocationModel.Adress);
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(proiectDRXTransportsContext[i].TransportationModel.DriverModel.LastName);
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(proiectDRXTransportsContext[i].TransportationModel.DriverModel.FirstName);
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(proiectDRXTransportsContext[i].TransportationModel.DriverModel.PhoneNr);
                    sb.Append("</td>");
                
                sb.Append("</tr>");
            }

            //Table end.
            sb.Append("</table>");
            
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString())))
            {

                ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                PdfWriter writer = new PdfWriter(byteArrayOutputStream);
                PdfDocument pdfDocument = new PdfDocument(writer);
                pdfDocument.SetDefaultPageSize(PageSize.A4);
                HtmlConverter.ConvertToPdf(stream, pdfDocument);
                pdfDocument.Close();
                return File(byteArrayOutputStream.ToArray(), "ProiectDRXTrasports/PDF", "Schedule Location "+ _userManager.GetUserAsync(HttpContext.User).Result.LocationId+".pdf");
            }
        }
        public ActionResult ToPDFFiltered()
        {
            
            var proiectDRXTransportsContext = _context.TransportationScheduleModel!.Include(t => t.GateModel).Include(t => t.TransportationModel).Include(t => t.TransportationModel.DriverModel).Include(t => t.TransportationModel.LocationModel).Where(t => t.GateModelId == (int)TempData["GateId"]).Where(t => t.TransportationModel.LocationModelId == (int)TempData["LocationId"]).ToArray();
            StringBuilder sb = new StringBuilder();

            //Table start.
            sb.Append("<table border='1' cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-family: Arial; font-size: 14pt;'>");

            //Building the Header row.
            sb.Append("<tr>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Delivery Time</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Gate ID</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Adress</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Driver Last Name</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Driver First Name</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Phone Number</th>");

            sb.Append("</tr>");

            //Building the Data rows.
            for (int i = 0; i < proiectDRXTransportsContext.Count(); i++)
            {

                sb.Append("<tr>");


                //Append data.
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(proiectDRXTransportsContext[i].DeliveryTime);
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(proiectDRXTransportsContext[i].GateModelId);
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(proiectDRXTransportsContext[i].TransportationModel.LocationModel.Adress);
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(proiectDRXTransportsContext[i].TransportationModel.DriverModel.LastName);
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(proiectDRXTransportsContext[i].TransportationModel.DriverModel.FirstName);
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(proiectDRXTransportsContext[i].TransportationModel.DriverModel.PhoneNr);
                sb.Append("</td>");

                sb.Append("</tr>");
            }

            //Table end.
            sb.Append("</table>");
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString())))
            {
                ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                PdfWriter writer = new PdfWriter(byteArrayOutputStream);
                PdfDocument pdfDocument = new PdfDocument(writer);
                pdfDocument.SetDefaultPageSize(PageSize.A4);
                HtmlConverter.ConvertToPdf(stream, pdfDocument);
                pdfDocument.Close();
                return File(byteArrayOutputStream.ToArray(), "ProiectDRXTrasports/PDF", "Schedule Location "+TempData["LocationId"]+" Gate "+TempData["GateId"]+".pdf");
            }
        }

        // GET: TransportationSchedules
        public async Task<IActionResult> Index()
        {
            var proiectDRXTransportsContext = _context.TransportationScheduleModel.Include(t => t.GateModel).Include(t => t.TransportationModel).Include(t => t.TransportationModel.DriverModel).Include(t => t.TransportationModel.LocationModel).Where(t => t.TransportationModel.LocationModelId== _userManager.GetUserAsync(HttpContext.User).Result.LocationId);
            return View(await proiectDRXTransportsContext.ToListAsync());
        }


        public async Task<IActionResult> FilteredDisplay(FilterModel filter)
        {
            var proiectDRXTransportsContext = _context.TransportationScheduleModel.Include(t => t.GateModel).Include(t => t.TransportationModel).Include(t => t.TransportationModel.DriverModel).Include(t => t.TransportationModel.LocationModel)
                                                .Where(t => t.GateModelId==filter.GateId).Where(t => t.TransportationModel.LocationModelId==filter.LocationId);
            TempData["GateId"] = filter.GateId;
            TempData["LocationId"] = filter.LocationId;
            return View(await proiectDRXTransportsContext.ToListAsync());
        }
        public IActionResult FilterByLocationAndGate()
        {
            return View();
        }
        public IActionResult FilterLocationV2()
        {
            ViewData["Locations"] = new SelectList(_context.LocationModel,"Adress","Adress");

            return View();
        }
        [HttpPost]
        public IActionResult FilterLocationV2(LocationModel location)
        {
            TempData["Location"] = location.Adress;

            return RedirectToAction(nameof(FilterGateV2));
        }

        public IActionResult FilterGateV2()
        {
            var gates = _context.GateModel.Where(t => t.LocationModel.Adress == TempData["Location"]);
            ViewData["LocationId"] = new SelectList(_context.LocationModel.Where(t => t.Adress == TempData["Location"]),"Id","Id");

            FilterModel filter = new FilterModel() { LocationId = _context.LocationModel.Where(t => t.Adress == TempData["Location"]).First().Id };
            ViewData["Gates"] = new SelectList(gates, "Id", "Id");
            return View(filter);
        }
        // GET: TransportationSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransportationScheduleModel == null)
            {
                return NotFound();
            }

            var transportationScheduleModel = await _context.TransportationScheduleModel
                .Include(t => t.GateModel)
                .Include(t => t.TransportationModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationScheduleModel == null)
            {
                return NotFound();
            }

            return View(transportationScheduleModel);
        }

        // GET: TransportationSchedules/Create
        public IActionResult Create()
        {
            ViewData["GateModelId"] = new SelectList(_context.GateModel?
                                                                .Where(t=>t.LocationModelId== _userManager
                                                                .GetUserAsync(HttpContext.User).Result.LocationId), "Id", "Id");
            ViewData["TransportationModelId"] = new SelectList(_context.TransportationModel?
                                                                .Where(t=>t.LocationModelId== _userManager
                                                                .GetUserAsync(HttpContext.User).Result.LocationId), "Id", "Id");
            ScheduleGatesTransportationsModel schedule = new ScheduleGatesTransportationsModel();
            schedule.TransportationModels = _context.TransportationModel.Where(t => t.LocationModelId == _userManager
                                                                                .GetUserAsync(HttpContext.User).Result.LocationId);
            schedule.GateModels = _context.GateModel.Where(t => t.LocationModelId == _userManager
                                                                                .GetUserAsync(HttpContext.User).Result.LocationId);
            return View(schedule);
        }

        // POST: TransportationSchedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeliveryTime,GateModelId,TransportationModelId")] TransportationScheduleModel transportationScheduleModel)
        {    
            var transportation = _context.TransportationModel?
                                        .Where(t => t.Id==transportationScheduleModel.TransportationModelId);
            var gate = _context.GateModel?
                                        .Where(t => t.Id == transportationScheduleModel.GateModelId);
            ScheduleGatesTransportationsModel schedule = new ScheduleGatesTransportationsModel();
            schedule.TransportationScheduleModel = transportationScheduleModel;
            schedule.TransportationModels = _context.TransportationModel.Where(t => t.LocationModelId == _userManager
                                                                                .GetUserAsync(HttpContext.User).Result.LocationId);
            schedule.GateModels = _context.GateModel.Where(t => t.LocationModelId == _userManager
                                                                                .GetUserAsync(HttpContext.User).Result.LocationId);

            ViewData["GateModelId"] = new SelectList(_context.GateModel?
                .Where(t => t.LocationModelId == _userManager
                .GetUserAsync(HttpContext.User).Result.LocationId), "Id", "Id", transportationScheduleModel.GateModelId);
            ViewData["TransportationModelId"] = new SelectList(_context.TransportationModel?
                .Where(t => t.LocationModelId == _userManager
                .GetUserAsync(HttpContext.User).Result.LocationId), "Id", "Id", transportationScheduleModel.TransportationModelId);
            
            if (transportation.First().StatusTransport == "Delivered")
            {
                ViewData["ErrorMsg"] = "Can Not Schedule A Delivered Transport";
                return View(schedule);
            }

            if (gate.First().LocationModelId == transportation.First().LocationModelId)
            {
                _context.Add(transportationScheduleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["ErrorMsg"] = "Selected Gate Can Not Be Found At The Destination Of The Selected Transport";
            return View(schedule);
        }

        // GET: TransportationSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransportationScheduleModel == null)
            {
                return NotFound();
            }

            var transportationScheduleModel = await _context.TransportationScheduleModel.FindAsync(id);
            if (transportationScheduleModel == null)
            {
                return NotFound();
            }
            ViewData["GateModelId"] = new SelectList(_context.GateModel.Where(t => t.LocationModelId == _userManager.GetUserAsync(HttpContext.User).Result.LocationId), "Id", "Id");
            ViewData["TransportationModelId"] = new SelectList(_context.TransportationModel.Where(t => t.LocationModelId == _userManager.GetUserAsync(HttpContext.User).Result.LocationId), "Id", "Id");
            ScheduleGatesTransportationsModel schedule = new ScheduleGatesTransportationsModel();
            schedule.TransportationScheduleModel = transportationScheduleModel;
            schedule.TransportationModels = _context.TransportationModel.Where(t => t.LocationModelId == _userManager.GetUserAsync(HttpContext.User).Result.LocationId);
            schedule.GateModels = _context.GateModel.Where(t => t.LocationModelId == _userManager.GetUserAsync(HttpContext.User).Result.LocationId);
            return View(schedule);

        }

        // POST: TransportationSchedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeliveryTime,GateModelId,TransportationModelId")] TransportationScheduleModel transportationScheduleModel)
        {
            if (id != transportationScheduleModel.Id)
            {
                return NotFound();
            }

                var transportation = _context.TransportationModel.Where(t => t.Id == transportationScheduleModel.TransportationModelId);
                var gate = _context.GateModel.Where(t => t.Id == transportationScheduleModel.GateModelId);
                int ok = 0;
                ScheduleGatesTransportationsModel schedule = new ScheduleGatesTransportationsModel();
                schedule.TransportationScheduleModel = transportationScheduleModel;
                schedule.TransportationModels = _context.TransportationModel;
                schedule.GateModels = _context.GateModel;

            if (transportation.First().StatusTransport == "Delivered")
            {
                ViewData["EditErrorMsg"] = "Can Not Schedule A Delivered Transport";
                return RedirectToAction(nameof(Edit),id);
            }
            if (gate.First().LocationModelId == transportation.First().LocationModelId)
                {
                    _context.Update(transportationScheduleModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["GateModelId"] = new SelectList(_context.GateModel, "Id", "Id", transportationScheduleModel.GateModelId);
                ViewData["TransportationModelId"] = new SelectList(_context.TransportationModel, "Id", "Id", transportationScheduleModel.TransportationModelId);
                ViewData["EditErrorMsg"] = "Selected Gate Can Not Be Found At The Destination Of The Selected Transport";
                return View(schedule);

                
            

        }

        // GET: TransportationSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransportationScheduleModel == null)
            {
                return NotFound();
            }

            var transportationScheduleModel = await _context.TransportationScheduleModel
                .Include(t => t.GateModel)
                .Include(t => t.TransportationModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationScheduleModel == null)
            {
                return NotFound();
            }

            return View(transportationScheduleModel);
        }

        // POST: TransportationSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransportationScheduleModel == null)
            {
                return Problem("Entity set 'ProiectDRXTransportsContext.TransportationScheduleModel'  is null.");
            }
            var transportationScheduleModel = await _context.TransportationScheduleModel.FindAsync(id);
            if (transportationScheduleModel != null)
            {
                _context.TransportationScheduleModel.Remove(transportationScheduleModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportationScheduleModelExists(int id)
        {
          return (_context.TransportationScheduleModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

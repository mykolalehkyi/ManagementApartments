using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagementApartments.Data;
using ManagementApartments.Data.Models;
using ManagementApartments.Data.Service.Interface;
using X.PagedList;
using ManagementApartments.Data.Config;
using Microsoft.AspNetCore.Http;
using System.IO;
using ManagementApartments.Data.DTO;
using System.Net;

namespace ManagementApartments.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly IApartmentsService apartmentService;
        private readonly ManagementApartmentDbContext _context;

        public ApartmentsController(IApartmentsService apartmentService, ManagementApartmentDbContext context)
        {
            this.apartmentService = apartmentService;
            _context = context;
        }

        // GET: Apartments
        public async Task<IActionResult> Index(int page = 1)
        {
            IPagedList<Apartment> apartments = apartmentService.GetByPage(page, 9);
            return View(apartments);
        }

        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // GET: Apartments/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Apartments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,ApartmentPrice,RentPrice,Area")] ApartmentCreateDTO apartment)
        {
            if (ModelState.IsValid)
            {
                apartmentService.Create(apartment, this.User.GetLoggedInUserId<string>());
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", apartment.ApplicationUserId);
            return View(apartment);
        }

        public ActionResult SaveImage(IFormFile file, int apartmentId)
        {
            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);

                List<string> allowedExtensions = new List<string>()
                {
                    ".png", ".bmp", ".svg", ".jpg", ".jpeg", ".gif"
                };

                if (!allowedExtensions.Contains(extension))
                {
                    return Json(new SaveImageFeedbackDTO
                    {
                        StatusSuccess = false,
                        Message = "Only .png .bmp .svg .jpg .jpeg .gif file types are allowed",
                        Title = "File type not supported."
                    });
                }
                string logoAsBase64 = this.apartmentService.SaveImage(file, apartmentId);

                return Json(new SaveImageFeedbackDTO
                {
                    StatusSuccess = true,
                    LogoAsBase64 = logoAsBase64
                },
                    new { MaxJsonLength = Int32.MaxValue });
            }
            else
            {
                return Json(new SaveImageFeedbackDTO
                {
                    StatusSuccess = false,
                    Message = "Only .png .bmp .svg .jpg .jpeg .gif file types are allowed",
                    Title = "File type not supported."
                });
            }
        }

        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", apartment.ApplicationUserId);
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ApartmentPrice,RentPrice,Area,ApplicationUserId")] Apartment apartment)
        {
            if (id != apartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentExists(apartment.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", apartment.ApplicationUserId);
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartment.FindAsync(id);
            _context.Apartment.Remove(apartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartment.Any(e => e.Id == id);
        }
    }
}

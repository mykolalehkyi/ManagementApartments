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

namespace ManagementApartments.Controllers
{
    public class UtilitiesController : Controller
    {
        private readonly IUtilitiesService utilitiesService;

        public UtilitiesController(IUtilitiesService utilitiesService)
        {
            this.utilitiesService = utilitiesService;
        }

        // GET: Utilities
        public IActionResult Index(int apartmentId)
        {
            ViewData["ApartmentId"] = apartmentId;
            return View(utilitiesService.GetList(apartmentId));
        }

        // GET: Utilities/Create
        public IActionResult Create(int apartmentId)
        {
            ViewData["ApartmentId"] = apartmentId;
            return View();
        }

        // POST: Utilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,UtilityType,Date,Price,ApartmentId")] Utility utility)
        {
            if (ModelState.IsValid)
            {
                utilitiesService.Create(utility);
                ViewData["ApartmentId"] = utility.ApartmentId;
                return RedirectToAction("Index", "Utilities", new { apartmentId = utility.ApartmentId });
            }
            ViewData["ApartmentId"] = utility.ApartmentId;
            return View(utility);
        }

        // GET: Utilities/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utility = utilitiesService.Get(id ?? 0);
            ViewData["ApartmentId"] = utility.ApartmentId;
            return View(utility);
        }

        // POST: Utilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,UtilityType,Date,Price,ApartmentId")] Utility utility)
        {
            if (id != utility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                utilitiesService.Update(utility);
                return RedirectToAction("Index", "Utilities", new { apartmentId = utility.ApartmentId });
            }
            ViewData["ApartmentId"] = utility.ApartmentId;
            return View(utility);
        }

        // GET: Utilities/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utility = utilitiesService.Get(id ?? 0);

            return View(utility);
        }

        // POST: Utilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var utility = utilitiesService.Get(id);
            utilitiesService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

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
    public class RentPeriodsController : Controller
    {
        private readonly IRentPeriodsService rentPeriodsService;
        private readonly ITenantsService tenantsService;

        public RentPeriodsController(IRentPeriodsService rentPeriodsService, ITenantsService tenantsService)
        {
            this.rentPeriodsService = rentPeriodsService;
            this.tenantsService = tenantsService;
        }

        // GET: RentPeriods
        public IActionResult Index(int apartmentId)
        {
            ViewData["ApartmentId"] = apartmentId;
            return View(rentPeriodsService.GetList(apartmentId));
        }

        // GET: RentPeriods/Create
        public IActionResult Create(int apartmentId)
        {
            ViewData["ApartmentId"] = apartmentId;
            return View();
        }

        // POST: RentPeriods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Start,End,Price,Payed,ApartmentId")] RentPeriod rentPeriod)
        {
            if (ModelState.IsValid)
            {
                rentPeriodsService.Create(rentPeriod);
                return RedirectToAction("Index", "RentPeriods", new { apartmentId = rentPeriod.ApartmentId });
            }
            ViewData["ApartmentId"] = rentPeriod.ApartmentId;
            return View(rentPeriod);
        }

        // GET: RentPeriods/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentPeriod = rentPeriodsService.Get(id??0);
            ViewData["ApartmentId"] = rentPeriod.ApartmentId;
            ViewData["Tenants"] = rentPeriodsService.GetTenants(id??0);

            return View(rentPeriod);
        }

        // POST: RentPeriods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Start,End,Price,Payed,ApartmentId")] RentPeriod rentPeriod, List<int> tenantsIds)
        {
            if (id != rentPeriod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                rentPeriodsService.Update(rentPeriod, tenantsIds);
                return RedirectToAction("Index", "RentPeriods", new { apartmentId = rentPeriod.ApartmentId });
            }
            ViewData["ApartmentId"] = rentPeriod.ApartmentId;
            return View(rentPeriod);
        }

        // GET: RentPeriods/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentPeriod = rentPeriodsService.Get(id ?? 0);
            return View(rentPeriod);
        }

        // POST: RentPeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = rentPeriodsService.Get(id);
            rentPeriodsService.Remove(id); 
            return RedirectToAction("Index", "RentPeriods", new { apartmentId = item.ApartmentId });
        }
    }
}

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
    public class ApartmentSpendingsController : Controller
    {
        private readonly IApartmentSpendingsService apartmentSpendingsService;

        public ApartmentSpendingsController(IApartmentSpendingsService apartmentSpendingsService)
        {
            this.apartmentSpendingsService = apartmentSpendingsService;
        }

        // GET: ApartmentSpendings
        public IActionResult Index(int apartmentId)
        {
            ViewData["ApartmentId"] = apartmentId;
            return View(apartmentSpendingsService.GetList(apartmentId));
        }

        // GET: ApartmentSpendings/Create
        public IActionResult Create(int apartmentId)
        {
            ViewData["ApartmentId"] = apartmentId;
            return View();
        }

        // POST: ApartmentSpendings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price,ApartmentId")] ApartmentSpending apartmentSpending)
        {
            if (ModelState.IsValid)
            {
                apartmentSpendingsService.Create(apartmentSpending);
                return RedirectToAction("Index", "ApartmentSpendings", new { apartmentId = apartmentSpending.ApartmentId });
            }
            ViewData["ApartmentId"] = apartmentSpending.ApartmentId;
            return View(apartmentSpending);
        }

        // GET: ApartmentSpendings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentSpending = apartmentSpendingsService.Get(id??0);

            ViewData["ApartmentId"] = apartmentSpending.ApartmentId;
            return View(apartmentSpending);
        }

        // POST: ApartmentSpendings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price,ApartmentId")] ApartmentSpending apartmentSpending)
        {
            if (id != apartmentSpending.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                apartmentSpendingsService.Update(apartmentSpending);
                return RedirectToAction("Index", "ApartmentSpendings", new { apartmentId = apartmentSpending.ApartmentId });
            }
            ViewData["ApartmentId"] = apartmentSpending.ApartmentId;
            return View(apartmentSpending);
        }

        // GET: ApartmentSpendings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentSpending = apartmentSpendingsService.Get(id ?? 0);
            return View(apartmentSpending);
        }

        // POST: ApartmentSpendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ApartmentSpending apartmentSpending = apartmentSpendingsService.Get(id);
            apartmentSpendingsService.Remove(id);
            return RedirectToAction("Index", "ApartmentSpendings", new { apartmentId = apartmentSpending.ApartmentId });
        }
    }
}

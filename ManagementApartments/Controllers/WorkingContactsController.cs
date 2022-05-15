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
using ManagementApartments.Data.Config;

namespace ManagementApartments.Controllers
{
    public class WorkingContactsController : Controller
    {
        private readonly ManagementApartmentDbContext _context;
        private readonly IWorkingContactService workingContactService;

        public WorkingContactsController(ManagementApartmentDbContext context, IWorkingContactService workingContactService)
        {
            _context = context;
            this.workingContactService = workingContactService;
        }

        // GET: WorkingContacts
        public IActionResult Index()
        {
            return View(workingContactService.GetList(this.User.GetLoggedInUserId<string>()));
        }

        // GET: WorkingContacts/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = this.User.GetLoggedInUserId<string>(); 
            return View();
        }

        // POST: WorkingContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,PhoneNumber,ApplicationUserId")] WorkingContact workingContact)
        {
            if (ModelState.IsValid)
            {
                workingContactService.Create(workingContact);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = this.User.GetLoggedInUserId<string>();
            return View(workingContact);
        }

        // GET: WorkingContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingContact = workingContactService.Get(id??0);

            ViewData["ApplicationUserId"] = this.User.GetLoggedInUserId<string>();
            return View(workingContact);
        }

        // POST: WorkingContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,PhoneNumber,ApplicationUserId")] WorkingContact workingContact)
        {
            if (id != workingContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                workingContactService.Update(workingContact);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = this.User.GetLoggedInUserId<string>();
            return View(workingContact);
        }

        // GET: WorkingContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingContact = workingContactService.Get(id ?? 0);
            if (workingContact == null)
            {
                return NotFound();
            }

            return View(workingContact);
        }

        // POST: WorkingContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            workingContactService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

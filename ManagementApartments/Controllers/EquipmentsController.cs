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
    public class EquipmentsController : Controller
    {
        private readonly ManagementApartmentDbContext _context;
        private readonly IEquipmentsService equipmentsService;

        public EquipmentsController(ManagementApartmentDbContext context, IEquipmentsService equipmentsService)
        {
            _context = context;
            this.equipmentsService = equipmentsService;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            var managementApartmentDbContext = _context.Equipment.Include(e => e.Room);
            return View(await managementApartmentDbContext.ToListAsync());
        }


        public ActionResult GetList(int roomId)
        {
            return Json(new { data = equipmentsService.GetList(roomId) });
        }

        // GET: Equipments/Create
        public IActionResult Create(int roomId)
        {
            ViewData["RoomId"] = roomId;
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,RoomId")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                equipmentsService.Create(equipment);
                return RedirectToAction("Edit", "Rooms", new { id = equipment.RoomId });
            }
            ViewData["RoomId"] = equipment.RoomId;
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = equipmentsService.Get(id ?? 0);
            if (equipment == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = equipment.RoomId;
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,RoomId")] Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                equipmentsService.Update(equipment);
                return RedirectToAction("Edit", "Rooms", new { id = equipment.RoomId });
            }
            ViewData["RoomId"] = equipment.RoomId;
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = equipmentsService.Get(id ?? 0);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipment = equipmentsService.Get(id);
            equipmentsService.Remove(id);
            return RedirectToAction("Edit", "Rooms", new { id = equipment.RoomId});
        }

        private bool EquipmentExists(int id)
        {
            return _context.Equipment.Any(e => e.Id == id);
        }
    }
}

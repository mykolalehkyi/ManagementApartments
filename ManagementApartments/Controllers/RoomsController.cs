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
    public class RoomsController : Controller
    {
        private readonly ManagementApartmentDbContext _context;
        private readonly IRoomService roomService;

        public RoomsController(ManagementApartmentDbContext context, IRoomService roomService)
        {
            _context = context;
            this.roomService = roomService;
        }

        public ActionResult GetList(int apartmentId)
        {
            return Json(new { data = roomService.GetList(apartmentId) });
        }

        // GET: Rooms/Create
        public IActionResult Create(int apartmentId)
        {
            ViewData["ApartmentId"] = apartmentId;
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,RoomStyle,Area,ApartmentId")] Room room)
        {
            if (ModelState.IsValid)
            {
                roomService.Create(room);
                return RedirectToAction("Edit","Apartments",new { id = room.ApartmentId});
            }
            ViewData["ApartmentId"] = room.ApartmentId;
            return View(room);
        }

        // GET: Rooms/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = roomService.Get(id??0);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["ApartmentId"] = room.ApartmentId;
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RoomStyle,Area,ApartmentId")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                roomService.Update(room);
                return RedirectToAction("Edit", "Apartments", new { id = room.ApartmentId });
            }
            ViewData["ApartmentId"] = room.ApartmentId;
            return View(room);
        }

        // GET: Rooms/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = roomService.Get(id?? 0);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var room = roomService.Get(id);
            roomService.Remove(id);
            return RedirectToAction("Edit", "Apartments", new { id = room.ApartmentId });
        }

    }
}

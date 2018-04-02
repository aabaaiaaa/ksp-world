using KerbalFlightRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KerbalFlightRegister.Controllers
{
    public class MissionsController : Controller
    {
        FlightDb _db = new FlightDb();

        protected override void Dispose(bool disposing)
        {
            if (disposing) _db.Dispose();
            base.Dispose(disposing);
        }

        // GET: Missions
        public ActionResult Index([Bind(Prefix = "FlightCrewId")] int id)
        {
            var crew = _db.FlightCrew.Find(id);
            return View(crew);
        }

        // GET: Missions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Missions/Create
        public ActionResult Create([Bind(Prefix = "FlightCrewId")] int id)
        {
            return View(new Mission() { FlightCrewId = id });
        }

        // POST: Missions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightCrewId,Description,TargetPlanet")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                _db.Missions.Add(mission);
                _db.SaveChanges();
                return RedirectToAction("Index", new { FlightCrewId = mission.FlightCrewId });
            }

            return View(mission);
        }

        // GET: Missions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Missions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Missions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Missions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

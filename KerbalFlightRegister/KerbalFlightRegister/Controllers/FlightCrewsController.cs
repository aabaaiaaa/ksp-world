using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KerbalFlightRegister.Models;

namespace KerbalFlightRegister.Controllers
{
    public class FlightCrewsController : Controller
    {
        private FlightDb db = new FlightDb();

        public ActionResult MostMissions()
        {
            var mostMissions = (from fc in db.FlightCrew
                                orderby fc.Missions.Count() descending
                                select new FlightCrewMostMissions()
                                {
                                    Name = fc.Name,
                                    NumberOfMissions = fc.Missions.Count()
                                }).AsEnumerable();
            var highestKerbin = mostMissions.First();
            var secondHighest = mostMissions.ElementAt(1);
            highestKerbin.MoreThanNextHighest = highestKerbin.NumberOfMissions - secondHighest?.NumberOfMissions ?? 0;
            highestKerbin.SecondPosition = secondHighest.Name;

            return PartialView("_mostMissionsPartialView", highestKerbin);
        }

        // GET: FlightCrews
        public ActionResult Index()
        {
            return View(db.FlightCrew.ToList());
        }

        // GET: FlightCrews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightCrew flightCrew = db.FlightCrew.Find(id);
            if (flightCrew == null)
            {
                return HttpNotFound();
            }
            return View(flightCrew);
        }

        // GET: FlightCrews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlightCrews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightCrewId,Name,Age,JoinedDate")] FlightCrew flightCrew)
        {
            if (ModelState.IsValid)
            {
                db.FlightCrew.Add(flightCrew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flightCrew);
        }

        // GET: FlightCrews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightCrew flightCrew = db.FlightCrew.Find(id);
            if (flightCrew == null)
            {
                return HttpNotFound();
            }
            return View(flightCrew);
        }

        // POST: FlightCrews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightCrewId,Name,Age,JoinedDate")] FlightCrew flightCrew)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flightCrew).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flightCrew);
        }

        // GET: FlightCrews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightCrew flightCrew = db.FlightCrew.Find(id);
            if (flightCrew == null)
            {
                return HttpNotFound();
            }
            return View(flightCrew);
        }

        // POST: FlightCrews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlightCrew flightCrew = db.FlightCrew.Find(id);
            db.FlightCrew.Remove(flightCrew);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

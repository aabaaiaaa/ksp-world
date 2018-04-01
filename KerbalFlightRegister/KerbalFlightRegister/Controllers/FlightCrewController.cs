using KerbalFlightRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KerbalFlightRegister.Controllers
{
    public class FlightCrewController : Controller
    {
        // GET: FlightCrew
        public ActionResult Index()
        {
            var crew = from fc in _flightCrew select fc;

            return View(crew);
        }

        // GET: FlightCrew/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightCrew/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlightCrew/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightCrew/Edit/5
        public ActionResult Edit(int id)
        {
            var crewEdit = _flightCrew.Single(fc => fc.CrewId == id);
            return View(crewEdit);
        }

        // POST: FlightCrew/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var crewReview = _flightCrew.Single(fc => fc.CrewId == id);
            if (TryUpdateModel(crewReview))
            {
                return RedirectToAction("Index");
            }
            return View(crewReview);
        }

        // GET: FlightCrew/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightCrew/Delete/5
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

        public static List<FlightCrew> _flightCrew = new List<FlightCrew>()
        {
            new FlightCrew()
            {
                CrewId = 1,
                Name = "Jebadiah",
                Age = 30,
                JoinedDate = new DateTime(2009, 1, 1)
            },
            new FlightCrew()
            {
                CrewId = 2,
                Name = "Bill",
                Age = 34,
                JoinedDate = new DateTime(2010, 2, 3)
            },
            new FlightCrew()
            {
                CrewId = 3,
                Name = "Bob",
                Age = 28,
                JoinedDate = new DateTime(2010, 5, 10)
            },
            new FlightCrew()
            {
                CrewId = 4,
                Name = "Valentina",
                Age = 31,
                JoinedDate = new DateTime(2012, 11, 21)
            }
        };
    }
}

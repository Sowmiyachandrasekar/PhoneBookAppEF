using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneBook.DAL;

namespace PhoneBookApp.Controllers
{
    public class CityController : Controller
    {
        private PersonContext db = new PersonContext();

        // GET: City
        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.State);
            cities = cities.Where(c => c.IsActive.Equals(true));
            return View(cities.ToList());
        }

        // GET: City/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Error processing your request.Please try again!";
                return View("Error");
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                ViewBag.Error = "Your data Not Found";
                return View("Error");
            }
            return View(city);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            var state = db.States.Where(s => s.IsActive).ToList();
            ViewBag.StateId = new SelectList(state, "StateId", "StateName");
            if (ViewBag.StateId != null)
            {
                return View();
            }
            else
            {
                ViewBag.Error = "Atleat one country is needed in State table ";
                return View("Error");
            }
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,CityName,IsActive,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", city.StateId);
            return View(city);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Error processing your request.Please try again!";
                return View("Error");
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                ViewBag.Error = "Your data Not Found";
                return View("Error");
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", city.StateId);
            return View(city);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,CityName,IsActive,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", city.StateId);
            return View(city);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Error processing your request .Please try again!";
                return View("Error");
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                ViewBag.Error = "Your data Not Found";
                return View("Error");
            }
            return View(city);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Person> person = db.Persons.Where(p => p.CityId == id).ToList();
            if (person.Count > 0)
            {
                ViewBag.Error = "Cannot delete this City because this country is used in people";
                return View("Error");
            }
            else
            {
                City city = db.Cities.Find(id);
                db.Cities.Remove(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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

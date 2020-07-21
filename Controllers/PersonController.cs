using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneBookApp.DAL;
using PhoneBookApp.Models;

namespace PhoneBookApp.Controllers
{
    public class PersonController : Controller
    {
        private PersonContext db = new PersonContext();

        // GET: Person
        public ActionResult Index(string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString)) 
            {
                var person=db.Persons.Where(p =>   (p.FirstName.Contains(SearchString) ||
                                                   p.LastName.Contains(SearchString) ||
                                                   p.PhoneNumber.Contains(SearchString)) &&
                                                   p.IsActive);
                return View(person.ToList());
            }
            var persons = db.Persons.Include(p => p.City).Include(p => p.Country).Include(p => p.State);
            return View(persons.ToList());
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNumber,EmailAddress,AddressOne,AddressTwo,Pincode,IsActive,CountryId,StateId,CityId")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", person.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", person.CountryId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", person.StateId);
            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", person.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", person.CountryId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", person.StateId);
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,PhoneNumber,EmailAddress,AddressOne,AddressTwo,Pincode,IsActive,CountryId,StateId,CityId")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", person.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", person.CountryId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", person.StateId);
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
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

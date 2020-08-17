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
    public class StateController : Controller
    {
        private PersonContext db = new PersonContext();

        // GET: State
        public ActionResult Index()
        {
            var states = db.States.Include(s => s.Country);
            states = states.Where(s => s.IsActive.Equals(true));
            return View(states.ToList());
        }

        // GET: State/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Error processing your request.Please try again!";
                return View("Error");
            }
            State state = db.States.Find(id);
            if (state == null)
            {
                ViewBag.Error = "Your data Not Found";
                return View("Error");
            }
            return View(state);
        }

        // GET: State/Create
        public ActionResult Create()
        {
            var country = db.Countries.Where(c => c.IsActive).ToList();
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            if (ViewBag.CountryId != null)
            {

                return View();
            }
            else
            {
                ViewBag.Error = "Atleat one country is needed in country table ";
                return View("Error");
            }
        }

        // POST: State/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateId,StateName,IsActive,CountryId")] State state)
        {
            if (ModelState.IsValid)
            {
                db.States.Add(state);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", state.CountryId);
            return View(state);
        }

        // GET: State/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Error processing your request.Please try again!";
                return View("Error");
            }
            State state = db.States.Find(id);
            if (state == null)
            {
                ViewBag.Error = "Your data Not Found";
                return View("Error");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", state.CountryId);
            return View(state);
        }

        // POST: State/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateId,StateName,IsActive,CountryId")] State state)
        {
            if (ModelState.IsValid)
            {
                db.Entry(state).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", state.CountryId);
            return View(state);
        }

        // GET: State/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Error processing your request.Please try again!";
                return View("Error");
            }
            State state = db.States.Find(id);
            if (state == null)
            {
                ViewBag.Error = "Your data Not Found";
                return View("Error");
            }
            return View(state);
        }

        // POST: State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Person> person = db.Persons.Where(p => p.StateId == id).ToList();
            if (person.Count > 0)
            {
                ViewBag.Error = "Cannot delete this country because this country is used in person";
                return View("Error");
            }
            else
            {
                State state = db.States.Find(id);
                db.States.Remove(state);
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

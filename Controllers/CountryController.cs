using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PhoneBookApp.DAL;
using PhoneBookApp.Models;

namespace PhoneBookApp.Controllers
{
    public class CountryController : Controller
    {
        private PersonContext db = new PersonContext();
        // GET: Country
        public ActionResult Index()
        {
            //IEnumerable<Country> countries = null;
            //using (var client = new HttpClient())
            //{
            //    try
            //    {
            //        HttpResponseMessage response = await client.GetAsync("https://localhost:44330/api/Country");
            //        var readTask = await response.Content.ReadAsAsync<IList<Country>>();
            //        countries = readTask;
            //    }
            //    catch (Exception e)
            //    {
            //        ViewBag.Error = e.Message;
            //        return View("Error");
            //    }

            //}
            return View();
        }

        // GET: Country/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null || country.IsActive.Equals(false))
            {
                ViewBag.Error = "Your data Not Found";
                return View("Error");
            }
            return View(country);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,CountryName,IsActive")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Error processing your request.Please try again!";
                return View("Error");
            }
            Country country = db.Countries.Find(id);
            if (country == null || country.IsActive.Equals(false))
            {
                ViewBag.Error = "Your data Not Found";
                return View("Error");
            }
            return View(country);
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,CountryName,IsActive")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Error processing your request.Please try again!";
                return View("Error");
            }
            Country country = db.Countries.Find(id);
            if (country == null || country.IsActive.Equals(false))
            {
                ViewBag.Error = "Your data Not Found";
                return View("Error");
            }
            return View(country);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Person> person = db.Persons.Where(p => p.CountryId == id).ToList();
            if (person.Count > 0)
            {
                ViewBag.Error = "Cannot delete this country because this country is used in person";
                return View("Error");
            }
            else
            {
                Country country = db.Countries.Find(id);
                db.Countries.Remove(country);
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

using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using PhoneBookApp.Models;
using System.Data;
using System.Collections;
using PhoneBookApp.DAL;

namespace PhoneBookApp.Controllers
{
    public class SearchController : Controller
    {
        private PersonContext db = new PersonContext();

        // GET: Search
        public ActionResult Index()
        {
            List<SelectListItem> listGroup = new List<SelectListItem>();
            listGroup.Add(new SelectListItem { Text = "EmailAddress", Value = "EmailAddress" });
            listGroup.Add(new SelectListItem { Text = "PhoneNumber", Value = "PhoneNumber" });
            listGroup.Add(new SelectListItem { Text = "State", Value = "State" });
            listGroup.Add(new SelectListItem { Text = "Country", Value = "Country" });
            listGroup.Add(new SelectListItem { Text = "City", Value = "City" });
            List<SelectListItem> listorderGroup = new List<SelectListItem>();
            listorderGroup.Add(new SelectListItem { Text = "Ascending", Value = "Ascending" });
            listorderGroup.Add(new SelectListItem { Text = "Descending", Value = "Descending" });
            ViewBag.listDropDown = listGroup;
            ViewBag.Counts = 0;
            ViewBag.order = listorderGroup;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection group)
        {
            List<SelectListItem> listGroup = new List<SelectListItem>();
            listGroup.Add(new SelectListItem { Text = "EmailAddress", Value = "EmailAddress" });
            listGroup.Add(new SelectListItem { Text = "PhoneNumber", Value = "PhoneNumber" });
            listGroup.Add(new SelectListItem { Text = "State", Value = "State" });
            listGroup.Add(new SelectListItem { Text = "Country", Value = "Country" });
            listGroup.Add(new SelectListItem { Text = "City", Value = "City" });
            List<SelectListItem> listorderGroup = new List<SelectListItem>();
            listorderGroup.Add(new SelectListItem { Text = "Ascending", Value = "Ascending" });
            listorderGroup.Add(new SelectListItem { Text = "Descending", Value = "Descending" });
            ViewBag.listDropDown = listGroup;
            ViewBag.Counts = 0;
            ViewBag.order = listorderGroup;
            if (!String.IsNullOrEmpty(group["selects"]))
            {
                ViewBag.SelectedField = group["selects"];

                var start = group["Start"];
                var nr = group["count"];
                switch (group["selects"])
                {

                    case "EmailAddress":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                            if (group["order"] == "Ascending")
                            {
                                var li = db.Persons.Where(p => p.IsActive).OrderBy(p => p.EmailAddress).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                            else
                            {
                                var li = db.Persons.Where(p => p.IsActive).OrderByDescending(p => p.EmailAddress).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Counts = li.Count();
                                ViewBag.Lists = li;
                                return View();
                            }
                        }
                        else
                        {
                            break;
                        }

                    case "PhoneNumber":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {

                            if (group["order"] == "Ascending")
                            {
                                var li = db.Persons.Where(p => p.IsActive).OrderBy(p => p.PhoneNumber).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                            else
                            {
                                var li = db.Persons.Where(p => p.IsActive).OrderByDescending(p => p.PhoneNumber).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                        }
                        else
                        {
                            break;
                        }
                    case "State":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {

                            if (group["order"] == "Ascending")
                            {
                                var li = db.Persons.Where(p => p.IsActive).OrderBy(p => p.StateId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                            else
                            {
                                var li = db.Persons.Where(p => p.IsActive).OrderByDescending(p => p.StateId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                        }
                        else
                        {
                            break;
                        }

                    case "Country":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {

                            if (group["order"] == "Ascending")
                            {
                                var li = db.Persons.Where(p => p.IsActive).OrderBy(p => p.CountryId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                            else
                            {
                                var li = db.Persons.Where(p => p.IsActive).OrderByDescending(p => p.CountryId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Counts = li.Count();
                                ViewBag.Lists = li;
                                return View();
                            }
                        }
                        else
                        {
                            break;
                        }
                    case "City":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                            if (group["order"] == "Ascending")
                            {
                                var li = db.Persons.Where(p => p.IsActive).OrderBy(p => p.CityId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Counts = li.Count();
                                ViewBag.Lists = li;
                                return View();
                            }
                            else
                            {
                                var li = db.Persons.Where(p => p.IsActive).OrderByDescending(p => p.CityId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Counts = li.Count();
                                ViewBag.Lists = li;
                                return View();
                            }
                        }
                        else
                        {
                            break;
                        }
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        // GET: Search
        public ActionResult Search()
        {

            List<Person> peoples = db.Persons.ToList();

            List<SelectListItem> listGroup = new List<SelectListItem>();
            listGroup.Add(new SelectListItem { Text = "City", Value = "City" });
            listGroup.Add(new SelectListItem { Text = "State", Value = "State" });
            listGroup.Add(new SelectListItem { Text = "Country", Value = "Country" });
            listGroup.Add(new SelectListItem { Text = "Pin Code", Value = "Pin Code" });

            ViewBag.listDropDown = listGroup;
            ViewBag.Count = 0;
            return View(peoples);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(FormCollection groupByString)
        {
            if (!String.IsNullOrEmpty(groupByString["select"]))
            {
                List<SelectListItem> listGroup = new List<SelectListItem>();
                listGroup.Add(new SelectListItem { Text = "City", Value = "City" });
                listGroup.Add(new SelectListItem { Text = "State", Value = "State" });
                listGroup.Add(new SelectListItem { Text = "Country", Value = "Country" });

                ViewBag.listDropDown = listGroup;
                var list = new List<KeyValuePair<string, int>>();
                switch (groupByString["select"])
                {
                    case "City":

                        var city = db.Persons.GroupBy(p => p.CityId).ToList();
                        foreach (var pp in city)
                        {
                            var citynames = db.Cities.Where(c => c.CityId.Equals(pp.Key)).Select(p => p.CityName).ToList();
                            foreach (var c in citynames)
                            {
                                list.Add(new KeyValuePair<string, int>(c.ToString(), pp.Count()));
                            }
                        }
                        ViewBag.list = list;
                        ViewBag.Count = city.Count();
                        break;

                    case "State":

                        var state = db.Persons.GroupBy(p => p.StateId).ToList();
                        foreach (var pp in state)
                        {
                            var statenames = db.States.Where(c => c.StateId.Equals(pp.Key)).Select(p => p.StateName).ToList();
                            foreach (var c in statenames)
                            {
                                list.Add(new KeyValuePair<string, int>(c.ToString(), pp.Count()));
                            }
                        }
                        ViewBag.list = list;
                        ViewBag.Count = state.Count();
                        break;

                    case "Country":

                        var country = db.Persons.GroupBy(p => p.CountryId).ToList();
                        foreach (var pp in country)
                        {
                            var countrynames = db.Countries.Where(c => c.CountryId.Equals(pp.Key)).Select(p => p.CountryName).ToList();
                            foreach (var c in countrynames)
                            {
                                list.Add(new KeyValuePair<string, int>(c.ToString(), pp.Count()));
                            }
                        }
                        ViewBag.list = list;
                        ViewBag.Count = country.Count();
                        break;
                }
                return View();
            }
            return RedirectToAction("Search");
        }
    }
}
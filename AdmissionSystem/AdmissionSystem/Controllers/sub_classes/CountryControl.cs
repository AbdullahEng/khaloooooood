using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes
{
    public class CountryControl : Controller
    {

        private readonly CRUD_Operation_Interface<Country> country_Repo;

        public CountryControl(CRUD_Operation_Interface<Country> country_Repo)
        {
            this.country_Repo = country_Repo;
        }
        // GET: CountryController
        public ActionResult Index()
        {
            var countrys = country_Repo.List();
            return View(countrys);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country collection)
        {
            try
            {
                country_Repo.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            var country = country_Repo.Find(id);
            return View(country);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Country collection)
        {
            try
            {
                country_Repo.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            var cou = country_Repo.Find(id);
            return View(cou);
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                country_Repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

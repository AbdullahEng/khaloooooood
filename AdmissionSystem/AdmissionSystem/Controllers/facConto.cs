using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers
{
    public class facConto : Controller
    {
        private readonly CRUD_Operation_Interface<Faculty> faculty_Repo;

        public facConto(CRUD_Operation_Interface<Faculty> Faculty_Repo)
        {
            faculty_Repo = Faculty_Repo;
        }
        // GET: Faculty_controller
        public ActionResult Index()
        {
            var fac = faculty_Repo.List().ToList();
            return View(fac);
        }

        // GET: Faculty_controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Faculty_controller/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Faculty_controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faculty collection)
        {
            try
            {
                //Faculty faculty = new Faculty
                //{
                //    Faculty_name = collection.Faculty_name

                //};
                faculty_Repo.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Faculty_controller/Edit/5
        public ActionResult Edit(int id)
        {
            var facFind = faculty_Repo.Find(id);
            return View(facFind);
        }

        // POST: Faculty_controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Faculty collection)
        {
            try
            {
                faculty_Repo.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Faculty_controller/Delete/5
        public ActionResult Delete(int id)
        {
            faculty_Repo.Find(id);
            return View();
        }

        // POST: Faculty_controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Faculty collection)
        {
            try
            {
                faculty_Repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

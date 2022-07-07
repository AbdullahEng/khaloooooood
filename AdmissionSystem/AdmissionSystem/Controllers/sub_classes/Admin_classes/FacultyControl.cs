using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes.Admin_classes
{
    public class FacultyControl : Controller
    {

        private readonly CRUD_Operation_Interface<Faculty> faculty_Repo;

        public FacultyControl(CRUD_Operation_Interface<Faculty> Faculty_Repo)
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
                var facultylist = faculty_Repo.List();
               bool facultyExists = false;
                foreach (var item in facultylist)
                {
                    if (item.Faculty_name == collection.Faculty_name)
                    {
                        facultyExists = true;

                    }
                   
                }
                //Faculty faculty = new Faculty
                //{
                //    Faculty_name = collection.Faculty_name

                //};
                if (!facultyExists)
                {

                    faculty_Repo.Add(collection);
                  
                    ViewBag.StatusMessageSuccess = "Add Faculty Success";
                    return View();

                }
                else {
                    ViewBag.StatusMessageFails = "The Faculty Already Exists";
                    return View();
                    //return RedirectToAction(nameof(Create));
                }
               // return RedirectToAction(nameof(Index));
               // ViewBag.StatusMessage = "The Faculty Already Exists";
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

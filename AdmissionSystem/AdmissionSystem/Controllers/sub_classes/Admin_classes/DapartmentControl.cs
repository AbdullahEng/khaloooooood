using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes.Admin_classes
{
    public class DapartmentControl : Controller
    {

        private readonly CRUD_Operation_Interface<Department> deprt_Repo;
        private readonly CRUD_Operation_Interface<Faculty> faculty_Repo;

        public DapartmentControl(CRUD_Operation_Interface<Department> deprt_repo
            , CRUD_Operation_Interface<Faculty> faculty_repo
            )
        {
            deprt_Repo = deprt_repo;
            faculty_Repo = faculty_repo;
        }
        // GET: Department_Controller
        public ActionResult Index()
        {
            // Department_faculty_view_model
            var delist = deprt_Repo.List().ToList();
            return View(delist);
        }

        // GET: Department_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department_Controller/Create
        public ActionResult Create()
        {
            var depart_fac_v_m = new Department_faculty_view_model
            {
                facultylist = FillSelliction()

            };
            return View(depart_fac_v_m);
        }

        // POST: Department_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department_faculty_view_model collection)
        {

            try
            {
                if (collection.facultyid == -1)
                {
                    ViewBag.Message = "Please Select an Faculty";
                    return View(GetAllDepartemnet());
                }
                var fac = faculty_Repo.Find(collection.facultyid);
                Department dep = new Department
                {
                    FK_faculty = fac,
                    specialization_name = collection.specialization_name


                };
                deprt_Repo.Add(dep);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Department_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            var dep = deprt_Repo.Find(id);
            var depvi = new Department_faculty_view_model
            {
                
                facultylist = FillSelliction(),
                specialization_name = dep.specialization_name


            };
            return View(depvi);
        }

        // POST: Department_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department_faculty_view_model collection)
        {
            try
            {
                var fac = faculty_Repo.Find(collection.facultyid);
                var dep = new Department
                {
                    id = collection.id,
                    FK_faculty = fac,
                    specialization_name = collection.specialization_name
                };
                deprt_Repo.Update(collection.id, dep);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Department_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            var dep = deprt_Repo.Find(id);
            var depvi = new Department_faculty_view_model
            {
                facultylist = FillSelliction(),
                specialization_name = dep.specialization_name


            };
            return View(depvi);
        }

        // POST: Department_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deprt_Repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public List<Faculty> FillSelliction()
        {
            var fac = faculty_Repo.List().ToList();
            fac.Insert(0, new Faculty { id = -1, Faculty_name = "please Enter The Faculty" });
            return fac;

        }
        public Department_faculty_view_model GetAllDepartemnet()
        {
            var model = new Department_faculty_view_model
            {
                facultylist = FillSelliction()

            };
            return model;
        }
    }
}

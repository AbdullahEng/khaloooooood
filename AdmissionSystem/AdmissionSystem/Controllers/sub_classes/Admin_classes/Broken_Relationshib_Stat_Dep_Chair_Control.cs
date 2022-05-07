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
    public class Broken_Relationshib_Stat_Dep_Chair_Control : Controller
    {

        private readonly CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair> broken_R_S_D_C_Repo;
        private readonly CRUD_Operation_Interface<Department> department_Repo;
        private readonly CRUD_Operation_Interface<Statues_of_admission_eligibilty> status_Of_Adm_Eligi_Repo;

        public Broken_Relationshib_Stat_Dep_Chair_Control(CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair> broken_r_s_d_c_Repo
            , CRUD_Operation_Interface<Department> Department_repo
            , CRUD_Operation_Interface<Statues_of_admission_eligibilty> status_of_adm_eligi_repo
            )
        {
            broken_R_S_D_C_Repo = broken_r_s_d_c_Repo;
            department_Repo = Department_repo;
            status_Of_Adm_Eligi_Repo = status_of_adm_eligi_repo;
        }
        // GET: Broken_Relationshib_Stat_Dep_Chair_Controller
        public ActionResult Index()
        {
            var broke = broken_R_S_D_C_Repo.List().ToList();
            return View(broke);
        }

        // GET: Broken_Relationshib_Stat_Dep_Chair_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Broken_Relationshib_Stat_Dep_Chair_Controller/Create
        public ActionResult Create()
        {
            var broken = new Broken_Relationshib_Stat_Dep_Chair_View_model
            {
                Fk_department = FillSellectionDepartment(),
                FK_statues_Of_Admission_Eligibilty = FillSellectionStatus_of_admi_eligi()

            };
            return View(broken);
        }

        // POST: Broken_Relationshib_Stat_Dep_Chair_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Broken_Relationshib_Stat_Dep_Chair_View_model collection)
        {
            try
            {
                if (collection.department_id == -1 || collection.status_of_admi_eligi_id == -1)
                {
                    ViewBag.Message = "The Department or Type of Admition is empty";
                    return View(GetAll());
                }
                var depfind = department_Repo.Find(collection.department_id);
                var statusFind = status_Of_Adm_Eligi_Repo.Find(collection.status_of_admi_eligi_id);
                var broken = new Broken_Relationshib_Stat_Dep_Chair
                {
                    Fk_department = depfind,
                    FK_statues_Of_Admission_Eligibilty = statusFind,
                    Chair_count = collection.Chair_count

                };
                broken_R_S_D_C_Repo.Add(broken);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Broken_Relationshib_Stat_Dep_Chair_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            var brokenfind = broken_R_S_D_C_Repo.Find(id);
            var brokenView = new Broken_Relationshib_Stat_Dep_Chair_View_model
            {
                FK_statues_Of_Admission_Eligibilty = FillSellectionStatus_of_admi_eligi(),
                Fk_department = FillSellectionDepartment(),
                Chair_count = brokenfind.Chair_count
            };
            return View(brokenView);
        }

        // POST: Broken_Relationshib_Stat_Dep_Chair_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Broken_Relationshib_Stat_Dep_Chair_View_model collection)
        {
            try
            {
                var depart = department_Repo.Find(collection.department_id);
                var status = status_Of_Adm_Eligi_Repo.Find(collection.status_of_admi_eligi_id);
                var broken = new Broken_Relationshib_Stat_Dep_Chair
                {
                    Chair_count = collection.Chair_count,
                    Fk_department = depart,
                    FK_statues_Of_Admission_Eligibilty = status
                };
                broken_R_S_D_C_Repo.Update(id, broken);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Broken_Relationshib_Stat_Dep_Chair_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            var broken = broken_R_S_D_C_Repo.Find(id);
            var brokenview = new Broken_Relationshib_Stat_Dep_Chair_View_model
            {
                FK_statues_Of_Admission_Eligibilty = FillSellectionStatus_of_admi_eligi(),
                Fk_department = FillSellectionDepartment(),
                Chair_count = broken.Chair_count
            };
            return View(brokenview);
        }

        // POST: Broken_Relationshib_Stat_Dep_Chair_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                broken_R_S_D_C_Repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Department> FillSellectionDepartment()
        {
            var deprt = department_Repo.List().ToList();
            deprt.Insert(0, new Department { id = -1, specialization_name = "_-_-_-_-please Enter Department------" });
            return deprt;
        }
        List<Statues_of_admission_eligibilty> FillSellectionStatus_of_admi_eligi()
        {
            var status = status_Of_Adm_Eligi_Repo.List().ToList();
            status.Insert(0, new Statues_of_admission_eligibilty { id = -1, Type_of_admission_eligibilty = "_-_-_-_-please Enter Type of Admition------" });
            return status;
        }
        Broken_Relationshib_Stat_Dep_Chair_View_model GetAll()
        {
            var broken = new Broken_Relationshib_Stat_Dep_Chair_View_model
            {
                Fk_department = FillSellectionDepartment(),
                FK_statues_Of_Admission_Eligibilty = FillSellectionStatus_of_admi_eligi()

            };
            return broken;
        }
    }
}

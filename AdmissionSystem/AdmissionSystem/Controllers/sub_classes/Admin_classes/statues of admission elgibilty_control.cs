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
    public class statues_of_admission_elgibilty_control : Controller
    {

        private readonly CRUD_Operation_Interface<Statues_of_admission_eligibilty> statues_O_A_E_Repo;

        public statues_of_admission_elgibilty_control(CRUD_Operation_Interface<Statues_of_admission_eligibilty> statues_o_a_e_repo)
        {
            statues_O_A_E_Repo = statues_o_a_e_repo;
        }
        // GET: statues_of_admission_elgibilty_controller
        public ActionResult Index()
        {
            var stlist = statues_O_A_E_Repo.List().ToList();
            return View(stlist);
        }

        // GET: statues_of_admission_elgibilty_controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: statues_of_admission_elgibilty_controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: statues_of_admission_elgibilty_controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Statues_of_admission_eligibilty collection)
        {
            try
            {
                statues_O_A_E_Repo.Add(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: statues_of_admission_elgibilty_controller/Edit/5
        public ActionResult Edit(int id)
        {
            var st = statues_O_A_E_Repo.Find(id);
            return View(st);
        }

        // POST: statues_of_admission_elgibilty_controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Statues_of_admission_eligibilty collection)
        {
            try
            {
                statues_O_A_E_Repo.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: statues_of_admission_elgibilty_controller/Delete/5
        public ActionResult Delete(int id)
        {
            var st = statues_O_A_E_Repo.Find(id);
            return View(st);
        }

        // POST: statues_of_admission_elgibilty_controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                statues_O_A_E_Repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

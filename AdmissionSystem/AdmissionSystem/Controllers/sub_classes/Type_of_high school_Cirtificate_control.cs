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
    public class Type_of_high_school_Cirtificate_control : Controller
    {
        private readonly CRUD_Operation_Interface<Type_of_high_school_Cirtificate> type_Of_High_School_Cirtif_Repo;

        public Type_of_high_school_Cirtificate_control(CRUD_Operation_Interface<Type_of_high_school_Cirtificate> type_of_high_school_cirtif_repo)
        {
            type_Of_High_School_Cirtif_Repo = type_of_high_school_cirtif_repo;
        }
        // GET: Type_of_high_school_Cirtificate_control
        public ActionResult Index()
        {
            var type = type_Of_High_School_Cirtif_Repo.List();

            return View(type);
        }

        // GET: Type_of_high_school_Cirtificate_control/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Type_of_high_school_Cirtificate_control/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Type_of_high_school_Cirtificate_control/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Type_of_high_school_Cirtificate collection)
        {
            try
            {
                var type = new Type_of_high_school_Cirtificate { 
                type=collection.type
                };
                type_Of_High_School_Cirtif_Repo.Add(type);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Type_of_high_school_Cirtificate_control/Edit/5
        public ActionResult Edit(int id)
        {
            var typefind = type_Of_High_School_Cirtif_Repo.Find(id);
            return View(typefind);
        }

        // POST: Type_of_high_school_Cirtificate_control/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Type_of_high_school_Cirtificate collection)
        {
            try
            {
                var type = new Type_of_high_school_Cirtificate
                {
                    id=collection.id,
                    type=collection.type

                };
                type_Of_High_School_Cirtif_Repo.Update(id,type);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Type_of_high_school_Cirtificate_control/Delete/5
        public ActionResult Delete(int id)
        {
            var typefind = type_Of_High_School_Cirtif_Repo.Find(id);
            return View(typefind);
        }

        // POST: Type_of_high_school_Cirtificate_control/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                type_Of_High_School_Cirtif_Repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

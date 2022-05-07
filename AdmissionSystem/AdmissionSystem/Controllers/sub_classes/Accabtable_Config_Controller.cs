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
    public class Accabtable_Config_Controller : Controller
    {
        public Accabtable_Config_Controller(CRUD_Operation_Interface<Accabtable_config> accbt_repo)
        {
                
        }
        // GET: Accabtable_Config_Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Accabtable_Config_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Accabtable_Config_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accabtable_Config_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Accabtable_Config_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Accabtable_Config_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Accabtable_Config_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Accabtable_Config_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

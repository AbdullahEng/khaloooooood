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
    public class Employee_Controller : Controller
    {
        public Employee_Controller(CRUD_Operation_Interface<Employee>Employee_repo)
        {

        }
        // GET: Employee_Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee_Controller/Create
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

        // GET: Employee_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee_Controller/Edit/5
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

        // GET: Employee_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee_Controller/Delete/5
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

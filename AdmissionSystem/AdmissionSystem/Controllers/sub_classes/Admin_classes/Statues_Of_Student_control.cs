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
    public class Statues_Of_Student_control : Controller
    {
        private readonly CRUD_Operation_Interface<Statues_Of_Student> statusRepooo;

        public Statues_Of_Student_control(CRUD_Operation_Interface<Statues_Of_Student> statusRepooo
            )
        {
            this.statusRepooo = statusRepooo;
        }
        // GET: Statues_Of_Student_control
        public ActionResult Index()
        {
            return View();
        }

        // GET: Statues_Of_Student_control/Details/5
        public ActionResult Details(int id)
        {
     
            return View();
        }

       

        // GET: Statues_Of_Student_control/Delete/5
        public ActionResult statusofstudnet()
        {
            var status = statusRepooo.List();
                   return View(status);
        }

        // POST: Statues_Of_Student_control/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult statusofstudnet(string term)
        {



            if (term != null)
            {
               
            var searchstatus = statusRepooo.List().Where(s => s.FK_Student_Info.First_Name_EN.Contains(term));
            return View(searchstatus);
            }

            var status = statusRepooo.List();
            return View(status);

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

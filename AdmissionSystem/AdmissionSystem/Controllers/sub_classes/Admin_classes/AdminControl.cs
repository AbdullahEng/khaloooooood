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
    public class AdminControl : Controller
    {
        private readonly CRUD_Operation_Interface<Country> countryRepoo;
        private readonly CRUD_Operation_Interface<Student> studentRepooo;
        private readonly CRUD_Operation_Interface<Accabtable_config> acceptedRepooo;
        private readonly CRUD_Operation_Interface<Statues_Of_Student> stautusofstuRepooo;

        public AdminControl(CRUD_Operation_Interface<Country> countryRepoo
            , CRUD_Operation_Interface<Student> StudentRepooo
            , CRUD_Operation_Interface<Accabtable_config> AcceptedRepooo
            , CRUD_Operation_Interface<Statues_Of_Student>stautusofstuRepooo
            )
        {
            this.countryRepoo = countryRepoo;
            studentRepooo = StudentRepooo;
            acceptedRepooo = AcceptedRepooo;
            this.stautusofstuRepooo = stautusofstuRepooo;
        }
        // GET: AdminControl
        public ActionResult Index(int id)
        {
            // a => (someCondition) ? a == "something" : true
            var ccountres = countryRepoo.List();
            var studnets1 = studentRepooo.List().Where(s => (s.Cirtificate_city != null) ? s.Cirtificate_city.id == 1 : false).ToList();
            var studnets2 = studentRepooo.List().Where(s => (s.Cirtificate_city != null) ? s.Cirtificate_city.id == 2 : false).ToList();
            var studnets3 = studentRepooo.List().Where(s => (s.Cirtificate_city != null) ? s.Cirtificate_city.id == 3 : false).ToList();
            var studnets4 = studentRepooo.List().Where(s => (s.Cirtificate_city != null) ? s.Cirtificate_city.id == 4 : false).ToList();
            var studnets5 = studentRepooo.List().Where(s => (s.Cirtificate_city != null) ? s.Cirtificate_city.id == 5 : false).ToList();
            var studnets6 = studentRepooo.List().Where(s => (s.Cirtificate_city != null) ? s.Cirtificate_city.id == 6 : false).ToList();
            var studnets7 = studentRepooo.List().Where(s => (s.Cirtificate_city != null) ? s.Cirtificate_city.id == 7 : false).ToList();
            var studnets8 = studentRepooo.List().Where(s => (s.Cirtificate_city != null) ? s.Cirtificate_city.id == 8 : false).ToList();
            var studnets9 = studentRepooo.List().Where(s => (s.Cirtificate_city != null) ? s.Cirtificate_city.id == 9 : false).ToList();
            var studnets10 = studentRepooo.List().Where(s => (s.Cirtificate_city != null) ? s.Cirtificate_city.id == 10 : false).ToList();



            var sY = studentRepooo.List().Where(s => (s.high_school_certificate != null) ? s.high_school_certificate == "Syrian" : false).ToList();
            var UN = studentRepooo.List().Where(s => (s.high_school_certificate != null) ? s.high_school_certificate == "UNSyrian" : false).ToList();

            var All = studentRepooo.List().ToList();

            var acc = acceptedRepooo.List().Where(a =>  a.Accepted_Or_Not == true ).ToList();
            var UNacc = acceptedRepooo.List().Where(a => a.Accepted_Or_Not == false).ToList();
            var SyChecked = stautusofstuRepooo.List().Where(a => (a.FK_Student_Info != null) ? a.FK_Student_Info.high_school_certificate == "Syrian"
                                                            && a.Checked_city_certificate == true
                                                            && a.Checked_Identity == true
                                                            && a.Checked_Rate == true
                                                            && a.Checked_recipet == true 
                                                            : false

            ).ToList();
            var SyUNChecked = stautusofstuRepooo.List().Where(a => (a.FK_Student_Info != null) ? a.FK_Student_Info.high_school_certificate == "Syrian"
                                                           || a.Checked_city_certificate == false
                                                           || a.Checked_Identity == false
                                                           || a.Checked_Rate == false
                                                           || a.Checked_recipet == false 
                                                           : false

           ).ToList();



            var UNSyChecked = stautusofstuRepooo.List().Where(a => (a.FK_Student_Info != null) ? a.FK_Student_Info.high_school_certificate == "UNSyrian"
                                                           && a.Checked_city_certificate == true
                                                           && a.Checked_Identity == true
                                                           && a.Checked_Rate == true
                                                           && a.Checked_recipet == true
                                                           : false

           ).ToList();


            var UNSyUNChecked = stautusofstuRepooo.List().Where(a => (a.FK_Student_Info != null) ? a.FK_Student_Info.high_school_certificate == "UNSyrian"
                                                        && a.Checked_city_certificate == false
                                                        && a.Checked_Identity == false
                                                        && a.Checked_Rate == false
                                                         && a.Checked_recipet == false 
                                                         : false

         ).ToList();
            var model = new Adminviewmodel
            {
                country1 = studnets1.Count.ToString(),
                country2 = studnets2.Count.ToString(),
                country3 = studnets3.Count.ToString(),
                country4 = studnets4.Count.ToString(),
                country5 = studnets5.Count.ToString(),
                country6 = studnets6.Count.ToString(),
                country7 = studnets7.Count.ToString(),
                country8 = studnets8.Count.ToString(),
                country9 = studnets9.Count.ToString(),
                country10 = studnets10.Count.ToString(),
                Systudent = sY.Count.ToString(),
                UnSYstudent = UN.Count.ToString(),
                allstudentNO = All.Count.ToString(),
                AcceptStudnet = acc.Count.ToString(),
                UNAcceptStudnet = UNacc.Count.ToString(),
                studentSYChecked = SyChecked.Count.ToString(),
                studentSYUNChecked = SyUNChecked.Count.ToString(),
                StudentUNSYchecked = UNSyChecked.Count.ToString(),
                StudentUNSYUNchecked = UNSyUNChecked.Count.ToString(),



            };


            return View(model);
           // return View();
        }

        // GET: AdminControl/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminControl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminControl/Create
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

        // GET: AdminControl/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminControl/Edit/5
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

        // GET: AdminControl/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminControl/Delete/5
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

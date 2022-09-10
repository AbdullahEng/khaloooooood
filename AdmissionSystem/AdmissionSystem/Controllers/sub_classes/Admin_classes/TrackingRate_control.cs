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
    public class TrackingRate_control : Controller
    {
        private readonly CRUD_Operation_Interface<Tracking_Rate> trackingRepo;
        private readonly CRUD_Operation_Interface<Student> studentRepoo;
        private readonly CRUD_Operation_Interface<Employee> employeeRepoo;

        public TrackingRate_control(CRUD_Operation_Interface<Tracking_Rate> trackingRepo
            , CRUD_Operation_Interface<Student> studentRepoo
              , CRUD_Operation_Interface<Employee> EmployeeRepoo
            )
        {
            this.trackingRepo = trackingRepo;
            this.studentRepoo = studentRepoo;
            employeeRepoo = EmployeeRepoo;
        }
        // GET: TrackingRate_control
        public ActionResult Index()
        {
            var trcking = trackingRepo.List();
           
           // var studnets = studentRepoo.List();



            return View(trcking);
        }


        // GET: TrackingRate_control/Delete/5
        public ActionResult TrackingStudnetrate()
        {
            //var trcking = trackingRepo.List();
            //var studnets = studentRepoo.List();
            //var employee = employeeRepoo.List();
            var trcking = trackingRepo.List();

            // var studnets = studentRepoo.List();



            return View(trcking);
        }

        //// POST: TrackingRate_control/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrackingStudnetrate(string term)
        {

            if (term != null)
            {
                var searchtracking = trackingRepo.List().Where(t =>
                                                             //employeeRepoo.Find(t.FK_Employee_Info.id).name.Contains(term) ||
                                                             t.FK_Student_Info.First_Name_EN.Contains(term)
                                                             ).ToList();

            return View( searchtracking);
            }
            var trcking = trackingRepo.List();
            return View(trcking);
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

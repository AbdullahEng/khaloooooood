using AdmissionSystem.Data;
using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes.Admin_classes
{
    public class FacultyControl : Controller
    {

        private readonly CRUD_Operation_Interface<Faculty> faculty_Repo;
        private readonly CRUD_Operation_Interface<Department> department_Repo;
        private readonly ApplicationDbContext _DB;
        public FacultyControl(CRUD_Operation_Interface<Faculty> Faculty_Repo
            , CRUD_Operation_Interface<Department> department_Repo
            , ApplicationDbContext DB
            )
        {
            _DB = DB;
            faculty_Repo = Faculty_Repo;
            this.department_Repo = department_Repo;
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
                  
                                
                    ViewBag.StatusMessageSuccess = "Faculty ' "+collection.Faculty_name+" ' has been added successfully";
                    ViewBag.StatusMessageSuccessArabic = "تم اضافه الكليه بنجاح ";     

                    return View();

                }
                else {
                    
                    ViewBag.StatusMessageFails = "The Faculty is Already Exists";
                    ViewBag.StatusMessageFailsArabic = "الكلية موجودة بالفعل";

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


                var result = _DB.Faculty.Where(fac_name => fac_name.Faculty_name == collection.Faculty_name).AsNoTracking().ToList();

                //var fac_list = faculty_Repo.List().ToList();
                //bool same_Faculty_name = false;
                //foreach (var fac in fac_list)
                //{
                //    if (fac.id != id)
                //    {
                //        if (fac.Faculty_name == collection.Faculty_name)
                //        {

                //            same_Faculty_name = true;
                //            break;
                //        }
                //    }
                //}

                //if (!same_Faculty_name)
                //{
                //    faculty_Repo.Update(id, collection);
                //    ViewBag.differentName = "Edit succeeded";

                //    return View();
                //}
                //else {
                //    ViewBag.sameName = "plese Change the name ";
                //       return View();
                //}
                //   bool s_f=  ff(id,collection.Faculty_name);
                if (result.Count == 1)
                {
                    ViewBag.identical = "This name identical ";
                    ViewBag.identicalArabic = "هذا الاسم متطابق ";

                    return View();
                }
                else if (result.Count == 0)
                {
                    faculty_Repo.Update(id, collection);
                    ViewBag.differentName = "Edit succeeded";
                    ViewBag.differentNameArabic = "نجح التحرير";

                    return View();
                }
                else
                {

                    ViewBag.sameName = "please Change the name ";
                    ViewBag.sameNameArabic = "الرجاء تغيير الاسم";
                    return View();
                }

                //return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }
        //public bool ff(int id,string facultyname) {

        //    var fac_list = faculty_Repo.List();
        //    bool same_Faculty_name = false;
        //    foreach (var fac in fac_list)
        //    {
        //        if (fac.id != id)
        //        {
        //            if (fac.Faculty_name == facultyname)
        //            {
        //                same_Faculty_name = true;
        //                break;
        //            }
        //        }
        //    }
        //    return same_Faculty_name;
        //}

        // GET: Faculty_controller/Delete/5
        public ActionResult Delete(int id)
        {
           var fac= faculty_Repo.Find(id);
            return View(fac);
        }

        // POST: Faculty_controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Faculty collection)
        {
            try
            {
                var fac = faculty_Repo.Find(id);
                if (fac == null) {
                    ViewBag.WasDeleted = "This faculty is already deleted";
                    ViewBag.WasDeletedArabic = "تم حذف هذه الكلية بالفعل";
                    return View();
                }
                var dep_list = department_Repo.List();
                bool faculty_Is_linked = false;
                foreach (var dep in dep_list)
                {
                    if (dep.FK_facultyId == id)
                    {
                        faculty_Is_linked = true;
                        break;
                    }
                   
                  
                }

                if (!faculty_Is_linked ) { 
                    
                    faculty_Repo.Delete(id);
                    ViewBag.freeFaculty = "Delete the '" + fac.Faculty_name + "' succeeded";
                    ViewBag.freeFacultyArabic = "تم حذف  '" + fac.Faculty_name + "' بنجاح";
                    return View(fac); }
                else {
                    ViewBag.linkedFaculty = "you can't delete This faculty because it is related with departments";
                 ViewBag.linkedFacultyArabic = "لا يمكنك حذف هذه الكلية لأنها مرتبطة بأقسام";  return View(fac); 
                
                }
                
                //return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }
    }
}

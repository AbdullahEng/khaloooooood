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
        private readonly CRUD_Operation_Interface<Department_relation_Type> departm_Realtion_Repoooo;
        private readonly CRUD_Operation_Interface<Student> student_Repoooo;

        public Type_of_high_school_Cirtificate_control(CRUD_Operation_Interface<Type_of_high_school_Cirtificate> type_of_high_school_cirtif_repo,
                                                       CRUD_Operation_Interface<Department_relation_Type> departm_realtion_repoooo,
                                                        CRUD_Operation_Interface<Student> student_repoooo


            )
        {
            type_Of_High_School_Cirtif_Repo = type_of_high_school_cirtif_repo;
            departm_Realtion_Repoooo = departm_realtion_repoooo;
            student_Repoooo = student_repoooo;
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

                var typelist = type_Of_High_School_Cirtif_Repo.List().Where(t=>t.type==collection.type).ToList();
             
                
                    

             
                if (typelist.Count == 0)
                {
                type_Of_High_School_Cirtif_Repo.Add(type);
                  
                    ViewBag.AddSuccess = "The addition succeeded";
                    ViewBag.AddSuccessArabic = "نجحت الإضافة";
                    return View();

                }
                else if (typelist.Count == 1)
                {
                    ViewBag.sameEdit = "Already Exists";
                    ViewBag.sameEditArabic = "موجود بالفعل";
                    return View();


                }
                else
                {
                    ViewBag.Addfails = "The addition fails";
                    ViewBag.AddfailsArabic = "فشل الإضافة";
                    return View();

                }






              //  return RedirectToAction(nameof(Index));
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
                var typelist = type_Of_High_School_Cirtif_Repo.List().Where(t => t.type == collection.type).ToList();



                if (typelist.Count == 0)
                {
                type_Of_High_School_Cirtif_Repo.Update(id,type);
                  
                    ViewBag.UpdateSuccess = "Editing success";
                    ViewBag.UpdateSuccessArabic = "نجاح التحرير";
                    return View();

                }
                else if (typelist.Count == 1)
                {
                    ViewBag.sameEdit = "Same Edit";
                    ViewBag.sameEditArabic = "نفس التحرير";
                    return View();


                }
                else
                {

                    ViewBag.updatefails = "Editing failed";
                    ViewBag.updatefailsArabic = "فشل التحرير";
                    return View();

                }

              //  return RedirectToAction(nameof(Index));
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
                var typefind = type_Of_High_School_Cirtif_Repo.Find(id);
                if (typefind == null)
                {
                    ViewBag.WasDeleted = "This department is already deleted";
                    ViewBag.WasDeletedArabic = "تم حذف هذا القسم بالفعل";

                    return View();
                }
                var deprealtiontypelist = departm_Realtion_Repoooo.List().Where(d=>d.FK_type_Of_High_School_CirtificateId==typefind.id).ToList();
                var studnet = student_Repoooo.List().Where(s=>s.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.FK_Type_of_high_school_Cirtificate.id==typefind.id).ToList();

               

                if (deprealtiontypelist.Count == 0 && studnet.Count == 0)
                {
                type_Of_High_School_Cirtif_Repo.Delete(id);
                   
                    ViewBag.freeDepartment = "Delete the '" + typefind.type +"is done";
                    ViewBag.freeDepartmentArabic = "حذف ال '" + typefind.type + " تم بنجاح";

                    return View();
                }
                else
                {
                    ViewBag.linkedDepartment = "you can't delete This item because it is related with Others(may stundent or department Realtion)";
                    ViewBag.linkedDepartmentArabic = "لا يمكنك حذف هذا العنصر لأنه مرتبط بالآخرين ";
                    return View(typefind);

                }


                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

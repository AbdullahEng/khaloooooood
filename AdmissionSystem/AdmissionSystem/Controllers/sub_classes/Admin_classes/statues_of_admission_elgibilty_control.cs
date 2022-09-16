using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes.Admin_classes
{
    [Authorize(Roles = "Admin")]
    public class statues_of_admission_elgibilty_control : Controller
    {

        private readonly CRUD_Operation_Interface<Statues_of_admission_eligibilty> statues_O_A_E_Repo;
        private readonly CRUD_Operation_Interface<Persentage_count_for_each__country> persentage_C_F_E_Repo;
        private readonly CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair> broken_Relation_Stat_Dep_Chair_REpo;
        private readonly CRUD_Operation_Interface<Accabtable_config> accabtable_Config_Repooo;

        public statues_of_admission_elgibilty_control(CRUD_Operation_Interface<Statues_of_admission_eligibilty> statues_o_a_e_repo
                                                     , CRUD_Operation_Interface<Persentage_count_for_each__country> Persentage_c_f_e_Repo
                                                     , CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair> broken_relation_Stat_Dep_Chair_REpo
                                                      , CRUD_Operation_Interface<Accabtable_config> Accabtable_config_Repooo
       )

        {
            statues_O_A_E_Repo = statues_o_a_e_repo;
            persentage_C_F_E_Repo = Persentage_c_f_e_Repo;
            broken_Relation_Stat_Dep_Chair_REpo = broken_relation_Stat_Dep_Chair_REpo;
            accabtable_Config_Repooo = Accabtable_config_Repooo;
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
                var ss = statues_O_A_E_Repo.List().Where(s => s.Number_Student == collection.Number_Student &&
                                                            s.Type_of_admission_eligibilty == collection.Type_of_admission_eligibilty &&
                                                            s.semester_no == collection.semester_no &&
                                                            s.semester_Date == collection.semester_Date &&
                                                            s.Begaining_date_of_the_process == collection.Begaining_date_of_the_process
                     ).ToList();



                if (ss.Count == 0)
                {
                    statues_O_A_E_Repo.Add(collection);
                    ViewBag.AddSuccess = "The addition succeeded";
                    ViewBag.AddSuccessArabic = "نجحت الإضافة";

                    return View();
                }
                else if (ss.Count == 1)
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




                //return RedirectToAction(nameof(Index));
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

                var ss = statues_O_A_E_Repo.List().Where(s => s.Number_Student == collection.Number_Student &&
                                                            s.Type_of_admission_eligibilty == collection.Type_of_admission_eligibilty &&
                                                            s.semester_no == collection.semester_no &&
                                                            s.semester_Date == collection.semester_Date &&
                                                            s.Begaining_date_of_the_process == collection.Begaining_date_of_the_process
                     ).ToList();



                if (ss.Count == 0)
                {
                    statues_O_A_E_Repo.Update(id, collection);
                    ViewBag.UpdateSuccess = "Editing success";
                    ViewBag.UpdateSuccessArabic = "نجاح التحرير";

                    return View();
                }
                else if (ss.Count == 1)
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





                //return RedirectToAction(nameof(Index));
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
                var st = statues_O_A_E_Repo.Find(id);
                if (st == null)
                {
                    ViewBag.WasDeleted = "This department is already deleted";
                    ViewBag.WasDeletedArabic = "تم حذف هذا القسم بالفعل";

                    return View();
                }
                var parcentlist = persentage_C_F_E_Repo.List().Where(p => p.FK_statues_of_admission_eligibiltyId == id).ToList();
                var brokenlist = broken_Relation_Stat_Dep_Chair_REpo.List().Where(b => b.FK_statues_Of_Admission_EligibiltyId == id).ToList();
                var acclist = accabtable_Config_Repooo.List().Where(a => a.FK_Statues_of_admission_eligibiltyId == id).ToList();
                if (parcentlist.Count == 0 && brokenlist.Count == 0 && acclist.Count == 0)
                {
                    statues_O_A_E_Repo.Delete(id);
                    ViewBag.freeDepartment = "Delete the '" + st.Type_of_admission_eligibilty + "' succeeded";
                    ViewBag.freeDepartmentArabic = "حذف ال '" + st.Type_of_admission_eligibilty + "' تم بنجاح";
                    return View();

                }
                else
                {
                    ViewBag.linkedDepartment = "you can't delete This item because it is related with Others";
                    ViewBag.linkedDepartmentArabic = "لا يمكنك حذف هذا العنصر لأنه مرتبط بالآخرين ";
                    return View();


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

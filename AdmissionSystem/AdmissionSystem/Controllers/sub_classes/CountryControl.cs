using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes
{
    [Authorize(Roles = "Admin")]
    public class CountryControl : Controller
    {

        private readonly CRUD_Operation_Interface<Country> country_Repo;
        private readonly CRUD_Operation_Interface<Persentage_count_for_each__country> persentage_Repooo;
        private readonly CRUD_Operation_Interface<Student> student_Repooo;

        public CountryControl(CRUD_Operation_Interface<Country> country_Repo
                             ,CRUD_Operation_Interface<Persentage_count_for_each__country> persentage_Repooo
                             , CRUD_Operation_Interface<Student> student_Repooo
            
            )
        {
            this.country_Repo = country_Repo;
            this.persentage_Repooo = persentage_Repooo;
            this.student_Repooo = student_Repooo;
        }
        // GET: CountryController
        public ActionResult Index()
        {
            var countrys = country_Repo.List();
            return View(countrys);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country collection)
        {
            try
            {
                var cc = country_Repo.List().Where(c=>c.country_name==collection.country_name).ToList();




                if (cc.Count == 0)
                {
                country_Repo.Add(collection);
                    
                    ViewBag.AddSuccess = "The addition succeeded";
                    ViewBag.AddSuccessArabic = "نجحت الإضافة";

                    return View();
                }
                else if (cc.Count == 1)
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

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            var country = country_Repo.Find(id);
            return View(country);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Country collection)
        {
            try
            {
                var cc = country_Repo.List().Where(c => c.country_name == collection.country_name).ToList();
                if (cc.Count == 0)
                {
                country_Repo.Update(id, collection);
                  
                    ViewBag.UpdateSuccess = "Editing success";
                    ViewBag.UpdateSuccessArabic = "نجاح التحرير";

                    return View();
                }
                else if (cc.Count == 1)
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

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            var cou = country_Repo.Find(id);
            return View(cou);
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var cou = country_Repo.Find(id);
                if (cou == null)
                {
                    ViewBag.WasDeleted = "This country is already deleted";
                    ViewBag.WasDeletedArabic = "تم حذف هذا البلد بالفعل";

                    return View();
                }




                var persantageList = persentage_Repooo.List().Where(p => p.FK_countryId == id).ToList() ;
                var studentlist = student_Repooo.List().Where(s=>s.Fk_Cirtificate_cityId==id).ToList();


                if (persantageList.Count == 0 && studentlist.Count == 0)
                {
                country_Repo.Delete(id);

                    ViewBag.freeDepartment = "Delete the '" +cou.country_name+ "' succeeded";
                    ViewBag.freeDepartmentArabic = "حذف ال '" + cou.country_name + "' تم بنجاح";
                    return View(cou);

                }
                else
                {
                    ViewBag.linkedDepartment = "you can't delete This item because it is related with Others";
                    ViewBag.linkedDepartmentArabic = "لا يمكنك حذف هذا العنصر لأنه مرتبط بالآخرين ";
                    return View(cou);


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

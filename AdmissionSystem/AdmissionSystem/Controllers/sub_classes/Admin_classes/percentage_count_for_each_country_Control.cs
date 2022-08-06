using AdmissionSystem.Data;
using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes.Admin_classes
{
    public class percentage_count_for_each_country_Control : Controller
    {


        private readonly CRUD_Operation_Interface<Persentage_count_for_each__country> percentage_Repo;
        private readonly CRUD_Operation_Interface<Country> country_Repo;
        private readonly CRUD_Operation_Interface<Statues_of_admission_eligibilty> st_Of_Adm_Eli_Repo;
        private readonly ApplicationDbContext dB;

        public percentage_count_for_each_country_Control(CRUD_Operation_Interface<Persentage_count_for_each__country> percentage_repo
            , CRUD_Operation_Interface<Country> country_repo
            , CRUD_Operation_Interface<Statues_of_admission_eligibilty> st_of_adm_eli_repo
            , ApplicationDbContext _DB
            )
        {
            percentage_Repo = percentage_repo;
            country_Repo = country_repo;
            st_Of_Adm_Eli_Repo = st_of_adm_eli_repo;
            dB = _DB;
        }
        // GET: percentage_count_for_each_country_Controller
        public ActionResult Index()
        {
            var perc = percentage_Repo.List().ToList();
            
            return View(perc);
        }

        // GET: percentage_count_for_each_country_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: percentage_count_for_each_country_Controller/Create
        public ActionResult Create()
        {
            var perc = new percentage_count_for_each_country_view_model
            {
                FK_country = FillSellectionCountry(),
                FK_statues_of_admission_eligibilty = FillSellectionStatus_OF_Adm_eli()
            };
            return View(perc);
        }

        // POST: percentage_count_for_each_country_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(percentage_count_for_each_country_view_model collection)
        {
            try
            {
                if (collection.countryId == -1 || collection.statues_of_adm_eli_ID == -1)
                {
                    ViewBag.Message = " The country or The status of admition is empty ";
                    return View(GetAll());
                }
                var country = country_Repo.Find(collection.countryId);
                var status_of___ = st_Of_Adm_Eli_Repo.Find(collection.statues_of_adm_eli_ID);
                
                var perc = new Persentage_count_for_each__country
                {
                    FK_country = country,
                    FK_statues_of_admission_eligibilty = status_of___,
                    Rate = collection.Rate
                };
                var percviwmodel = new percentage_count_for_each_country_view_model
                {
                    FK_country = FillSellectionCountry(),
                    FK_statues_of_admission_eligibilty = FillSellectionStatus_OF_Adm_eli()
                    ,countryId=collection.countryId,
                    statues_of_adm_eli_ID=collection.statues_of_adm_eli_ID,
                    Rate=collection.Rate
                };



                var countryinpercentage = percentage_Repo.List().Where(c=>c.FK_countryId==country.id).ToList();//customize to one to one realationship


                if (countryinpercentage.Count == 0)
                {
                percentage_Repo.Add(perc);
                    ViewBag.AddSuccess = "The addition succeeded";
                    ViewBag.AddSuccessArabic = "نجحت الإضافة";

                    return View(percviwmodel);
                }
                else if (countryinpercentage.Count == 1)
                {
                    ViewBag.sameEdit = "you can't do more than one customize to this country ''"+country.country_name+"''";
                    ViewBag.sameEditArabic = "لا يمكنك إجراء أكثر من تخصيص واحد لهذا البلد''" + country.country_name + "''";

                    return View(percviwmodel);

                }
                else
                {
                    ViewBag.Addfails = "The addition fails";
                    ViewBag.AddfailsArabic = "فشل الإضافة";

                    return View(percviwmodel);

                }







                //return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: percentage_count_for_each_country_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            var perc = percentage_Repo.Find(id);
            var con = country_Repo.Find(perc.FK_countryId);
            var status = st_Of_Adm_Eli_Repo.Find(perc.FK_statues_of_admission_eligibiltyId);
            var percvi = new percentage_count_for_each_country_view_model
            {
                FK_country = FillSellectionCountryEdit(con),
                FK_statues_of_admission_eligibilty = FillSellectionStatus_OF_Adm_eliEdit(status),
                Rate = perc.Rate
            };
            return View(percvi);
        }

        // POST: percentage_count_for_each_country_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, percentage_count_for_each_country_view_model collection)
        {
            try
            {
                var percfind = percentage_Repo.Find(id);
                var con = country_Repo.Find(percfind.FK_countryId);
                var status_of_admi = st_Of_Adm_Eli_Repo.Find(collection.statues_of_adm_eli_ID);
                //if (collection.countryId == -1 )
                //{
                //    ViewBag.Message = " The country is empty ";
                //    return View(GetAll());
                //}
                //if (collection.statues_of_adm_eli_ID == -1) {
                //    ViewBag.Message = "  The status of admition is empty ";

                //    return View(GetAll());

                //}
              

               // var country = country_Repo.Find(collection.countryId);
               
                var perc = new Persentage_count_for_each__country
                {
                    id=id,
                    FK_statues_of_admission_eligibilty = status_of_admi,
                    FK_country = con,
                    Rate = collection.Rate
                };
                //percentage_Repo.Delete(id);
                var perWhere = percentage_Repo.List().Where(p=>p.FK_countryId==con.id 
                                                            && p.FK_statues_of_admission_eligibiltyId==status_of_admi.id
                                                            && p.Rate==collection.Rate).ToList();

               // var countryinpercentage = percentage_Repo.List().Where(c => c.FK_countryId == con.id).ToList();//customize to one to one realationship
                // remember to more profisional error message



                if (perWhere.Count == 0 )
                {
                  
               
                    percentage_Repo.Update(id, perc);
                    ViewBag.UpdateSuccess = "Editing success";
                    ViewBag.UpdateSuccessArabic = "نجاح التحرير";

                    return View(GetAllEDit(con, status_of_admi));
                }
                else if (perWhere.Count == 1)
                {
                    ViewBag.sameEdit = "Same Edit";
                    ViewBag.sameEditArabic = "نفس التحرير";

                    return View(GetAllEDit(con, status_of_admi));

                }
                else
                {

                    ViewBag.updatefails = "Editing failed";
                    ViewBag.updatefailsArabic = "فشل التحرير";

                    return View(GetAllEDit(con,status_of_admi));

                }




                //return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: percentage_count_for_each_country_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            var percfind = percentage_Repo.Find(id);
            var con = country_Repo.Find(percfind.FK_countryId);
            var status = st_Of_Adm_Eli_Repo.Find(percfind.FK_statues_of_admission_eligibiltyId);

            //var percvi = new percentage_count_for_each_country_view_model
            //{
            //    FK_statues_of_admission_eligibilty =FillSellectionStatus_OF_Adm_eli() ,
            //    FK_country = FillSellectionCountry(),
            //    Rate = percfind.Rate
            //};
            var percvi = new Persentage_count_for_each__country { 
            FK_country= con,
            FK_statues_of_admission_eligibilty=status,
            Rate=percfind.Rate
            };
            return View(percvi);
        }

        // POST: percentage_count_for_each_country_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var percfind = percentage_Repo.Find(id);
                if (percfind == null)
                {
                    ViewBag.WasDeleted = "This item is already deleted";
                    ViewBag.WasDeletedArabic = "تم حذف هذا العنصر بالفعل";

                    return View();
                }
                else {
                percentage_Repo.Delete(id);
                    ViewBag.freeDepartment = "Delete the item succeeded";
                    ViewBag.freeDepartmentArabic = "تم الحذف";
                    return View();

                }
                //if ()
                //{
                   
                //    ViewBag.freeDepartment = "Delete the '" + st.Type_of_admission_eligibilty + "' succeeded";
                //    ViewBag.freeDepartmentArabic = "حذف ال '" + st.Type_of_admission_eligibilty + "' تم بنجاح";
                //    return View();

                //}
                //else
                //{
                //    ViewBag.linkedDepartment = "you can't delete This item because it is related with Others";
                //    ViewBag.linkedDepartmentArabic = "لا يمكنك حذف هذا العنصر لأنه مرتبط بالآخرين ";
                //    return View();


                //}

                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Country> FillSellectionCountry()
        {
            var coun = country_Repo.List().ToList();
            coun.Insert(0, new Country { id = -1, country_name = "_-_-_-_-please Enter country------" });
            return coun;
        }
        List<Country> FillSellectionCountryEdit( Country c)
        {
            var coun = country_Repo.List().ToList();
            var conlist = new List<Country>();
            conlist.Insert(0,c);
            //conlist.Insert(1, new Country { id = -1, country_name = "_-_-_-_-please Enter country------" });
            coun.Remove(c);
            conlist.InsertRange(1, coun);
            return conlist;
        }
        List<Statues_of_admission_eligibilty> FillSellectionStatus_OF_Adm_eli()
        {
            var statusADEL = st_Of_Adm_Eli_Repo.List().ToList();
            statusADEL.Insert(0, new Statues_of_admission_eligibilty { id = -1, Type_of_admission_eligibilty = "_-_-_-_-please Enter Status Of Admintion Eligilplity------" });
            return statusADEL;
        }
        List<Statues_of_admission_eligibilty> FillSellectionStatus_OF_Adm_eliEdit(Statues_of_admission_eligibilty sss)
        {
            var statusADEL = dB.Statues_of_admission_eligibilty.ToList();
            //var statusADEL = st_Of_Adm_Eli_Repo.List().ToList();
            var statusAdellist =  new List<Statues_of_admission_eligibilty>();
            statusAdellist.Insert(0, sss);
            statusADEL.Remove(sss);
                       //statusAdellist.Insert(1, new Statues_of_admission_eligibilty { id = -1, Type_of_admission_eligibilty = "_-_-_-_-please Enter Status Of Admintion Eligilplity------" });
            statusAdellist.InsertRange(1,statusADEL);
            //statusAdellist.Remove(s);
            return statusAdellist;
        }

        percentage_count_for_each_country_view_model GetAll()
        {
            var all = new percentage_count_for_each_country_view_model
            {
                FK_statues_of_admission_eligibilty = FillSellectionStatus_OF_Adm_eli(),
                FK_country = FillSellectionCountry()

            };
            return all;
        }
        percentage_count_for_each_country_view_model GetAllEDit( Country c,Statues_of_admission_eligibilty s)
        {
            var all = new percentage_count_for_each_country_view_model
            {
                FK_statues_of_admission_eligibilty = FillSellectionStatus_OF_Adm_eliEdit(s),
                FK_country = FillSellectionCountryEdit(c)

            };
            return all;
        }
    }
}

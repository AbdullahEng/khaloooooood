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
    public class percentage_count_for_each_country_Control : Controller
    {


        private readonly CRUD_Operation_Interface<Persentage_count_for_each__country> percentage_Repo;
        private readonly CRUD_Operation_Interface<Country> country_Repo;
        private readonly CRUD_Operation_Interface<Statues_of_admission_eligibilty> st_Of_Adm_Eli_Repo;

        public percentage_count_for_each_country_Control(CRUD_Operation_Interface<Persentage_count_for_each__country> percentage_repo
            , CRUD_Operation_Interface<Country> country_repo
            , CRUD_Operation_Interface<Statues_of_admission_eligibilty> st_of_adm_eli_repo
            )
        {
            percentage_Repo = percentage_repo;
            country_Repo = country_repo;
            st_Of_Adm_Eli_Repo = st_of_adm_eli_repo;
        }
        // GET: percentage_count_for_each_country_Controller
        public ActionResult Index()
        {
            var perc = percentage_Repo.List();
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
                percentage_Repo.Add(perc);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: percentage_count_for_each_country_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            var perc = percentage_Repo.Find(id);
            var percvi = new percentage_count_for_each_country_view_model
            {
                FK_country = FillSellectionCountry(),
                FK_statues_of_admission_eligibilty = FillSellectionStatus_OF_Adm_eli(),
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
                var country = country_Repo.Find(collection.countryId);
                var status_of_admi = st_Of_Adm_Eli_Repo.Find(collection.statues_of_adm_eli_ID);
                var perc = new Persentage_count_for_each__country
                {
                    FK_statues_of_admission_eligibilty = status_of_admi,
                    FK_country = country,
                    Rate = collection.Rate
                };
                percentage_Repo.Update(id, perc);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: percentage_count_for_each_country_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            var percfind = percentage_Repo.Find(id);
            var percvi = new percentage_count_for_each_country_view_model
            {
                FK_statues_of_admission_eligibilty = FillSellectionStatus_OF_Adm_eli(),
                FK_country = FillSellectionCountry(),
                Rate = percfind.Rate
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
                percentage_Repo.Delete(id);
                return RedirectToAction(nameof(Index));
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
        List<Statues_of_admission_eligibilty> FillSellectionStatus_OF_Adm_eli()
        {
            var statusADEL = st_Of_Adm_Eli_Repo.List().ToList();
            statusADEL.Insert(0, new Statues_of_admission_eligibilty { id = -1, Type_of_admission_eligibilty = "_-_-_-_-please Enter Status Of Admintion Eligilplity------" });
            return statusADEL;
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
    }
}

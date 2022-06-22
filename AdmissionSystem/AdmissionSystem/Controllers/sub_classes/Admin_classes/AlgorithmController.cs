using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.View_Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes.Admin_classes
{
    public class AlgorithmController : Controller
    {
        private readonly CRUD_Operation_Interface<Student> studentRepository;
        private readonly IHostingEnvironment hosting_;
        private readonly CRUD_Operation_Interface<Type_of_high_school_Cirtificate> type_Of_High_School_Cirtificate_Repository;
        private readonly CRUD_Operation_Interface<Department_relation_Type> department_Relation_Type_Repository;
        private readonly CRUD_Operation_Interface<Statues_Of_Student> statues_Of_Student_Repository;
        private readonly CRUD_Operation_Interface<Tracking_Rate> tracking_Rate_Repository;
        private readonly CRUD_Operation_Interface<Admission_Eligibilty_Certificate> admission_Eligibilty_Certificate_Repository;
        private readonly CRUD_Operation_Interface<Country> country_Repository;
        private readonly CRUD_Operation_Interface<Statues_of_admission_eligibilty> statues_Of_Admission_Eligibilty_Repository;
        private readonly CRUD_Operation_Interface<Department> department_Repository;

        public AlgorithmController(CRUD_Operation_Interface<Student> StudentRepository,
            IHostingEnvironment hosting_,
            CRUD_Operation_Interface<Type_of_high_school_Cirtificate> Type_of_high_school_Cirtificate_Repository,
            CRUD_Operation_Interface<Department_relation_Type> Department_relation_Type_Repository,
            CRUD_Operation_Interface<Statues_Of_Student> Statues_Of_Student_Repository,
             CRUD_Operation_Interface<Tracking_Rate> Tracking_Rate_Repository,
             CRUD_Operation_Interface<Admission_Eligibilty_Certificate> Admission_Eligibilty_Certificate_Repository
          , CRUD_Operation_Interface<Country> Country_Repository,
             CRUD_Operation_Interface<Statues_of_admission_eligibilty> Statues_of_admission_eligibilty_Repository,
              CRUD_Operation_Interface<Department> Department_Repository)
        {
            studentRepository = StudentRepository;
            this.hosting_ = hosting_;
            type_Of_High_School_Cirtificate_Repository = Type_of_high_school_Cirtificate_Repository;
            department_Relation_Type_Repository = Department_relation_Type_Repository;
            statues_Of_Student_Repository = Statues_Of_Student_Repository;
            tracking_Rate_Repository = Tracking_Rate_Repository;
            admission_Eligibilty_Certificate_Repository = Admission_Eligibilty_Certificate_Repository;
            country_Repository = Country_Repository;
            statues_Of_Admission_Eligibilty_Repository = Statues_of_admission_eligibilty_Repository;
            department_Repository = Department_Repository;
        }


        // GET: AlgorithmController


        public ActionResult Index()
        {
             List<Algorithm> lista= Algorithm();
            return View(lista);
        }

        // GET: AlgorithmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlgorithmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlgorithmController/Create
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

        // GET: AlgorithmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlgorithmController/Edit/5
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

        // GET: AlgorithmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlgorithmController/Delete/5
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


        public List<Algorithm> Algorithm()
        {
            var stlist = studentRepository.List().OrderByDescending(s=>s.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate).ToList();

            List<Algorithm> lista = new List<Algorithm>();

            int count = 0;//counter fo accepted student 
            int all_student_syrian = 9;

            foreach (var st in stlist) {

                if (st.high_school_certificate=="Syrian") {
                    //if for all student that must be accepted by minster of eduction
                    if (count <= all_student_syrian)
                    {
                        if (st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate >= admission_Eligibilty_Certificate_Repository.Find(st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id).wish1.Minemum_of_Rate )
                        {
                            //if (count2< st.Admission_Eligibilty_Requist_For_UNsy_Certificate.wish1.chaircount)
                            //{
                            //accepted
                            //}

                            Algorithm studentd = new Algorithm() { name = st.First_Name_EN, mark = st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate.ToString()
                            , Accepted = true, Counter = count + 1,WishNumber=1
                            };
                            lista.Add(studentd);
                        }
                        else if (st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate >= admission_Eligibilty_Certificate_Repository.Find(st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id).wish2.Minemum_of_Rate)
                        {
                            //if (count2< st.Admission_Eligibilty_Requist_For_UNsy_Certificate.wish1.chaircount)
                            //{
                            //accepted
                            //}

                            Algorithm studentd = new Algorithm()
                            {
                                name = st.First_Name_EN,
                                mark = st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate.ToString()
                            ,
                                Accepted = true,
                                Counter = count + 1,
                                WishNumber = 2
                            };
                            lista.Add(studentd);
                        }
                        else if (st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate >= admission_Eligibilty_Certificate_Repository.Find(st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id).wish3.Minemum_of_Rate)
                        {

                            //if (count2< st.Admission_Eligibilty_Requist_For_UNsy_Certificate.wish1.chaircount)
                            //{
                            //accepted
                            //}

                            Algorithm studentd = new Algorithm()
                            {
                                name = st.First_Name_EN,
                                mark = st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate.ToString()
                            ,
                                Accepted = true,
                                Counter = count + 1,
                                WishNumber = 3
                            };
                            lista.Add(studentd);
                        }

                    }
                    else if (st.high_school_certificate == "UnSyrian")
                    {
                        
                    }
                    count++;
                }

            }
  return lista ;
        }
    }
}

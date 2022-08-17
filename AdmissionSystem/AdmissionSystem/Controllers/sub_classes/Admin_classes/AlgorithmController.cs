using AdmissionSystem.Data;
using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.View_Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly CRUD_Operation_Interface<Persentage_count_for_each__country> percentRepo;
        private readonly CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair> brokRepo;
        private readonly CRUD_Operation_Interface<Accabtable_config> acceptedREpo;
        private readonly CRUD_Operation_Interface<Country> countryRepoooooo;
        private readonly ApplicationDbContext dB;

        public AlgorithmController(CRUD_Operation_Interface<Student> StudentRepository,
            IHostingEnvironment hosting_,
            CRUD_Operation_Interface<Type_of_high_school_Cirtificate> Type_of_high_school_Cirtificate_Repository,
            CRUD_Operation_Interface<Department_relation_Type> Department_relation_Type_Repository,
            CRUD_Operation_Interface<Statues_Of_Student> Statues_Of_Student_Repository,
             CRUD_Operation_Interface<Tracking_Rate> Tracking_Rate_Repository,
             CRUD_Operation_Interface<Admission_Eligibilty_Certificate> Admission_Eligibilty_Certificate_Repository
          , CRUD_Operation_Interface<Country> Country_Repository,
             CRUD_Operation_Interface<Statues_of_admission_eligibilty> Statues_of_admission_eligibilty_Repository,
              CRUD_Operation_Interface<Department> Department_Repository
            , CRUD_Operation_Interface<Persentage_count_for_each__country> percentRepo
            , CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair> brokRepo
            , CRUD_Operation_Interface<Accabtable_config> acceptedREpo
            ,CRUD_Operation_Interface<Country>countryRepoooooo
             ,   ApplicationDbContext DB
           
            )

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
            this.percentRepo = percentRepo;
            this.brokRepo = brokRepo;
            this.acceptedREpo = acceptedREpo;
            this.countryRepoooooo = countryRepoooooo;
            dB = DB;
        }


        // GET: AlgorithmController


        public ActionResult Index()
        {
            // List<Algorithm> lista= Algorithm();
            //return View(lista);
            return View();
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
        public ActionResult AlgorithmUNSyrain()
        {
            var cont = countryRepoooooo.List().ToList();
            var alogviewmodel = new AlgorithemViewModel { 
            CountryList=cont
            };
            return View(alogviewmodel);
        
        }
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlgorithmUNSyrain(AlgorithemViewModel country )
        {

            var percentagelist = percentRepo.List().SingleOrDefault(c => c.FK_countryId == country.countryId);

            var brokenlist = brokRepo.List();
            var listDeaprtmentsCahir = new List<NumberoStuentsForEachDepartment>();

            //   if(country.id==1)
            foreach (var item in brokenlist)
            {

                var number = new NumberoStuentsForEachDepartment
                {

                    chaircount = (int)percentagelist.Rate * item.Chair_count / 100,
                    Department_id = item.Fk_departmentId

                };
                listDeaprtmentsCahir.Add(number);

            }
            var listOfCheckedStudent = studentRepository.List().Where(s => s.Statues_Of_Student.Checked_city_certificate == true
                                                                      && s.Statues_Of_Student.Checked_Identity == true
                                                                      && s.Statues_Of_Student.Checked_Rate == true
                                                                      && s.Statues_Of_Student.Checked_recipet == true
                                                                      && s.Fk_Cirtificate_cityId == country.countryId).ToList();

            var sortedListOfcheckedstudent = listOfCheckedStudent.OrderByDescending(s => s.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate).ToList();





            foreach (var student in sortedListOfcheckedstudent)
            {
                //  if (student.high_school_certificate=="Syrian")
                var NumberofstudentinDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                               student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.wish1.FK_DepartmentId);
                var NumberofstudentinSECOUNDDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                 student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.wish2.FK_DepartmentId);
                var NumberofstudentinTHEREDDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                              student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.wish3.FK_DepartmentId);

                if (NumberofstudentinDepartmentREAlTIME.chaircount != 0)
                {
                    //  accepted
                    var stuAccconfig = acceptedREpo.Find(student.Id);

                    stuAccconfig.Accepted_wish = stuAccconfig.Accepted_wish;
                    stuAccconfig.Accepted_Or_Not = true;


                    stuAccconfig.FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty;
                    //  var acc = new Accabtable_config
                    //  {
                    //      Accepted_wish = stuAccconfig.Accepted_wish,
                    //      Accepted_Or_Not = true
                    //,
                    //      FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty
                    //  ,
                    //      FK_studentId = student.Id

                    //  };
                    //UpdateAcceptTable
                    acceptedREpo.Update(stuAccconfig.id, stuAccconfig);//remmber you want to bring database
                    listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                 student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.wish1.FK_DepartmentId).chaircount = NumberofstudentinDepartmentREAlTIME.chaircount - 1;
               
                }
                else if (NumberofstudentinSECOUNDDepartmentREAlTIME.chaircount != 0)
                {
                    //  accepted
                    var stuAccconfig = acceptedREpo.Find(student.Id);
                    stuAccconfig.Accepted_wish = stuAccconfig.Accepted_wish;
                    stuAccconfig.Accepted_Or_Not = true;


                    stuAccconfig.FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty;
                    //  var acc = new Accabtable_config
                    //  {
                    //      Accepted_wish = stuAccconfig.Accepted_wish,
                    //      Accepted_Or_Not = true
                    //,
                    //      FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty
                    //  ,
                    //      FK_studentId = student.Id

                    //  };
                    //UpdateAcceptTable
                    acceptedREpo.Update(stuAccconfig.id, stuAccconfig);//remmber you want to bring database
                    listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                 student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.wish2.FK_DepartmentId).chaircount = NumberofstudentinSECOUNDDepartmentREAlTIME.chaircount - 1;

                }
                else if (NumberofstudentinTHEREDDepartmentREAlTIME.chaircount != 0)
                {
                    //  accepted
                    var stuAccconfig = acceptedREpo.Find(student.Id);
                    stuAccconfig.Accepted_wish = stuAccconfig.Accepted_wish;
                    stuAccconfig.Accepted_Or_Not = true;


                    stuAccconfig.FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty;
                    //  var acc = new Accabtable_config
                    //  {
                    //      Accepted_wish = stuAccconfig.Accepted_wish,
                    //      Accepted_Or_Not = true
                    //,
                    //      FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty
                    //  ,
                    //      FK_studentId = student.Id

                    //  };
                    //UpdateAcceptTable
                    acceptedREpo.Update(stuAccconfig.id, stuAccconfig);//remmber you want to bring database
                    listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                 student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.wish3.FK_DepartmentId).chaircount = NumberofstudentinTHEREDDepartmentREAlTIME.chaircount - 1;

                }
                //else { 


                //}







            }

                return View();







            //          var stlist = studentRepository.List().OrderByDescending(s=>s.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate).ToList();

            //          List<Algorithm> lista = new List<Algorithm>();

            //          int count = 0;//counter fo accepted student 
            //          int all_student_syrian = 9;

            //          foreach (var st in stlist) {

            //              if (st.high_school_certificate=="Syrian") {
            //                  //if for all student that must be accepted by minster of eduction
            //                  if (count <= all_student_syrian)
            //                  {
            //                      if (st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate >= admission_Eligibilty_Certificate_Repository.Find(st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id).wish1.Minemum_of_Rate )
            //                      {
            //                          //if (count2< st.Admission_Eligibilty_Requist_For_UNsy_Certificate.wish1.chaircount)
            //                          //{
            //                          //accepted
            //                          //}

            //                          Algorithm studentd = new Algorithm() { name = st.First_Name_EN, mark = st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate.ToString()
            //                          , Accepted = true, Counter = count + 1,WishNumber=1
            //                          };
            //                          lista.Add(studentd);
            //                      }
            //                      else if (st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate >= admission_Eligibilty_Certificate_Repository.Find(st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id).wish2.Minemum_of_Rate)
            //                      {
            //                          //if (count2< st.Admission_Eligibilty_Requist_For_UNsy_Certificate.wish1.chaircount)
            //                          //{
            //                          //accepted
            //                          //}

            //                          Algorithm studentd = new Algorithm()
            //                          {
            //                              name = st.First_Name_EN,
            //                              mark = st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate.ToString()
            //                          ,
            //                              Accepted = true,
            //                              Counter = count + 1,
            //                              WishNumber = 2
            //                          };
            //                          lista.Add(studentd);
            //                      }
            //                      else if (st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate >= admission_Eligibilty_Certificate_Repository.Find(st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id).wish3.Minemum_of_Rate)
            //                      {

            //                          //if (count2< st.Admission_Eligibilty_Requist_For_UNsy_Certificate.wish1.chaircount)
            //                          //{
            //                          //accepted
            //                          //}

            //                          Algorithm studentd = new Algorithm()
            //                          {
            //                              name = st.First_Name_EN,
            //                              mark = st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate.ToString()
            //                          ,
            //                              Accepted = true,
            //                              Counter = count + 1,
            //                              WishNumber = 3
            //                          };
            //                          lista.Add(studentd);
            //                      }

            //                  }
            //                  else if (st.high_school_certificate == "UnSyrian")
            //                  {

            //                  }
            //                  count++;
            //              }

            //          }
            //return lista ;
        }

        public ActionResult AlgorithmSyrain()
        {
            var cont = countryRepoooooo.List().ToList();
            var alogviewmodel = new AlgorithemViewModel
            {
                CountryList = cont
            };
            return View(alogviewmodel);

        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlgorithmSyrain(AlgorithemViewModel country)
        {

            var percentagelist = percentRepo.List().SingleOrDefault(c => c.FK_countryId == country.countryId);

            var brokenlist = brokRepo.List();
            var departmentRelation = department_Relation_Type_Repository.List();
            var listDeaprtmentsCahir = new List<NumberoStuentsForEachDepartment>();

            //   if(country.id==1)
            foreach (var item in departmentRelation)
            {
                var broken = brokRepo.List().SingleOrDefault(d => d.Fk_departmentId == item.FK_DepartmentId);
                var cahaircountWithouttype = percentagelist.Rate * broken.Chair_count / 100;
                var number = new NumberoStuentsForEachDepartment
                {

                    chaircount = (int)(cahaircountWithouttype * item.Rate_of_chaire_count) / 100,
                    Department_id = item.FK_DepartmentId
                    ,
                    type_of_highschool_Id = item.FK_type_Of_High_School_CirtificateId

                };
                listDeaprtmentsCahir.Add(number);

            }

            var listOfCheckedStudent = studentRepository.List().Where(s => statues_Of_Student_Repository.Find(s.Id).Checked_city_certificate == true
                                                                      && statues_Of_Student_Repository.Find(s.Id).Checked_Identity == true
                                                                      && statues_Of_Student_Repository.Find(s.Id).Checked_Rate == true
                                                                      && statues_Of_Student_Repository.Find(s.Id).Checked_recipet == true
                                                                     // && s.Fk_Cirtificate_cityId == country.countryId
                                                                      && s.high_school_certificate == "Syrian"
                                                                      ).ToList();

            //var listOfCheckedStudent = studentRepository.List().Where(s =>
            //                                                    //       s.Fk_Cirtificate_cityId == country.countryId
            //                                                          //&& s.high_school_certificate == "Syrian"
            //                                                          ).ToList();


            //  var listOfCheckedStudent = studentRepository.List();
            var sortedListOfcheckedstudent = listOfCheckedStudent.OrderByDescending(s => s.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate).ToList();



            
            foreach (var student in sortedListOfcheckedstudent)
            {
                //  if (student.high_school_certificate=="Syrian")
                var admissioncirtificate = dB.Admission_Eligibilty_Certificate.AsNoTracking().Include(a => a.FK_Type_of_high_school_Cirtificate).Include(a => a.wish1).Include(a => a.wish2).Include(a => a.wish3).SingleOrDefault(a => a.id == student.Id);
                
                var NumberofstudentinDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                               admissioncirtificate.wish1.FK_DepartmentId
                            && d.type_of_highschool_Id ==
                           admissioncirtificate.wish1.FK_type_Of_High_School_CirtificateId);
                var NumberofstudentinSECOUNDDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                               admissioncirtificate.wish2.FK_DepartmentId
                                    && d.type_of_highschool_Id ==
                           admissioncirtificate.wish2.FK_type_Of_High_School_CirtificateId);
                var NumberofstudentinTHEREDDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                               admissioncirtificate.wish3.FK_DepartmentId
                                                 && d.type_of_highschool_Id ==
                            admissioncirtificate.wish3.FK_type_Of_High_School_CirtificateId);

                if (NumberofstudentinDepartmentREAlTIME.chaircount != 0)
                {
                    //  accepted
                    var stuAccconfig = dB.Accabtable_config.AsNoTracking().SingleOrDefault(a => a.id == student.Id);
                    var departmentrealtion = dB.Department.AsNoTracking().SingleOrDefault(d => d.id == admissioncirtificate.wish1.FK_DepartmentId);
                    stuAccconfig.Accepted_wish = departmentrealtion.specialization_name;
                    stuAccconfig.Accepted_Or_Not = true;
                    stuAccconfig.FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty;

                    //student.FK_Accabtable_configInfo = stuAccconfig;
                    //  var accfind = acceptedREpo.Find(student.Id);
                    //  var acc = new Accabtable_config
                    //  {
                    //      id = accfind.id,
                    //      Accepted_wish = stuAccconfig.Accepted_wish,
                    //      Accepted_Or_Not = true
                    //,
                    //      FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty
                    //  ,
                    //      FK_studentId = student.Id

                    //  };
                 //   student.FK_Accabtable_configInfo = acc;
                    //UpdateAcceptTable
                    dB.Accabtable_config.Update(stuAccconfig);
                   // dB.Student.Update( student );//remmber you want to bring database
                   
                    
                    
                    dB.SaveChanges();
                    listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                 admissioncirtificate.wish1.FK_DepartmentId
                                  && d.type_of_highschool_Id ==
                           admissioncirtificate.wish1.FK_type_Of_High_School_CirtificateId
                                 ).chaircount = NumberofstudentinDepartmentREAlTIME.chaircount - 1;

                }
                else if (NumberofstudentinSECOUNDDepartmentREAlTIME.chaircount != 0)
                {
                    //  accepted
                    var stuAccconfig = acceptedREpo.Find(student.Id);
                    stuAccconfig.Accepted_wish = stuAccconfig.Accepted_wish;
                    stuAccconfig.Accepted_Or_Not = true;


                    stuAccconfig.FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty;
                    //  var acc = new Accabtable_config
                    //  {
                    //      Accepted_wish = stuAccconfig.Accepted_wish,
                    //      Accepted_Or_Not = true
                    //,
                    //      FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty
                    //  ,
                    //      FK_studentId = student.Id

                    //  };
                    //UpdateAcceptTable
                    acceptedREpo.Update(stuAccconfig.id, stuAccconfig);//remmber you want to bring database
                    listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                 student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.wish2.FK_DepartmentId
                                  && d.type_of_highschool_Id ==
                            student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.wish2.FK_type_Of_High_School_CirtificateId
                                 ).chaircount = NumberofstudentinSECOUNDDepartmentREAlTIME.chaircount - 1;

                }
                else if (NumberofstudentinTHEREDDepartmentREAlTIME.chaircount != 0)
                {
                    //  accepted
                    var stuAccconfig = acceptedREpo.Find(student.Id);
                    stuAccconfig.Accepted_wish = stuAccconfig.Accepted_wish;
                    stuAccconfig.Accepted_Or_Not = true;


                    stuAccconfig.FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty;
                    //  var acc = new Accabtable_config
                    //  {
                    //      Accepted_wish = stuAccconfig.Accepted_wish,
                    //      Accepted_Or_Not = true
                    //,
                    //      FK_Statues_of_admission_eligibilty = student.Statues_Of_Admission_Eligibilty
                    //  ,
                    //      FK_studentId = student.Id

                    //  };
                    //UpdateAcceptTable
                    acceptedREpo.Update(stuAccconfig.id, stuAccconfig);//remmber you want to bring database
                    listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                 student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.wish3.FK_DepartmentId
                                  && d.type_of_highschool_Id ==
                            student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.wish3.FK_type_Of_High_School_CirtificateId
                                 ).chaircount = NumberofstudentinTHEREDDepartmentREAlTIME.chaircount - 1;

                }
                //else { 


                //}




            }

            return View();
        }
    }
}

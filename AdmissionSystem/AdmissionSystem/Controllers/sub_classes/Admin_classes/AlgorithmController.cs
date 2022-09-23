using AdmissionSystem.Data;
using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.View_Model;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes.Admin_classes
{
    [Authorize(Roles = "Admin")]
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
            , CRUD_Operation_Interface<Country> countryRepoooooo
             , ApplicationDbContext DB

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
           
           
            var accinfolist = new List<AcceptebleIformationAnd_Details>();
            var alogviewmodel = new AlgorithemViewModel
            {
                CountryList = fillcountryUnSyrian()
                  ,
                Accinfo = accinfolist
                ,
                departmentList =FillDepartment()
                ,statues_Of_Admission_Eligibiltieslist= fillstatusAdmsissionUnSyrian()
            };
            return View(alogviewmodel);

        }
        public List<Country> fillcountryUnSyrian() {
            
            var cont = dB.Country.ToList();
            var countfind = countryRepoooooo.Find(1);
            cont.Remove(countfind);
            var listcountry = new List<Country>();
            listcountry.Insert(0,new Country {id=-1 ,country_name="please Enter hte country" });
            listcountry.InsertRange(1,cont);
            return listcountry;
        }
        public List<Statues_of_admission_eligibilty> fillstatusAdmsissionUnSyrian()
        {

            var status = dB.Statues_of_admission_eligibilty.ToList();
            status.Insert(0, new Statues_of_admission_eligibilty { id = -1, Type_of_admission_eligibilty = "please Enter hte status" });
           return status;
        }
        public List<Department> FillDepartment() {
            var dep = department_Repository.List().ToList();
            var listdep = new List<Department>();
            listdep.Insert(0,new Department {id=-1, specialization_name="Please Enter The department" });
            listdep.InsertRange(1,dep);
            return listdep;

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlgorithmUNSyrain(AlgorithemViewModel modelAlgo)
        {
            if (modelAlgo.countryId == -1 || modelAlgo.DepartmentId == -1) {
                ViewBag.message = "Please Select All Info";
                var accinfolist1 = new List<AcceptebleIformationAnd_Details>();
                var alogviewmodel = new AlgorithemViewModel
                {
                    CountryList = fillcountryUnSyrian()
                      ,
                    Accinfo = accinfolist1
                    ,
                    departmentList = FillDepartment()
                     ,
                    statues_Of_Admission_Eligibiltieslist = fillstatusAdmsissionUnSyrian()
                };
                return View(alogviewmodel);
            }
            var percentagelist = percentRepo.List().SingleOrDefault(c => c.FK_countryId == modelAlgo.countryId);

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
            //var findstauts =;
            var listOfCheckedStudent = studentRepository.List().Where(s => statues_Of_Student_Repository.Find(s.Id).Checked_city_certificate == true
                                                                       && statues_Of_Student_Repository.Find(s.Id).Checked_Identity == true
                                                                       && statues_Of_Student_Repository.Find(s.Id).Checked_Rate == true
                                                                       && statues_Of_Student_Repository.Find(s.Id).Checked_recipet == true
                                                                       // && s.Fk_Cirtificate_cityId == country.countryId
                                                                       && s.high_school_certificate == "UNSyrian"
                                                                       && s.Statues_Of_Admission_Eligibilty.id==modelAlgo.statusofAdmissionId
                                                                       ).ToList();
            var sortedListOfcheckedstudent = listOfCheckedStudent.OrderByDescending(s => s.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate).ToList();





            foreach (var student in sortedListOfcheckedstudent)
            {
                var admissioncirtificate = dB.Admission_Eligibilty_Certificate.AsNoTracking().Include(a => a.FK_Type_of_high_school_Cirtificate).Include(a => a.wish1).Include(a => a.wish2).Include(a => a.wish3).SingleOrDefault(a => a.id == student.Id);
                NumberoStuentsForEachDepartment NumberofstudentinDepartmentREAlTIME = new NumberoStuentsForEachDepartment { chaircount = 0 };
                NumberoStuentsForEachDepartment NumberofstudentinSECOUNDDepartmentREAlTIME = new NumberoStuentsForEachDepartment { chaircount = 0 };
                NumberoStuentsForEachDepartment NumberofstudentinTHEREDDepartmentREAlTIME = new NumberoStuentsForEachDepartment { chaircount = 0 };
                //  if (student.high_school_certificate=="Syrian")
                if (admissioncirtificate.wish1 != null)
                {
                    NumberofstudentinDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                 admissioncirtificate.wish1.FK_DepartmentId);
                }
                if (admissioncirtificate.wish2 != null)
                {
                    NumberofstudentinSECOUNDDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                  admissioncirtificate.wish2.FK_DepartmentId);

                }
                if (admissioncirtificate.wish3 != null)
                {
                    NumberofstudentinTHEREDDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                             admissioncirtificate.wish3.FK_DepartmentId);
                }

                if (NumberofstudentinDepartmentREAlTIME.chaircount != 0)
                {
                    var stuAccconfig = dB.Accabtable_config.AsNoTracking().SingleOrDefault(a => a.id == student.Id);
                    var departmentrealtion = dB.Department.AsNoTracking().SingleOrDefault(d => d.id == admissioncirtificate.wish1.FK_DepartmentId);
                    stuAccconfig.Accepted_wish = departmentrealtion.specialization_name;
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
                    dB.Accabtable_config.Update(stuAccconfig);
                    // dB.Student.Update( student );//remmber you want to bring database



                    dB.SaveChanges();//remmber you want to bring database
                    listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                 admissioncirtificate.wish1.FK_DepartmentId).chaircount = NumberofstudentinDepartmentREAlTIME.chaircount - 1;

                }
                else
                // if(NumberofstudentinSECOUNDDepartmentREAlTIME.chaircount!=null) to memorize  And or not And *-*
                if (NumberofstudentinSECOUNDDepartmentREAlTIME.chaircount != 0)
                {
                    //  accepted
                    var stuAccconfig = dB.Accabtable_config.AsNoTracking().SingleOrDefault(a => a.id == student.Id);
                    var departmentrealtion = dB.Department.AsNoTracking().SingleOrDefault(d => d.id == admissioncirtificate.wish2.FK_DepartmentId);
                    stuAccconfig.Accepted_wish = departmentrealtion.specialization_name;
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
                                admissioncirtificate.wish2.FK_DepartmentId).chaircount = NumberofstudentinSECOUNDDepartmentREAlTIME.chaircount - 1;

                }
                else if (NumberofstudentinTHEREDDepartmentREAlTIME.chaircount != 0)
                {
                    //  accepted
                    var stuAccconfig = dB.Accabtable_config.AsNoTracking().SingleOrDefault(a => a.id == student.Id);
                    var departmentrealtion = dB.Department.AsNoTracking().SingleOrDefault(d => d.id == admissioncirtificate.wish3.FK_DepartmentId);
                    stuAccconfig.Accepted_wish = departmentrealtion.specialization_name;
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
                    dB.Accabtable_config.Update(stuAccconfig);
                    // dB.Student.Update( student );//remmber you want to bring database



                    dB.SaveChanges();//remmber you want to bring database
                    listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                admissioncirtificate.wish3.FK_DepartmentId).chaircount = NumberofstudentinTHEREDDepartmentREAlTIME.chaircount - 1;

                }
                //else { 


                //}







            }



            var viewwithCountry = acceptedREpo.List().Where(a =>
                                                                        countryRepoooooo.Find(studentRepository.Find(a.FK_studentId).Cirtificate_city.id).id
                                                                          == modelAlgo.countryId
                                                                          && a.FK_Statues_of_admission_eligibilty.id ==modelAlgo.statusofAdmissionId
                                                                          ).ToList();
            var departments = department_Repository.List().SingleOrDefault(a => a.id == modelAlgo.DepartmentId);
            var accinfolist = new List<AcceptebleIformationAnd_Details>();

            foreach (var item in viewwithCountry)
            {
                if (viewwithCountry != null)
                {
                    var stu = studentRepository.Find(item.FK_studentId);
                    var country11 = countryRepoooooo.Find(stu.Cirtificate_city.id);
                    var Admission = admission_Eligibilty_Certificate_Repository.Find(stu.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
                    var statusof = statues_Of_Admission_Eligibilty_Repository.Find(item.FK_Statues_of_admission_eligibiltyId);
                    if (item.Accepted_wish == departments.specialization_name)
                    {
                        var accifo = new AcceptebleIformationAnd_Details
                        {
                            Accepted_wish = item.Accepted_wish,
                            cuntry = country11.country_name,
                            Status_of_Admission_elgibility = statusof.Type_of_admission_eligibilty,
                            beganing_date_of_Admission=statusof.Begaining_date_of_the_process.ToString()
                            ,
                            semester_NO=statusof.semester_no
                            ,

                            studnet_name = item.FK_student.Father_Name_EN,
                            The_rate = Admission.The_Rate

                        };
                        accinfolist.Add(accifo);
                    }
                }
            }
            var cont = countryRepoooooo.List().ToList();
            var dep = department_Repository.List().ToList();
            var algo = new AlgorithemViewModel
            {
                CountryList = fillcountryUnSyrian(),
                Accinfo = accinfolist
               ,
                departmentList = FillDepartment()
                ,statues_Of_Admission_Eligibiltieslist=fillstatusAdmsissionUnSyrian()
            };











            return View(algo);







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
            var dep = department_Repository.List().ToList();
            var accinfolist = new List<AcceptebleIformationAnd_Details>();
            //Accepted_wish=null,
            //Status_of_Admission_elgibility=null,
            //studnet_name=null,
            //The_rate=0,
            //cuntry=null,



            //};
            var alogviewmodel = new AlgorithemViewModel
            {
                CountryList = fillcountrySyrian()
                ,
                Accinfo = accinfolist
                ,
                departmentList = FillDepartment()
                , statues_Of_Admission_Eligibiltieslist = fillstatusAdmsissionUnSyrian()
            };
            return View(alogviewmodel);

        }


        public List<Country> fillcountrySyrian()
        {

            var cont = dB.Country.ToList();
           // var countfind = countryRepoooooo.Find(1);
           if(cont.Count>1)
            cont.RemoveRange(1,cont.Count-1);
            var listcountry = new List<Country>();
            listcountry.Insert(0, new Country { id = -1, country_name = "please Enter the country" });
            listcountry.InsertRange(1, cont);
            return listcountry;
        }
        ///    /////    ////////////////////////////////////////////////////////////////////////////////////////////----------SY-------------//////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlgorithmSyrain(AlgorithemViewModel modelAlgo)
        {

            if (modelAlgo.countryId == -1 || modelAlgo.DepartmentId == -1)
            {
                ViewBag.message = "Please Select All Info";
                var accinfolist1 = new List<AcceptebleIformationAnd_Details>();
               
                var alogviewmodel = new AlgorithemViewModel
                {
                    CountryList = fillcountrySyrian()
                    ,
                    Accinfo = accinfolist1
                    ,
                    departmentList = FillDepartment()
                     ,
                    statues_Of_Admission_Eligibiltieslist = fillstatusAdmsissionUnSyrian()
                };
                return View(alogviewmodel);
                //    ViewBag.message = "Please Select All Info";
                //    var accinfolist2 = new List<AcceptebleIformationAnd_Details>();
                //    var alogviewmodel = new AlgorithemViewModel
                //    {
                //        CountryList = fillcountry()
                //          ,
                //        Accinfo = accinfolist2
                //        ,
                //        departmentList = FillDepartment()
                //    };
                //    return View(alogviewmodel);
               // return View();
            }

          //  var countryfindsy = countryRepoooooo.Find(1);
            var percentagelist = percentRepo.List().SingleOrDefault(c => c.FK_countryId == modelAlgo.countryId);

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
                                                                       && s.Statues_Of_Admission_Eligibilty.id == modelAlgo.statusofAdmissionId
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
                if (sortedListOfcheckedstudent != null)
                {

                    NumberoStuentsForEachDepartment NumberofstudentinDepartmentREAlTIME = new NumberoStuentsForEachDepartment { chaircount = 0 };
                    NumberoStuentsForEachDepartment NumberofstudentinSECOUNDDepartmentREAlTIME = new NumberoStuentsForEachDepartment { chaircount = 0 };
                    NumberoStuentsForEachDepartment NumberofstudentinTHEREDDepartmentREAlTIME = new NumberoStuentsForEachDepartment { chaircount = 0 };



                    var admissioncirtificate = dB.Admission_Eligibilty_Certificate.AsNoTracking().Include(a => a.FK_Type_of_high_school_Cirtificate).Include(a => a.wish1).Include(a => a.wish2).Include(a => a.wish3).SingleOrDefault(a => a.id == student.Id);
                    if (admissioncirtificate.wish1 != null)
                    {
                        NumberofstudentinDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                   admissioncirtificate.wish1.FK_DepartmentId
                                && d.type_of_highschool_Id ==
                               admissioncirtificate.wish1.FK_type_Of_High_School_CirtificateId);
                    }
                    if (admissioncirtificate.wish2 != null)
                    {
                        NumberofstudentinSECOUNDDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                  admissioncirtificate.wish2.FK_DepartmentId
                                       && d.type_of_highschool_Id ==
                              admissioncirtificate.wish2.FK_type_Of_High_School_CirtificateId);
                    }
                    if (admissioncirtificate.wish3 != null)
                    {
                        NumberofstudentinTHEREDDepartmentREAlTIME = listDeaprtmentsCahir.SingleOrDefault(d => d.Department_id ==
                                                   admissioncirtificate.wish3.FK_DepartmentId
                                                     && d.type_of_highschool_Id ==
                                admissioncirtificate.wish3.FK_type_Of_High_School_CirtificateId);
                    }
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
                        var stuAccconfig = dB.Accabtable_config.AsNoTracking().SingleOrDefault(a => a.id == student.Id);
                        var departmentrealtion = dB.Department.AsNoTracking().SingleOrDefault(d => d.id == admissioncirtificate.wish2.FK_DepartmentId);
                        stuAccconfig.Accepted_wish = departmentrealtion.specialization_name;
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
                        var stuAccconfig = dB.Accabtable_config.AsNoTracking().SingleOrDefault(a => a.id == student.Id);
                        var departmentrealtion = dB.Department.AsNoTracking().SingleOrDefault(d => d.id == admissioncirtificate.wish3.FK_DepartmentId);
                        stuAccconfig.Accepted_wish = departmentrealtion.specialization_name;
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



            }

            //  var country = countryRepoooooo.Find();

            var viewwithCountry = acceptedREpo.List().Where(a =>
                                                                        countryRepoooooo.Find(studentRepository.Find(a.FK_studentId).Cirtificate_city.id).id
                                                                          == modelAlgo.countryId
                                                                          && a.FK_Statues_of_admission_eligibilty.id == modelAlgo.statusofAdmissionId
                                                                          ).ToList();
            var departments = department_Repository.List().SingleOrDefault(a => a.id == modelAlgo.DepartmentId);
            var accinfolist = new List<AcceptebleIformationAnd_Details>();

            foreach (var item in viewwithCountry)
            {
                if (viewwithCountry != null)
                {
                    var stu = studentRepository.Find(item.FK_studentId);
                    var country11 = countryRepoooooo.Find(stu.Cirtificate_city.id);
                    var Admission = admission_Eligibilty_Certificate_Repository.Find(stu.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
                    var statusof = statues_Of_Admission_Eligibilty_Repository.Find(item.FK_Statues_of_admission_eligibiltyId);
                    if (item.Accepted_wish == departments.specialization_name)
                    {
                        var accifo = new AcceptebleIformationAnd_Details
                        {
                            Accepted_wish = item.Accepted_wish,
                            cuntry = country11.country_name,
                            Status_of_Admission_elgibility = statusof.Type_of_admission_eligibilty,
                            beganing_date_of_Admission = statusof.Begaining_date_of_the_process.ToString()
                            ,
                            semester_NO = statusof.semester_no
                            ,
                            studnet_name = item.FK_student.Father_Name_EN,
                            The_rate = Admission.The_Rate

                        };
                        accinfolist.Add(accifo);
                    }
                }
            }
          //  var cont = countryRepoooooo.List().ToList();
          //  var dep = department_Repository.List().ToList();
            var algo = new AlgorithemViewModel
            {
                CountryList = fillcountrySyrian(),
                Accinfo = accinfolist
               ,
                departmentList = FillDepartment()
                 ,
                statues_Of_Admission_Eligibiltieslist = fillstatusAdmsissionUnSyrian()
            };













            //using (var workbook=new XLWorkbook()) {
            //    var worksheet = workbook.Worksheets.Add("Admission");
            //    var currentRow = 1;
            //    worksheet.Cell(currentRow,1).Value= "Student name";
            //    worksheet.Cell(currentRow,2).Value= "Accepted Wish";
            //    worksheet.Cell(currentRow, 3).Value = "country";
            //    worksheet.Cell(currentRow, 4).Value = "Rate";
            //    worksheet.Cell(currentRow, 5).Value = "Status of Admission elgibility";





            //    foreach (var item in accinfolist)
            //    {
            //        currentRow++;
            //        worksheet.Cell(currentRow, 1).Value = item.studnet_name;
            //        worksheet.Cell(currentRow, 2).Value = item.Accepted_wish;
            //        worksheet.Cell(currentRow, 3).Value = item.cuntry;
            //        worksheet.Cell(currentRow, 4).Value = item.The_rate;
            //        worksheet.Cell(currentRow, 5).Value = item.Status_of_Admission_elgibility;
            //    }
            //    using (var stream = new MemoryStream()) {
            //        workbook.SaveAs(stream);
            //        var content = stream.ToArray();
            //        return File(content,
            //            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            //            "Admission.xlsx"
            //            );



            //    }




            //}

           // ExcelsheetAdmission(modelAlgo);

            return View(algo);
        }
        public ActionResult ExcelsheetAdmission(AlgorithemViewModel modelalgo)
        {

          //  var countryfindsy = countryRepoooooo.Find(1);
            var viewwithCountry = acceptedREpo.List().Where(a =>
                                                                 countryRepoooooo.Find(studentRepository.Find(a.FK_studentId).Cirtificate_city.id).id


                                                                   == modelalgo.countryId
                                                                      && a.FK_Statues_of_admission_eligibilty.id == modelalgo.statusofAdmissionId

                                                                   ).ToList();
            var departments = department_Repository.List().SingleOrDefault(a => a.id == modelalgo.DepartmentId);
            var accinfolist = new List<AcceptebleIformationAnd_Details>();

            foreach (var item in viewwithCountry)
            {
                if (viewwithCountry != null)
                {
                    var stu = studentRepository.Find(item.FK_studentId);
                    var country11 = countryRepoooooo.Find(stu.Cirtificate_city.id);
                    var Admission = admission_Eligibilty_Certificate_Repository.Find(stu.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
                    var statusof = statues_Of_Admission_Eligibilty_Repository.Find(item.FK_Statues_of_admission_eligibiltyId);
                    if (item.Accepted_wish == departments.specialization_name)
                    {
                        var accifo = new AcceptebleIformationAnd_Details
                        {
                            Accepted_wish = item.Accepted_wish,
                            cuntry = country11.country_name,
                            Status_of_Admission_elgibility = statusof.Type_of_admission_eligibilty,
                            beganing_date_of_Admission = statusof.Begaining_date_of_the_process.ToString()
                            ,
                            semester_NO = statusof.semester_no
                            ,
                            studnet_name = item.FK_student.Father_Name_EN,
                            The_rate = Admission.The_Rate
                             ,
                            University_ID = stu.UnvirstyId.ToString()

                        };
                        accinfolist.Add(accifo);
                    }
                }
            }
            var cont = countryRepoooooo.List().ToList();
            var dep = department_Repository.List().ToList();
            var algo = new AlgorithemViewModel
            {
                CountryList = cont,
                Accinfo = accinfolist
               ,
                departmentList = dep

            };










            var depfind = department_Repository.Find(modelalgo.DepartmentId);
          

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Admission");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Student name";
                worksheet.Cell(currentRow, 2).Value = "Accepted Wish";
                worksheet.Cell(currentRow, 3).Value = "country";
                worksheet.Cell(currentRow, 4).Value = "Rate";
                worksheet.Cell(currentRow, 5).Value = "Status of Admission elgibility";
                worksheet.Cell(currentRow, 6).Value = "beginning date of Admission";
                worksheet.Cell(currentRow, 7).Value = "semester NO";
                worksheet.Cell(currentRow, 8).Value = "Unvirsty Id";





                foreach (var item in accinfolist)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.studnet_name;
                    worksheet.Cell(currentRow, 2).Value = item.Accepted_wish;
                    worksheet.Cell(currentRow, 3).Value = item.cuntry;
                    worksheet.Cell(currentRow, 4).Value = item.The_rate;
                    worksheet.Cell(currentRow, 5).Value = item.Status_of_Admission_elgibility;
                    worksheet.Cell(currentRow, 6).Value = item.beganing_date_of_Admission;
                    worksheet.Cell(currentRow, 7).Value = item.semester_NO;
                    worksheet.Cell(currentRow, 8).Value = item.University_ID;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Admission "+ depfind.specialization_name + ".xlsx"
                        );



                }




            }

        }

        public ActionResult ExcelsheetAdmissionAll(AlgorithemViewModel modelalgo)
        {

            //  var countryfindsy = countryRepoooooo.Find(1);
            var viewwithCountry = acceptedREpo.List().Where(a =>
                                                                 countryRepoooooo.Find(studentRepository.Find(a.FK_studentId).Cirtificate_city.id).id


                                                                   == modelalgo.countryId
                                                                      && a.FK_Statues_of_admission_eligibilty.id == modelalgo.statusofAdmissionId

                                                                   ).ToList();
           // var departments = department_Repository.List().SingleOrDefault(a => a.id == modelalgo.DepartmentId);
            var accinfolist = new List<AcceptebleIformationAnd_Details>();

            foreach (var item in viewwithCountry)
            {
                if (viewwithCountry != null)
                {
                    var stu = studentRepository.Find(item.FK_studentId);
                    var country11 = countryRepoooooo.Find(stu.Cirtificate_city.id);
                    var Admission = admission_Eligibilty_Certificate_Repository.Find(stu.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
                    var statusof = statues_Of_Admission_Eligibilty_Repository.Find(item.FK_Statues_of_admission_eligibiltyId);
                    if (item.Accepted_Or_Not == true)
                    {
                        var accifo = new AcceptebleIformationAnd_Details
                        {
                            Accepted_wish = item.Accepted_wish,
                            cuntry = country11.country_name,
                            Status_of_Admission_elgibility = statusof.Type_of_admission_eligibilty,
                            beganing_date_of_Admission = statusof.Begaining_date_of_the_process.ToString()
                            ,
                            semester_NO = statusof.semester_no
                            ,
                            studnet_name = item.FK_student.Father_Name_EN,
                            The_rate = Admission.The_Rate
                           ,University_ID=stu.UnvirstyId.ToString()

                        };
                        accinfolist.Add(accifo);
                    }
                }
            }
            var cont = countryRepoooooo.List().ToList();
            var dep = department_Repository.List().ToList();
            var algo = new AlgorithemViewModel
            {
                CountryList = cont,
                Accinfo = accinfolist
               ,
                departmentList = dep

            };










            //   var depfind = department_Repository.Find(modelalgo.DepartmentId);
            var countr = countryRepoooooo.Find(modelalgo.countryId);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Admission");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Student name";
                worksheet.Cell(currentRow, 2).Value = "Accepted Wish";
                worksheet.Cell(currentRow, 3).Value = "country";
                worksheet.Cell(currentRow, 4).Value = "Rate";
                worksheet.Cell(currentRow, 5).Value = "Status of Admission elgibility";
                worksheet.Cell(currentRow, 6).Value = "beginning date of Admission";
                worksheet.Cell(currentRow, 7).Value = "semester NO";
                worksheet.Cell(currentRow, 8).Value = "Unvirsty Id";





                foreach (var item in accinfolist)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.studnet_name;
                    worksheet.Cell(currentRow, 2).Value = item.Accepted_wish;
                    worksheet.Cell(currentRow, 3).Value = item.cuntry;
                    worksheet.Cell(currentRow, 4).Value = item.The_rate;
                    worksheet.Cell(currentRow, 5).Value = item.Status_of_Admission_elgibility;
                    worksheet.Cell(currentRow, 6).Value = item.beganing_date_of_Admission;
                    worksheet.Cell(currentRow, 7).Value = item.semester_NO;
                    worksheet.Cell(currentRow, 8).Value = item.University_ID;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Admission " + countr.country_name + ".xlsx"
                        );



                }




            }

        }






        public ActionResult ExcelsheetAdmissionUNSrian(AlgorithemViewModel modelalgo)
        {

            // var countryfindsy = countryRepoooooo.Find(1);
            var viewwithCountry = acceptedREpo.List().Where(a =>
                                                                         countryRepoooooo.Find(studentRepository.Find(a.FK_studentId).Cirtificate_city.id).id
                                                                           == modelalgo.countryId
                                                                           && a.FK_Statues_of_admission_eligibilty.id == modelalgo.statusofAdmissionId
                                                                           ).ToList();
            var departments = department_Repository.List().SingleOrDefault(a => a.id == modelalgo.DepartmentId);
            var accinfolist = new List<AcceptebleIformationAnd_Details>();

            foreach (var item in viewwithCountry)
            {
                if (viewwithCountry != null)
                {
                    var stu = studentRepository.Find(item.FK_studentId);
                    var country11 = countryRepoooooo.Find(stu.Cirtificate_city.id);
                    var Admission = admission_Eligibilty_Certificate_Repository.Find(stu.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
                    var statusof = statues_Of_Admission_Eligibilty_Repository.Find(item.FK_Statues_of_admission_eligibiltyId);
                    if (item.Accepted_wish == departments.specialization_name)
                    {
                        var accifo = new AcceptebleIformationAnd_Details
                        {
                            Accepted_wish = item.Accepted_wish,
                            cuntry = country11.country_name,
                            Status_of_Admission_elgibility = statusof.Type_of_admission_eligibilty,
                            beganing_date_of_Admission = statusof.Begaining_date_of_the_process.ToString()
                            ,
                            semester_NO = statusof.semester_no
                            ,
                            studnet_name = item.FK_student.Father_Name_EN,
                            The_rate = Admission.The_Rate
                             ,
                            University_ID = stu.UnvirstyId.ToString()

                        };
                        accinfolist.Add(accifo);
                    }
                }
            }
            //var cont = countryRepoooooo.List().ToList();
            //var dep = department_Repository.List().ToList();
            //var algo = new AlgorithemViewModel
            //{
            //    CountryList = cont,
            //    Accinfo = accinfolist
            //   ,
            //    departmentList = dep
            //};










            var depfind = department_Repository.Find(modelalgo.DepartmentId);


            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Admission");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Student name";
                worksheet.Cell(currentRow, 2).Value = "Accepted Wish";
                worksheet.Cell(currentRow, 3).Value = "country";
                worksheet.Cell(currentRow, 4).Value = "Rate";
                worksheet.Cell(currentRow, 5).Value = "Status of Admission elgibility";
                worksheet.Cell(currentRow, 6).Value = "beginning date of Admission";
                worksheet.Cell(currentRow, 7).Value = "semester NO";
                worksheet.Cell(currentRow, 8).Value = "Unvirsty Id";


                foreach (var item in accinfolist)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.studnet_name;
                    worksheet.Cell(currentRow, 2).Value = item.Accepted_wish;
                    worksheet.Cell(currentRow, 3).Value = item.cuntry;
                    worksheet.Cell(currentRow, 4).Value = item.The_rate;
                    worksheet.Cell(currentRow, 5).Value = item.Status_of_Admission_elgibility;
                    worksheet.Cell(currentRow, 6).Value = item.beganing_date_of_Admission;
                    worksheet.Cell(currentRow, 7).Value = item.semester_NO;
                    worksheet.Cell(currentRow, 8).Value = item.University_ID;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Admission " + depfind.specialization_name + ".xlsx"
                        );



                }




            }

        }





        public ActionResult ExcelsheetAdmissionAllUNSrian(AlgorithemViewModel modelalgo)
        {

            // var countryfindsy = countryRepoooooo.Find(1);
            var viewwithCountry = acceptedREpo.List().Where(a =>
                                                                         countryRepoooooo.Find(studentRepository.Find(a.FK_studentId).Cirtificate_city.id).id
                                                                           == modelalgo.countryId
                                                                           && a.FK_Statues_of_admission_eligibilty.id == modelalgo.statusofAdmissionId
                                                                           ).ToList();
          //  var departments = department_Repository.List().SingleOrDefault(a => a.id == modelalgo.DepartmentId);
            var accinfolist = new List<AcceptebleIformationAnd_Details>();

            foreach (var item in viewwithCountry)
            {
                if (viewwithCountry != null)
                {
                    var stu = studentRepository.Find(item.FK_studentId);
                    var country11 = countryRepoooooo.Find(stu.Cirtificate_city.id);
                    var Admission = admission_Eligibilty_Certificate_Repository.Find(stu.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
                    var statusof = statues_Of_Admission_Eligibilty_Repository.Find(item.FK_Statues_of_admission_eligibiltyId);
                    if (item.Accepted_Or_Not == true)
                    {
                        var accifo = new AcceptebleIformationAnd_Details
                        {
                            Accepted_wish = item.Accepted_wish,
                            cuntry = country11.country_name,
                            Status_of_Admission_elgibility = statusof.Type_of_admission_eligibilty,
                            beganing_date_of_Admission = statusof.Begaining_date_of_the_process.ToString()
                            ,
                            semester_NO = statusof.semester_no
                            ,
                            studnet_name = item.FK_student.Father_Name_EN,
                            The_rate = Admission.The_Rate
                            ,University_ID=stu.UnvirstyId.ToString()
                        };
                        accinfolist.Add(accifo);
                    }
                }
            }
            //var cont = countryRepoooooo.List().ToList();
            //var dep = department_Repository.List().ToList();
            //var algo = new AlgorithemViewModel
            //{
            //    CountryList = cont,
            //    Accinfo = accinfolist
            //   ,
            //    departmentList = dep
            //};










            //  var depfind = department_Repository.Find(modelalgo.DepartmentId);
            var countr = countryRepoooooo.Find(modelalgo.countryId);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Admission");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Student name";
                worksheet.Cell(currentRow, 2).Value = "Accepted Wish";
                worksheet.Cell(currentRow, 3).Value = "country";
                worksheet.Cell(currentRow, 4).Value = "Rate";
                worksheet.Cell(currentRow, 5).Value = "Status of Admission elgibility";
                worksheet.Cell(currentRow, 6).Value = "beginning date of Admission";
                worksheet.Cell(currentRow, 7).Value = "semester NO";
                worksheet.Cell(currentRow, 8).Value = "Unvirsty Id";


                foreach (var item in accinfolist)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.studnet_name;
                    worksheet.Cell(currentRow, 2).Value = item.Accepted_wish;
                    worksheet.Cell(currentRow, 3).Value = item.cuntry;
                    worksheet.Cell(currentRow, 4).Value = item.The_rate;
                    worksheet.Cell(currentRow, 5).Value = item.Status_of_Admission_elgibility;
                    worksheet.Cell(currentRow, 6).Value = item.beganing_date_of_Admission;
                    worksheet.Cell(currentRow, 7).Value = item.semester_NO;
                    worksheet.Cell(currentRow, 8).Value = item.University_ID;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Admission " + countr.country_name + ".xlsx"
                        );



                }




            }

        }








    }
}

using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.View_Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers
{
    public class StudenController : Controller
    {
        private readonly CRUD_Operation_Interface<Student> studentRepository;
        private readonly IHostingEnvironment hosting_;
        private readonly CRUD_Operation_Interface<Type_of_high_school_Cirtificate> type_Of_High_School_Cirtificate_Repository;
        private readonly CRUD_Operation_Interface<Department_relation_Type> department_Relation_Type_Repository;
        private readonly CRUD_Operation_Interface<Statues_Of_Student> statues_Of_Student_Repository;
        private readonly CRUD_Operation_Interface<Tracking_Rate> tracking_Rate_Repository;

        public StudenController(CRUD_Operation_Interface<Student> StudentRepository,
            IHostingEnvironment hosting_,
            CRUD_Operation_Interface<Type_of_high_school_Cirtificate> Type_of_high_school_Cirtificate_Repository,
            CRUD_Operation_Interface<Department_relation_Type> Department_relation_Type_Repository,
            CRUD_Operation_Interface<Statues_Of_Student> Statues_Of_Student_Repository,
             CRUD_Operation_Interface<Tracking_Rate> Tracking_Rate_Repository
            )
        {
            studentRepository = StudentRepository;
            this.hosting_ = hosting_;
            type_Of_High_School_Cirtificate_Repository = Type_of_high_school_Cirtificate_Repository;
            department_Relation_Type_Repository = Department_relation_Type_Repository;
            statues_Of_Student_Repository = Statues_Of_Student_Repository;
            tracking_Rate_Repository = Tracking_Rate_Repository;
        }
        // GET: StudenController
        public ActionResult Index()
        {
            var allstudents = studentRepository.List().ToList();
            return View(allstudents);
        }

        // GET: StudenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudenController/Create
        public ActionResult Create()
        {
            var Student_With_Certificate = new Student_View_Model();
            return View(Student_With_Certificate);
        }

        // POST: StudenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student_View_Model collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                           string filenameIMa = string.Empty;
                        if (collection.Image_Of_Crtificat != null)
                        {
                            string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                            filenameIMa = collection.Identity_No.ToString() + collection.Image_Of_Crtificat.FileName;
                            string fullpath = Path.Combine(uploads, filenameIMa);
                            collection.Image_Of_Crtificat.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }
                        string filenameFront = string.Empty;
                        if (collection.front_image_of_identity_URL != null)
                        {
                            string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                            filenameFront = collection.Identity_No.ToString() + collection.front_image_of_identity_URL.FileName;
                            string fullpath = Path.Combine(uploads, filenameFront);
                            collection.front_image_of_identity_URL.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }
                        string filenameBack = string.Empty;
                        if (collection.back_image_of_identity_URL != null)
                        {
                            string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                            filenameBack = collection.Identity_No.ToString() + collection.back_image_of_identity_URL.FileName;
                            string fullpath = Path.Combine(uploads, filenameBack);
                            collection.back_image_of_identity_URL.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }

                        string filenameCheck = string.Empty;
                        if (collection.check_recipt_image_URL != null)
                        {
                            string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                            filenameCheck = collection.Identity_No.ToString() + collection.check_recipt_image_URL.FileName;
                            string fullpath = Path.Combine(uploads, filenameCheck);
                            collection.check_recipt_image_URL.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }


                    var certificate = new Admission_Eligibilty_Certificate
                    {
                        course_number = collection.course_number,
                        city_of_high_school_cirtificate = collection.city_of_high_school_cirtificate,
                        Image_of_crtificat_URL = filenameIMa,
                        check_recipt_image_URL = filenameCheck,
                        The_Rate = collection.The_Rate,
                        LAnguge_of_the_addmintion = collection.LAnguge_of_the_addmintion,
                        Subscription_number = collection.Subscription_number,
                        date_of_high_school_cirtificate = collection.date_of_high_school_cirtificate,
                           FK_Type_of_high_school_Cirtificate=type_Of_High_School_Cirtificate_Repository.Find(collection.Type_Of_Certificat),
                        wish1 = department_Relation_Type_Repository.Find(collection.wish_Department_Id1),
                        wish2 = department_Relation_Type_Repository.Find(collection.wish_Department_Id2),
                        wish3 = department_Relation_Type_Repository.Find(collection.wish_Department_Id2)
                    };

                        var student = new Student
                    {
                        Nick_Name = collection.Nick_Name,
                        Birth = collection.Birth,
                        Civil_Registriation_City = collection.Civil_Registriation_City,
                        Email = collection.Email,
                        Current_Address = collection.Current_Address,
                        Father_Name_AR = collection.Father_Name_AR,
                        First_Name_AR = collection.First_Name_AR,
                        Father_Name_EN = collection.Father_Name_EN,
                        First_Name_EN = collection.First_Name_EN,
                        Full_Address = collection.Full_Address,
                        gender = collection.gender,
                        Grandfather_Name_AR = collection.Grandfather_Name_AR,
                        Grandfather_Name_EN = collection.Grandfather_Name_EN,
                        high_school_certificate = collection.high_school_certificate,
                        Identity_back_image = filenameBack,
                        Nationality = collection.Nationality,
                        Mobile_Phone = collection.Mobile_Phone,
                        Home_s_Phone = collection.Home_s_Phone,
                        Passport_No = collection.Passport_No,
                        Identity_front_image = filenameFront,
                        Mother_Name_AR = collection.Mother_Name_AR,
                        Identity_No = collection.Identity_No,
                        Marital_status = collection.Marital_status,
                        Mother_Name_EN = collection.Mother_Name_EN,
                        Civil_Registrition_No = collection.Civil_Registrition_No,
                     Admission_Eligibilty_Requist_For_UNsy_Certificate= certificate
                    
                        };

                    studentRepository.Add(student);

                    var Tracking = new Tracking_Rate
                    {
                        FK_Student_Info = student,
                        old_rate = collection.The_Rate,

                    };
                    tracking_Rate_Repository.Add(Tracking);
                    var status_of_student = new Statues_Of_Student
                    {
                        Checked_city_certificate = false,
                        Checked_Identity = false,
                        Checked_Rate = false,
                        Checked_recipet = false,
                        FK_Student_Info = student,

                    };
                    statues_Of_Student_Repository.Add(status_of_student);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return View();
            }
        }

        // GET: StudenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudenController/Edit/5
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

        // GET: StudenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudenController/Delete/5
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
    }
}

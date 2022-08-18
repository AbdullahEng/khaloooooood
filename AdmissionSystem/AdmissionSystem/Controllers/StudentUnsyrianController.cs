using AdmissionSystem.Data;
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
    public class StudentUnsyrianController : Controller
    {
        private readonly ApplicationDbContext dB;
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

        public StudentUnsyrianController(ApplicationDbContext DB,CRUD_Operation_Interface<Student> StudentRepository,
            IHostingEnvironment hosting_,
            CRUD_Operation_Interface<Type_of_high_school_Cirtificate> Type_of_high_school_Cirtificate_Repository,
            CRUD_Operation_Interface<Department_relation_Type> Department_relation_Type_Repository,
            CRUD_Operation_Interface<Statues_Of_Student> Statues_Of_Student_Repository,
             CRUD_Operation_Interface<Tracking_Rate> Tracking_Rate_Repository,
             CRUD_Operation_Interface<Admission_Eligibilty_Certificate> Admission_Eligibilty_Certificate_Repository,
               CRUD_Operation_Interface<Country> Country_Repository,
                CRUD_Operation_Interface<Statues_of_admission_eligibilty> Statues_of_admission_eligibilty_Repository
        , CRUD_Operation_Interface<Department> Department_Repository
            )
        {
            dB = DB;
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
        // GET: StudenController
        public ActionResult Index()
        {
            var allstudents = studentRepository.List();
            List<Student> lista = new List<Student>();
            foreach (var x in allstudents) {
                if (x.high_school_certificate == "UNSyrian") {
                    lista.Add(x);                
                }            
            }
            return View(lista);
        }


        // GET: StudenController/Details/5
        public ActionResult Details(int id)
        {

            var student = studentRepository.Find(id);
            var certeficat = admission_Eligibilty_Certificate_Repository.Find(student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);

            var collection = new Student_View_Model
            {
                Birth = student.Birth,
                Civil_Registriation_City = student.Civil_Registriation_City,
                Email = student.Email,
                Current_Address = student.Current_Address,
                Father_Name_AR = student.Father_Name_AR,
                Father_Name_EN = student.Father_Name_EN,
                First_Name_AR = student.First_Name_AR,
                Nick_Name = student.Nick_Name,
                Marital_status = student.Marital_status,
                high_school_certificate = student.high_school_certificate,
                Home_s_Phone = student.Home_s_Phone,
                Passport_No = student.Passport_No,
                Mobile_Phone = student.Mobile_Phone,
                First_Name_EN = student.First_Name_EN,
                gender = student.gender,
                Full_Address = student.Full_Address,
                Grandfather_Name_AR = student.Grandfather_Name_AR,
                Grandfather_Name_EN = student.Grandfather_Name_EN,
                Civil_Registrition_No = student.Civil_Registrition_No,
                Nationality = student.Nationality,
                Mother_Name_AR = student.Mother_Name_AR,
                Mother_Name_EN = student.Mother_Name_EN,
                Identity_No = student.Identity_No,
                Identity_back_image_URL = student.Identity_back_image,
                Identity_front_image_URL = student.Identity_front_image,

                LAnguge_of_the_addmintion = certeficat.LAnguge_of_the_addmintion,
                Check_recipt_image_URL = certeficat.check_recipt_image_URL,
                date_of_high_school_cirtificate = certeficat.date_of_high_school_cirtificate,
                Subscription_number = certeficat.Subscription_number,
                The_Rate = student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate,
                city_of_high_school_cirtificate = certeficat.city_of_high_school_cirtificate,
                course_number = certeficat.course_number,
                Type_Of_Certificat = certeficat.FK_Type_of_high_school_Cirtificate.id,
                Type_Of_certificate_list = FillSelection2(),
                wish_Department_Id1 = certeficat.wish1.id,
                wish_Department_Id2 = certeficat.wish2.id,
                wish_Department_Id3 = certeficat.wish3.id,
                Image_of_crtificat_URL = certeficat.Image_of_crtificat_URL,


            };

            return View(collection);


        }

        // GET: StudenController/Create
        public ActionResult Create()
        {
            var Student_With_Certificate = new Student_View_Model
            {
                //specializtions = FillSelection(),
                Type_Of_certificate_list = FillSelection2()
                ,CountryList = FillSelection3()
                      ,
                Addmition_eleigibilty = statues_Of_Admission_Eligibilty_Repository.List().Last().Type_of_admission_eligibilty

            };
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
                    if (collection.Identity_front_image != null)
                    {
                        string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                        filenameFront = collection.Identity_No.ToString() + collection.Identity_front_image.FileName;
                        string fullpath = Path.Combine(uploads, filenameFront);
                        collection.Identity_front_image.CopyTo(new FileStream(fullpath, FileMode.Create));
                    }
                    string filenameBack = string.Empty;
                    if (collection.Identity_back_image != null)
                    {
                        string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                        filenameBack = collection.Identity_No.ToString() + collection.Identity_back_image.FileName;
                        string fullpath = Path.Combine(uploads, filenameBack);
                        collection.Identity_back_image.CopyTo(new FileStream(fullpath, FileMode.Create));
                    }

                    string filenameCheck = string.Empty;
                    if (collection.check_recipt_image != null)
                    {
                        string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                        filenameCheck = collection.Identity_No.ToString() + collection.check_recipt_image.FileName;
                        string fullpath = Path.Combine(uploads, filenameCheck);
                        collection.check_recipt_image.CopyTo(new FileStream(fullpath, FileMode.Create));
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
                        FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Type_Of_Certificat),
                        //    wish1 = department_Relation_Type_Repository.Find(collection.wish_Department_Id1),
                        //    wish2 = department_Relation_Type_Repository.Find(collection.wish_Department_Id2),
                        //    wish3 = department_Relation_Type_Repository.Find(collection.wish_Department_Id2)
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
                        FK_Admission_Eligibilty_Requist_For_UNsy_Certificate = certificate,
                        Cirtificate_city=country_Repository.Find( collection.country),
                        Statues_Of_Admission_Eligibilty = statues_Of_Admission_Eligibilty_Repository.List().Last()

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
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return View();
            }
        }


        // GET: StudenController/Edit/5
        public ActionResult Edit(int id)
        {

            var student = studentRepository.Find(id);
            var certeficat = admission_Eligibilty_Certificate_Repository.Find(student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);

            if (student.Mother_Name_AR == null)
            {

                var Student_With_Certificate = new UnStudent_View_Model
                {
                    //specializtions= FillSelection(),
                    Type_Of_certificate_list = FillSelection2()
                 ,
                    CountryList = FillSelection3()
                 ,
                    Addmition_eleigibilty = statues_Of_Admission_Eligibilty_Repository.List().Last().Type_of_admission_eligibilty

                ,
                    Birth = student.Birth,
                    gender = student.gender,
                    Email = student.Email,
                    Identity_No = student.Identity_No,
                    First_Name_EN = student.First_Name_EN,
                    Nick_Name = student.Nick_Name,
                    Mobile_Phone = student.Mobile_Phone,
                    high_school_certificate = student.high_school_certificate,


                };
                return View(Student_With_Certificate);

            }
            else
            {

                var Student_With_Certificate = new UnStudent_View_Model
                {
                    //specializtions= FillSelection(),
                    Type_Of_certificate_list = FillSelection2()
                 ,
                    CountryList = FillSelection3()
                 ,
                    Addmition_eleigibilty = statues_Of_Admission_Eligibilty_Repository.List().Last().Type_of_admission_eligibilty

                ,
                    Birth = student.Birth,
                    gender = student.gender,
                    Email = student.Email,
                    Identity_No = student.Identity_No,
                    First_Name_EN = student.First_Name_EN,
                    Nick_Name = student.Nick_Name,
                    Mobile_Phone = student.Mobile_Phone,
                    high_school_certificate = student.high_school_certificate,
                    Civil_Registriation_City = student.Civil_Registriation_City,
                    Current_Address = student.Current_Address,
                    Father_Name_AR = student.Father_Name_AR,
                    Father_Name_EN = student.Father_Name_EN,
                    First_Name_AR = student.First_Name_AR,
                    Marital_status = student.Marital_status,
                    Home_s_Phone = student.Home_s_Phone,
                    Passport_No = student.Passport_No,
                    Full_Address = student.Full_Address,
                    Grandfather_Name_AR = student.Grandfather_Name_AR,
                    Grandfather_Name_EN = student.Grandfather_Name_EN,
                    Civil_Registrition_No = student.Civil_Registrition_No,
                    Nationality = student.Nationality,
                    Mother_Name_AR = student.Mother_Name_AR,
                    Mother_Name_EN = student.Mother_Name_EN,
                    Identity_back_image_URL = student.Identity_back_image,
                    Identity_front_image_URL = student.Identity_front_image,

                    //LAnguge_of_the_addmintion = certeficat.LAnguge_of_the_addmintion,
                    Check_recipt_image_URL = certeficat.check_recipt_image_URL,
                    date_of_high_school_cirtificate = certeficat.date_of_high_school_cirtificate,
                    //Subscription_number = certeficat.Subscription_number,
                    The_Rate = student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate,
                    //old_Rate = student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.The_Rate,
                    city_of_high_school_cirtificate = certeficat.city_of_high_school_cirtificate,
                    //course_number = certeficat.course_number,
                    Type_Of_Certificat = certeficat.FK_Type_of_high_school_Cirtificate.id,
                    oldType_Of_Certificat = certeficat.FK_Type_of_high_school_Cirtificate.id,
                    Image_of_crtificat_URL = certeficat.Image_of_crtificat_URL,
                    country = student.Cirtificate_city.id,
                    wish_Department_Id1 = certeficat.wish1ID,
                    wish_Department_Id2 = certeficat.wish2ID,
                    wish_Department_Id3 = certeficat.wish3ID

                };



                return View(Student_With_Certificate);
            }



        }

        // POST: StudenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UnStudent_View_Model collection)
        {
            try
            {

                //var stu = studentRepository.Find(id);
                string filenameIMa = string.Empty;
                string filenameFront = string.Empty;
                string filenameBack = string.Empty;
                string filenameCheck = string.Empty;

                if (collection.Check_recipt_image_URL != null || collection.Identity_front_image_URL != null || collection.Identity_back_image_URL != null || collection.Image_of_crtificat_URL != null)
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    if (collection.Image_Of_Crtificat != null)
                    {
                        string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                        filenameIMa = collection.Identity_No.ToString() + collection.Image_Of_Crtificat.FileName;
                        string fullpath = Path.Combine(uploads, filenameIMa);
                        //delete Old File

                        string oldFileName = collection.Image_of_crtificat_URL;
                        string fullOldPath = Path.Combine(uploads, oldFileName);
                        if (fullpath != fullOldPath)
                        {


                            System.IO.File.Delete(fullOldPath);

                            //save new image
                            collection.Image_of_crtificat_URL = filenameIMa;
                            collection.Image_Of_Crtificat.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }
                    }

                    if (collection.Identity_front_image != null)
                    {
                        string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                        filenameFront = collection.Identity_No.ToString() + collection.Identity_front_image.FileName;
                        string fullpath = Path.Combine(uploads, filenameFront);

                        string oldFileName = collection.Identity_front_image_URL;
                        string fullOldPath = Path.Combine(uploads, oldFileName);
                        if (fullpath != fullOldPath)
                        {


                            System.IO.File.Delete(fullOldPath);
                            //save new image
                            collection.Identity_front_image_URL = filenameFront;
                            collection.Identity_front_image.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }




                    }

                    if (collection.Identity_back_image != null)
                    {
                        string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                        filenameBack = collection.Identity_No.ToString() + collection.Identity_back_image.FileName;
                        string fullpath = Path.Combine(uploads, filenameBack);

                        string oldFileName = collection.Identity_back_image_URL;
                        string fullOldPath = Path.Combine(uploads, oldFileName);
                        if (fullpath != fullOldPath)
                        {
                            System.IO.File.Delete(fullOldPath);
                            //save new image
                            collection.Identity_back_image_URL = filenameBack;
                            collection.Identity_back_image.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }


                    }
                    if (collection.check_recipt_image != null)
                    {
                        string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                        filenameCheck = collection.Identity_No.ToString() + collection.check_recipt_image.FileName;
                        string fullpath = Path.Combine(uploads, filenameCheck);

                        string oldFileName = collection.Check_recipt_image_URL;
                        string fullOldPath = Path.Combine(uploads, oldFileName);
                        if (fullpath != fullOldPath)
                        {
                            System.IO.File.Delete(fullOldPath);
                            collection.Check_recipt_image_URL = filenameCheck;
                            //save new image
                            collection.check_recipt_image.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }

                    }
                }
                else
                {

                    if (collection.Image_Of_Crtificat != null)
                    {
                        if (collection.Image_Of_Crtificat.Length != collection.Identity_front_image.Length && collection.Image_Of_Crtificat.Length != collection.Identity_back_image.Length && collection.Image_Of_Crtificat.Length != collection.check_recipt_image.Length)
                        {
                            string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                            filenameIMa = collection.Identity_No.ToString() + collection.Image_Of_Crtificat.FileName;
                            string fullpath = Path.Combine(uploads, filenameIMa);
                            collection.Image_of_crtificat_URL = filenameIMa;

                            collection.Image_Of_Crtificat.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }
                    }

                    if (collection.Identity_front_image != null)
                    {
                        if (collection.Identity_front_image.Length != collection.Image_Of_Crtificat.Length && collection.Identity_front_image.Length != collection.Identity_back_image.Length && collection.Identity_front_image.Length != collection.check_recipt_image.Length)
                        {
                            string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                            filenameFront = collection.Identity_No.ToString() + collection.Identity_front_image.FileName;
                            string fullpath = Path.Combine(uploads, filenameFront);
                            collection.Identity_front_image_URL = filenameFront;

                            collection.Identity_front_image.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }
                    }

                    if (collection.Identity_back_image != null)
                    {
                        if (collection.Identity_back_image.Length != collection.Image_Of_Crtificat.Length && collection.Identity_back_image.Length != collection.Identity_front_image.Length && collection.Identity_back_image.Length != collection.check_recipt_image.Length)
                        {
                            string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                            filenameBack = collection.Identity_No.ToString() + collection.Identity_back_image.FileName;
                            string fullpath = Path.Combine(uploads, filenameBack);
                            collection.Identity_back_image_URL = filenameBack;
                            collection.Identity_back_image.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }
                    }


                    if (collection.check_recipt_image != null)
                    {
                        if (collection.check_recipt_image.Length != collection.Identity_front_image.Length && collection.check_recipt_image.Length != collection.Identity_back_image.Length && collection.check_recipt_image.Length != collection.Image_Of_Crtificat.Length && collection.Identity_back_image.Length != collection.Image_Of_Crtificat.Length && collection.Identity_back_image.Length != collection.Identity_front_image.Length && collection.Identity_back_image.Length != collection.check_recipt_image.Length)
                        {
                            string uploads = Path.Combine(hosting_.WebRootPath, "Uploads");
                            filenameCheck = collection.Identity_No.ToString() + collection.check_recipt_image.FileName;
                            string fullpath = Path.Combine(uploads, filenameCheck);
                            collection.Check_recipt_image_URL = filenameCheck;
                            collection.check_recipt_image.CopyTo(new FileStream(fullpath, FileMode.Create));
                        }
                    }

                }





                if (ModelState.IsValid)
                {

                  
                        var certificate_ = new Admission_Eligibilty_Certificate
                        {
                            //id=student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id,
                            id = id,
                            // id = stu.Admission_Eligibilty_Requist_For_UNsy_Certificate.id,
                            FK_studentId = id,
                            //  FK_student =student ,
                            check_recipt_image_URL = collection.Check_recipt_image_URL,
                            city_of_high_school_cirtificate = collection.city_of_high_school_cirtificate,
                            //course_number = collection.course_number,
                            date_of_high_school_cirtificate = collection.date_of_high_school_cirtificate,
                            Image_of_crtificat_URL = collection.Image_of_crtificat_URL,
                            //LAnguge_of_the_addmintion = collection.LAnguge_of_the_addmintion,
                            //Subscription_number = collection.Subscription_number,
                            The_Rate = collection.The_Rate,
                            wish1ID = collection.wish_Department_Id1,
                            wish2ID = collection.wish_Department_Id2,
                            wish3ID = collection.wish_Department_Id3,
                            FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Type_Of_Certificat)

                        };


                        var student = new Student
                        {

                            Id = id,
                            Birth = collection.Birth,
                            Civil_Registriation_City = collection.Civil_Registriation_City,
                            Civil_Registrition_No = collection.Civil_Registrition_No,
                            Current_Address = collection.Current_Address,
                            Email = collection.Email,
                            Father_Name_AR = collection.Father_Name_AR,
                            Father_Name_EN = collection.Father_Name_EN,
                            Grandfather_Name_AR = collection.Grandfather_Name_AR,
                            Grandfather_Name_EN = collection.Grandfather_Name_EN,
                            Identity_back_image = collection.Identity_back_image_URL,
                            Identity_front_image = collection.Identity_front_image_URL,
                            First_Name_AR = collection.First_Name_AR,
                            First_Name_EN = collection.First_Name_EN,
                            Full_Address = collection.Full_Address,
                            gender = collection.gender,
                            high_school_certificate = collection.high_school_certificate,
                            Home_s_Phone = collection.Home_s_Phone,
                            Identity_No = collection.Identity_No,
                            Marital_status = collection.Marital_status,
                            Mobile_Phone = collection.Mobile_Phone,
                            Mother_Name_AR = collection.Mother_Name_AR,
                            Mother_Name_EN = collection.Mother_Name_EN,
                            Nationality = collection.Nationality,
                            Nick_Name = collection.Nick_Name,
                            Passport_No = collection.Passport_No,
                            Cirtificate_city = country_Repository.Find(collection.country)
                            ,
                            Statues_Of_Admission_Eligibilty = statues_Of_Admission_Eligibilty_Repository.List().Last()
                            //, FK_Admission_Eligibilty_Requist_For_UNsy_Certificate = certificate_
                        };


                        // var cerid = admission_Eligibilty_Certificate_Repository.Find(student.Admission_Eligibilty_Requist_For_UNsy_Certificate.id);

                        admission_Eligibilty_Certificate_Repository.Update(id, certificate_);
                        studentRepository.Update(id, student);
                        //admission_Eligibilty_Certificate_Repository.Update(stu.Admission_Eligibilty_Requist_For_UNsy_Certificate.id, certificate_);


                        //DB.Admission_Eligibilty_Certificate.Update(certificate_);
                        //DB.Student.Update(student);
                        //DB.SaveChanges();
                        //ViewBag.succeed = "succeed";
                        string url = "/StudentUnsyrian/WishesSelection/" + id.ToString();
                        return Redirect(url);
                    
                    //return RedirectToAction(nameof(Index));
                }
                else
                {

                    if (collection.check_recipt_image != null || collection.Identity_front_image != null || collection.Identity_back_image != null || collection.Image_Of_Crtificat != null)
                    {
                        //if (collection.check_recipt_image.Length != collection.Identity_front_image.Length && collection.check_recipt_image.Length != collection.Identity_back_image.Length &&collection.check_recipt_image.Length != collection.Image_Of_Crtificat.Length
                        //    &&collection.Identity_front_image.Length != collection.Image_Of_Crtificat.Length && collection.Identity_front_image.Length != collection.Identity_back_image.Length && collection.Identity_front_image.Length != collection.check_recipt_image.Length
                        //    && collection.Image_Of_Crtificat.Length != collection.Identity_front_image.Length && collection.Image_Of_Crtificat.Length != collection.Identity_back_image.Length && collection.Image_Of_Crtificat.Length != collection.check_recipt_image.Length)
                        //{
                        var certificate_2 = new Admission_Eligibilty_Certificate
                        {
                            id = id,
                            check_recipt_image_URL = collection.Check_recipt_image_URL,
                            Image_of_crtificat_URL = collection.Image_of_crtificat_URL
                        };
                        var student_2 = new Student
                        {
                            Id = id,
                            Identity_back_image = collection.Identity_back_image_URL,
                            Identity_front_image = collection.Identity_front_image_URL,
                            FK_Admission_Eligibilty_Requist_For_UNsy_Certificate = certificate_2
                        };
                        dB.Admission_Eligibilty_Certificate.Update(certificate_2);
                        //admission_Eligibilty_Certificate_Repository.Update(id, certificate_2);
                        studentRepository.Update(id, student_2);
                    }/* }*/

                    ModelState.AddModelError("", "");
                    ViewBag.Erroremessage = "please cheack and reach all requirments";
                    UnStudent_View_Model collection2 = collection;
                    collection2.CountryList = FillSelection3();
                    collection2.Type_Of_certificate_list = FillSelection2();
                    collection2.Addmition_eleigibilty = statues_Of_Admission_Eligibilty_Repository.List().Last().Type_of_admission_eligibilty;
                    //collection2.Identity_front_image = collection.Identity_front_image;
                    //collection2.Identity_back_image_URL = collection.Identity_back_image_URL;
                    //collection2.Image_Of_Crtificat = collection.Image_Of_Crtificat;
                    //collection2.check_recipt_image = collection.check_recipt_image;
                    //collection2.Identity_back_image_URL = collection.Identity_back_image_URL;
                    //collection2.Identity_front_image_URL = collection.Identity_front_image_URL;
                    //collection2.Image_Of_Crtificat = collection.Image_Of_Crtificat;
                    //collection2.Check_recipt_image_URL = collection.Check_recipt_image_URL;
                    return View(collection2);
                }
            }
            catch (Exception e)
            {
                return View(e);
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

        //for selecting wishs

        // GET: StudenController
        public ActionResult WishesSelection(int id)
        {
            List<Wishes> lista_of_wishes = new List<Wishes>();

            foreach (var x in FillSelection())
            {
                Wishes y = new Wishes
                {
                    id = x.id,
                    FK_Department = x.FK_Department,
                    DepartmentName = department_Repository.Find(x.FK_Department.id).specialization_name,
                    FK_type_Of_High_School_Cirtificate = x.FK_type_Of_High_School_Cirtificate,
                    Minemum_of_Rate = x.Minemum_of_Rate
                };

                lista_of_wishes.Add(y);
            }

            Student st = studentRepository.Find(id);
            Admission_Eligibilty_Certificate certificate = admission_Eligibilty_Certificate_Repository.Find(st.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
            var CertificatRate = certificate.The_Rate;
            var CertificatType = certificate.FK_Type_of_high_school_Cirtificate;
            List<Wishes> lista_of_the_student = new List<Wishes>();
            foreach (var x in lista_of_wishes)
            {
                if (x.Minemum_of_Rate <= CertificatRate && x.FK_type_Of_High_School_Cirtificate.id == CertificatType.id)
                    lista_of_the_student.Add(x);
            }

            if (certificate.wish1 != null && certificate.wish2 != null && certificate.wish3 != null)
            {
                var Student_Wishes_View_Model = new Student_Wishes_View_Model
                {
                    specializtions = lista_of_the_student,
                    wish_Department_Id1 = certificate.wish1.id,
                    wish_Department_Id2 = certificate.wish2.id,
                    wish_Department_Id3 = certificate.wish3.id

                };
                ViewBag.wish1 = 1;

                return View(Student_Wishes_View_Model);
            }
            else if (certificate.wish1 != null && certificate.wish2 != null && certificate.wish3 == null)
            {
                var Student_Wishes_View_Model = new Student_Wishes_View_Model
                {
                    specializtions = lista_of_the_student,
                    wish_Department_Id1 = certificate.wish1.id,
                    wish_Department_Id2 = certificate.wish2.id,


                };
                return View(Student_Wishes_View_Model);
            }
            else if (certificate.wish1 != null && certificate.wish2 == null && certificate.wish3 != null)
            {
                var Student_Wishes_View_Model = new Student_Wishes_View_Model
                {
                    specializtions = lista_of_the_student,
                    wish_Department_Id1 = certificate.wish1.id,


                };
                return View(Student_Wishes_View_Model);
            }
            else if (certificate.wish1 == null && certificate.wish2 != null && certificate.wish3 != null)
            {
                var Student_Wishes_View_Model = new Student_Wishes_View_Model
                {
                    specializtions = lista_of_the_student,
                    wish_Department_Id3 = certificate.wish3.id,
                    wish_Department_Id2 = certificate.wish2.id,


                };
                return View(Student_Wishes_View_Model);
            }
            else if (certificate.wish1 != null && certificate.wish2 == null && certificate.wish3 == null)
            {
                var Student_Wishes_View_Model = new Student_Wishes_View_Model
                {
                    specializtions = lista_of_the_student,
                    wish_Department_Id1 = certificate.wish1.id,



                };
                return View(Student_Wishes_View_Model);
            }
            else if (certificate.wish1 == null && certificate.wish2 != null && certificate.wish3 == null)
            {
                var Student_Wishes_View_Model = new Student_Wishes_View_Model
                {
                    specializtions = lista_of_the_student,
                    wish_Department_Id2 = certificate.wish2.id,



                };
                return View(Student_Wishes_View_Model);
            }
            else if (certificate.wish1 == null && certificate.wish2 == null && certificate.wish3 != null)
            {
                var Student_Wishes_View_Model = new Student_Wishes_View_Model
                {
                    specializtions = lista_of_the_student,
                    wish_Department_Id3 = certificate.wish3.id,



                };
                return View(Student_Wishes_View_Model);
            }
            else
            {
                var Student_Wishes_View_Model = new Student_Wishes_View_Model
                {
                    specializtions = lista_of_the_student,

                };
                return View(Student_Wishes_View_Model);
            }
        }

        // POST: StudenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WishesSelection(int id, Student_Wishes_View_Model collection)
        {
            try
            {
                Student st = studentRepository.Find(id);
                Admission_Eligibilty_Certificate certificate = admission_Eligibilty_Certificate_Repository.Find(st.Id);
                certificate.wish1 = department_Relation_Type_Repository.Find(collection.wish_Department_Id1);
                certificate.wish2 = department_Relation_Type_Repository.Find(collection.wish_Department_Id2);
                certificate.wish3 = department_Relation_Type_Repository.Find(collection.wish_Department_Id3);

                admission_Eligibilty_Certificate_Repository.Update(id, certificate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Department_relation_Type> FillSelection()
        {
            var types = department_Relation_Type_Repository.List().ToList();
            // types.Insert(0, new Department_relation_Type { id = -1, = "-------pleas select auther-------" });
            return (types);

        }

        List<Type_of_high_school_Cirtificate> FillSelection2()
        {
            var types = type_Of_High_School_Cirtificate_Repository.List().ToList();
            List<Type_of_high_school_Cirtificate> ListForUnSyrian = new List<Type_of_high_school_Cirtificate>();
            ListForUnSyrian.Add(types[0]);
            ListForUnSyrian.Add(types[1]);

            // types.Insert(0, new Department_relation_Type { id = -1, = "-------pleas select auther-------" });
            return (ListForUnSyrian);

        }

        List<Country> FillSelection3()
        {
            var types = country_Repository.List().ToList();
            List<Country> listForUnSyrian = new List<Country>();
            foreach(var x in types) 
            {
                if (x.country_name != "سوريا") 
                {
                    listForUnSyrian.Add(x);
                }
            }
            // types.Insert(0, new Department_relation_Type { id = -1, = "-------pleas select auther-------" });
            return (listForUnSyrian);

        }
    }
}

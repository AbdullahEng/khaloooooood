using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CRUD_Operation_Interface<Employee> employee_Repository;
        private readonly CRUD_Operation_Interface<Statues_Of_Student> statues_Of_Student_Repository;
        private readonly CRUD_Operation_Interface<Student> student_Repository;
        private readonly CRUD_Operation_Interface<Admission_Eligibilty_Certificate> admission_Eligibilty_Certificate_Repository;
        private readonly CRUD_Operation_Interface<Tracking_Rate> tracking_Rate_Repository;
        private readonly CRUD_Operation_Interface<Type_of_high_school_Cirtificate> type_Of_High_School_Cirtificate_Repository;
        private readonly CRUD_Operation_Interface<Country> country_Repository;

        public EmployeeController(CRUD_Operation_Interface<Employee> Employee_Repository,
            CRUD_Operation_Interface<Statues_Of_Student> Statues_Of_Student_Repository,
            CRUD_Operation_Interface<Student> Student_Repository,
            CRUD_Operation_Interface<Admission_Eligibilty_Certificate> Admission_Eligibilty_Certificate_Repository,
            CRUD_Operation_Interface<Tracking_Rate> Tracking_Rate_Repository,
            CRUD_Operation_Interface<Type_of_high_school_Cirtificate> Type_of_high_school_Cirtificate_Repository,
             CRUD_Operation_Interface<Country> Country_Repository)
        {
            employee_Repository = Employee_Repository;
            statues_Of_Student_Repository = Statues_Of_Student_Repository;
            student_Repository = Student_Repository;
            admission_Eligibilty_Certificate_Repository = Admission_Eligibilty_Certificate_Repository;
            tracking_Rate_Repository = Tracking_Rate_Repository;
            type_Of_High_School_Cirtificate_Repository = Type_of_high_school_Cirtificate_Repository;
            country_Repository = Country_Repository;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var lista = employee_Repository.List();
            return View(lista);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            var em = new Employee { };
            return View(em);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee collection)
        {
            try
            {
                var em = collection;
                employee_Repository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var em = employee_Repository.Find(id);
            return View(em);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee collection)
        {
            try
            {
                var em = new Employee
                {
                    Email = collection.Email,
                    name = collection.name,
                    Nick_Name = collection.Nick_Name,
                    Phone_Number = collection.Phone_Number,
                    id = collection.id

                };
                employee_Repository.Update(id, em);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
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




        public ActionResult Index_Status_of_student()
        {
            var Status_of_student_list = statues_Of_Student_Repository.List();
            List<Statues_Of_Student> lista = new List<Statues_Of_Student>();
            Student y;
            foreach (var x in Status_of_student_list)
            {
                y = student_Repository.Find(x.FK_Student_InfoId);
                if (y.high_school_certificate == "Syrian")
                    lista.Add(x);
            }


            return View(lista);
        }

        // get: EmployeeController//
        public ActionResult Edit_Status_of_student(int id)
        {
            var student = student_Repository.Find(id);
            var certificate = admission_Eligibilty_Certificate_Repository.Find(student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
            var Status_of_student = new Status_Of_Student_View_Model
            {
                Birth = student.Birth,
                Email = student.Email,
                Identity_No = student.Identity_No,
                Passport_No = student.Passport_No,
                Identity_front_image = student.Identity_front_image,
                Identity_back_image = student.Identity_back_image,
                Father_Name_AR = student.Father_Name_AR,
                Nationality = student.Nationality,
                First_Name_AR = student.First_Name_AR,
                Civil_Registrition_No = student.Civil_Registrition_No,
                Full_Address = student.Full_Address,
                high_school_certificate = student.high_school_certificate,
                Mobile_Phone = student.Mobile_Phone,
                Mother_Name_AR = student.Mother_Name_AR,
                Nick_Name = student.Nick_Name,
                course_number = certificate.course_number,
                date_of_high_school_cirtificate = certificate.date_of_high_school_cirtificate,
                Image_of_crtificat_URL = certificate.Image_of_crtificat_URL,
                The_Old_Rate = certificate.The_Rate,
                LAnguge_of_the_addmintion = certificate.LAnguge_of_the_addmintion,
                city_of_high_school_cirtificate = certificate.city_of_high_school_cirtificate,
                Civil_Registriation_City = student.Civil_Registriation_City,
                Subscription_number = certificate.Subscription_number,
                check_recipt_image_URL = certificate.check_recipt_image_URL,
                CountryList = FillSelection3(),
                Old_Country = student.Cirtificate_city.id,
                New_Country = student.Cirtificate_city.id,
                Type_Of_certificate_list = FillSelection2(),
                Old_Type_Of_Certificat = certificate.FK_Type_of_high_school_Cirtificate.id,
                New_Type_Of_Certificat = certificate.FK_Type_of_high_school_Cirtificate.id,

            };
            return View(Status_of_student);
        }

        // POST: EmployeeController//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Status_of_student(int id, Status_Of_Student_View_Model collection)
        {
            try
            {

                // I chosed this employee for testing 
                Employee em = employee_Repository.Find(1);
                Student student = student_Repository.Find(id);
                Admission_Eligibilty_Certificate Certificate = admission_Eligibilty_Certificate_Repository.Find(student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
                Tracking_Rate traking = tracking_Rate_Repository.Find(id);
                var status_of_student = new Statues_Of_Student
                {
                    id = id,
                    Checked_city_certificate = collection.Checking_city_Certificate,
                    Checked_Identity = collection.Checking_Identity_Image,
                    Checked_Rate = collection.Checking_Rate_Image,
                    Checked_recipet = collection.Checking_Recipte_Image,
                    Date_of_Acshiving = DateTime.Now,
                    FK_Student_InfoId = id,
                    FK_Employee_Info = em
                };

                //1
                if (collection.New_Country != collection.Old_Country && collection.New_Type_Of_Certificat == collection.Old_Type_Of_Certificat && collection.The_Old_Rate == collection.The_New_Rate)
                {

                    //new_rate = collection.The_New_Rate,
                    //traking.old_rate = collection.The_Old_Rate;
                    traking.FK_Employee_Info = em;
                    traking.Date_Of_Modification = DateTime.Now;
                    traking.new_country = country_Repository.Find(collection.New_Country).country_name;
                    traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    //new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type,
                    //traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    student_Repository.Update(id, student);
                    //Certificate.The_Rate = collection.The_New_Rate;
                    //Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    //admission_Eligibilty_Certificate_Repository.Update(id, Certificate);
                }//2
                else if (collection.New_Country == collection.Old_Country && collection.New_Type_Of_Certificat != collection.Old_Type_Of_Certificat && collection.The_Old_Rate == collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    //new_rate = collection.The_New_Rate,
                    //traking.old_rate = collection.The_Old_Rate;
                    traking.Date_Of_Modification = DateTime.Now;
                    //new_country = country_Repository.Find(collection.New_Country).country_name,
                    //traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    traking.new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type;
                    traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    //student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    //student_Repository.Update(id, student);
                    //Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);
                }//3
                else if (collection.New_Country == collection.Old_Country && collection.New_Type_Of_Certificat == collection.Old_Type_Of_Certificat && collection.The_Old_Rate != collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    traking.new_rate = collection.The_New_Rate;
                    traking.old_rate = collection.The_Old_Rate;

                    traking.Date_Of_Modification = DateTime.Now;
                    //new_country = country_Repository.Find(collection.New_Country).country_name,
                    //traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    ////new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type,
                    //traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    //student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    //student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    //Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);
                }//4
                else if (collection.New_Country != collection.Old_Country && collection.New_Type_Of_Certificat != collection.Old_Type_Of_Certificat && collection.The_Old_Rate == collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    //new_rate = collection.The_New_Rate,
                    //traking.old_rate = collection.The_Old_Rate;
                    traking.Date_Of_Modification = DateTime.Now;
                    traking.new_country = country_Repository.Find(collection.New_Country).country_name;
                    traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    traking.new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type;
                    traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    student_Repository.Update(id, student);
                    //Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);
                }//5
                else if (collection.New_Country != collection.Old_Country && collection.New_Type_Of_Certificat == collection.Old_Type_Of_Certificat && collection.The_Old_Rate != collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    traking.new_rate = collection.The_New_Rate;
                    traking.old_rate = collection.The_Old_Rate;
                    traking.Date_Of_Modification = DateTime.Now;
                    traking.new_country = country_Repository.Find(collection.New_Country).country_name;
                    traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    //new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type,
                    //traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    //Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);
                }//6
                else if (collection.New_Country == collection.Old_Country && collection.New_Type_Of_Certificat != collection.Old_Type_Of_Certificat && collection.The_Old_Rate != collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    traking.new_rate = collection.The_New_Rate;
                    traking.old_rate = collection.The_Old_Rate;
                    traking.FK_Employee_Info = em;
                    traking.FK_Student_InfoId = id; ;
                    traking.Date_Of_Modification = DateTime.Now;
                    //new_country = country_Repository.Find(collection.New_Country).country_name,
                    //traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    traking.new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type;
                    traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    //student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    //student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);

                }//7
                //else if (collection.New_Country == collection.Old_Country && collection.New_Type_Of_Certificat == collection.Old_Type_Of_Certificat && collection.The_Old_Rate == collection.The_New_Rate)
                //{
                //    var traking = new Tracking_Rate
                //    {
                //        id = id,
                //        //new_rate = collection.The_New_Rate,
                //        old_rate = collection.The_Old_Rate,
                //        FK_Employee_Info = em,
                //        FK_Student_InfoId = id,
                //        Date_Of_Modification = DateTime.Now,
                //     //   new_country = country_Repository.Find(collection.New_Country).country_name,
                //        old_country = country_Repository.Find(collection.Old_Country).country_name,
                //      //  new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type,
                //        old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type


                //    };

                //    tracking_Rate_Repository.Update(id, traking);
                //    //student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                //    //student_Repository.Update(id, student);
                //    ////Certificate.The_Rate = collection.The_New_Rate;
                //    //Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                //    //admission_Eligibilty_Certificate_Repository.Update(id, Certificate);

                //}//8
                else if (collection.New_Country != collection.Old_Country && collection.New_Type_Of_Certificat != collection.Old_Type_Of_Certificat && collection.The_Old_Rate != collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    traking.new_rate = collection.The_New_Rate;
                    traking.old_rate = collection.The_Old_Rate;
                    traking.Date_Of_Modification = DateTime.Now;
                    traking.new_country = country_Repository.Find(collection.New_Country).country_name;
                    traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    traking.new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type;
                    traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);

                }

                statues_Of_Student_Repository.Update(id, status_of_student);
                return RedirectToAction(nameof(Index_Status_of_student));
            }
            catch
            {
                return View();
            }
        }

        ///////// the unsyrina student......

        public ActionResult Index_Status_of_Unsyrian_student()
        {
            var Status_of_student_list = statues_Of_Student_Repository.List();
            List<Statues_Of_Student> lista = new List<Statues_Of_Student>();
            Student y;
            foreach (var x in Status_of_student_list)
            {
                y = student_Repository.Find(x.FK_Student_InfoId);
                if (y.high_school_certificate == "UnSyrian")
                    lista.Add(x);
            }


            return View(lista);
        }

        // get: EmployeeController//
        public ActionResult Edit_Status_of_Unsyrian_student(int id)
        {
            var student = student_Repository.Find(id);
            var certificate = admission_Eligibilty_Certificate_Repository.Find(student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
            var Status_of_student = new Status_Of_Student_View_Model
            {
                Birth = student.Birth,
                Email = student.Email,
                Identity_No = student.Identity_No,
                Passport_No = student.Passport_No,
                Identity_front_image = student.Identity_front_image,
                Identity_back_image = student.Identity_back_image,
                Father_Name_AR = student.Father_Name_AR,
                Nationality = student.Nationality,
                First_Name_AR = student.First_Name_AR,
                Civil_Registrition_No = student.Civil_Registrition_No,
                Full_Address = student.Full_Address,
                high_school_certificate = student.high_school_certificate,
                Mobile_Phone = student.Mobile_Phone,
                Mother_Name_AR = student.Mother_Name_AR,
                Nick_Name = student.Nick_Name,
                course_number = certificate.course_number,
                date_of_high_school_cirtificate = certificate.date_of_high_school_cirtificate,
                Image_of_crtificat_URL = certificate.Image_of_crtificat_URL,
                The_Old_Rate = certificate.The_Rate,
                LAnguge_of_the_addmintion = certificate.LAnguge_of_the_addmintion,
                city_of_high_school_cirtificate = certificate.city_of_high_school_cirtificate,
                Civil_Registriation_City = student.Civil_Registriation_City,
                Subscription_number = certificate.Subscription_number,
                check_recipt_image_URL = certificate.check_recipt_image_URL,
                CountryList = FillSelection3(),
                Old_Country = student.Cirtificate_city.id,
                New_Country = student.Cirtificate_city.id,
                Type_Of_certificate_list = FillSelection2(),
                Old_Type_Of_Certificat = certificate.FK_Type_of_high_school_Cirtificate.id,
                New_Type_Of_Certificat = certificate.FK_Type_of_high_school_Cirtificate.id,

            };
            return View(Status_of_student);
        }

        // POST: EmployeeController//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Status_of_Unsyrian_student(int id, Status_Of_Student_View_Model collection)
        {
            try
            {
                // I chosed this employee for testing 
                Employee em = employee_Repository.Find(1);
                Student student = student_Repository.Find(id);
                Admission_Eligibilty_Certificate Certificate = admission_Eligibilty_Certificate_Repository.Find(student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
                Tracking_Rate traking = tracking_Rate_Repository.Find(id);
                var status_of_student = new Statues_Of_Student
                {
                    id = id,
                    Checked_city_certificate = collection.Checking_city_Certificate,
                    Checked_Identity = collection.Checking_Identity_Image,
                    Checked_Rate = collection.Checking_Rate_Image,
                    Checked_recipet = collection.Checking_Recipte_Image,
                    Date_of_Acshiving = DateTime.Now,
                    FK_Student_InfoId = id,
                    FK_Employee_Info = em
                };

                //1
                if (collection.New_Country != collection.Old_Country && collection.New_Type_Of_Certificat == collection.Old_Type_Of_Certificat && collection.The_Old_Rate == collection.The_New_Rate)
                {

                    traking.FK_Employee_Info = em;
                    //new_rate = collection.The_New_Rate,
                    //traking.old_rate = collection.The_Old_Rate;
                    traking.Date_Of_Modification = DateTime.Now;
                    traking.new_country = country_Repository.Find(collection.New_Country).country_name;
                    traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    //new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type,
                    //traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    student_Repository.Update(id, student);
                    //Certificate.The_Rate = collection.The_New_Rate;
                    //Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    //admission_Eligibilty_Certificate_Repository.Update(id, Certificate);
                }//2
                else if (collection.New_Country == collection.Old_Country && collection.New_Type_Of_Certificat != collection.Old_Type_Of_Certificat && collection.The_Old_Rate == collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    //new_rate = collection.The_New_Rate,
                    //traking.old_rate = collection.The_Old_Rate;
                    traking.Date_Of_Modification = DateTime.Now;
                    //new_country = country_Repository.Find(collection.New_Country).country_name,
                    //traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    traking.new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type;
                    traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    //student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    //student_Repository.Update(id, student);
                    //Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);
                }//3
                else if (collection.New_Country == collection.Old_Country && collection.New_Type_Of_Certificat == collection.Old_Type_Of_Certificat && collection.The_Old_Rate != collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    traking.new_rate = collection.The_New_Rate;
                    traking.old_rate = collection.The_Old_Rate;

                    traking.Date_Of_Modification = DateTime.Now;
                    //new_country = country_Repository.Find(collection.New_Country).country_name,
                    //traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    ////new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type,
                    //traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    //student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    //student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    //Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);
                }//4
                else if (collection.New_Country != collection.Old_Country && collection.New_Type_Of_Certificat != collection.Old_Type_Of_Certificat && collection.The_Old_Rate == collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    //new_rate = collection.The_New_Rate,
                    //traking.old_rate = collection.The_Old_Rate;
                    traking.Date_Of_Modification = DateTime.Now;
                    traking.new_country = country_Repository.Find(collection.New_Country).country_name;
                    traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    traking.new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type;
                    traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    student_Repository.Update(id, student);
                    //Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);
                }//5
                else if (collection.New_Country != collection.Old_Country && collection.New_Type_Of_Certificat == collection.Old_Type_Of_Certificat && collection.The_Old_Rate != collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    traking.new_rate = collection.The_New_Rate;
                    traking.old_rate = collection.The_Old_Rate;
                    traking.Date_Of_Modification = DateTime.Now;
                    traking.new_country = country_Repository.Find(collection.New_Country).country_name;
                    traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    //new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type,
                    //traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    //Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);
                }//6
                else if (collection.New_Country == collection.Old_Country && collection.New_Type_Of_Certificat != collection.Old_Type_Of_Certificat && collection.The_Old_Rate != collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    traking.new_rate = collection.The_New_Rate;
                    traking.old_rate = collection.The_Old_Rate;
                    traking.FK_Employee_Info = em;
                    traking.FK_Student_InfoId = id; ;
                    traking.Date_Of_Modification = DateTime.Now;
                    //new_country = country_Repository.Find(collection.New_Country).country_name,
                    //traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    traking.new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type;
                    traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    //student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    //student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);

                }//7
                //else if (collection.New_Country == collection.Old_Country && collection.New_Type_Of_Certificat == collection.Old_Type_Of_Certificat && collection.The_Old_Rate == collection.The_New_Rate)
                //{
                //    var traking = new Tracking_Rate
                //    {
                //        id = id,
                //        //new_rate = collection.The_New_Rate,
                //        old_rate = collection.The_Old_Rate,
                //        FK_Employee_Info = em,
                //        FK_Student_InfoId = id,
                //        Date_Of_Modification = DateTime.Now,
                //     //   new_country = country_Repository.Find(collection.New_Country).country_name,
                //        old_country = country_Repository.Find(collection.Old_Country).country_name,
                //      //  new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type,
                //        old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type


                //    };

                //    tracking_Rate_Repository.Update(id, traking);
                //    //student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                //    //student_Repository.Update(id, student);
                //    ////Certificate.The_Rate = collection.The_New_Rate;
                //    //Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                //    //admission_Eligibilty_Certificate_Repository.Update(id, Certificate);

                //}//8
                else if (collection.New_Country != collection.Old_Country && collection.New_Type_Of_Certificat != collection.Old_Type_Of_Certificat && collection.The_Old_Rate != collection.The_New_Rate)
                {
                    traking.FK_Employee_Info = em;
                    traking.new_rate = collection.The_New_Rate;
                    traking.old_rate = collection.The_Old_Rate;
                    traking.Date_Of_Modification = DateTime.Now;
                    traking.new_country = country_Repository.Find(collection.New_Country).country_name;
                    traking.old_country = country_Repository.Find(collection.Old_Country).country_name;
                    traking.new_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat).type;
                    traking.old_typeofcertificate = type_Of_High_School_Cirtificate_Repository.Find(collection.Old_Type_Of_Certificat).type;




                    tracking_Rate_Repository.Update(id, traking);
                    student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);

                }

                statues_Of_Student_Repository.Update(id, status_of_student);
                return RedirectToAction(nameof(Index_Status_of_Unsyrian_student));
            }
            catch (Exception w)
            {
                return View(w);
            }
        }


        List<Type_of_high_school_Cirtificate> FillSelection2()
        {
            var types = type_Of_High_School_Cirtificate_Repository.List().ToList();
            // types.Insert(0, new Department_relation_Type { id = -1, = "-------pleas select auther-------" });
            return (types);

        }

        List<Country> FillSelection3()
        {
            var types = country_Repository.List().ToList();
            // types.Insert(0, new Department_relation_Type { id = -1, = "-------pleas select auther-------" });
            return (types);

        }



    }
}

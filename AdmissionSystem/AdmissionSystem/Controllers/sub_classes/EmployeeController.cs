using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.Services;
using AdmissionSystem.View_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly CRUD_Operation_Interface<Employee> employee_Repository;
        private readonly CRUD_Operation_Interface<Statues_Of_Student> statues_Of_Student_Repository;
        private readonly CRUD_Operation_Interface<Student> student_Repository;
        private readonly CRUD_Operation_Interface<Admission_Eligibilty_Certificate> admission_Eligibilty_Certificate_Repository;
        private readonly CRUD_Operation_Interface<Tracking_Rate> tracking_Rate_Repository;
        private readonly CRUD_Operation_Interface<Type_of_high_school_Cirtificate> type_Of_High_School_Cirtificate_Repository;
        private readonly CRUD_Operation_Interface<Country> country_Repository;
        private readonly IMailingService mailingService;
        private readonly CRUD_Operation_Interface<Statues_of_admission_eligibilty> statues_Of_Admission_Eligibilty_Repository;

        public EmployeeController(CRUD_Operation_Interface<Employee> Employee_Repository,
            CRUD_Operation_Interface<Statues_Of_Student> Statues_Of_Student_Repository,
            CRUD_Operation_Interface<Student> Student_Repository,
            CRUD_Operation_Interface<Admission_Eligibilty_Certificate> Admission_Eligibilty_Certificate_Repository,
            CRUD_Operation_Interface<Tracking_Rate> Tracking_Rate_Repository,
            CRUD_Operation_Interface<Type_of_high_school_Cirtificate> Type_of_high_school_Cirtificate_Repository,
             CRUD_Operation_Interface<Country> Country_Repository,
             IMailingService mailingService,
              CRUD_Operation_Interface<Statues_of_admission_eligibilty> Statues_of_admission_eligibilty_Repository)
        {
            employee_Repository = Employee_Repository;
            statues_Of_Student_Repository = Statues_Of_Student_Repository;
            student_Repository = Student_Repository;
            admission_Eligibilty_Certificate_Repository = Admission_Eligibilty_Certificate_Repository;
            tracking_Rate_Repository = Tracking_Rate_Repository;
            type_Of_High_School_Cirtificate_Repository = Type_of_high_school_Cirtificate_Repository;
            country_Repository = Country_Repository;
            this.mailingService = mailingService;
            statues_Of_Admission_Eligibilty_Repository = Statues_of_admission_eligibilty_Repository;
        }
        // GET: EmployeeController
        //public ActionResult Index()
        //{
        //    var lista = employee_Repository.List();
        //    return View(lista);
        //}

        //// GET: EmployeeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: EmployeeController/Create
        //public ActionResult Create()
        //{
        //    var em = new Employee { };
        //    return View(em);
        //}

        //// POST: EmployeeController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Employee collection)
        //{
        //    try
        //    {
        //        var em = collection;
        //        employee_Repository.Add(collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //// GET: EmployeeController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    var em = employee_Repository.Find(id);
        //    return View(em);
        //}

        //// POST: EmployeeController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Employee collection)
        //{
        //    try
        //    {
        //        var em = new Employee
        //        {
        //            Email = collection.Email,
        //            name = collection.name,
        //            Nick_Name = collection.Nick_Name,
        //            Phone_Number = collection.Phone_Number,
        //            id = collection.id

        //        };
        //        employee_Repository.Update(id, em);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: EmployeeController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete()
        //{
        //    try
        //    {


        //        return RedirectToAction();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult AccessError()
        {
            return View();
        }

        public ActionResult Home(int id)
        {
           
            var Employee = employee_Repository.Find(id);
            var user = HttpContext.User.Identity.Name;
            if (user != Employee.name)
            {
                string url = "/Employee/AccessError";
                return Redirect(url);
            }
            return View(Employee);
        }

        public ActionResult loak_Syrian(Statues_of_Student_EmployeeId collection)
        {
            var em = employee_Repository.Find(collection.id);
            var statues = statues_Of_Student_Repository.Find(collection.statusId);
            if (statues.loack == false || (statues.loack == true && statues.FK_Employee_Info == em))
            {
                statues.loack = true;
                statues.FK_Employee_Info = em;
                statues_Of_Student_Repository.Update(collection.statusId, statues);
                 return RedirectToAction("Edit_Status_of_student", new { id = collection.statusId, host = em.id });
            }
            else
            {
                string url = "/Employee/Errorview/"+em.id;
                return Redirect(url);
            }
        }


        public ActionResult Index_Status_of_student(int id)
        {
            var Status_of_student_list = statues_Of_Student_Repository.List();
            List<Statues_Of_Student> lista = new List<Statues_Of_Student>();
            Student y;
            Statues_Of_Student y2;
            var em = employee_Repository.Find(id);
            var user = HttpContext.User.Identity.Name;
            if (user != em.name)
            {
                string url = "/Employee/AccessError";
                return Redirect(url);
            }
            foreach (var x in Status_of_student_list)
            {
                y = student_Repository.Find(x.FK_Student_InfoId);
                y2 = statues_Of_Student_Repository.Find(y.Id);
               
                if (y.high_school_certificate == "Syrian" &&y.Conformation==1)
                {
                    if (y2.Checked_city_certificate != true || y2.Checked_recipet != true || y2.Checked_Identity != true || y2.Checked_Rate != true)
                    {

                        if (y2.loack == false && y2.FK_Employee_Info==null)
                        {
                            lista.Add(x);
                        }
                        else if (y2.loack == true && y2.FK_Employee_Info == em)
                        {
                            lista.Add(x);
                        }
                        else if (y2.loack == false && y2.FK_Employee_Info == em)
                        {
                            lista.Add(x);
                        }
                    }
                }
            }
            var Statues_of_Student_EmployeeId = new Statues_of_Student_EmployeeId
            {
                id = id,
                Employee = em,
                ListaOfStudent = lista
            };


            return View(Statues_of_Student_EmployeeId);

        }
        public ActionResult Errorview(int id)
        {
            var em = employee_Repository.Find(id);
            return View(em);
        }

      


        // get: EmployeeController//
        public ActionResult Edit_Status_of_student(int id, int host)
        {
            var student = student_Repository.Find(id);
            var certificate = admission_Eligibilty_Certificate_Repository.Find(student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
            var statuesofstudent = statues_Of_Student_Repository.Find(id);
            var em = employee_Repository.Find(host);
            var user = HttpContext.User.Identity.Name;
            if (user != em.name)
            {
                string url = "/Employee/AccessError";
                return Redirect(url);
            }
            if (statuesofstudent.Checked_city_certificate == true && statuesofstudent.Checked_Rate == true && statuesofstudent.Checked_Identity == true && statuesofstudent.Checked_recipet == true)
            {

                string url = "/Employee/Errorview/"+host;
                return Redirect(url);
            }
            else if (host == 0 || statuesofstudent.loack == false)
            {
                string url = "/Employee/Errorview/" + host;
                return Redirect(url);
            }
            else if (statuesofstudent.loack == true && host != statuesofstudent.FK_Employee_Info.id)
            {
                string url = "/Employee/Errorview/" + host;
                return Redirect(url);
            }

            else
            {
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
                    Checking_city_Certificate = statuesofstudent.Checked_city_certificate,
                    Checking_Identity_Image = statuesofstudent.Checked_Identity,
                    Checking_Rate_Image = statuesofstudent.Checked_Rate,
                    Checking_Recipte_Image = statuesofstudent.Checked_recipet,
                    EmployeeId = statuesofstudent.FK_Employee_Info.id

                };
                return View(Status_of_student);
            }
        }

        // POST: EmployeeController//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Status_of_student(int id, Status_Of_Student_View_Model collection)
        {
            try
            {
                
                // I chosed this employee for testing 
                Employee em = employee_Repository.Find(collection.EmployeeId);
                Student student = student_Repository.Find(id);
                Admission_Eligibilty_Certificate Certificate = admission_Eligibilty_Certificate_Repository.Find(id);
                Tracking_Rate traking = tracking_Rate_Repository.Find(id);
                if (collection.Body != null)
                {
                    if (collection.Checking_city_Certificate == true && collection.Checking_Identity_Image == true && collection.Checking_Rate_Image == true && collection.Checking_Recipte_Image == true && collection.The_New_Rate != 0)
                    { collection.Body = null; }
                    else
                    {
                        await mailingService.SendEmailAsync(collection.Email, "تنبيه هام", collection.Body);
                        student.Conformation = 3;
                    }
                }
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
                if (collection.Checking_city_Certificate == true && collection.Checking_Identity_Image == true && collection.Checking_Rate_Image == true && collection.Checking_Recipte_Image == true && collection.The_New_Rate != 0)
                {
                    student.Conformation = 1;
                    if (collection.New_Country == collection.Old_Country && collection.New_Type_Of_Certificat == collection.Old_Type_Of_Certificat && collection.The_Old_Rate == collection.The_New_Rate)
                    {
                        collection.Subject = "مفاضلة جامعة القلمون الخاصة";
                        collection.Body = "تم التحقق من طلبكم الرجاءانتظار النتائج " + student.First_Name_EN + "\n اسم المستخدم لتسجيل الدخول";
                      
                    }
                    int semester_Number = student.Statues_Of_Admission_Eligibilty.semester_no;
                    int year = DateTime.Now.Year;
                    if (semester_Number == 2 || semester_Number == 3)
                    {
                        year = year - 1;
                    }


                    var Laststudent = statues_Of_Student_Repository.List().Where(c => c.Checked_city_certificate == true && c.Checked_Identity == true && c.Checked_Rate == true && c.Checked_recipet == true).LastOrDefault();

                    if (Laststudent == null)
                    {
                        student.UnvirstyId = double.Parse(year.ToString() + semester_Number.ToString() + "0001");
                    }
                    else if (Laststudent.FK_Student_Info.Statues_Of_Admission_Eligibilty.Begaining_date_of_the_process.Year != student.Statues_Of_Admission_Eligibilty.Begaining_date_of_the_process.Year && semester_Number == 1)
                    {
                        student.UnvirstyId = double.Parse(year.ToString() + semester_Number.ToString() + "0001");
                    }
                    else
                    {
                        string SectionofNumber = Laststudent.FK_Student_Info.UnvirstyId.ToString().Substring(5);

                        if (int.Parse(SectionofNumber) == 9999)
                        {
                            student.UnvirstyId = double.Parse(year.ToString() + semester_Number.ToString() + (int.Parse(SectionofNumber) + 1).ToString());
                        }
                        else if (Laststudent.FK_Student_Info.Statues_Of_Admission_Eligibilty.semester_no != student.Statues_Of_Admission_Eligibilty.semester_no)
                        {
                            student.UnvirstyId = double.Parse(year.ToString() + semester_Number.ToString() + "0001");

                        }
                        else
                        {
                            student.UnvirstyId = Laststudent.FK_Student_Info.UnvirstyId + 1;
                        }
                    }
                    student_Repository.Update(id,student);
                }


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

                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;

                    collection.Subject = "مفاضلة جامعة القلمون الخاصة";
                    collection.Body = "المعذرة ,تم تصحيح بياناتكم من قبل الموظف المختص " +
                        "الرجاء تسجيل الدخول واعادة اختيار الرغبات";
                    if (student.Conformation == 3)
                    {
                        student.Conformation = 4;
                    }
                    else {
                        student.Conformation = 2;
                    }
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

                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;

                    collection.Subject = "مفاضلة جامعة القلمون الخاصة";
                    collection.Body = "المعذرة ,تم تصحيح بياناتكم من قبل الموظف المختص " +
                        "الرجاء تسجيل الدخول واعادة اختيار الرغبات";
                    if (student.Conformation == 3)
                    {
                        student.Conformation = 4;
                    }
                    else
                    {
                        student.Conformation = 2;
                    }
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
                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;

                    collection.Subject = "مفاضلة جامعة القلمون الخاصة";
                    collection.Body = "المعذرة ,تم تصحيح بياناتكم من قبل الموظف المختص " +
                        "الرجاء تسجيل الدخول واعادة اختيار الرغبات";
                    if (student.Conformation == 3)
                    {
                        student.Conformation = 4;
                    }
                    else
                    {
                        student.Conformation = 2;
                    }

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


                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;

                    collection.Subject = "مفاضلة جامعة القلمون الخاصة";
                    collection.Body = "المعذرة ,تم تصحيح بياناتكم من قبل الموظف المختص " +
                        "الرجاء تسجيل الدخول واعادة اختيار الرغبات";
                    if (student.Conformation == 3)
                    {
                        student.Conformation = 4;
                    }
                    else
                    {
                        student.Conformation = 2;
                    }
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

                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;

                    collection.Subject = "مفاضلة جامعة القلمون الخاصة";
                    collection.Body = "المعذرة ,تم تصحيح بياناتكم من قبل الموظف المختص " +
                        "الرجاء تسجيل الدخول واعادة اختيار الرغبات";
                    if (student.Conformation == 3)
                    {
                        student.Conformation = 4;
                    }
                    else
                    {
                        student.Conformation = 2;
                    }
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
                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;


                    collection.Subject = "مفاضلة جامعة القلمون الخاصة";
                    collection.Body = "المعذرة ,تم تصحيح بياناتكم من قبل الموظف المختص " +
                        "الرجاء تسجيل الدخول واعادة اختيار الرغبات";
                    if (student.Conformation == 3)
                    {
                        student.Conformation = 4;
                    }
                    else
                    {
                        student.Conformation = 2;
                    }
                    tracking_Rate_Repository.Update(id, traking);
                    //student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    //student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);

                }//7
            
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


                    collection.Subject = "مفاضلة جامعة القلمون الخاصة";
                    collection.Body = "المعذرة ,تم تصحيح بياناتكم من قبل الموظف المختص " +
                        "الرجاء تسجيل الدخول واعادة اختيار الرغبات";

                    if (student.Conformation == 3)
                    {
                        student.Conformation = 4;
                    }
                    else
                    {
                        student.Conformation = 2;
                    }
                    tracking_Rate_Repository.Update(id, traking);
                    student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);

                }
                if (collection.Body != null)
                {
                    await mailingService.SendEmailAsync(collection.Email, collection.Subject, collection.Body);
                }
                statues_Of_Student_Repository.Update(id, status_of_student);
                string url = "/Employee/Index_Status_of_student/" + em.id;
                return Redirect(url);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ErrorForiegnview(int id)
        {
            var em = employee_Repository.Find(id);
            return View(em);
        }

        ///////// the unsyrina student......
        public ActionResult loak_UnSyrian(Statues_of_Student_EmployeeId collection)
        {
            var em = employee_Repository.Find(collection.id);
            var statues = statues_Of_Student_Repository.Find(collection.statusId);
            if (statues.loack == false || (statues.loack == true && statues.FK_Employee_Info == em))
            {
                statues.loack = true;
                statues.FK_Employee_Info = em;
                statues_Of_Student_Repository.Update(collection.statusId, statues);
                //string url = "/Employee/Edit_Status_of_Unsyrian_student/" + id.ToString();
                //return Redirect(url);
                //return RedirectToAction("Edit_Status_of_Unsyrian_student", "Employee", new { id = id,{ name = em.id} });
                return RedirectToAction("Edit_Status_of_Unsyrian_student", new { id = collection.statusId,host= em.id });
            }
            else
            {
                string url = "/Employee/ErrorForiegnview/" + em.id;
                return Redirect(url);
            }
        }
        public ActionResult Index_Status_of_Unsyrian_student(int id)
        {
            var Status_of_student_list = statues_Of_Student_Repository.List();
            List<Statues_Of_Student> lista = new List<Statues_Of_Student>();
            Student y;
            Statues_Of_Student y2;
            var em = employee_Repository.Find(id);   
            var user = HttpContext.User.Identity.Name;
            if (user != em.name)
            {
                string url = "/Employee/AccessError";
                return Redirect(url);
            }
            foreach (var x in Status_of_student_list)
            {
                y = student_Repository.Find(x.FK_Student_InfoId);
                y2 = statues_Of_Student_Repository.Find(y.Id);
                if (y.high_school_certificate == "UNSyrian"&&y.Conformation == 1)
                {

                    if (y2.Checked_city_certificate != true || y2.Checked_recipet != true || y2.Checked_Identity != true || y2.Checked_Rate != true)
                    {
                        if (y2.loack == false && y2.FK_Employee_Info == null)
                        {
                            lista.Add(x);
                        }
                        else if(y2.loack == true && y2.FK_Employee_Info == em)
                        {
                            lista.Add(x);
                        }
                        else if (y2.loack == false && y2.FK_Employee_Info == em)
                        {
                            lista.Add(x);
                        }
                    }
                }
                    
            }
        
            var Statues_of_Student_EmployeeId = new Statues_of_Student_EmployeeId {
                id=id,
                Employee = em,
                ListaOfStudent=lista
            };


            return View(Statues_of_Student_EmployeeId);
        }

        // get: EmployeeController//
      
        public ActionResult Edit_Status_of_Unsyrian_student(int id ,int host)
        {
            var student = student_Repository.Find(id);
            var certificate = admission_Eligibilty_Certificate_Repository.Find(student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
            var statuesofstudent = statues_Of_Student_Repository.Find(id);
            var em = employee_Repository.Find(host);
            var user = HttpContext.User.Identity.Name;
            if (user != em.name)
            {
                string url = "/Employee/AccessError";
                return Redirect(url);
            }
            if (statuesofstudent.Checked_city_certificate == true && statuesofstudent.Checked_Rate == true && statuesofstudent.Checked_Identity == true && statuesofstudent.Checked_recipet == true)
            {

                string url = "/Employee/ErrorForiegnview/" + host;
                return Redirect(url);
            }else if (host == 0|| statuesofstudent.loack == false)
            {
                string url = "/Employee/ErrorForiegnview/" + host;
                return Redirect(url);
            }else if(statuesofstudent.loack==true&& host != statuesofstudent.FK_Employee_Info.id)
            {
                string url = "/Employee/ErrorForiegnview/" + host;
                return Redirect(url);
            }
            else
            {
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
                    CountryList = UNSyrianFillSelection3(),
                    Old_Country = student.Cirtificate_city.id,
                    New_Country = student.Cirtificate_city.id,
                    Type_Of_certificate_list = UNSyrianFillSelection2(),
                    Old_Type_Of_Certificat = certificate.FK_Type_of_high_school_Cirtificate.id,
                    New_Type_Of_Certificat = certificate.FK_Type_of_high_school_Cirtificate.id,
                    Checking_city_Certificate = statuesofstudent.Checked_city_certificate,
                    Checking_Identity_Image = statuesofstudent.Checked_Identity,
                    Checking_Rate_Image = statuesofstudent.Checked_Rate,
                    Checking_Recipte_Image = statuesofstudent.Checked_recipet,
                    EmployeeId=statuesofstudent.FK_Employee_Info.id
                    
                };
                return View(Status_of_student);
            }
        }

        // POST: EmployeeController//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Status_of_Unsyrian_student(int id, Status_Of_Student_View_Model collection)
        {
            try
            {
                // I chosed this employee for testing 
                Employee em = employee_Repository.Find(collection.EmployeeId);
                Student student = student_Repository.Find(id);
                Admission_Eligibilty_Certificate Certificate = admission_Eligibilty_Certificate_Repository.Find(student.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate.id);
                Tracking_Rate traking = tracking_Rate_Repository.Find(id);

                if (collection.Body != null)
                {
                    if (collection.Checking_city_Certificate == true && collection.Checking_Identity_Image == true && collection.Checking_Rate_Image == true && collection.Checking_Recipte_Image == true && collection.The_New_Rate != 0)
                    { collection.Body = null; }
                    else
                    {
                        await mailingService.SendEmailAsync(collection.Email, "تنبيه هام", collection.Body);
                        student.Conformation = 3;
                    }
                }
              

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

                if (collection.Checking_city_Certificate == true && collection.Checking_Identity_Image == true && collection.Checking_Rate_Image == true && collection.Checking_Recipte_Image == true && collection.The_New_Rate != 0)
                {
                    student.Conformation = 2;
                    collection.Subject = "مفاضلة جامعة القلمون الخاصة";
                    collection.Body = "تم التحقق من طلبكم الرجاء تسجيل الدخول لإختيار الرغبات +" + student.First_Name_EN + "\n اسم المستخدم لتسجيل الدخول";
                    int semester_Number = student.Statues_Of_Admission_Eligibilty.semester_no;
                    int year = DateTime.Now.Year;
                    if (semester_Number == 2 || semester_Number == 3)
                    {
                        year = year - 1;
                    }


                    var Laststudent = statues_Of_Student_Repository.List().Where(c => c.Checked_city_certificate == true && c.Checked_Identity == true && c.Checked_Rate == true && c.Checked_recipet == true).LastOrDefault();

                    if (Laststudent == null)
                    {
                        student.UnvirstyId = double.Parse(year.ToString() + semester_Number.ToString() + "0001");
                    }
                    else if (Laststudent.FK_Student_Info.Statues_Of_Admission_Eligibilty.Begaining_date_of_the_process.Year != student.Statues_Of_Admission_Eligibilty.Begaining_date_of_the_process.Year && semester_Number == 1)
                    {
                        student.UnvirstyId = double.Parse(year.ToString() + semester_Number.ToString() + "0001");
                    }
                    else
                    {
                        string SectionofNumber = Laststudent.FK_Student_Info.UnvirstyId.ToString().Substring(5);

                        if (int.Parse(SectionofNumber) == 9999)
                        {
                            student.UnvirstyId = double.Parse(year.ToString() + semester_Number.ToString() + (int.Parse(SectionofNumber) + 1).ToString());
                        }
                        else if (Laststudent.FK_Student_Info.Statues_Of_Admission_Eligibilty.semester_no != student.Statues_Of_Admission_Eligibilty.semester_no)
                        {
                            student.UnvirstyId = double.Parse(year.ToString() + semester_Number.ToString() + "0001");

                        }
                        else
                        {
                            student.UnvirstyId = Laststudent.FK_Student_Info.UnvirstyId + 1;
                        }
                    }
                }
                
                    student_Repository.Update(id, student);
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

                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;



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

                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;



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

                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;




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

                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;




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

                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;




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

                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;


                    tracking_Rate_Repository.Update(id, traking);
                    //student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    //student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);

                }
              
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
                    Certificate.wish1ID = null;
                    Certificate.wish2ID = null;
                    Certificate.wish3ID = null;


                    tracking_Rate_Repository.Update(id, traking);
                    student.Cirtificate_city = country_Repository.Find(collection.New_Country);
                    student_Repository.Update(id, student);
                    Certificate.The_Rate = collection.The_New_Rate;
                    Certificate.FK_Type_of_high_school_Cirtificate = type_Of_High_School_Cirtificate_Repository.Find(collection.New_Type_Of_Certificat);
                    admission_Eligibilty_Certificate_Repository.Update(id, Certificate);

                }
                if (collection.Body != null)
                {
                    await mailingService.SendEmailAsync(collection.Email, collection.Subject, collection.Body);
                }
                statues_Of_Student_Repository.Update(id, status_of_student);
                string url = "/Employee/Index_Status_of_Unsyrian_student/"+em.id;
                return Redirect(url);
                //return RedirectToAction(nameof(Index_Status_of_Unsyrian_student));
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

        List<Type_of_high_school_Cirtificate> UNSyrianFillSelection2()
        {
            var types = type_Of_High_School_Cirtificate_Repository.List().ToList();
            List<Type_of_high_school_Cirtificate> ListForUnSyrian = new List<Type_of_high_school_Cirtificate>();
            ListForUnSyrian.Add(types[0]);
            ListForUnSyrian.Add(types[1]);

            // types.Insert(0, new Department_relation_Type { id = -1, = "-------pleas select auther-------" });
            return (ListForUnSyrian);

        }

        List<Country> UNSyrianFillSelection3()
        {
            var types = country_Repository.List().ToList();
            List<Country> listForUnSyrian = new List<Country>();
            foreach (var x in types)
            {
                if (x.country_name != "سوريا")
                {
                    listForUnSyrian.Add(x);
                }
            }
            // types.Insert(0, new Department_relation_Type { id = -1, = "-------pleas select auther-------" });
            return (listForUnSyrian);

        }
        double? LastCheckedStudent()
        {
            return statues_Of_Student_Repository.List().Last().FK_Student_Info.UnvirstyId;
        }

    }
}

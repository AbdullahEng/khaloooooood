﻿using AdmissionSystem.Model;
using AdmissionSystem.Model.GoogleCaptcha;
using AdmissionSystem.Model.Identity_classes;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.Services;
using AdmissionSystem.View_Model.Identity_view_model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;


namespace AdmissionSystem.Controllers.Identity_control
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyIdentityUser> userManager;
        private readonly SignInManager<MyIdentityUser> LoginInManager;
        private readonly RoleManager<MyIdentityRole> roleManager;
        private readonly CRUD_Operation_Interface<Employee> employeeRepo;
        private readonly CRUD_Operation_Interface<Student> studentRepo;
        private readonly CRUD_Operation_Interface<Statues_Of_Student> statues_Of_Student_Repository;
        private readonly CRUD_Operation_Interface<Tracking_Rate> tracking_Rate_Repository;
        private readonly GoogleCaptcahService googleCaptcahServiceeee;
        private readonly CRUD_Operation_Interface<Statues_of_admission_eligibilty> statusofAdmissionREpo;
        private readonly CRUD_Operation_Interface<Accabtable_config> accRepo;
        private readonly IOptions<GoogleCaptchaConfig> config;
        private readonly ILogger<AccountController> logger;
        private readonly IMailingService mailingService;

        public AccountController(UserManager<MyIdentityUser> userManager,
             SignInManager<MyIdentityUser> LogInManager,
             RoleManager<MyIdentityRole> roleManager,
              CRUD_Operation_Interface<Employee> EmployeeRepo,
              CRUD_Operation_Interface<Student> StudentRepo,
               CRUD_Operation_Interface<Statues_Of_Student> Statues_Of_Student_Repository,
              CRUD_Operation_Interface<Tracking_Rate> Tracking_Rate_Repository
             //,GoogleCaptcahService googleCaptcahServiceeee
             , CRUD_Operation_Interface<Statues_of_admission_eligibilty> statusofAdmissionREpo
             , CRUD_Operation_Interface<Accabtable_config> accRepo
             , IOptions<GoogleCaptchaConfig> config
            , ILogger<AccountController> logger
            , IMailingService mailingService
       )
        {
            this.userManager = userManager;
            this.LoginInManager = LogInManager;
            this.roleManager = roleManager;
            employeeRepo = EmployeeRepo;
            studentRepo = StudentRepo;
            statues_Of_Student_Repository = Statues_Of_Student_Repository;
            tracking_Rate_Repository = Tracking_Rate_Repository;
            this.statusofAdmissionREpo = statusofAdmissionREpo;
            this.accRepo = accRepo;
            this.config = config;
            this.logger = logger;
            this.mailingService = mailingService;
            this.googleCaptcahServiceeee = new GoogleCaptcahService(config);
        }

        public ActionResult Index()
        {
            // Department_faculty_view_model
            return View();
        }
        public ActionResult IndexAdmin(int id)
        {
            // Department_faculty_view_model
            return View();
        }

        /// ////////////////////////////////////////////////////////////////////////
        // //// /////////// Admin

        //public IActionResult Register_Admin()
        //{
        //    //ViewBag.Roles = new SelectList(roleManager.Roles.Where(a=>!a.Name.Contains("Admin")),"Name","Name");
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Register_Admin(RegisterViewModel obj) {
        //    if (ModelState.IsValid)
        //    {
        //        MyIdentityUser user = new MyIdentityUser();
        //        user.UserName = obj.UserName;
        //        user.Email = obj.Email;
        //        user.TheIDnumber = obj.TheIDnumber;
        //        IdentityResult result = userManager.CreateAsync
        //            (user, obj.password).Result;
        //        if (result.Succeeded) {
        //            if (!roleManager.RoleExistsAsync("Admin").Result) {
        //                MyIdentityRole role = new MyIdentityRole();
        //                role.Name = "Admin";
        //                role.Description = "perform Admin operatoins";
        //                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
        //                if (!roleResult.Succeeded)
        //                {
        //                    ModelState.AddModelError("", "Error while creatin");
        //                    return View(obj);
        //                }

        //            }
        //            userManager.AddToRoleAsync(user, "Admin").Wait();
        //            return RedirectToAction("login", "Account");
        //        }
        //    }
        //    return View(obj);
        //}




        //////////////////////////////////////////////////////////////////////////////////////////
        ///  // Studnet


        public PartialViewResult Register_Student()
        {
            var model = new RegisteerStudentViweModel
            {
                sitkey = config.Value.SiteKey

            };
            //var login = new LoginViewModle();
            //var tuple = new Tuple<LoginViewModle, RegisteerStudentViweModel>(login, model);
            //return View(tuple);
            return PartialView("Index", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> Register_Student(RegisteerStudentViweModel obj)
        {

            //string captchaREsponse = Request.Form["g-recaptcha-response"].ToString();
            //var validate = googleCaptcahServiceeee.ValidateCaptcah(captchaREsponse);
            //if (!validate.success)
            //{
            //    var merror = validate.Message.ToArray();
            //    foreach (var item in merror)
            //    {
            //        ViewBag.captchMessageregi = item + "    ";
            //    }
            //    //  =validate.Message.ToArray();
            //    //  return RedirectToAction("Login",obj);
            //    return PartialView("Index");
            //}
            if (ModelState.IsValid)
            {
                var studentWhere = studentRepo.List().Where(s => s.First_Name_EN == obj.UserName
                                                            && s.Email == obj.Email
                                                            && s.Identity_No == obj.TheIDnumber
                                                            && s.Nick_Name == obj.Nick_Name
                                                            && s.Birth == obj.Birth
                                                            && s.gender == obj.Gender
                                                            && s.high_school_certificate == obj.high_school_certificate
                                                            // && s.Mobile_Phone = obj.Mobile_Phone
                                                            ).ToList();
                var emailstudent = studentRepo.List().Where(s=>s.Email==obj.Email).ToList();
                var TheIDnumberstudent = studentRepo.List().Where(s => s.Identity_No == obj.TheIDnumber).ToList();
            //var listofUsers=userManager.Users;
            //  var emailstudentfromuserTable= listofUsers.Where(s => s.Email == obj.Email).ToList();
            //    var TheIDnumberstudentfromuserTable = listofUsers.Where(s => s.TheIDnumber == obj.TheIDnumber).ToList();
                if (studentWhere.Count == 0)
                {

                  if (emailstudent.Count==0 && TheIDnumberstudent.Count==0 )
                     // && emailstudentfromuserTable.Count == 0 && TheIDnumberstudentfromuserTable.Count==0
                     // )

                    {




                   
                    MyIdentityUser user = new MyIdentityUser();
                    user.UserName = obj.UserName;
                    user.Email = obj.Email;
                    user.TheIDnumber = obj.TheIDnumber;
                    IdentityResult result = userManager.CreateAsync
                        (user, obj.password).Result;
                    var certificate = new Admission_Eligibilty_Certificate();
                    var student = new Student()
                    {
                        Nick_Name = obj.Nick_Name,//
                        Birth = obj.Birth,//
                        Email = obj.Email,//
                        First_Name_EN = obj.UserName,//
                        gender = obj.Gender,//
                        high_school_certificate = obj.high_school_certificate,//
                        Mobile_Phone = obj.Mobile_Phone,//
                        Identity_No = obj.TheIDnumber//
                        ,
                        FK_Admission_Eligibilty_Requist_For_UNsy_Certificate = certificate
                    };
                 
                    if (result.Succeeded)
                    {

                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        //var confirmationlink = Url.Action("ConfirmEmail", "Account",
                        //                                    new { UserId = user.Id, token = token }, Request.Scheme);
                        //    string htmlll = confirmationlink ;
                        //   await mailingService.SendEmailAsync(obj.Email, "تاكيد الحساب", confirmationlink);

                            ////////////////////////////////////////////


                        
                            var result1 = await userManager.ConfirmEmailAsync(user, token);



                            if (!roleManager.RoleExistsAsync("Student").Result)
                        {
                            MyIdentityRole role = new MyIdentityRole();
                            role.Name = "Student";
                            role.Description = "perform Student operatoins";
                            IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                            if (!roleResult.Succeeded)
                            {
                                ModelState.AddModelError("", "Error while creatin");
                                return PartialView("Index", obj);
                            }

                        }
                        userManager.AddToRoleAsync(user, "Student").Wait();
                        studentRepo.Add(student);
                        var Tracking = new Tracking_Rate
                        {
                            FK_Student_Info = student
                            //  old_rate = collection.The_Rate,

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
                        //remember to add accebted table and status..........
                        statues_Of_Student_Repository.Add(status_of_student);
                        var stauts = statusofAdmissionREpo.List().Last();



                        var accept = new Accabtable_config {
                            // Accepted_Or_Not = false,
                            // Accepted_wish = "" ,
                            FK_studentId = student.Id,
                            FK_Statues_of_admission_eligibiltyId = stauts.id


                        };
                        accRepo.Add(accept);

                        return PartialView("Success_Registeration_Studnet");
                    }
                    else {
                        var disc = result.Errors.Select(e => e.Description).ToArray();
                        foreach (var item in disc)
                        {
                            ViewBag.errorinfo += item + "  ";
                        }

                        return PartialView("Index");
                    }
                    }
                 else
                 {
                   ViewBag.message = "Registration fails becouse IdentityNO or Email is Repeated by another student ";

                        return PartialView("Index");
                 }
                }
                else
                {

                    ViewBag.message = "Registration fails becouse there is another student with  the same info ";

                    return PartialView("Index");
                }
                //  return View(obj);
            }
            return PartialView("Index");
        }






        //////////////////////////////////////////////////////////////////////////////////////////
        /// // Employee


        public IActionResult Register_Employee()
        {
            var model = new RegisterViewModel
            {
                sitkey = config.Value.SiteKey

            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Register_Employee(RegisterViewModel obj)
        {


            //string captchaREsponse = Request.Form["g-recaptcha-response"].ToString();
            //var validate = googleCaptcahServiceeee.ValidateCaptcah(captchaREsponse);
            //if (!validate.success)
            //{
            //    var merror = validate.Message.ToArray();
            //    foreach (var item in merror)
            //    {
            //        ViewBag.captchMessage = item + "    ";
            //    }
            //    //  =validate.Message.ToArray();
            //    //  return RedirectToAction("Login",obj);
            //    return View();
            //}
            if (ModelState.IsValid)
            {
                var emailstudent = employeeRepo.List().Where(e => e.Email == obj.Email).ToList();
                var TheIDnumberstudent = employeeRepo.List().Where(e => e.The_ID_Number == obj.TheIDnumber).ToList();
                //var listofUsers = userManager.Users;
                //var emailstudentfromuserTable = listofUsers.Where(s => s.Email == obj.Email).ToList();
                //var TheIDnumberstudentfromuserTable = listofUsers.Where(s => s.TheIDnumber == obj.TheIDnumber).ToList();
                if (emailstudent.Count == 0 && TheIDnumberstudent.Count == 0)
                      //&& emailstudentfromuserTable.Count == 0 && TheIDnumberstudentfromuserTable.Count == 0
                      //)
                {
                    MyIdentityUser user = new MyIdentityUser();
                user.UserName = obj.UserName;
                user.Email = obj.Email;
                user.TheIDnumber = obj.TheIDnumber;

                IdentityResult result = userManager.CreateAsync
                    (user, obj.password).Result;
                var Employee = new Employee() {
                    Email = obj.Email,
                    Type = obj.Type,
                    Birth = obj.Birth_Date,
                    Gender = obj.gender,
                    name = obj.UserName,
                    Nick_Name = obj.Nick_name,
                    Phone_Number = obj.phone_Mobile,
                    The_ID_Number = obj.TheIDnumber
                };
                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationlink = Url.Action("ConfirmEmail", "Account",
                                                        new { UserId = user.Id, token = token }, Request.Scheme);
                    string htmlll = confirmationlink;
                    await mailingService.SendEmailAsync(obj.Email, "تاكيد الحساب", confirmationlink);


                    if (!roleManager.RoleExistsAsync("Employee").Result ||
                        !roleManager.RoleExistsAsync("Admin").Result
                        )
                    {


                        if (obj.Type == "Emplyee")
                        {
                            MyIdentityRole role = new MyIdentityRole();
                            role.Name = "Employee";
                            role.Description = "perform Employee operatoins";
                            IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                            if (!roleResult.Succeeded)
                            {
                                ModelState.AddModelError("", "Error while creatin");
                                return View(obj);
                            }
                        }
                        else if (obj.Type == "Admin")
                        {
                            MyIdentityRole role = new MyIdentityRole();
                            role.Name = "Admin";
                            role.Description = "perform Admin operatoins";
                            IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                            if (!roleResult.Succeeded)
                            {
                                ModelState.AddModelError("", "Error while creatin");
                                return View(obj);
                            }
                        }
                    }
                    if (obj.Type == "Employee")
                    {
                        userManager.AddToRoleAsync(user, "Employee").Wait();


                    }
                    else if (obj.Type == "Admin")
                    {

                        userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
                    employeeRepo.Add(Employee);
                    return View("Success_Register_Employee");
                }

                else
                {
                    var disc = result.Errors.Select(e => e.Description).ToArray();
                    foreach (var item in disc)
                    {
                        ViewBag.errorinfo += item + "  ";
                    }

                    return View(obj);
                }
                }
                else
                {

                    ViewBag.message = "Registration fails becouse there is another student with  the same info ";

                    return View();
                }
            }
            return View(obj);
        }



        public PartialViewResult Login() {
            var model = new LoginViewModle {
                sitkey = config.Value.SiteKey

            };
            //var rige = new RegisteerStudentViweModel();
            //var tuple = new Tuple<LoginViewModle, RegisteerStudentViweModel>(model, rige);
            //return View(tuple);
            return PartialView("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Login(LoginViewModle obj)
        {
            
            //string captchaREsponse =  Request.Form["g-recaptcha-response"].ToString();
           
            //var validate = googleCaptcahServiceeee.ValidateCaptcah(captchaREsponse);
            //if (!validate.success)
            //{
            //    var merror = validate.Message.ToArray();
            //    foreach (var item in merror)
            //    {
            //        ViewBag.captchMessage = item + "    ";
            //    }
               
            //    return View("Index");
            //}
            
            if (ModelState.IsValid)
            {

                //var userfindemail = await userManager.FindByEmailAsync(obj.Email);
                //if (userfindemail != null && !userfindemail.Emailconfirmed &&
                //    (await userManager.CheckPasswordAsync(userfindemail, obj.password))) {

                //    ModelState.AddModelError(string.Empty,"Email not confirmed yet");
                //    return View(obj);
                //}


                var Allstudent = studentRepo.List();
                var AllEmployee = employeeRepo.List();
                var AllUsers = userManager.Users.ToList();
                var AllRoles = roleManager.Roles.ToList();
                // var usersAndRoles = new List<UserRoleModel>();
                // var allRolesUsers=
                // var studnetFind = studentRepo.Find();
                var result = LoginInManager.PasswordSignInAsync
                    (obj.UserName, obj.password,
                    obj.RememberMe, false).Result;

                if (result.Succeeded)
                {

                    //foreach (var role in AllRoles)
                    //{


                    foreach (var user in AllUsers)
                    {

                        //if (role.Name == "Employee" || role.Name == "Admin")
                        foreach (var Employee in AllEmployee)
                        {
                            if (obj.UserName == Employee.name &&
                                user.Email == Employee.Email &&
                                user.TheIDnumber == Employee.The_ID_Number
                                )
                            {
                                if (Employee.Type == "Admin")
                                {
                                    return RedirectToAction("Index", "AdminControl", new { id = Employee.id });

                                }
                                else if (Employee.Type == "Employee")
                                {
                                    return RedirectToAction("Home", "Employee", new { id = Employee.id });

                                }


                                //return RedirectToAction("Edit", "Employee", new { id = Employee.id });

                            }
                        }

                        //else if (role.Name == "Student")
                        //{



                        foreach (var student in Allstudent)
                        {
                            // var studnetFind = studentRepo.Find(student.Id);
                            if (obj.UserName == student.First_Name_EN &&
                                user.Email == student.Email &&
                                user.TheIDnumber == student.Identity_No
                                )
                            {
                                if (student.high_school_certificate == "Syrian")
                                    return RedirectToAction("Home", "Studen", new { id = student.Id });
                                else if (student.high_school_certificate == "UNSyrian")
                                    return RedirectToAction("Home", "StudentUnsyrian", new { id = student.Id });

                            }
                        }
                        // }

                    }
                    /// }




                    ViewBag.invalidlogin = "Invalid login!!";
                    return View("Index");
                }
                ViewBag.invalidlogin = "Invalid login!!";
               // ModelState.AddModelError("", "Invalid login!!");

            }
            ViewBag.invalidlogin = "Invalid login!!";
            //}
            //else {
            //    ViewBag.norecaptcha = "please check out your internet connection";


            //}
            return View("Index");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            LoginInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Account");
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(Change_passowrd_Mode model)
        {
            // userManager.ChangePasswordAsync(1,"","");
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if (User == null)
                {
                    return RedirectToAction("");
                }
                var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassowrd);
                if (!result.Succeeded)
                {
                    foreach (var Error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, Error.Description);
                    }
                    return View();
                }

                await LoginInManager.RefreshSignInAsync(user);
                LogOff();
                return View("Success_change_password");
            }
            return View(model);
        }
        public async Task<IActionResult> EditUser() {

            var us = await userManager.GetUserAsync(User);
            var usid = us.Id;
            var user = await userManager.FindByIdAsync(usid);
            if (user == null) {
                ViewBag.ErrorMessage = $"User with Id ={usid} cannot be found";
                return View();
            }
            var claimss = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var model = new EditUserViewModell {
                Id = user.Id,
                Email = user.Email,
                IDNumber = user.TheIDnumber
            , Claims = claimss.Select(c => c.Value).ToList(),
                Roles = roles.ToList()
            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModell model)
        {
            var emailstudent = employeeRepo.List().Where(e => e.Email == model.Email).ToList();
            var TheIDnumberuser = employeeRepo.List().Where(e => e.The_ID_Number == model.IDNumber).ToList();
            if (emailstudent.Count == 0 && TheIDnumberuser.Count == 0)

            {
                var us = await userManager.GetUserAsync(User);
                var usid = us.Id;
                var user = await userManager.FindByIdAsync(usid);
                var roleuser = await userManager.GetRolesAsync(user);
                var roel = "";
                foreach (var item in roleuser)
                {
                    roel = item;
                }
                if (roel == "Admin" || roel == "Employee")
                {
                    var empl = employeeRepo.List().SingleOrDefault(e => e.name == us.UserName);
                    empl.Email = model.Email;
                    empl.The_ID_Number = model.IDNumber;
                    //var employeeedit = new Employee { 
                    //Email=model.Email,
                    //The_ID_Number=model.IDNumber

                    //};
                    employeeRepo.Update(empl.id, empl);
                }
                else if (roel == "Student")
                {
                    var stu = studentRepo.List().SingleOrDefault(s => s.First_Name_EN == us.UserName);
                    stu.Email = model.Email;
                    stu.Identity_No = model.IDNumber;
                    studentRepo.Update(stu.Id, stu);
                }
                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with Id ={usid} cannot be found";
                    return View();
                }
                else
                {
                    user.Email = model.Email;
                    user.TheIDnumber = model.IDNumber;
                    var result = await userManager.UpdateAsync(user);
                    //  if(roleuser.=="Admin")
                    if (result.Succeeded)
                    {
                        //  must return To succec view
                        return View("Success_Change_Info");
                    }
                    foreach (var erorr in result.Errors)
                    {
                        ModelState.AddModelError("", erorr.Description);
                    }
                    return View(model);

                }
            }
            //else if (emailstudent.Count == 1 && TheIDnumberuser.Count == 1)
            //{
            //    ViewBag.message = "Same Edit!!!";

            //    return View();

            //}
            else {
                ViewBag.message = "Edit fails becouse there is another student with  the same info ";

                return View();
            }


        }
        public IActionResult Forgot_password()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Forgot_password(Forgot_PasswordViewmodel model)
        {
            if (ModelState.IsValid) {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetlink = Url.Action("ResetPassword", "Account",
                                                        new { email = model.Email, token = token }, Request.Scheme);
                    await mailingService.SendEmailAsync(model.Email, "إعادة ضبط كلمة المرور", passwordResetlink);

                    //   logger.Log(LogLevel.Warning, passwordResetlink);

                    return View("success_send_link_forgot");
                }
                else {
                    ViewBag.checkoutEmail = "Please check out your Email Adress";
             //   ModelState.AddModelError("", "Please check out your Email Adress");
                    return View();
                }

            }
            return View();

        }
        public IActionResult ResetPassword(string token, string email) {
            if (token == null || email == null) {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid) {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("Success_Reset_Password");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                return View();
            }
            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token) {
            if (userId == null || token == null) {
                return View();
            
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null) {
                return View();
            
            }
            var result = await userManager.ConfirmEmailAsync(user,token);
            if (result.Succeeded) {
                return View();
            }
            return View();
        
        }
    }
}

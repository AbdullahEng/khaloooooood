using AdmissionSystem.Model;
using AdmissionSystem.Model.Identity_classes;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.View_Model.Identity_view_model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
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

        public AccountController(UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> LogInManager,
            RoleManager<MyIdentityRole> roleManager,
             CRUD_Operation_Interface<Employee> EmployeeRepo,
             CRUD_Operation_Interface<Student> StudentRepo,
              CRUD_Operation_Interface<Statues_Of_Student> Statues_Of_Student_Repository,
             CRUD_Operation_Interface<Tracking_Rate> Tracking_Rate_Repository


            )
        {
            this.userManager = userManager;
            this.LoginInManager = LogInManager;
            this.roleManager = roleManager;
            employeeRepo = EmployeeRepo;
            studentRepo = StudentRepo;
            statues_Of_Student_Repository = Statues_Of_Student_Repository;
            tracking_Rate_Repository = Tracking_Rate_Repository;
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


        public IActionResult Register_Student()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register_Student(RegisteerStudentViweModel obj)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser();
                user.UserName = obj.UserName;
                user.Email = obj.Email;
                user.TheIDnumber = obj.TheIDnumber;
                IdentityResult result = userManager.CreateAsync
                    (user, obj.password).Result;
                var student = new Student() {
                    Nick_Name = obj.Nick_Name,//
                    Birth = obj.Birth,//
                    Email = obj.Email,//
                    First_Name_EN = obj.UserName,//
                    gender = obj.Gender,//
                    high_school_certificate = obj.high_school_certificate,//
                    Mobile_Phone = obj.Mobile_Phone,//
                    Identity_No = obj.TheIDnumber//
                
                   // ,Admission_Eligibilty_Requist_For_UNsy_Certificate
                };
                if (result.Succeeded )
                {
                    if (!roleManager.RoleExistsAsync("Student").Result)
                    {
                        MyIdentityRole role = new MyIdentityRole();
                        role.Name = "Student";
                        role.Description = "perform Student operatoins";
                        IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Error while creatin");
                            return View(obj);
                        }

                    }
                    userManager.AddToRoleAsync(user, "Student").Wait();
                    studentRepo.Add(student);
                    var Tracking = new Tracking_Rate
                    {
                        FK_Student_Info = student,
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
                    statues_Of_Student_Repository.Add(status_of_student);




                    return RedirectToAction("login", "Account");
                }
            }
            return View(obj);
        }






        //////////////////////////////////////////////////////////////////////////////////////////
        /// // Employee


        public IActionResult Register_Employee()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register_Employee(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser();
                user.UserName = obj.UserName;
                user.Email = obj.Email;
                user.TheIDnumber = obj.TheIDnumber;
               
                IdentityResult result = userManager.CreateAsync
                    (user, obj.password).Result;
                var Employee = new Employee() { 
                Email=obj.Email,
                Type=obj.Type,
                Birth=obj.Birth_Date,
                Gender=obj.gender,
                name=obj.UserName,
                Nick_Name=obj.Nick_name,
                Phone_Number=obj.phone_Mobile,
                The_ID_Number=obj.TheIDnumber
                };
                if (result.Succeeded )
                {
                    if (!roleManager.RoleExistsAsync("Employee").Result||
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
                    if (obj.Type == "Emplyee")
                    {
                        userManager.AddToRoleAsync(user, "Employee").Wait();
                       

                    }
                    else if (obj.Type == "Admin")
                    {

                        userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
                    employeeRepo.Add(Employee);
                    return RedirectToAction("login", "Account");
                }
            }
            return View(obj);
        }



        public IActionResult Login() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModle obj)
        {
            if (ModelState.IsValid)
            {
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
                                             if (Employee.Type == "Admin") {
                                                     return RedirectToAction("Edit", "Employee", new { id = Employee.id });

                                             }
                                            else if (Employee.Type == "Employee") {
                                                     return RedirectToAction("Edit", "Employee", new { id = Employee.id });

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

                                        return RedirectToAction("Edit", "Studen", new { id = student.Id });

                                    }
                                }
                           // }

                        }
                   /// }




                   
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login!!");

            }
            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            LoginInManager.SignOutAsync().Wait();
            return RedirectToAction("Login", "Account");
        }


    }
}

using AdmissionSystem.Data;
using AdmissionSystem.Model.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Identity_classes
{
    public class MyIdentityDataInitializer
    {
        private readonly CRUD_Operation_Interface<Employee> employeerepooo;
        private readonly ApplicationDbContext dB;

        public MyIdentityDataInitializer()
        {

        }
        public  MyIdentityDataInitializer(  CRUD_Operation_Interface<Employee> employeerepooo, ApplicationDbContext DB)
        {
            this.employeerepooo = employeerepooo;
            dB = DB;
        }
        public  void SeedData(UserManager<MyIdentityUser> userManager,RoleManager<MyIdentityRole> roleManager
        
            ) {
            
            SeedRoles(roleManager);
            SeedaUsers(userManager);
           // seedemployee();

        }
        //public void seedemployee() {
        //   var adm1= employeerepooo.List().SingleOrDefault(e=>e.name=="Admin1");
        //    var adm2 = employeerepooo.List().SingleOrDefault(e => e.name == "Admin2");
        //    if (adm1 == null) {
        //        var emp = new Employee {  name = "Admin1", Email = "useer2@localhost", Type = "Admin", Gender = "Male", Nick_Name = "adm", Phone_Number = 0987, The_ID_Number = 8765 };
        //        dB.Employee.Add(emp);
        //    }
        //    if (adm2 == null) {

        //        var emp = new Employee {  name = "Admin2", Email = "useer2@localhost", Type = "Admin", Gender = "Male", Nick_Name = "adm", Phone_Number = 0987, The_ID_Number = 8765 };
        //        dB.Employee.Add(emp);
        //    }
        //}
        public  void SeedaUsers(UserManager<MyIdentityUser> userManager) {

            if (userManager.FindByNameAsync("Admin1").Result == null) {

                MyIdentityUser user = new MyIdentityUser();
                user.UserName = "Admin1";
                user.Email = "useer1@localhost";
              
                //user.FullName = "Nancy Davolio";
                //user.BirhtDate = new DateTime(1960, 1, 1);
                IdentityResult result = userManager.CreateAsync(user, "Abd_12345").Result;
                if (result.Succeeded) {

                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    var token =  userManager.GenerateEmailConfirmationTokenAsync(user).ToString();
                    //var user = await userManager.FindByIdAsync(userId);
                    var result1 =  userManager.ConfirmEmailAsync(user, token);
                   
                }
               
            }
            /////////
            ///
            if (userManager.FindByNameAsync("Admin2").Result == null)
            {

                MyIdentityUser user = new MyIdentityUser();
                user.UserName = "Admin2";
                user.Email = "Admin2@localhost";
              
                //user.FullName = "Nancy Davolio";
                // user.BirhtDate = new DateTime(1960, 1, 1);
                IdentityResult result = userManager.CreateAsync(user, "Abd_12345").Result;
                if (result.Succeeded)
                {

                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    var token =  userManager.GenerateEmailConfirmationTokenAsync(user).ToString();
                    //// var user = await userManager.FindByIdAsync(userId);
                    var result1 =  userManager.ConfirmEmailAsync(user, token);
                   
                }
            }



        }






        public static void SeedRoles(RoleManager<MyIdentityRole> roleManager) {
            //role for Admin
            if (!roleManager.RoleExistsAsync("Admin").Result) {
                MyIdentityRole role = new MyIdentityRole();
                role.Name = "Admin";
                role.Description = "perform normal operation.";
                IdentityResult roleresult = roleManager.CreateAsync(role).Result;
            }
            //role for Employee
            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                MyIdentityRole role = new MyIdentityRole();
                role.Name = "Employee";
                role.Description = "perform normal operation.";
                IdentityResult roleresult = roleManager.CreateAsync(role).Result;
            }
            //role for Student
            if (!roleManager.RoleExistsAsync("Student").Result)
            {
                MyIdentityRole role = new MyIdentityRole();
                role.Name = "Student";
                role.Description = "perform normal operation.";
                IdentityResult roleresult = roleManager.CreateAsync(role).Result;
            }


        }

    }
}

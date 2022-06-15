using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Identity_classes
{
    public class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<MyIdentityUser> userManager,RoleManager<MyIdentityRole> roleManager) {
            
            SeedRoles(roleManager);
            SeedaUsers(userManager);
                

        }
        public static void SeedaUsers(UserManager<MyIdentityUser> userManager) {

            if (userManager.FindByNameAsync("useer1").Result == null) {

                MyIdentityUser user = new MyIdentityUser();
                user.UserName = "useer1";
                user.Email = "useer1@localhost";
                //user.FullName = "Nancy Davolio";
               //user.BirhtDate = new DateTime(1960, 1, 1);
                IdentityResult result = userManager.CreateAsync(user, "password_goes_here").Result;
                if (result.Succeeded) {

                    userManager.AddToRoleAsync(user, "normauser").Wait();
                }
            }
            /////////
            ///
            if (userManager.FindByNameAsync("useer2").Result == null)
            {

                MyIdentityUser user = new MyIdentityUser();
                user.UserName = "useer2";
                user.Email = "useer2@localhost";
                //user.FullName = "Nancy Davolio";
               // user.BirhtDate = new DateTime(1960, 1, 1);
                IdentityResult result = userManager.CreateAsync(user, "password_goes_here").Result;
                if (result.Succeeded)
                {

                    userManager.AddToRoleAsync(user, "normauser2").Wait();
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

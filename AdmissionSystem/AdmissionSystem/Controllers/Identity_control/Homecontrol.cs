using AdmissionSystem.Model.Identity_classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.Identity_control
{
    public class Homecontrol : Controller
    {
        private readonly UserManager<MyIdentityUser> userManager;

        public Homecontrol(UserManager<MyIdentityUser>userManager)
        {
            this.userManager = userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            MyIdentityUser user = userManager.GetUserAsync
                (HttpContext.User).Result;
            ViewBag.Message = $"Welcome{user.UserName}!";
            if (userManager.IsInRoleAsync(user, "NormalUser").Result) {
                ViewBag.RoleMessage = "You are a normalUser.";
            }
            return View();
        }
    }
}

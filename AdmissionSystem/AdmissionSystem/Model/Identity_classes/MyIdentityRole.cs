using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Identity_classes
{
    public class MyIdentityRole:IdentityRole
    {
        public string Description { get; set; }
    }
}

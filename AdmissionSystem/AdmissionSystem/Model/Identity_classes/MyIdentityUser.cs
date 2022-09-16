using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Identity_classes
{
    public class MyIdentityUser:IdentityUser
    {
        public string TheIDnumber { get; set; }
      //  public DateTime birhtdate { get; set; }
    }
}

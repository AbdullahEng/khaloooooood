using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model.Identity_view_model
{
    public class RegisteerStudentViweModel
    {

        [Required]
        [Display(Name ="User Name ")]
        [StringLength(15,MinimumLength =3)]
        public string UserName { get; set; }
        [Required]
        [Display(Name ="Nick name")]
        [StringLength(15, MinimumLength = 3)]
        public string Nick_Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display]
        public string password { get; set; }
        [Required]
        [Compare("password")]
        [DataType(DataType.Password)]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
       // [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Range(0,999999999999)]
        [Required]
        [Display(Name ="The ID number")]
        public int  TheIDnumber { get; set; }

        [Required]
        [Display(Name= "High school certificate ")]
        public string high_school_certificate { get; set; }
        [Required]
        [Display(Name ="Gender")]
        public string Gender { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required]
        [Display(Name ="Mobile phone")]
       // [Phone]
        public int Mobile_Phone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Birht")]
       
        public DateTime Birth { get; set; }

        public string sitkey { get; set; }


    }
}

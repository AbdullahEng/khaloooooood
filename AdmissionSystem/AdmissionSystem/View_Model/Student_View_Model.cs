using AdmissionSystem.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model
{
    public class Student_View_Model
    {   public string high_school_certificate { get; set; }//syrian or not syrian certificate.
        public string First_Name_AR { get; set; }
        public string Father_Name_AR { get; set; }
        public string Grandfather_Name_AR { get; set; }
        public string Mother_Name_AR { get; set; }
        public string First_Name_EN { get; set; }
        public string Father_Name_EN { get; set; }
        public string Grandfather_Name_EN { get; set; }
        public string Mother_Name_EN { get; set; }
        public string Nick_Name { get; set; }
        public string gender { get; set; }
        public string Nationality { get; set; }
        public DateTime Birth { get; set; }
        public string Marital_status { get; set; }
        public string Civil_Registriation_City { get; set; }
        public int Civil_Registrition_No { get; set; }
        public int Passport_No { get; set; }
        public int Identity_No { get; set; }
        public string Full_Address { get; set; }
        public string Email { get; set; }
        public string Current_Address { get; set; }//address after the acciption
        public int Mobile_Phone { get; set; }
        public int Home_s_Phone { get; set; }
         public int The_Rate { get; set; }
        public string city_of_high_school_cirtificate { get; set; }
        public DateTime date_of_high_school_cirtificate { get; set; }

        public List<Type_of_high_school_Cirtificate> Type_Of_certificate_list { get; set; }

        public int Type_Of_Certificat { get; set; }
        /// for syrian student 
        public string LAnguge_of_the_addmintion { get; set; }
        public string Subscription_number { get; set; }
        public int course_number { get; set; }


        public IFormFile Image_Of_Crtificat { get; set; }
        public IFormFile Identity_front_image { get; set; }
        public IFormFile Identity_back_image { get; set; }
        public IFormFile check_recipt_image { get; set; }
        public string Image_of_crtificat_URL { get; set; }
        public string Identity_front_image_URL { get; set; }
        public string Identity_back_image_URL { get; set; }
        public string Check_recipt_image_URL { get; set; }


        public List<Department_relation_Type> specializtions { get; set; }
        public int wish_Department_Id1 { get; set; }
        public int wish_Department_Id2 { get; set; }
        public int wish_Department_Id3 { get; set; }

    }
}

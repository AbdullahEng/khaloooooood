using AdmissionSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model
{
    public class Status_Of_Student_View_Model
    {

        public string high_school_certificate { get; set; }//syrian or not syrian certificate.
        /// <summary>
        /// 
        /// </summary>
        public List<Country> CountryList { get; set; }
        public int Old_Country { get; set; }
        public int New_Country { get; set; }

        public List<Type_of_high_school_Cirtificate> Type_Of_certificate_list { get; set; }
        public int Old_Type_Of_Certificat { get; set; }
        public int New_Type_Of_Certificat { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string First_Name_AR { get; set; }
        public string Father_Name_AR { get; set; }
        public string Mother_Name_AR { get; set; }
        public string Nick_Name { get; set; }
        public string Nationality { get; set; }
        public DateTime Birth { get; set; }
        public string Civil_Registriation_City { get; set; }
        public int Civil_Registrition_No { get; set; }
        public string Passport_No { get; set; }
        public string Identity_No { get; set; }
        public string Full_Address { get; set; }
        public string Email { get; set; }
        public string Mobile_Phone { get; set; }
        public string Identity_front_image { get; set; }
        public string Identity_back_image { get; set; }
        public string Image_of_crtificat_URL { get; set; }
        public string check_recipt_image_URL { get; set; }


        /// for syrian student 
        public string LAnguge_of_the_addmintion { get; set; }
        public string Subscription_number { get; set; }
        public int course_number { get; set; }



        public float The_New_Rate { get; set; }

        public float The_Old_Rate { get; set; }

        public string city_of_high_school_cirtificate { get; set; }
        public DateTime date_of_high_school_cirtificate { get; set; }
        public bool Checking_city_Certificate { get; set; }
        public bool Checking_Identity_Image { get; set; }
        public bool Checking_Rate_Image { get; set; }
        public bool Checking_Recipte_Image { get; set; }


        //for email
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public int EmployeeId { get; set; }
    }

}

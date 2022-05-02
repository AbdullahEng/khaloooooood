using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model
{
    public class Status_Of_Student_View_Model
    {

        public string high_school_certificate { get; set; }//syrian or not syrian certificate.
        public string Country { get; set; }
        public string First_Name_AR { get; set; }
        public string Father_Name_AR { get; set; }
        public string Mother_Name_AR { get; set; }
        public string Nick_Name { get; set; }
        public string Nationality { get; set; }
        public DateTime Birth { get; set; }
        public string Civil_Registriation_City { get; set; }
        public int Civil_Registrition_No { get; set; }
        public int Passport_No { get; set; }
        public int Identity_No { get; set; }
        public string Full_Address { get; set; }
        public string Email { get; set; }
        public int Mobile_Phone { get; set; }
        public string Identity_front_image { get; set; }
        public string Identity_back_image { get; set; }
        public string Image_of_crtificat_URL { get; set; }
        public string check_recipt_image_URL { get; set; }


        /// for syrian student 
        public string LAnguge_of_the_addmintion { get; set; }
        public string Subscription_number { get; set; }
        public int course_number { get; set; }



        public int The_New_Rate { get; set; }

        public int The_Old_Rate { get; set; }

        public string city_of_high_school_cirtificate { get; set; }
        public DateTime date_of_high_school_cirtificate { get; set; }
        public bool Checking_city_Certificate{ get; set; }
        public bool Checking_Identity_Image { get; set; }
        public bool Checking_Rate_Image { get; set; }
        public bool Checking_Recipte_Image { get; set; }
    }

}

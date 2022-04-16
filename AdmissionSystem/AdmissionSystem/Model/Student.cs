using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Student
    {  public int Id { get; set; }
        public string high_school_certificate { get; set; }//syrian or not syrian certificate.
      
         public Country Cirtificate_city  { get; set; }// هل هذا يتصل بجدول البلاد ؟؟؟؟؟؟؟وسؤال تاني انو براي هذا الفيتشر لازم تكون موجوده بجدول الشهاده بحيث اذا كان الشهاده اجنبية لازم يعبي منين اخدها واذا كانت الشهاده سورية لازم ينحط باي ديفولت انو البلد سوري  
        /// <summary>
        /// إي المفروض يرتبط بجدول البلاد 1
        /// 2اذا كان هون ولا بجدول الشهاده نفس الشي  مو العلاقه واحد ل واحد 
        /// </summary>
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
        public string Identity_front_image { get; set; }
        public string Identity_back_image { get; set; }
        public Admission_Eligibilty_Requist_For_UNsy_Certificate Admission_Eligibilty_Requist_For_UNsy_Certificate { get; set; }
        public Statues_Of_Student Statues_Of_Student { get; set; }
        public Tracking_Rate FK_Tracking_Rate { get; set; }//sorry i modify it ^_^
         public Statues_of_admission_eligibilty Statues_Of_Admission_Eligibilty { get; set; }//Modifid AB
        public Accabtable_config FK_Accabtable_configInfo { get; set; }//Modifid AB//one_to_one relationship
    }
}

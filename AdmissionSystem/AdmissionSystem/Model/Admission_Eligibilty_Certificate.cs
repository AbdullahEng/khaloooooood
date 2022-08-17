using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Admission_Eligibilty_Certificate
    {

        //[ForeignKey("FK_student_Info")]
     
        public int id { get; set; }
        public float The_Rate { get; set; }
        public string city_of_high_school_cirtificate { get; set; }
        public DateTime date_of_high_school_cirtificate { get; set; }
        public string Image_of_crtificat_URL { get; set; }//ما العمل اذا كانت الشهادة من اكثر من صورة 
        /// <summary>
        /// بيغير الجامعه ( ͡¬ ‿ ͡¬)
        /// بخخخخخخخخخخخخ
        /// ممكن تكون مصفوفة بس هلق كنت عم شوف الشهاده يلي صورناها عند عبدو فهيي كانت صورة وححده لشهاد كويتية ....عكلن منسأل ان شاء الله 
        /// </summary>
        public string check_recipt_image_URL { get; set; }
      
        /// for syrian student 
        public string LAnguge_of_the_addmintion { get; set; }
        public string Subscription_number { get; set; }
        public int course_number { get; set; }
       public int ? wish1ID { get; set; }
        public Department_relation_Type wish1 { get; set; }//Modifid AB////
        public int? wish2ID { get; set; }
        public Department_relation_Type wish2 { get; set; }//Modifid AB////
        public int? wish3ID { get; set; }

        public Department_relation_Type wish3 { get; set; }//Modifid AB////

       // public int FK_student_InfoId { get; set; } //(FK)//AB//sorry i modify it ^_^ 
       //////[ForeignKey("FK_student_InfoId")]
       // public Student FK_student_Info { get; set; }//sorry i modify it ^_^ 


        public int FK_studentId { get; set; }//one_to_one relationship
        public Student FK_student { get; set; }//one_to_one relationship

        //// public int FK_Type_of_high_school_CirtificateId { get; set; }//Modifid AB//one_to_many relationship
        public Type_of_high_school_Cirtificate FK_Type_of_high_school_Cirtificate { get; set; }//one_to_many relationship//sorry i modify it ^_^ 
    }
}

using AdmissionSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Data
{
    public static class ModelBuilderExtenisons
    {   public static void seed(this ModelBuilder modelbuilder ) {
            modelbuilder.Entity<Faculty>().HasData(
                new Faculty {id=1,Faculty_name= "كلية طبية" },
                 new Faculty { id = 2, Faculty_name = "كلية الهندسة المدنية والمعمارية" },
                  new Faculty { id = 3, Faculty_name = "كلية الهندسة" },
                    new Faculty { id = 4, Faculty_name = "كليةالأعمال والإدارة" },
                     new Faculty { id = 5, Faculty_name = "كليةالفنون والإعلام" },
                      new Faculty { id = 6, Faculty_name = "كليةالحقوق والعلوم الإنسانية" }


                );
            modelbuilder.Entity<Type_of_high_school_Cirtificate>().HasData(
                new Type_of_high_school_Cirtificate {id=1,type="علمي" },
                new Type_of_high_school_Cirtificate { id = 2, type = "أدبي" },
                new Type_of_high_school_Cirtificate { id = 3, type = "تجارة" },
                new Type_of_high_school_Cirtificate { id = 4, type = "مهني حاسوب" },
                new Type_of_high_school_Cirtificate { id = 5, type = "مهني فنون" }
               );

            modelbuilder.Entity<Country>().HasData(
                new Country { id=1,country_name="سوريا"},
                new Country { id = 2, country_name = "الإمارات" },
                new Country { id = 3, country_name = "الكويت" },
                new Country { id = 4, country_name = "السعودية" });

            modelbuilder.Entity<Department>().HasData(
                new Department { id=1,FK_facultyId=1, specialization_name="الطب"},
                new Department { id = 2, FK_facultyId = 1, specialization_name = "طب الأسنان" },
                  new Department { id = 3, FK_facultyId = 1, specialization_name = "الصيدلة" },
                  new Department { id = 4, FK_facultyId = 2, specialization_name = "الهندسة المعمارية" },
                  new Department { id = 5, FK_facultyId = 2, specialization_name = "الهندسة المدنية" },
                  new Department { id = 6, FK_facultyId = 3, specialization_name = "هندسة تقانة المعلومات" },
                  new Department { id = 7, FK_facultyId = 3, specialization_name = "هندسة الميكاترونيكس" },
                  new Department { id = 8, FK_facultyId = 4, specialization_name = "إدارة" },
                  new Department { id = 9, FK_facultyId = 4, specialization_name = "تمويل بنوك" },
                  new Department { id = 10, FK_facultyId = 5, specialization_name = "التصميم الداخلي" }, 
                  new Department { id = 11, FK_facultyId = 5, specialization_name = "التصميم الغرافيكي" },
                     new Department { id = 12, FK_facultyId = 6, specialization_name = "الحقوق" }
                  );
            modelbuilder.Entity<Department_relation_Type>().HasData(
                new Department_relation_Type { id=1,FK_DepartmentId=1,FK_type_Of_High_School_CirtificateId=1,Minemum_of_Rate=83,},
                  new Department_relation_Type { id = 2, FK_DepartmentId = 2, FK_type_Of_High_School_CirtificateId = 1, Minemum_of_Rate = 78,
                  },new Department_relation_Type { id = 3, FK_DepartmentId = 3, FK_type_Of_High_School_CirtificateId = 1, Minemum_of_Rate = 78, },
                  new Department_relation_Type { id = 4, FK_DepartmentId = 4, FK_type_Of_High_School_CirtificateId = 1, Minemum_of_Rate = 68, },
                  new Department_relation_Type { id = 5, FK_DepartmentId = 5, FK_type_Of_High_School_CirtificateId = 1, Minemum_of_Rate = 68, },
                  new Department_relation_Type { id = 6, FK_DepartmentId = 6, FK_type_Of_High_School_CirtificateId = 1, Minemum_of_Rate = 68, },
                  new Department_relation_Type { id = 7, FK_DepartmentId = 6, FK_type_Of_High_School_CirtificateId = 4, Minemum_of_Rate = 83, },
                  new Department_relation_Type { id = 8, FK_DepartmentId = 7, FK_type_Of_High_School_CirtificateId = 1, Minemum_of_Rate = 68, },
                  new Department_relation_Type { id = 9, FK_DepartmentId = 7, FK_type_Of_High_School_CirtificateId = 4, Minemum_of_Rate = 83, },
                  new Department_relation_Type { id = 10, FK_DepartmentId = 8, FK_type_Of_High_School_CirtificateId = 1, Minemum_of_Rate = 56, },
                  new Department_relation_Type { id = 11, FK_DepartmentId = 8, FK_type_Of_High_School_CirtificateId = 2, Minemum_of_Rate = 56, },
                  new Department_relation_Type { id =12, FK_DepartmentId = 8, FK_type_Of_High_School_CirtificateId = 3, Minemum_of_Rate = 63, },
                  new Department_relation_Type { id = 13, FK_DepartmentId = 9, FK_type_Of_High_School_CirtificateId = 1, Minemum_of_Rate = 56, },
                  new Department_relation_Type { id = 14, FK_DepartmentId = 9, FK_type_Of_High_School_CirtificateId = 2, Minemum_of_Rate = 56, },
                  new Department_relation_Type { id = 15, FK_DepartmentId = 9, FK_type_Of_High_School_CirtificateId = 3, Minemum_of_Rate = 63, },
                  new Department_relation_Type { id = 16, FK_DepartmentId = 10, FK_type_Of_High_School_CirtificateId = 1, Minemum_of_Rate = 56, },
                  new Department_relation_Type { id = 17, FK_DepartmentId = 10, FK_type_Of_High_School_CirtificateId = 2, Minemum_of_Rate = 56, },
                  new Department_relation_Type { id = 18, FK_DepartmentId = 10, FK_type_Of_High_School_CirtificateId = 5, Minemum_of_Rate = 63, },
                  new Department_relation_Type { id = 19, FK_DepartmentId = 11, FK_type_Of_High_School_CirtificateId = 1, Minemum_of_Rate = 56, },
                  new Department_relation_Type { id = 20, FK_DepartmentId = 11, FK_type_Of_High_School_CirtificateId = 2, Minemum_of_Rate = 56, },
                  new Department_relation_Type { id = 21, FK_DepartmentId = 11, FK_type_Of_High_School_CirtificateId = 5, Minemum_of_Rate = 63, }

             );

            modelbuilder.Entity<Employee>().HasData(

                new Employee { id=1, name = "Admin1", Email = "useer1@localhost", Type = "Admin", Gender = "Male", Nick_Name = "adm", Phone_Number = "0987", The_ID_Number = "8765" },

                 new Employee { id=2, name = "Admin2", Email = "useer2@localhost", Type = "Admin", Gender = "Male", Nick_Name = "adm", Phone_Number = "0987", The_ID_Number = "8765" }
          
                
                );
            

        }
        
    }
   
}

using AdmissionSystem.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Admission_Eligibilty_Requist_For_UNsy_Certificate>()//one_to_one relationship
                    .HasOne<Department_relation_Type>(w => w.wish1)
                    .WithOne(a_d => a_d.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate1)
                    .HasForeignKey<Department_relation_Type>(a_d_id => a_d_id.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate1Id);


            modelBuilder.Entity<Admission_Eligibilty_Requist_For_UNsy_Certificate>()//one_to_one relationship
                    .HasOne<Department_relation_Type>(w => w.wish2)
                    .WithOne(a_d => a_d.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate2)
                    .HasForeignKey<Department_relation_Type>(a_d_id => a_d_id.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate2Id);



            modelBuilder.Entity<Admission_Eligibilty_Requist_For_UNsy_Certificate>()//one_to_one relationship
                    .HasOne<Department_relation_Type>(w => w.wish3)
                    .WithOne(a_d => a_d.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate3)
                    .HasForeignKey<Department_relation_Type>(a_d_id => a_d_id.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate3Id);

        }
    }
}

using AdmissionSystem.Model;
using AdmissionSystem.Model.Identity_classes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionSystem.Data
{

    public class ApplicationDbContext : IdentityDbContext<MyIdentityUser, MyIdentityRole, String>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Admission_Eligibilty_Requist_For_UNsy_Certificate>()//one_to_one relationship
            //        .HasOne<Department_relation_Type>(w => w.wish1)
            //        .WithOne(a_d => a_d.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate1)
            //        .HasForeignKey<Department_relation_Type>(a_d_id => a_d_id.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate1Id);


            //modelBuilder.Entity<Admission_Eligibilty_Requist_For_UNsy_Certificate>()//one_to_one relationship
            //        .HasOne<Department_relation_Type>(w => w.wish2)
            //        .WithOne(a_d => a_d.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate2)
            //        .HasForeignKey<Department_relation_Type>(a_d_id => a_d_id.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate2Id);



            //modelBuilder.Entity<Admission_Eligibilty_Requist_For_UNsy_Certificate>()//one_to_one relationship
            //        .HasOne<Department_relation_Type>(w => w.wish3)
            //        .WithOne(a_d => a_d.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate3)
            //        .HasForeignKey<Department_relation_Type>(a_d_id => a_d_id.FK_Admission_Eligibilty_Requist_For_UNsy_Certificate3Id);

            //modelBuilder.Entity<Student>()
            //  . (s => s.) // Mark Address property optional in Student entity
            //  .WithRequired(ad => ad.Student); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student

        }
        public DbSet<Accabtable_config> Accabtable_config { get; set; }
        public DbSet<Admission_Eligibilty_Certificate> Admission_Eligibilty_Certificate { get; set; }
        public DbSet<Broken_Relationshib_Stat_Dep_Chair> Broken_Relationshib_Stat_Dep_Chair { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Department_relation_Type> Department_relation_Type { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Persentage_count_for_each__country> Persentage_count_for_each__country { get; set; }
        public DbSet<Statues_of_admission_eligibilty> Statues_of_admission_eligibilty { get; set; }
        public DbSet<Statues_Of_Student> Statues_Of_Student { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Tracking_Rate> Tracking_Rate { get; set; }
        public DbSet<Type_of_high_school_Cirtificate> Type_of_high_school_Cirtificate { get; set; }

    }
}

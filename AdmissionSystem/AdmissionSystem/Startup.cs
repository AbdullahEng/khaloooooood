using AdmissionSystem.Data;
using AdmissionSystem.Model;
using AdmissionSystem.Model.Identity_classes;
using AdmissionSystem.Model.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<MyIdentityUser, MyIdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
       .AddEntityFrameworkStores<ApplicationDbContext>()
       .AddDefaultTokenProviders();

            services.AddScoped<CRUD_Operation_Interface<Admission_Eligibilty_Certificate>, Admission_Eligibilty_Certificate_Repo>();

            services.AddScoped<CRUD_Operation_Interface<Employee>, Employee_Repo>();

            services.AddScoped<CRUD_Operation_Interface<Statues_Of_Student>, Statues_Of_Student_Repo>();

            services.AddScoped<CRUD_Operation_Interface<Student>, Student_Repo>();

            services.AddScoped<CRUD_Operation_Interface<Tracking_Rate>, Tracking_Rate_Repo>();

            services.AddScoped<CRUD_Operation_Interface<Type_of_high_school_Cirtificate>, Type_of_high_school_Cirtificate_Repo>();
            services.AddScoped<CRUD_Operation_Interface<Department_relation_Type>, Department_relation_Type_Repo>();





            services.AddScoped<CRUD_Operation_Interface<Faculty>, faculty_Repo>();
            services.AddScoped<CRUD_Operation_Interface<Department>, Department_Repo>();
            services.AddScoped<CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair>, Broken_Relationshib_Stat_Dep_Chair_Repo>();
            services.AddScoped<CRUD_Operation_Interface<Persentage_count_for_each__country>, percentage_count_for_each_country_Repo>();
            services.AddScoped<CRUD_Operation_Interface<Statues_of_admission_eligibilty>, statues_of_admission_elgibilty_Repo>();
            services.AddScoped<CRUD_Operation_Interface<Accabtable_config>, Accabtable_Config_Repo>();
            services.AddScoped<CRUD_Operation_Interface<Country>, country_Repo>();





            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
           
            services.AddMvc();
          services.AddMvc(option => option.EnableEndpointRouting = false); //ÂÌ ÷› Â« „‘«‰ Ì‘ €· «·—«Ê Ì‰€ «·ÌœÊÌ 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<MyIdentityUser>userManager,RoleManager<MyIdentityRole>roleManager)
        {
            //app.UseAuthentication();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();   // ÂÌ «· ⁄·Ì„Â „‘«‰ «ﬁœ— «⁄„· —Ê  »‘ﬂ· ÌœÊÌ ·«‰Ê „‰ œÊ‰Â« ⁄ÿ«‰Ì «‰Ê «·’›Õ…  »⁄ «·ÿ«·» €Ì— „ÊÃÊœÂ 
            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            MyIdentityDataInitializer.SeedData(userManager, roleManager);//
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

        }
    }
}

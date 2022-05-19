using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee;

namespace RAM___RUC_Allocation_Manager
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

            services.AddRazorPages();
          
            #region Cookie Atuhentication Setup
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request. 
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions =>
            {
                cookieOptions.LoginPath = "/LoginPage/LoginPage";
            });

            /*services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "admin"));
            });*/
          
            services.AddMvc().AddRazorPagesOptions(options =>
            {
              
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            #endregion
              
            services.AddDbContext<RamDbContext>();
            services.AddTransient<DbService<LeaderProgramme>, DbService<LeaderProgramme>>();
            services.AddTransient<DbService<Employee>, DbService<Employee>>();
            services.AddTransient<DbService<Leader>, DbService<Leader>>();
            services.AddTransient<DbService<Programme>, DbService<Programme>>();
            services.AddTransient<DbService<CustomCommittee>, DbService<CustomCommittee>>();
            services.AddTransient<DbService<PromotionCommitteeTask>, DbService<PromotionCommitteeTask>>();
            services.AddTransient<DbService<HiringCommittee>, DbService<HiringCommittee>>();
            services.AddTransient<DbService<Course>, DbService<Course>>();
            services.AddTransient<DbService<GroupFacilitationTask>, DbService<GroupFacilitationTask>>();
            services.AddTransient<DbService<PhdTasks>, DbService<PhdTasks>>();
            services.AddTransient<DbService<Group>, DbService<Group>>();
            services.AddTransient<DbService<Redemption>, DbService<Redemption>>();
            services.AddTransient<DbService<EmployeeCourse>, DbService<EmployeeCourse>>();
            services.AddTransient<DbService<EmployeeCustomCommittee>, DbService<EmployeeCustomCommittee>>();
            services.AddTransient<DbService<EmployeeGroup>, DbService<EmployeeGroup>>();
            services.AddTransient<DbService<EmployeeHiringCommittee>, DbService<EmployeeHiringCommittee>>();
            services.AddTransient<DbService<EmployeeProgramme>, DbService<EmployeeProgramme>>();

            services.AddSingleton<JSONFileService<BaseSettings>, JSONFileService<BaseSettings>>();
            services.AddSingleton<UserService, UserService>();
            services.AddSingleton<SettingsService, SettingsService>();
            services.AddSingleton<LoginService, LoginService>();
            services.AddSingleton<PropertyStoringService, PropertyStoringService>();

            services.AddTransient<PaginationService<Leader>, PaginationService<Leader>>();
            services.AddTransient<PaginationService<Employee>, PaginationService<Employee>>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

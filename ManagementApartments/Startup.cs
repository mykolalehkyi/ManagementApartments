using ManagementApartments.Data;
using ManagementApartments.Data.Config;
using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository;
using ManagementApartments.Data.Repository.Interface;
using ManagementApartments.Data.Service;
using ManagementApartments.Data.Service.Interface;
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

namespace ManagementApartments
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
            services.AddDistributedMemoryCache();

            services.AddSession();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContext<ManagementApartmentDbContext>();
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ManagementApartmentDbContext>();
            services.AddRazorPages();

            services.AddScoped<IApartmentsService, ApartmentsService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IEquipmentsService, EquipmentsService>();
            services.AddScoped<ITenantsService, TenantsService>();
            services.AddScoped<IWorkingContactService, WorkingContactService>();
            services.AddScoped<IRentPeriodsService, RentPeriodsService>();

            services.AddScoped<IApartmentsRepository, ApartmentsRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IEquipmentsRepository, EquipmentsRepository>();
            services.AddScoped<ITenantsRepository, TenantsRepository>();
            services.AddScoped<IWorkingContactRepository, WorkingContactRepository>();
            services.AddScoped<IRentPeriodsRepository, RentPeriodsRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}

using System;
using System.Threading.Tasks;
using CinemaZ.Data;
using CinemaZ.Helpers;
using CinemaZ.Models;
using CinemaZ.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CinemaZ
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

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();

            services.AddScoped<SqlArticleService>();
            services.AddScoped<SqlCinemaService>();
            services.AddScoped<SqlMovieRoomService>();
            services.AddScoped<SqlMovieService>();
            services.AddScoped<SqlPremiereService>();
            services.AddScoped<SqlRoomService>();
            services.AddScoped<SqlSeatService>();

            services.AddSingleton<ImageUpload>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //TestService(serviceProvider).Wait();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        /*private async Task TestService(IServiceProvider serviceProvider)
        {
            SqlRoomService sqlRoomService = serviceProvider.GetRequiredService<SqlRoomService>();
            SqlMovieService sqlMovieService = serviceProvider.GetRequiredService<SqlMovieService>();
            SqlMovieRoomService sqlMovieRoomService = serviceProvider.GetRequiredService<SqlMovieRoomService>();

            Movie movieTest = new Movie()
            {
                Category = CategoryType.Action,
                Name = "New Movie  test",
                Price = 2.34M,
                ReleaseDate = DateTime.Now,
                PremiereId = 8
            };

            Room roomTest = sqlRoomService.GetRoom(2);

            sqlMovieService.CreateMovie(movieTest);
            
            sqlMovieRoomService.AddMovieToRoom(movieTest, roomTest);
        } */
    }
}

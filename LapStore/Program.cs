using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.SqlClient;
using LapStore.Models;
using Domains;
using Bl;
using LapStore.Bl;

namespace LapStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database connection string
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Test database connection
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Connection successful, proceed with configuration
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error connecting to database: " + ex.Message);
                throw; // Re-throw exception to halt application startup if database is not accessible
            }

            // Add services to the container
            builder.Services.AddControllersWithViews();

             builder.Services.AddDbContext<LapShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Configure Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<LapShopContext>()
            .AddDefaultTokenProviders(); // Ensure default token providers are added for password reset, etc.

            // Add custom services
            builder.Services.AddScoped<ICategories, ClsCategories>();
            builder.Services.AddScoped<IItems, ClsItems>();
            builder.Services.AddScoped<IItemTypes, ClsItemTypes>();
            builder.Services.AddScoped<IOs, ClsOs>();
            builder.Services.AddScoped<IItemImages, ClsItemImages>();
            builder.Services.AddScoped<ISalesInvoice, ClsSalesInvoice>();
            builder.Services.AddScoped<ISalesInvoiceItems, ClsSalesInvoiceItems>();
            builder.Services.AddScoped<ISliders, ClsSliders>();
            builder.Services.AddScoped<ISettings, ClsSettings>();
            builder.Services.AddScoped<IUsers, ClsUsers>();
            builder.Services.AddScoped<IPages, ClsPages>();

            // Configure session and cookies
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDistributedMemoryCache();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Users/AccessDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = "/Users/Login";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "LandingPages",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "ali",
                    pattern: "ali/{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}

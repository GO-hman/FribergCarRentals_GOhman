using FribergCarRentals_GOhman.Data;
using FribergCarRentals_GOhman.Services;
using FribergCarRentals_GOhman.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals_GOhman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(
                options =>
                options.UseSqlServer(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetSection("ConnectionStrings")["FribergRentalsDb"]));
            builder.Services.AddTransient<ICar, CarRepository>();
            builder.Services.AddTransient<IUser, UserRepository>();
            builder.Services.AddTransient<IBooking, BookingRepository>();
            builder.Services.AddTransient<IAdmin, AdminRepository>();

            builder.Services.AddTransient<MockData>();
            builder.Services.AddTransient<BookingService>();
            builder.Services.AddTransient<AuthLogin>();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Login}/{id?}");

            app.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseSession();


            app.Run();
        }
    }
}

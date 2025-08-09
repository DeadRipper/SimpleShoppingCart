using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SimpleShoppingCart.Data;
using SimpleShoppingCart.Helpers;
using SimpleShoppingCart.Helpers.InterfacesHelpers;
namespace SimpleShoppingCart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SimpleShoppingCartContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SimpleShoppingCartContext") ?? throw new InvalidOperationException("Connection string 'SimpleShoppingCartContext' not found.")));
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<IValidate, Validate>();
            builder.Services.AddScoped<IDBWorker, DBWorker>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Auth/LoginPageViews/Login";
                options.LogoutPath = "/Auth/Logout";
                options.AccessDeniedPath = "/Auth/Denied";
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.SlidingExpiration = true;
            });

            var app = builder.Build();            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/ShopCart/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=ShopCart}/{action=Main}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SimpleShoppingCart.Data;
using SimpleShoppingCart.Helpers;
using SimpleShoppingCart.Helpers.InterfacesHelpers;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add DbContext with connection string
        services.AddDbContext<SimpleShoppingCartContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SimpleShoppingCartContext")
                                 ?? throw new InvalidOperationException("Connection string 'SimpleShoppingCartContext' not found.")));

        // Add services for MVC
        services.AddControllersWithViews();

        // Dependency Injection for IValidate and IDBWorker
        services.AddTransient<IValidate, Validate>();
        services.AddScoped<IDBWorker, DBWorker>();

        // Configure authentication
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Auth/LoginPageViews/Login";
                options.LogoutPath = "/Auth/Logout";
                options.AccessDeniedPath = "/Auth/Denied";
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.SlidingExpiration = true;
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseHsts();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Redirect HTTP requests to HTTPS
        app.UseHttpsRedirection();

        // Serve static files
        app.UseStaticFiles();  // This enables serving static files (like CSS, JS, images, etc.)

        // Configure routing
        app.UseRouting();

        // Use Authorization middleware
        app.UseAuthorization();

        // Set up default controller route
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=ShopCart}/{action=Main}/{id?}");
        });
    }
}
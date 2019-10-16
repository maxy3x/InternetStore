using System;
using AutoMapper;
using System.Net;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Context;
using DataAccess.Initializers;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DocsExchangeGoogle;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebStore.Services;

namespace WebStore
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
            services.AddAutoMapper();

            services.AddTransient<IEmployeeBusinessLogic, EmployeeBusinessLogic>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IProductBusinessLogic, ProductBusinessLogic>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductImagesBusinessLogic, ProductImagesBusinessLogic>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IProductTypeBusinessLogic, ProductTypeBusinessLogic>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<IProductMetalBusinessLogic, ProductMetalBusinessLogic>();
            services.AddTransient<IProductMetalRepository, ProductMetalRepository>();
            services.AddTransient<IProductColorBusinessLogic, ProductColorBusinessLogic>();
            services.AddTransient<IProductColorRepository, ProductColorRepository>();
            services.AddTransient<IProductAvStatusBusinessLogic, ProductAvStatusBusinessLogic>();
            services.AddTransient<IProductAvStatusRepository, ProductAvStatusRepository>();
            services.AddTransient<IProductStatusBusinessLogic, ProductStatusBusinessLogic>();
            services.AddTransient<IProductStatusRepository, ProductStatusRepository>();
            services.AddTransient<IGenderBusinessLogic, GenderBusinessLogic>();
            services.AddTransient<IGenderRepository, GenderRepository>();

            services.AddDbContext<WebStoreDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<WebStoreDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                })
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    var services = serviceScope.ServiceProvider;
                    try
                    {
                        var context = services.GetRequiredService<WebStoreDbContext>();
                        DbInitializer.Initialize(context);
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while seeding the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}, Failed to migrate or seed database");
            }
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context /* other dependencies */)
    {
        try
        {
            await _next(context);
            if (context.Response.StatusCode == (int)HttpStatusCode.NotFound) throw new InvalidOperationException("404");

        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError; // 500 if unexpected

        context.Response.StatusCode = (int)code;
        context.Response.ContentType = "text/HTML";
        var result = new ErrorPageMaker(exception, context).PageMaker();//��� ������ ������, �� � ������ ��� ���

        return context.Response.WriteAsync(result);
    }

}
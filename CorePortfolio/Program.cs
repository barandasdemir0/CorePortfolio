using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CorePortfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<WriterUser, WriterRole>().AddEntityFrameworkStores<Context>();

            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            //{
            //    x.LoginPath = "/AdminLoginController/Index/";
            //});

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.AccessDeniedPath = "/ErrorPage/Index/";
                options.LoginPath = "/Writer/Login/Index/";
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();



            }

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");


            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");
    

            app.Run();
        }
    }
}

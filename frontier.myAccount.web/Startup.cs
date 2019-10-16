using frontier.myAccount.web.Services.Interfaces;
using frontier.myAccount.web.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;


namespace frontier.myAccount.web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
                options.HttpOnly = HttpOnlyPolicy.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {

                // options.Cookie.IsEssential = true;

                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;

                options.Cookie.Name = "myDomain.myAccount.AuthCookie";
                options.Cookie.Path = "/";
                options.AccessDeniedPath = "/Account/Login";
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";

                options.Cookie.SameSite = SameSiteMode.None;


                // Do not use this setting at all as this setting is deprecated
                // this will not expire the token
                /* options.Cookie.Expiration = TimeSpan.FromSeconds(100); */

                options.ExpireTimeSpan = TimeSpan.FromDays(1000);
                options.SlidingExpiration = true;
            });

            services.AddMvc(options =>
            {
                //  options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

                //var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                //options.Filters.Add(new AuthorizeFilter(policy));
                //options.Filters.Add(new AuthorizeFilter());

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpContextAccessor();

            // register your services here
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IServiceAccountService, ServiceAccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
               // app.UseHsts();
            }

           // app.UseHttpsRedirection();
            app.UseStaticFiles();


            // enabling cookie and authentication middleware
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "areas",
                //    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "dabba",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}

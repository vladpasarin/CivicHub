using CivicHub.Data;
using CivicHub.Helpers;
using CivicHub.Interfaces;
using CivicHub.IServices;
using CivicHub.Models;
using CivicHub.Repositories;
using CivicHub.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using CivicHub.Mapper;

namespace CivicHub
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

            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperSetup());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IIssueRepository, IssueRepository>();
            services.AddTransient<IIssueStateCommentPhotoRepository, IssueStateCommentPhotoRepository>();
            services.AddTransient<IIssueStateCommentRepository, IssueStateCommentRepository>();
            services.AddTransient<IIssueStatePhotoRepository, IssueStatePhotoRepository>();
            services.AddTransient<IIssueStateReactionRepository, IssueStateReactionRepository>();
            services.AddTransient<IIssueStateRepository, IssueStateRepository>();
            services.AddTransient<IIssueStateVideoRepository, IssueStateVideoRepository>();
            //services.AddTransient<>
            //services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IIssueService, IssueService>();
            services.AddTransient<IIssueStateService, IssueStateService>();

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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

            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            
            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}

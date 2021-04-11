using Application;
using ApplicationServices.Implementation;
using ApplicationServices.Interfaces;
using DataAccess;
using DataAccess.Interfaces;
using Delivery.CompanyN;
using Delivery.Interfaces;
using DomainServices.Implementation;
using DomainServices.Interfaces;
using Email.Implemintation;
using Email.Interfaces;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mobile.UseCases.Member.BackgroundJobs;
using UseCases.Member.Commands;
using WebApp.Interfaces;
using WebApp.Services;

namespace WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            

            //Domain            
            services.AddScoped<IMemberAnemicService, MemberAnemicService>();

            //Infrastructure
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddDbContext<IDbContext, AppDbContext>(builder =>
                 builder.UseSqlServer(Configuration.GetConnectionString("MsSql")));
            services.AddScoped<IDeliveryNService, DeliveryNService>();
            services.AddScoped<IBackgroundJobService, BackgroundJobService>();


            //Application
            //services.AddScoped<IMemberService, MemberService>();//before
            services.AddScoped<ISecurityService, SecurityService>();

            //Frameworks
            services.AddControllers();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddMediatR(typeof(CreateMemberCommand));
            services.AddHangfire(cfg => cfg.UseSqlServerStorage(Configuration.GetConnectionString("MsSql")));
            services.AddHangfireServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandlerMiddleware();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseHangfireServer();
            RecurringJob.AddOrUpdate<UpdateDeliveryStatusJob>("UpdateDeliveryStatusJob", (job) => job.ExecuteAsync(), Cron.Daily);
        }
    }
}

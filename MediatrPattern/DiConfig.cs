using AspNetCoreHero.ToastNotification;
using MediatR;
using MediatrPattern.Data;
using MediatrPattern.Repository;
using MediatrPattern.Repository.Interface;
using MediatrPattern.Services;
using MediatrPattern.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrPattern
{
    public static class DiConfig
    {
        public static IServiceCollection UseConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IEmployeeService, EmployeeService>();
            services.AddMediatR(typeof(Startup));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddNotyf(config=> { config.DurationInSeconds = 10;config.IsDismissable = true;config.Position = NotyfPosition.TopRight; });
            return services;
        }
    }
}
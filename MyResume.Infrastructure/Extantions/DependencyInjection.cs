using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyResume.Infrastructure.AppContext;
using MyResume.Infrastructure.Repositories.AboutRepositories;
using MyResume.Infrastructure.Repositories.AdminRepositories;
using MyResume.Infrastructure.Repositories.ContactRepositories;
using MyResume.Infrastructure.Repositories.EducationRepositories;
using MyResume.Infrastructure.Repositories.FeatureRepositories;
using MyResume.Infrastructure.Repositories.MessageRepositories;
using MyResume.Infrastructure.Repositories.PortfolioRepositories;
using MyResume.Infrastructure.Repositories.ResumeRepositories;
using MyResume.Infrastructure.Repositories.SkillRepositories;
using MyResume.Infrastructure.Repositories.SocialMediaRepositories;
using MyResume.Infrastructure.Repositories.SummaryRepositories;
using MyResume.Infrastructure.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Extantions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
            {

                options.UseSqlServer(configuration.GetConnectionString("OnlineConnectionString"));
            });

            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IAboutRepositories, AboutRepositories>();
            services.AddScoped<IContactRepositories, ContactRepositories>();
            services.AddScoped<IMessageRepositories, MessageRepositories>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IResumeRepository, ResumeRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<ISummaryRepository, SummaryRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();


            AdminSeed.AdminSeedAsync(configuration).GetAwaiter().GetResult();


            return services;
        }
    }
}

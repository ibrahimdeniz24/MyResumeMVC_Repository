using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyResume.Business.Services.AboutServices;
using MyResume.Business.Services.AccountServices;
using MyResume.Business.Services.AdminServices;
using MyResume.Business.Services.ContactServices;
using MyResume.Business.Services.EducationServices;
using MyResume.Business.Services.EmailServices;
using MyResume.Business.Services.FeatureServices;
using MyResume.Business.Services.HangFireServices;
using MyResume.Business.Services.MessageServices;
using MyResume.Business.Services.PotfolioServices;
using MyResume.Business.Services.ReCAPTCHAServices;
using MyResume.Business.Services.ResumeServices;
using MyResume.Business.Services.SkillServices;
using MyResume.Business.Services.SummaryServices;
using MyResume.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace MyResume.Business.Extantions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<ISummaryServices, SummaryServices>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IHangFireServices, HangFireService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IReCAPTCHAService, ReCaptchaServiceV3>();
            services.AddHttpClient<ReCaptchaServiceV3>();

            return services;
        }
    }
}

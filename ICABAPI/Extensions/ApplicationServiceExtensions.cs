using ICABAPI.Data;
using ICABAPI.Helpers;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using ICABAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ICABAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IFirmEntry, FirmRepository>();
            services.AddTransient<PdfService>();
           // services.AddTransient<TabulationRepository>();
            // services.AddScoped<ICPLSubjectCourseRepository, CPLSubjectCourseRepository>();
            services.AddScoped<ITabulationRepository, TabulationRepository>();
            services.AddScoped<IStudentTypeRepository, StudentTypeRepository>();
            services.AddScoped<IPrincipalEntry, PrincipalRepository>();
            services.AddScoped<IMarks, MarksRepository>();
            //services.AddScoped<ICPLExemtion, CPLExemtionRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IStudentExpelledService, StudentExpelledRepository>();
            services.AddScoped<IStudentArticleshipCancelationService, StudentArticleshipCancelationRepository>();
            services.AddSingleton<IGetResultFromMoodleService, GetResultFromMoodleRepository>();
            services.AddAutoMapper(typeof(MapperProfile).Assembly);

            services.AddDbContext<ModelContext>(options =>
            {
                options.UseOracle(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
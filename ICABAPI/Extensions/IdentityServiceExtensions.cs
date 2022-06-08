// using System.Text;
// using AutoMapper.Configuration;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.IdentityModel.Tokens;

// namespace ICABAPI.Extensions
// {
//     public static class IdentityServiceExtensions
//     {   
//         public static IServiceCollection AddIdentityService(this IServiceCollection services,IConfiguration config)
//         {
//              services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//             .AddJwtBearer(options =>{
//                 options.TokenValidationParameters = new TokenValidationParameters
//                 {
//                     ValidateIssuerSigningKey=true,
//                     IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config ["TokenKey"])),
//                     ValidateIssuer=false,
//                     ValidateAudience=false,
//                 };
//             });
//             return services;
//         }
        
//     }
// }
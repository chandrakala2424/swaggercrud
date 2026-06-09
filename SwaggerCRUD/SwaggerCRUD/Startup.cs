using System.Text;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Microsoft.IdentityModel.Tokens;
using Owin;

[assembly: OwinStartup(typeof(SwaggerCRUD.Startup))]

namespace SwaggerCRUD
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var key = Encoding.UTF8.GetBytes(
                "SwaggerCRUD_2026_SUPER_SECRET_KEY_1234567890");

            //app.UseJwtBearerAuthentication(
            //    new JwtBearerAuthenticationOptions
            //    {
            //        TokenValidationParameters =
            //            new TokenValidationParameters
            //            {
            //                ValidateIssuer = true,
            //                ValidateAudience = true,
            //                ValidateLifetime = true,
            //                ValidateIssuerSigningKey = true,

            //                ValidIssuer = "SwaggerCRUD",
            //                ValidAudience = "SwaggerCRUDUsers",

            //                IssuerSigningKey =
            //                    new SymmetricSecurityKey(key)
            //            }
            //    });

            app.UseJwtBearerAuthentication(
    new JwtBearerAuthenticationOptions
    {
        TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "SwaggerCRUD",
            ValidAudience = "SwaggerCRUDUsers"
        }
    });
        }
    }
}
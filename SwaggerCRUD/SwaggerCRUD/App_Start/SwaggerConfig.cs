using System.Web.Http;
using WebActivatorEx;
using SwaggerCRUD;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SwaggerCRUD
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "SwaggerCRUD");

                    // JWT Token Support
                    c.ApiKey("Bearer")
                        .Description("JWT Authorization header using the Bearer scheme. Example: Bearer {token}")
                        .Name("Authorization")
                        .In("header");
                })
                .EnableSwaggerUi(c =>
                {
                    c.EnableApiKeySupport("Authorization", "header");
                });
        }
    }
}
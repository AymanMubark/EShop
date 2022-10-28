using Microsoft.IdentityModel.Tokens;

namespace Catalog.API.Extensions
{
    public static class IdentityServiceExtension
    {

        public static IServiceCollection IdentityService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = configuration["AuthorityUrl"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                    options.RequireHttpsMetadata = false;
                });


            return services;
        }
    }
}

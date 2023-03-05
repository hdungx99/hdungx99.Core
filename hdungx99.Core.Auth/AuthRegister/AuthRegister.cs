
using Microsoft.Extensions.DependencyInjection;

namespace hdungx99.Core.Auth.AuthRegister
{
    public static class AuthRegister
    {
        public static void AddAuthServices(this IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
               .AddJwtBearer("Bearer", opt =>
               {
                   opt.RequireHttpsMetadata = false;
                   opt.Authority = "https://localhost:5005";
                   opt.Audience = "companyApi";
               });
        }
    }
}

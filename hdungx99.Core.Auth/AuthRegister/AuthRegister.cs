

using hdungx99.Core.Auth.AuthClientDI;
using hdungx99.Core.Auth.AuthConstant;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace hdungx99.Core.Auth.AuthRegister
{
    public static class AuthRegister
    {
        public static void AddAuthServices(this IServiceCollection services, AuthScheme authScheme)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthClient, AuthClient>();
            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = "Cookies";
                opt.DefaultChallengeScheme = "oidc";
            }).AddCookie("Cookies")
            .AddOpenIdConnect("oidc", opt =>
            {
                opt.SignInScheme = "Cookies";
                opt.Authority = "https://localhost:5005";
                opt.ClientId = authScheme.ClientId;
                opt.ResponseType = "code id_token";
                opt.SaveTokens = true;
                opt.ClientSecret = authScheme.ClientSecret;
            });
        }

        public static void AddAuthAPIServices(this IServiceCollection services, string audience)
        {
            services.AddAuthentication("Bearer")
               .AddJwtBearer("Bearer", opt =>
               {
                   opt.RequireHttpsMetadata = false;
                   opt.Authority = "https://localhost:5005";
                   opt.Audience = audience;
               });
        }
    }
}

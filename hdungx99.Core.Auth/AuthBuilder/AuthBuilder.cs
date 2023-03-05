using Microsoft.AspNetCore.Builder;

namespace hdungx99.Core.Auth.AuthBuilder
{
    public static class AuthBuilder
    {
        public static void AddAuthBuilder(this IApplicationBuilder builder)
        {
            builder.UseAuthentication();
            builder.UseAuthorization();
        }
    }
}

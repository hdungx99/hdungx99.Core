using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hdungx99.Core.EF.CoreEFRegister
{
    public static class CoreEFRegister
    {
        public static void AddCoreEFServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config["RedisConfig:Connection"];
                options.InstanceName = "hdungx99.Cache";
            });
        }
    }
}

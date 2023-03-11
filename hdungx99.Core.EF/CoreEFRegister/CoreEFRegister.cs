using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

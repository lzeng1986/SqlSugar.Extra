using System;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using SqlSugar.Extra;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SqlSugarExtentions
    {
        public static IServiceCollection UseSqlSugar<TConfig>(this IServiceCollection services) where TConfig : SqlSugarConfig
        {
            services.AddTransient<TConfig>();
            services.AddSingleton((Func<IServiceProvider, ISqlSugarHost<TConfig>>)delegate (IServiceProvider p)
            {
                TConfig requiredService = p.GetRequiredService<TConfig>();
                requiredService.ConfigConnection(p.GetRequiredService<IConfiguration>());
                SqlSugarConnectionFluent sqlSugarConnectionFluent = new SqlSugarConnectionFluent(requiredService.ConnectionConfig);
                requiredService.ConfigUsingFluent(sqlSugarConnectionFluent);
                return new SqlSugarHost<TConfig>(requiredService);
            });
            return services;
        }
    }
}

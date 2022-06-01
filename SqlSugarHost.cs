using System;
using System.Threading;

namespace SqlSugar
{
    internal class SqlSugarHost<T> : ISqlSugarHost<T>, IDisposable where T : SqlSugarConfig
    {
        private Lazy<SqlSugarScope> cache;

        private int n = 0;

        public SqlSugarScope Client => cache.Value;

        public SqlSugarHost(T config)
        {
            SqlSugarHost<T> sqlSugarHost = this;
            cache = new Lazy<SqlSugarScope>(() => new SqlSugarScope(config.ConnectionConfig, delegate (SqlSugarClient client)
            {
                if (Interlocked.CompareExchange(ref sqlSugarHost.n, 1, 0) == 0)
                {
                    config.ConfigSugarClientOnce(client);
                }
                config.ConfigSugarClient(client);
            }));
        }

        public void Dispose()
        {
            if (cache.IsValueCreated)
            {
                cache.Value.Dispose();
            }
        }
    }
}

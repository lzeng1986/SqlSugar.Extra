using Microsoft.Extensions.Configuration;
using SqlSugar.Extra;

namespace SqlSugar
{
    public abstract class SqlSugarConfig
    {
        private ConnectionConfig connectionConfig = new ConnectionConfig();

        public ConnectionConfig ConnectionConfig => connectionConfig;

        public void ConfigConnection(IConfiguration configuration)
        {
            ConfigConnection(connectionConfig, configuration);
        }

        protected abstract void ConfigConnection(ConnectionConfig sqlSugarConfig, IConfiguration configuration);

        public virtual void ConfigUsingFluent(SqlSugarConnectionFluent sqlSugarConnectionFluent)
        {
        }

        public virtual void ConfigSugarClientOnce(SqlSugarClient client)
        {
        }

        public virtual void ConfigSugarClient(SqlSugarClient client)
        {
        }
    }
}

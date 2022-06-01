using System;

namespace SqlSugar
{
    public interface ISqlSugarHost<TConnection> : IDisposable where TConnection : SqlSugarConfig
    {
        SqlSugarScope Client { get; }
    }
}

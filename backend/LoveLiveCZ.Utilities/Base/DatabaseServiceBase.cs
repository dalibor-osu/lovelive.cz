using System.Data;

namespace LoveLiveCZ.Utilities.Base;

public abstract class DatabaseServiceBase
{
    public Func<IDbConnection> ConnectionFactory { get; }
    
    protected DatabaseServiceBase(Func<IDbConnection> connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }
}
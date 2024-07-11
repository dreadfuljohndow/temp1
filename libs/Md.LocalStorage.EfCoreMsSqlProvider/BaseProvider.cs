namespace Md.LocalStorage.EfCoreMsSqlProvider;

public abstract class BaseProvider
{
    private readonly string _connectionString;
    internal BaseProvider(string connectionString)
    {
        _connectionString = connectionString;
    }

    private protected DbDataContext GetDbContext()
    {
        return new DbDataContext(_connectionString);
    }
}
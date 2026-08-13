namespace Vestora.DAL.Configuration;

public static class DatabaseConnectionFactory
{
    public static string Create(DatabaseConfig config)
    {
        return
            $"Host={config.Host};" +
            $"Port={config.Port};" +
            $"Database={config.Name};" +
            $"Username={config.Username};" +
            $"Password={config.Password};";
    }
}

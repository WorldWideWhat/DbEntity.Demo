using System.Data;
using Microsoft.Data.Sqlite;

namespace DbEntity.Demo.Managers;

/// <summary>
/// SQLite database connection
/// </summary>
public class SQLiteDbManager : IDbManager
{
    private readonly string _connectionString;

    public SQLiteDbManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> GetConnectionAsync()
    {
        var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }

    public IDbConnection GetConnection()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        return connection;
    }
}

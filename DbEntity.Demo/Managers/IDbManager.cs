using System.Data;

namespace DbEntity.Demo.Managers;

/// <summary>
/// Database interface
/// </summary>
public interface IDbManager
{
    /// <summary>
    /// Get database connection async
    /// </summary>
    /// <returns></returns>
    Task<IDbConnection> GetConnectionAsync();

    /// <summary>
    /// Get database connection
    /// </summary>
    /// <returns></returns>
    IDbConnection GetConnection();
}

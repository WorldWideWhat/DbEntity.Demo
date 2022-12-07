using DbEntity.Demo.Entities;
using Dapper;

namespace DbEntity.Demo.Managers;

/// <summary>
/// Code base for User object
/// </summary>
public class UserManager : User
{
    private readonly IDbManager _dbManager;
    public UserManager(IDbManager dbManager)
    {
        _dbManager = dbManager;
        Init();
    }

    private const string LIST_SQL = "SELECT Id, Name, Email FROM users;";
    private const string LOAD_SQL = "SELECT Id, Name, Email FROM users WHERE Id=@Id;";
    private const string INSERT_SQL = "INSERT INTO users (Id, Name, Email) VALUES (@Id, @Name, @Email);";
    private const string UPDATE_SQL = "UPDATE users SET Name=@Name, Email=@Email WHERE Id=@Id;";
    private const string DELETE_SQL = "DELETE FROM users WERE Id=@Id";
    private const string CREATE_SQL = "CREATE TABLE IF NOT EXISTS users (Id TEXT PRIMARY KEY, Name TEXT, Email TEXT);";
    
    /// <summary>
    /// Initialize.
    /// Create table if not exist
    /// </summary>
    private void Init()
    {
        try
        {
            using var connection = _dbManager.GetConnection();
            connection.Execute(CREATE_SQL);                
        }
        catch
        {
        }
    }

    public override User NewUser()
    {
        return new UserManager(_dbManager);
    }

    public override async Task<IEnumerable<User?>> ListAsync()
    {
        using var connection = await _dbManager.GetConnectionAsync();
        return await connection.QueryAsync<User?>(LIST_SQL);
    }

    public override IEnumerable<User?> List()
    {
        using var connection = _dbManager.GetConnection();
        return connection.Query<User?>(LIST_SQL);
    }

    public override async Task<User?> LoadAsync(Guid id)
    {
        using var connection = await _dbManager.GetConnectionAsync();
        return await connection.QueryFirstOrDefaultAsync<User?>(LOAD_SQL);
    }

    public override User? Load(Guid id)
    {
        var connection = _dbManager.GetConnection();
        return connection.QueryFirstOrDefault<User?>(LOAD_SQL, new {Id = id});
    }

    public override async Task<bool> InsertAsync()
    {
        var user = await LoadAsync(Id);
        if (user is not null) return false;
        using var connection = await _dbManager.GetConnectionAsync();
        return await connection.ExecuteAsync(INSERT_SQL, this) > 0;
    }

    public override bool Insert()
    {
        var user = Load(Id);
        if (user is not null) return false;
        using var connection = _dbManager.GetConnection();
        return connection.Execute(INSERT_SQL, this) > 0;
    }

    public override async Task<bool> UpdateAsync()
    {
        using var connection = await _dbManager.GetConnectionAsync();
        return await connection.ExecuteAsync(UPDATE_SQL, this) > 0;
    }


    public override bool Update()
    {
        using var connection = _dbManager.GetConnection();
        return connection.Execute(UPDATE_SQL, this) > 0;
    }

    public override async Task<bool> DeleteAsync()
    {
        using var connection = await _dbManager.GetConnectionAsync();
        return await connection.ExecuteAsync(DELETE_SQL, new { Id }) > 0;
    }

    public override bool Delete()
    {
        using var connection = _dbManager.GetConnection();
        return connection.Execute(DELETE_SQL, new { Id }) > 0;
    }
}

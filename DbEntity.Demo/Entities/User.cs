
namespace DbEntity.Demo.Entities;

/// <summary>
/// User entity
/// </summary>
[Annotation.ServiceInstance(typeof(Managers.UserManager))]
public abstract class User
{
    /// <summary>
    /// User identification
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();
    
    /// <summary>
    /// Full name
    /// </summary>
    /// <remarks>Nullable</remarks>
    public string ?Name { get; set; }
    /// <summary>
    /// Email address
    /// </summary>
    /// <remarks>Nullable</remarks>
    public string ?Email { get; set; }

    /// <summary>
    /// New user object
    /// </summary>
    /// <returns>User</returns>
    public abstract User NewUser();


    /// <summary>
    /// Get list of all users async
    /// </summary>
    /// <returns>IEnumerable<User></returns>
    public abstract Task<IEnumerable<User?>> ListAsync();
    /// <summary>
    /// Get list of all users
    /// </summary>
    /// <returns>IEnumerable<User></returns>    
    public abstract IEnumerable<User?> List();
    
    /// <summary>
    /// Load single user async
    /// </summary>
    /// <param name="id">User Id</param>
    /// <returns>User (or null if not found)</returns>
    public abstract Task<User?> LoadAsync(Guid id);

    /// <summary>
    /// Load single user
    /// </summary>
    /// <param name="id">User Id</param>
    /// <returns>User (or null if not found)</returns>
    public abstract User? Load(Guid id);
    
    /// <summary>
    /// Insert user into database async
    /// </summary>
    /// <returns>Success</returns>
    public abstract Task<bool> InsertAsync();
    /// <summary>
    /// Insert user into database async
    /// </summary>
    /// <returns>Success</returns>
    public abstract bool Insert();

    /// <summary>
    /// Update user record in database async
    /// </summary>
    /// <returns>Success</returns>
    public abstract Task<bool> UpdateAsync();
    /// <summary>
    /// Update user record in database
    /// </summary>
    /// <returns>Success</returns>
    public abstract bool Update();

    /// <summary>
    /// Delete user record in database async
    /// </summary>
    /// <returns>Success</returns>
    public abstract Task<bool> DeleteAsync();
    /// <summary>
    /// Delete user record in database
    /// </summary>
    /// <returns>Success</returns>
    public abstract bool Delete();
}

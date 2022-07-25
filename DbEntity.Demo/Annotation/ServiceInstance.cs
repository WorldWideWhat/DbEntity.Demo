namespace DbEntity.Demo.Annotation;

/// <summary>
/// Service instance
/// </summary>
public class ServiceInstance : Attribute
{
    /// <summary>
    /// Manager type
    /// </summary>
    private readonly Type _manager;

    public ServiceInstance(Type instance)
    {
        _manager = instance;
    }

    /// <summary>
    /// Manager property
    /// </summary>
    public Type Manager => _manager;
}

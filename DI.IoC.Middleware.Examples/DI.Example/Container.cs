namespace DI.Example;

public class Container : IContainer
{
    /// <summary>
    /// Key: object containing the type of the object to resolve and the name of the instance (if any);
    /// Value: delegate that creates the instance of the object
    /// </summary>
    private readonly Dictionary<MappingKey, Func<object>> _mappings;
 
 
    /// <summary>
    /// Creates a new instance of <see cref="Container"/>
    /// </summary>
    public Container()
    {
        _mappings = new Dictionary<MappingKey, Func<object>>();
    }
    
    public void Register<TFrom, TTo>(string instanceName = null) where TTo : TFrom
    {
        Register(typeof(TFrom), typeof(TTo), instanceName);
    }
    
    public void Register(Type from, Type to, string instanceName = null)
    {
        if (to == null)
        {
            throw new ArgumentNullException(nameof(to));
        }

        if(!from.IsAssignableFrom(to))
        {
            var errorMessage =
                $"Error trying to register the instance: '{from.FullName}' is not assignable from '{to.FullName}'";
 
            throw new InvalidOperationException(errorMessage);
        }
        
        Register(from, 
            () => Activator.CreateInstance(to), 
            instanceName);
    }
    
    public void Register<T>(Func<T> createInstanceDelegate, string instanceName = null)
    {
        if (createInstanceDelegate == null)
        {
            throw new ArgumentNullException(nameof(createInstanceDelegate));
        }

        var createInstance = createInstanceDelegate as Func<object> ;
        Register(typeof(T), createInstance, instanceName);
    }


    public void Register(Type type, Func<object> createInstanceDelegate, string instanceName = null)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (createInstanceDelegate == null)
        {
            throw new ArgumentNullException(nameof(createInstanceDelegate));
        }

        var key = new MappingKey(type, instanceName);
 
        if (_mappings.ContainsKey(key))
        {
            throw new InvalidOperationException($"The requested mapping already exists - {key.ToTraceString()}");
        }
 
        _mappings.Add(key, createInstanceDelegate);
    }

    public bool IsRegistered<T>(string instanceName = null)
    {
        return IsRegistered(typeof(T), instanceName);
    }

    public bool IsRegistered(Type type, string instanceName = null)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        var key = new MappingKey(type, instanceName);
        return _mappings.ContainsKey(key);
    }

    

    public object Resolve(Type type, string instanceName = null)
    {
        var key = new MappingKey(type, instanceName);

        return !_mappings.TryGetValue(key, out var createInstance)
            ? throw new InvalidOperationException($"Could not find mapping for type '{type.FullName}'")
            : createInstance();
    }

    public T Resolve<T>(string instanceName = null)
    {
        var instance = Resolve(typeof(T), instanceName);
 
        return (T) instance;
    }
}
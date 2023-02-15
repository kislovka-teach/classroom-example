namespace DI.Example;

public class NewContainer : IContainer
{
    private Dictionary<Type, Func<object>> _typeMapper;

    public NewContainer()
    {
        _typeMapper = new Dictionary<Type, Func<object>>();
    }
    public void Register(Type from, Type to, string instanceName = null)
    {
        Register(from, () => Activator.CreateInstance(to), instanceName);
    }

    public void Register<TFrom, TTo>(string instanceName = null) where TTo : TFrom
    {
        Register(typeof(TFrom), typeof(TTo), instanceName);
    }

    public void Register(Type type, Func<object> createInstanceDelegate, string instanceName = null)
    {
        _typeMapper.Add(type, createInstanceDelegate);
    }

    public void Register<T>(Func<T> createInstanceDelegate, string instanceName = null)
    {
        Register(typeof(T), createInstanceDelegate as Func<object>, instanceName);
    }

    public bool IsRegistered(Type type, string instanceName = null)
    {
        return _typeMapper.ContainsKey(type);
    }

    public bool IsRegistered<T>(string instanceName = null)
    {
        return IsRegistered(typeof(T));
    }

    public object Resolve(Type type, string instanceName = null)
    {
        return _typeMapper[type]();
    }

    public T Resolve<T>(string instanceName = null)
    {
        return (T)Resolve(typeof(T), instanceName);
    }
}
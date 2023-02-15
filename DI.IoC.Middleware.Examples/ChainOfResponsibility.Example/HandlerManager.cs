namespace ChainOfResponsibility.Example;

public class HandlerManager<T>
{
    private IHandler<T> _head;
    private IHandler<T> _current;

    public HandlerManager(IHandler<T> head)
    {
        _head = head;
        _current = head;
    }

    public void AddHandler(IHandler<T> handler)
    {
        _current.Successor = handler;
        _current = handler;
    }
    
    public void StartChain(T data)
    {
        _head.Handle(data);
    }
}
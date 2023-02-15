namespace ChainOfResponsibility.Example;

public interface IHandler<T>
{
    IHandler<T> Successor { get; set; } 
    void Handle(T data);
}
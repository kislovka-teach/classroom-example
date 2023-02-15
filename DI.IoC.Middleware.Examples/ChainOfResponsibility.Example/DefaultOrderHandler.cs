namespace ChainOfResponsibility.Example;

public class DefaultOrderHandler : IHandler<OrderData>
{
    public IHandler<OrderData> Successor { get; set; }
    public void Handle(OrderData data)
    {
        data.Id = Guid.NewGuid();
        
        Successor?.Handle(data);
    }
}
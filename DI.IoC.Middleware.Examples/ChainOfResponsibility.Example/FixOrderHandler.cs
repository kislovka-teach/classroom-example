namespace ChainOfResponsibility.Example;

public class FixOrderHandler : IHandler<OrderData>
{
    public IHandler<OrderData> Successor { get; set; }
    public void Handle(OrderData data)
    {
        data.DateToPay = DateOnly.FromDateTime(DateTime.Now);
        
        Successor?.Handle(data);
    }
}
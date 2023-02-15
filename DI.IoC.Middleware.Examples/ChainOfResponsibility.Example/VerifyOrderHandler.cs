namespace ChainOfResponsibility.Example;

public class VerifyOrderHandler: IHandler<OrderData>
{
    public IHandler<OrderData> Successor { get; set; }
    public void Handle(OrderData data)
    {
        if (data.Id == Guid.Empty || data.CustomerId == 0)
        {
            throw new ArgumentException("Идентификатор заявки пустой или не присовен продавец!", nameof(data));
        }

        if (data.Amount <= 0)
        {
            throw new ArgumentException(nameof(data.Amount)); 
        }
        
        if (data.ItemId <= 0)
        {
            throw new ArgumentException(nameof(data.ItemId)); 
        }
        
        Successor?.Handle(data);
    }
}
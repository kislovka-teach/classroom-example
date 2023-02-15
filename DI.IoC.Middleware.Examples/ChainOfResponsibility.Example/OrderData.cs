namespace ChainOfResponsibility.Example;

public class OrderData
{
    public Guid Id { get; set; }
    public DateOnly DateToPay { get; set; }
    public int ItemId { get; set; }
    public int Amount { get; set; }
    public int CustomerId { get; set; }
}

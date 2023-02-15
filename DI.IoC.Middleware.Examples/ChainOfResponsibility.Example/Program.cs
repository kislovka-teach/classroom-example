// See https://aka.ms/new-console-template for more information

using ChainOfResponsibility.Example;

var orderHandlerManager = new HandlerManager<OrderData>(new DefaultOrderHandler());
orderHandlerManager.AddHandler(new VerifyOrderHandler());
orderHandlerManager.AddHandler(new VerifyOrderHandler());

var order = new OrderData
{
    Amount = 100,
    CustomerId = new Random().Next(1,100),
    ItemId = new Random().Next(1,100)
};

orderHandlerManager.StartChain(order);
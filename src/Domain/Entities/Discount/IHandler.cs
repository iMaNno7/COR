namespace COR.Domain.Entities.Discount;

public interface IHandler
{
    Order Calc(Order order);
}

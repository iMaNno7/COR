namespace COR.Domain.Entities.Discount;

public class MoreThan500Handler : DiscountHandler
{
    public MoreThan500Handler(DiscountHandler handler) : base(15, handler) { }

    public override Order Calc(Order order)
    {
        if (order.Price >= 500)
        {
            order.DiscountPercent = Percent;
            return order;
        }
        else return _nextHandler.Calc(order);
    }

}

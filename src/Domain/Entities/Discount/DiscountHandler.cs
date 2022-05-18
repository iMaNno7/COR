namespace COR.Domain.Entities.Discount;

public abstract class DiscountHandler : IHandler
{
    protected readonly DiscountHandler _nextHandler;
    public byte Percent { get; private set; }
    protected DiscountHandler(byte percent, DiscountHandler discountHandler)
    {
        _nextHandler = discountHandler;
        Percent = percent;
    }
    public virtual Order Calc(Order order)
    {
        return order;
    }

}


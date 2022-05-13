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
    public virtual void Calc(ref Order order)
    {
        _nextHandler?.Calc(ref order);
    }

}


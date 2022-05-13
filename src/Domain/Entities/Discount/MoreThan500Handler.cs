namespace COR.Domain.Entities.Discount;

public class MoreThan500Handler : DiscountHandler
{
    public MoreThan500Handler(DiscountHandler handler) : base(15, handler) { }

    public override void Calc(ref Order order)
    {
        if (order.Price >= 500)
        {
            order.DiscountPercent = Percent;
        }
        else base.Calc(ref order);
    }

}

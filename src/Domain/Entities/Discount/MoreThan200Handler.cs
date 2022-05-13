namespace COR.Domain.Entities.Discount;

public class MoreThan200Handler : DiscountHandler
{

    public MoreThan200Handler(DiscountHandler handler) : base(5, handler) { }

    public override void Calc(ref Order order)
    {
        if (order.Price >= 200 && order.Price <= 499)
        {
            order.DiscountPercent = Percent;
        }
        else base.Calc(ref order);
    }
}

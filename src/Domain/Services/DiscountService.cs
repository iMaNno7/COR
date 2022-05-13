using COR.Domain.Entities.Discount;

namespace COR.Domain.Services;

public class DiscountService
{
    private readonly IOrderRepository _orderRepository;
    readonly DiscountHandler _discountHandler;
    public DiscountService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
        _discountHandler = new MoreThan200Handler(new MoreThan500Handler(null));
    }

    public Order CalcDiscount(int orderId)
    {
        var order = _orderRepository.GetOrder(orderId);

        _discountHandler.Calc(ref order);

        return order;
    }
}

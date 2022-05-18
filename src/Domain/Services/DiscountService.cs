using COR.Domain.Entities.Discount;
using COR.Domain.Exceptions;
using COR.Domain.Validation;

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

        order.CheckValidityOrder(checkOrder);

        return _discountHandler.Calc(order);

    }

    public void checkOrder(Order order)
    {
        if (order == null) throw new OrderNullException();
        else if (order.Price <= 0)        
            throw new InvalidPriceException(order.Price);        
    }
}

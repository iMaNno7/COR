namespace COR.Domain.Services;

public interface IOrderRepository
{
    Order GetOrder(int id);
}

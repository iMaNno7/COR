namespace COR.Domain.Entities.Discount;

public interface IHandler
{
    void Calc(ref Order order);
}

using COR.Domain.Entities;
using COR.Domain.Services;
using Moq;
using Xunit;

namespace COR.Domain.UnitTests.Discount;
public class CalcDiscountTests : TestBase
{

    [Theory]
    [InlineData(500)]
    [InlineData(300)]
    [InlineData(200)]
    public async Task ShouldCalcDiscount(decimal totalPrice)
    {
        var mock = new Mock<IOrderRepository>();
        mock.Setup(s => s.GetOrder(It.IsAny<int>()))
            .Returns(new Order
            {
                Id = 1,
                ShippedDate = DateTime.Now,
                Price = totalPrice,
                TrackingCode = "123456"
            });
        var service = new DiscountService(mock.Object);

        var order = service.CalcDiscount(12);
        //Assert
        Assert.Equal(order.TotalDiscountedPrice, totalPrice * order.DiscountPercent / 100);
    }

}

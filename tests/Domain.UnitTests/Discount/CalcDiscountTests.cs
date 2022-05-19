using COR.Domain.Entities;
using COR.Domain.Exceptions;
using COR.Domain.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace COR.Domain.UnitTests.Discount;
public class CalcDiscountTests : TestBase
{
    public CalcDiscountTests()
    {
            
    }
    [Fact]    
    public async Task ShouldThrowOrderNullException()
    {

        var mock = new Mock<IOrderRepository>();
        mock.Setup(s => s.GetOrder(It.IsAny<int>()))
            .Returns(new Order());
        var service = new DiscountService(mock.Object);

        FluentActions.Invoking(() => service.CalcDiscount(10))
                  .Should().Throw<InvalidPriceException>();
    }

    [Theory]
    [InlineData(500)]
    [InlineData(300)]
    [InlineData(200)]
    public async Task ShouldCalcDiscount(decimal totalPrice)
    {
        //arrange
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
        // act
        var order = service.CalcDiscount(12);
        //Assert
        Assert.Equal(order.TotalDiscountedPrice, totalPrice * order.DiscountPercent / 100);
    }

}

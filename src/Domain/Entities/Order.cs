namespace COR.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public string TrackingCode { get; set; }
    public DateTime ShippedDate { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice
    {
        get =>
            Price - TotalDiscountedPrice ?? 0;
    }
    public byte DiscountPercent { get; set; }
    public decimal? TotalDiscountedPrice { get => (Price * DiscountPercent) / 100; }
}
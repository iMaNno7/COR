namespace COR.Domain.Exceptions
{
    public class InvalidPriceException: ArgumentException
    {
        public InvalidPriceException(decimal price)
            : base($"price : \"{price}\" is invalid.")
        {
        }
    }
}

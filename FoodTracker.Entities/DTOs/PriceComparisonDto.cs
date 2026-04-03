namespace FoodTracker.Entities.DTOs;

public class PriceComparisonDto
{
    public string PlatformName { get; set; } = string.Empty;
    public string ProductName { get; set; }  = string.Empty;
    public decimal Price { get; set; }
    public decimal DiscountedPrice { get; set; }
    public string CheapestPlatform { get; set; } = string.Empty;
}
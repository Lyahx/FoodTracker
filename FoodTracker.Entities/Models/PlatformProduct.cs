namespace FoodTracker.Entities.Models;

public class PlatformProduct
{
    public int Id { get; set; }
    public Platform Platform { get; set; } = new Platform();
    public int PlatformId { get; set; }
    public RestaurantProduct RestaurantProduct { get; set; } = new RestaurantProduct();
    public int RestaurantProductId { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountRate { get; set; }
}
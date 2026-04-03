namespace FoodTracker.Entities.DTOs.CreateDtos;

public class CreatePlatformProductDto
{
    public int PlatformId { get; set; }
    public int RestaurantProductId { get; set; }
    public decimal OriginalPrize { get; set; }
    public decimal DiscountRate { get; set; }
}
namespace FoodTracker.Entities.DTOs.CreateDtos;

public class CreateCampaignDto
{
    public int PlatformId { get; set; }
    public int RestaurantId { get; set; }
    public decimal DiscountRate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Name { get; set; } = string.Empty;
}
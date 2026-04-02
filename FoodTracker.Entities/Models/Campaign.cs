namespace FoodTracker.Entities.Models;

public class Campaign
{
    public int Id { get; set; }
    public Platform Platform { get; set; } = new Platform();
    public int PlatformId { get; set; }
    public Restaurant Restaurant { get; set; } = new Restaurant();
    public int RestaurantId { get; set; }
    public decimal DiscountRate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
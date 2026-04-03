namespace FoodTracker.Entities.DTOs;

public class CampaignDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<string> Products { get; set; } = new List<string>();
    public string Platform { get; set; } = string.Empty;
    public decimal DiscountRate { get; set; }
}
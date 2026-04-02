namespace FoodTracker.Entities.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<RestaurantProduct> RestaurantProducts { get; set; } = new List<RestaurantProduct>();
}
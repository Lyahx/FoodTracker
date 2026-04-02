namespace FoodTracker.Entities.Models;

public class RestaurantProduct
{
    public int Id { get; set; }
    public Restaurant Restaurant { get; set; } = new Restaurant();
    public int RestaurantId { get; set; }
    public Product Product { get; set; } = new Product();
    public int ProductId { get; set; }
}
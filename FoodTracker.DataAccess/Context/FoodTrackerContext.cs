using FoodTracker.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTracker.DataAccess.Context;

public class FoodTrackerContext:DbContext
{
    public FoodTrackerContext(DbContextOptions<FoodTrackerContext> options) : base(options)
    {
    }

    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<PlatformProduct> PlatformProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<RestaurantProduct> RestaurantProducts { get; set; }
    public DbSet<User> Users { get; set; }
}
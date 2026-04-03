using FoodTracker.DataAccess.Abstracts;
using FoodTracker.DataAccess.Context;
using FoodTracker.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTracker.DataAccess.Concretes;

public class PlatformProductRepository : Repository<PlatformProduct>, IPlatformProductRepository
{
    private readonly FoodTrackerContext _context;

    public PlatformProductRepository(FoodTrackerContext context) : base(context)
    {
        _context = context;
    }
    public Task<List<PlatformProduct>> GetAllPlatformPricesAsync(int productId)
    {
        return _context.PlatformProducts.Include(x =>x.RestaurantProduct)
            .Where(x => x.RestaurantProduct.ProductId == productId).ToListAsync();
    }
}
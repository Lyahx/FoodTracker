using FoodTracker.DataAccess.Context;
using FoodTracker.Entities.Models;

namespace FoodTracker.DataAccess.Abstracts;

public interface IPlatformProductRepository : IRepository<PlatformProduct>
{
    public Task<List<PlatformProduct>> GetAllPlatformPricesAsync(int productId);
}
using FoodTracker.Entities.DTOs;

namespace FoodTracker.Business.Abstracts;

public interface IPlatformProductService
{
    Task<List<PriceComparisonDto>> CheapestPlatformsList(int productId);
}
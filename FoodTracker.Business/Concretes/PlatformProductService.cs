using FoodTracker.Business.Abstracts;
using FoodTracker.DataAccess.Abstracts;
using FoodTracker.DataAccess.Concretes;
using FoodTracker.DataAccess.Context;
using FoodTracker.Entities.DTOs;
using FoodTracker.Entities.Models;

namespace FoodTracker.Business.Concretes;

public class PlatformProductService : IPlatformProductService
{
    private readonly IPlatformProductRepository _platformProductRepository;
    private readonly ICampaignRepository _campaignRepository;

    public PlatformProductService(IPlatformProductRepository platformProductRepository,ICampaignRepository campaignRepository)
    {
        _platformProductRepository = platformProductRepository;
        _campaignRepository = campaignRepository;
    }

    public async Task<List<PriceComparisonDto>> CheapestPlatformsList(int productId)
    {
        var product = await _platformProductRepository.GetAllPlatformPricesAsync(productId);
        var result = new List<PriceComparisonDto>();
        foreach (var platformProduct in product)
        {
            var discountedPrice = platformProduct.OriginalPrice * (1 - platformProduct.DiscountRate);
            var activeCampaings =
                await _campaignRepository.GetActiveCampaignsAsync(platformProduct.RestaurantProduct.RestaurantId);
            if (activeCampaings.Any())
            {
                foreach (var activeCampaing in activeCampaings)
                {
                    discountedPrice = discountedPrice * (1 - activeCampaing.DiscountRate);
                }
            }

            var dto = new PriceComparisonDto
            {
                Price = platformProduct.OriginalPrice,
                PlatformName = platformProduct.Platform.Name,
                DiscountedPrice = discountedPrice,
                ProductName = platformProduct.RestaurantProduct.Product.Name
            };
            result.Add(dto);
        }
        var cheapest = result.MinBy(x => x.DiscountedPrice);
        result.ForEach(x => x.CheapestPlatform = cheapest.PlatformName);
        return result;
    }
}
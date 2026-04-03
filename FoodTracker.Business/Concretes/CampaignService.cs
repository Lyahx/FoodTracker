using FoodTracker.Business.Abstracts;
using FoodTracker.DataAccess.Abstracts;
using FoodTracker.Entities.DTOs;

namespace FoodTracker.Business.Concretes;

public class CampaignService : ICampaignService
{
    private readonly ICampaignRepository _repository;

    public CampaignService(ICampaignRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CampaignDto>> GetActiveCampaignsAsync(int restourantId)
    {
        var actives = await _repository.GetActiveCampaignsAsync(restourantId);
        var activeones = new List<CampaignDto>();
        foreach (var campaign in actives)
        {
            var dto = new CampaignDto
            {
                EndDate = campaign.EndDate,
                StartDate = campaign.StartDate,
                Platform = campaign.Platform.Name,
                Name = campaign.Name,
                Products = campaign.Restaurant.RestaurantProducts.Select(x =>x.Product.Name).ToList()
            };
            activeones.Add(dto);
        }

        return activeones;
    }

    public async Task<List<CampaignDto>> GetAllActiveCampaignsAsync()
    {
        var allActives = await _repository.GetAllActiveCampaignsAsync();
        var allActiveones = new List<CampaignDto>();
        foreach (var allActiveone in allActives)
        {
            var dto = new CampaignDto
            {
                EndDate = allActiveone.EndDate,
                StartDate = allActiveone.StartDate,
                Name = allActiveone.Name,
                Platform = allActiveone.Platform.Name,
                Products = allActiveone.Restaurant.RestaurantProducts.Select(x=>x.Product.Name).ToList()
            };
            allActiveones.Add(dto);
        }

        return allActiveones;
    }
}
using FoodTracker.Entities.DTOs;

namespace FoodTracker.Business.Abstracts;

public interface ICampaignService
{
    Task<List<CampaignDto>> GetActiveCampaignsAsync(int restourantId);
    Task<List<CampaignDto>> GetAllActiveCampaignsAsync();
}
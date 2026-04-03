using FoodTracker.Entities.Models;

namespace FoodTracker.DataAccess.Abstracts;

public interface ICampaignRepository : IRepository<Campaign>
{
    public Task<List<Campaign>> GetActiveCampaignsAsync(int restourantId);
    public Task<List<Campaign>> GetAllActiveCampaignsAsync();
}
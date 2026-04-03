using FoodTracker.DataAccess.Abstracts;
using FoodTracker.DataAccess.Context;
using FoodTracker.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTracker.DataAccess.Concretes;

public class CampaignRepository : Repository<Campaign>, ICampaignRepository
{
    private readonly FoodTrackerContext _context;

    public CampaignRepository(FoodTrackerContext context) :base(context)
    {
        _context = context;
    }

    public Task<List<Campaign>> GetActiveCampaignsAsync(int restourantId)
    {
        return _context.Campaigns.Include(x => x.Restaurant)
            .Where(x => x.RestaurantId == restourantId && DateTime.Now >= x.StartDate && DateTime.Now <= x.EndDate).ToListAsync();
    }

    public Task<List<Campaign>> GetAllActiveCampaignsAsync()
    {
        return _context.Campaigns.Where(x => DateTime.Now >= x.StartDate && DateTime.Now <= x.EndDate).ToListAsync();
    }
}
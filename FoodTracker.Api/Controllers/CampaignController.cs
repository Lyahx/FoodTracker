using FoodTracker.Business.Abstracts;
using FoodTracker.Business.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class CampaignController:ControllerBase
{
    private readonly ICampaignService _service;

    public CampaignController(ICampaignService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllActiveCampaigns()
    {
        var allActiveCampaigns = await _service.GetAllActiveCampaignsAsync();
        return Ok(allActiveCampaigns);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActiveCampaigns(int id)
    {
        var activeCampaigns = await _service.GetActiveCampaignsAsync(id);
        return Ok(activeCampaigns);
    }
}
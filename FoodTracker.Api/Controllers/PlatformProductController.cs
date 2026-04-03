using FoodTracker.Business.Abstracts;
using FoodTracker.Business.Concretes;
using FoodTracker.DataAccess.Abstracts;
using FoodTracker.DataAccess.Concretes;
using FoodTracker.Entities.DTOs.CreateDtos;
using FoodTracker.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PlatformProductController:ControllerBase 
{
    private readonly IPlatformProductService _service;
    private readonly IRepository<PlatformProduct> _repository;

    public PlatformProductController(IPlatformProductService service,IRepository<PlatformProduct> repository)
    {
        _service = service;
        _repository = repository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> CheapestPlatformsList(int id)
    {
       var list = await _service.CheapestPlatformsList(id);
        return Ok(list);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreatePlatformProductDto dto)
    {
        var entity = new PlatformProduct
        {
            PlatformId = dto.PlatformId,
            RestaurantProductId = dto.RestaurantProductId,
            OriginalPrice = dto.OriginalPrize,
            DiscountRate = dto.DiscountRate
        };
        await _repository.AddAsync(entity);
        return Ok(entity);
    }
    
}
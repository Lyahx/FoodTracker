using FoodTracker.DataAccess.Abstracts;
using FoodTracker.Entities.DTOs.CreateDtos;
using FoodTracker.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class RestaurantProductController : ControllerBase
{
    private readonly IRepository<RestaurantProduct> _repository;

    public RestaurantProductController(IRepository<RestaurantProduct> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _repository.GetAllAsync();
        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRestaurantProductDto dto)
    {
        var entity = new RestaurantProduct
        {
            RestaurantId = dto.RestaurantId,
            ProductId = dto.ProductId
        };
        await _repository.AddAsync(entity);
        return Ok(entity);
    }
}
using FoodTracker.DataAccess.Abstracts;
using FoodTracker.Entities.DTOs.CreateDtos;
using FoodTracker.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class RestaurantController:ControllerBase
{
    private readonly IRepository<Restaurant> _repository;

    public RestaurantController(IRepository<Restaurant> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRestaurants()
    {
        var restaurants = await _repository.GetAllAsync();
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurantById(int id)
    {
        var restaurant = await _repository.GetByIdAsync(id);
        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantDto dto)
    {
        var restaurant = new Restaurant { Name = dto.Name };
        await _repository.AddAsync(restaurant);
        return Ok(restaurant);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRestaurant(Restaurant restaurant)
    {
        await _repository.UpdateAsync(restaurant);
        return Ok(restaurant);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant(int id)
    {
        var restaurant = await _repository.GetByIdAsync(id);
        if (restaurant == null)
            return NotFound();
        await _repository.DeleteAsync(id);
        return Ok();
    }
}
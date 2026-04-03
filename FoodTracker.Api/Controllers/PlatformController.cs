using FoodTracker.DataAccess.Abstracts;
using FoodTracker.Entities.DTOs.CreateDtos;
using FoodTracker.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class PlatformController:ControllerBase
{
    private readonly IRepository<Platform> _repository;

    public PlatformController(IRepository<Platform> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlatforms()
    {
        var platforms = await _repository.GetAllAsync();
        return Ok(platforms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlatformById(int id)
    {
        var platform = await _repository.GetByIdAsync(id);
        return Ok(platform);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlatform(CreatePlatformDto dto)
    {
        var platform = new Platform { Name = dto.Name };
        await _repository.AddAsync(platform);
        return Ok(platform);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePlatform(Platform platform)
    {
        await _repository.UpdateAsync(platform);
        return Ok(platform);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlatform(int id)
    {
        var platform = await _repository.GetByIdAsync(id);
        if (platform == null)
            return NotFound();
        await _repository.DeleteAsync(id);
        return Ok();
    }
}
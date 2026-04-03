using FoodTracker.Entities.DTOs.Auth;

namespace FoodTracker.Business.Abstracts;

public interface IUserService
{
    Task RegisterAsync(RegisterDto dto);
    Task<string> LoginAsync(LoginDto dto);
}
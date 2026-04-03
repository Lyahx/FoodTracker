using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FoodTracker.Business.Abstracts;
using FoodTracker.DataAccess.Context;
using FoodTracker.Entities.DTOs.Auth;
using FoodTracker.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FoodTracker.Business.Concretes;

public class UserService : IUserService
{
    private readonly FoodTrackerContext _context;
    private readonly IConfiguration _configuration;

    public UserService(FoodTrackerContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    public async Task RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
        if (existingUser != null)
        {
            throw new Exception("Bu email zaten kayıtlı");
        }

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            CreatedAt = DateTime.UtcNow,
            Role = dto.Role ?? "User"
        };
        
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
        if (user == null)
            throw new Exception("Email yada şifre hatalı");
        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            throw new Exception("Girdiğiniz şifre yada email hatalı");
        return GenerateToken(user);
    }
    private string GenerateToken(User user)
    {
        var secretKey = _configuration["JwtSettings:SecretKey"];
        var issuer = _configuration["JwtSettings:Issuer"];
        var audience = _configuration["JwtSettings:Audience"];
        var expirationDays = int.Parse(_configuration["JwtSettings:ExpirationDays"]);
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim(ClaimTypes.Role,user.Role),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Username)
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(expirationDays),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
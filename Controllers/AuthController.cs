using FirstAPI.Dto;
using FirstAPI.Dtos;
using FirstAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public ActionResult<ApiResponse<string>> Login([FromBody] LoginDto dto)
    {
        if(dto.Username != "admin" || dto.Password != "password123")
        {
            return Unauthorized(ApiResponse<string>.ErrorResponse("Invalid username or password."));
        }

        var token = _tokenService.GenerateToken(dto.Username);
        return Ok(ApiResponse<string>.SuccessResponse(token, "Login successful."));
    }
}
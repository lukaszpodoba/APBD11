using JWT.RequestModel;
using JWT.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthServices authServices) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
    { 
        var response = await authServices.LoginAsync(loginRequestModel);
        if (response != null)
        {
            return Ok(response);
        }
        return Unauthorized("Wrong username or password");
    }
    
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken(RefreshTokenRequestModel refreshTokenRequestModel)
    {
        var response = await authServices.RefreshTokenAsync(refreshTokenRequestModel.RefreshToken);
        if (response != null)
        {
            return Ok(response);
        }
        return Unauthorized("Invalid token");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestModel registerRequestModel)
    {
        var result = await authServices.RegisterAsync(registerRequestModel);
        if (result)
        {
            return Ok("User registered successfully");
        }
        return BadRequest("Username already exists");
    }
}
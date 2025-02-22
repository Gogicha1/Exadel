using Exadel.Requests;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

[Route("api/auth")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly JwtService _jwtService;

    public LoginController(JwtService jwtTokenService)
    {
        _jwtService = jwtTokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Exadel.Requests.LoginRequest request)
    {
        if (request.Username == "admin" && request.Password == "admin")
        {
            var token = _jwtService.GenerateJwtToken(request.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}

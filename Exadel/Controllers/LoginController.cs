//using Exadel.Requests;
//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Mvc;

//[Route("api/auth")]
//[ApiController]
//public class LoginController : ControllerBase
//{
//    private readonly JwtService _jwtTokenService;

//    public LoginController(JwtService jwtTokenService)
//    {
//        _jwtTokenService = jwtTokenService;
//    }

//    [HttpPost("login")]
//    public IActionResult Login([FromBody] Exadel.Requests.LoginRequest request)
//    {
//        if (request.Username == "admin" && request.Password == "password")
//        {
//            var token = _jwtTokenService.GenerateToken(request.Username);
//            return Ok(new { Token = token });
//        }

//        return Unauthorized();
//    }
//}

using DesktopDiplomProject.ServerASP.Features.Authentification;
using DiplomDataLibrary.Authentification.Requests;
using DiplomDataLibrary.Authentification.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesktopDiplomProject.ServerASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthentificationController : Controller
    {
        private const string STRINGFORIP = "X-Forwarded-For";
        private readonly IAuthentificationService _service;
        private readonly ILogger<AuthentificationController> _logger;

        public AuthentificationController(IAuthentificationService service, ILogger<AuthentificationController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var ipAddress = GetIPAddress();
            var response = await _service.LoginUser(request, ipAddress);
            if (response == null) return StatusCode(500, new {error = "Login failed"});
            return ReturnAuthentificationAction(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _service.RegisterUser(request);
            if (response == null) return StatusCode(500, new { error = "Registration failed" });
            if (response.Status.Equals(RegistrationStatus.OK))
                return Ok(response);
            switch (response.Status)
            {
                case RegistrationStatus.UsernameIsUsed:
                    return Conflict(new { error = "Username already registered" });
                case RegistrationStatus.EmailIsUsed:
                    return Conflict(new { error = "Email already registered" });
                case RegistrationStatus.AnotherError:
                    return Conflict(new { error = "Another error" });
                default:
                    return StatusCode(500, new { error = "Unknow error" });
            }
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshRequest request)
        {
            if (request == null)
                return BadRequest(new { error = "Refresh request is required" });
            var ipAddress = GetIPAddress();
            var response = await _service.RefreshToken(request, ipAddress);
            if (response == null) return StatusCode(500, new { error = "Refresh failed" });
            return ReturnAuthentificationAction(response);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            if (request == null)
                return BadRequest(new { error = "Logout requrest is required" });
            var ipAddress = GetIPAddress();
            await _service.Logout(request, ipAddress);
            return Ok(new { message = "Logged out successfully" });
        }

        [Authorize]
        [HttpPost("logout-all")]
        public async Task<IActionResult> LogoutAllDevices([FromBody] LogoutAllDevicesRequest request)
        {
            if (request == null) return BadRequest(new { error = "LogoutAllDevicesRequest is required" });
            var ipAddress = GetIPAddress();
            await _service.LogoutAllDevices(request, ipAddress);
            return Ok(new { message = "Logged out from all devices successfully" });
        }

        public IActionResult Index()
        {
            return View();
        }

        private string GetIPAddress()
        {
            if (Request.Headers.ContainsKey(STRINGFORIP))
                return Request.Headers[STRINGFORIP].ToString();
            return HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        }

        private IActionResult ReturnAuthentificationAction(AuthentificationResponse response)
        {
            if (response.Status.Equals(AuthentificationStatus.OK))
                return Ok(response);
            switch (response?.Status)
            {
                case AuthentificationStatus.UserNotFound:
                    return Unauthorized(new { error = "User not found" });
                case AuthentificationStatus.WarningPassword:
                    return Unauthorized(new { error = "Password is wrong" });
                case AuthentificationStatus.AccessTokenError:
                    return BadRequest(new { error = "The Access token can't be created" });
                case AuthentificationStatus.RefreshTokenError:
                    return BadRequest(new { error = "The Refresh token can't be created" });
                case AuthentificationStatus.AnotherError:
                    return BadRequest(new { error = "Another error" });
                default:
                    return StatusCode(500, new { error = "Authentification failed" });

            }
        }
    }
}

using GyF_Api_Challenge.Api.Models.Auth;
using GyF_Api_Challenge.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GyF_Api_Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly AuthManager _authManager;
        public AuthController(ILogger<AuthController> logger, AuthManager authManager)
        {
            _logger = logger;
            _authManager = authManager;
        }

        [HttpPost]
        public async Task<IActionResult> Token(LoginModel model)
        {
            try
            {
                var isValid = await _authManager.ValidateAsync(model.UserName, model.Password);

                if (!isValid)
                {
                    return Problem("Usuario y/o contraseña incorrecta");
                }

                var token = _authManager.CreateToken();

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Token));
                return Problem("Un problem ha ocurrido", statusCode: 500);
            }
        }
    }
}

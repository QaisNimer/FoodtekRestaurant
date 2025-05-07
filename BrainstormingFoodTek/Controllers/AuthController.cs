using BrainstormingFoodTek.DTOs.Registration.Request;
using BrainstormingFoodTek.Interfaces;
using BrainstormingFoodTek.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BrainstormingFoodTek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ItemsService _itemService;
        private readonly  AuthenticationService _authenticationService;
        private readonly IAuthentication _IAuthentication;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(ItemsService itemService,AuthenticationService authenticationService,
            IAuthentication IAuthentication, ITokenProvider tokenProvider)
        {
            _itemService = itemService;
            _authenticationService = authenticationService;
            _IAuthentication = IAuthentication;
            _tokenProvider = tokenProvider;
        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInRequestDTO input)
        {
            try
            {
                var token = await _authenticationService.SignIn(input);
                if (string.IsNullOrEmpty(token) || token == "User not found")
                    return Unauthorized(new { message = "Invalid credentials." });

                return Ok(new { token = token });
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(RegistrationRequestDTO input) {

            try
            {
                var token= await _authenticationService.SignUp(input);
                return Ok(token);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequestDTO input)
        {
            try
            {
                await _authenticationService.ResetPassword(input);
                return Ok(200);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("verification")]
        public async Task<IActionResult> Verification(VerificationRequestDTO input)
        {
            try
            {
                var result = await _authenticationService.Verification(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}


using chatbox.data.models;
using chatbox.data.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chatbox.web.Controllers
{
    [ApiController]
    public class AuthController : ApplicationBaseController
    {
        private readonly IUserService _userService;
        private readonly ITokenGeneratorService _tokenService;

        public AuthController(IUserService userService, ITokenGeneratorService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLogin user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var valid = await _userService.IsValidUserAccountAsync(user);
            if (valid)
            {
                var userInfo = await _userService.GetUserInfoAsync(user.Username);
                var token = _tokenService.GetToken(userInfo);

                return Ok(new
                {
                    token,
                });
            }

            return BadRequest(new
            {
                statusCode = "invalid_user_account"
            });
        }
    }

}

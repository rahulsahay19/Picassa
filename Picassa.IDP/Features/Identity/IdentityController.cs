namespace Picassa.IDP.Features.Identity
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.AspNetCore.Http;
    using Models;
    using Controllers;
    using Data.Models;


    public class IdentityController : ApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IIdentityService _identityService;
        private readonly ApplicationSettings _appSettings;

        public IdentityController(UserManager<User> userManager, IOptions<ApplicationSettings> appSettings, IIdentityService identityService)
        {
            _userManager = userManager;
            _identityService = identityService;
            _appSettings = appSettings.Value;
        }
        /// <summary>
        /// Method to register a user. It takes username, password and email.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(Register))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email

            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
        /// <summary>
        /// Method to login a user. It takes username and password.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(Login))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            var encryptedSecurityToken = _identityService.CreateJWTToken(user.Id, user.UserName, _appSettings.Secret);

            return new LoginResponseModel
            {
                Token = encryptedSecurityToken
            };
        }
    }
}

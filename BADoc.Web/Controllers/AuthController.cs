using System;
using System.Threading.Tasks;
using BADoc.UseCases.Interfaces;
using BADoc.UseCases.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BADoc.Web.DTO;
using BADoc.Web.Utils;

namespace BADoc.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtGenerator _jwtGeneraror;
        public AuthController(IUserService userService, IJwtGenerator jwtGeneraror)
        {
            _userService = userService;
            _jwtGeneraror = jwtGeneraror;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO userDTO)
        {
            try
            {
                await _userService.Create(userDTO);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ErrorDTO.Create(ex.Message));
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CheckCredentialsDTO credentialsDTO)
        {
            try
            {
                GetUserDTO user = await _userService.CheckCredentials(credentialsDTO);
                return Ok(new UserTokenDTO()
                {
                    Email = user.Email,
                    AccessToken = _jwtGeneraror.CreateToken(user)
                });
            }
            catch (System.Exception ex)
            {
                return BadRequest(ErrorDTO.Create(ex.Message));
            }

        }

    }
}

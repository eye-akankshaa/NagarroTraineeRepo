using BookBorrowingSharedLayer.Models;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// used to login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var existing_user = await userService.GetUserByEmailAsync(user.Username);
            if (existing_user == null)
            {
                return NotFound(new { Message = "User Not Found" });
            }
            if (existing_user.Password != user.Password)
            {
                return BadRequest(new { Message = "Password is Incorrect" });
            }

            user.Token = CreateJwt(existing_user);

            return Ok(new
            {
                
                Token = user.Token,
                Message = "Login Success"
            });

        }

        private string CreateJwt(UserModel user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("MiniAssignment...");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim (ClaimTypes.Name, user.Name),
             
                new Claim(ClaimTypes.Email, user.Username),
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials,
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);// to send token as string
        }


        /// <summary>
        /// Used to get details  of currently loggedin user through email
        /// </summary>
        ///  <param name="email"></param>
        /// <returns></returns>


        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> CurrentUser(string email)
        {
            try
            {
                var currentUser = await userService.CurrentUser(email);
                if (currentUser == null)
                {
                    return NotFound();
                }
                return Ok(currentUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }

        /// <summary>
        /// Used to get details  of any user by id
        /// </summary>
        /// <param name="id"></param> 
        /// <returns></returns>

        [Authorize]
        [HttpGet("GetUserbyId")]
        public async Task<IActionResult> GetUserbyId(int id)
        {
            try
            {
                var currentUser = await userService.GetUserbyId(id);
                if (currentUser == null)
                {
                    return NotFound();
                }
                return Ok(currentUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }

        /// <summary>
        /// Update details of user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedUser"></param>
        /// <returns></returns>


        [Authorize]
       
        [HttpPut("UpdateUser/{id}")]

        public async Task<IActionResult> UpdateUser([FromRoute] int id, UserModel updatedUser)
        {
            try
            {
                var user= await userService.GetUserbyId(id);
                if (user == null)
                {
                    return NotFound();
                }
                
                user.Name = updatedUser.Name;
               user.Username = updatedUser.Username;
               user.Password = updatedUser.Password;
                user.Tokens_Available = updatedUser.Tokens_Available;
           
                await userService.UpdateUserAsync(user);
                return Ok(user);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

    }
}

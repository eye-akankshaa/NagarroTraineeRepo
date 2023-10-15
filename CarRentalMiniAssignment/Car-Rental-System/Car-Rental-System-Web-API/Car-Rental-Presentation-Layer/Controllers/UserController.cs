
using Car_Rental_Business_Layer.IRepository;
using Car_Rental_Business_Layer.Repository;
using Car_Rental_Data_Layer.Data;
using Car_Rental_Data_Layer.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public UserController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        [HttpPost("LoginUser")]
        public IActionResult Login([FromBody] LoginEntity userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            var userExist = _userRepository.Login(userObj);
            if (userExist == null)
            {
               
                return Ok("No such user exist in database!");
            }
            else if (userExist.Password == userObj.Password)
            {
                return Ok(userExist);
            }
         
            else return Ok( "Password incorrect!" );




        }


        [HttpGet("CurrentUser")]
        public IActionResult  CurrentUser(string email)
        {
            var currentUser = _userRepository.CurrentUser(email);
            return Ok(currentUser);
        }

       



    }












}

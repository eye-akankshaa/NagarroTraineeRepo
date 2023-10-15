using Grocery_App_Data_Access_Layer.Data;
using BusinessLogicLayer.Respositories;
using Grocery_App_Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grocery_App_Presentation_Layer.Controllers
{


     [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class RegisterController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IRegisterRepository _registerRepository;

        public RegisterController(IConfiguration configuration, IRegisterRepository registerRepository)
        {
            _configuration = configuration;
            _registerRepository = registerRepository;

        }
        [HttpPost("CreateRegister")]
        public IActionResult Create(RegisterEntity user)
        {
            string result = _registerRepository.Create(user);
            return Ok(result);
        }

        [HttpPost("LoginUser")]
        public IActionResult Login(LoginEntity user)
        {
            var userAvailable = _registerRepository.Login(user);
            if (userAvailable != null)
            {
                return Ok(userAvailable);
            }
            return Ok("Failure");
        }

        [HttpGet("CurrentUser")]
        public async Task<IActionResult> FindCurrentUser(string email)
        {
            var currentUser = await _registerRepository.FindCurrentUser(email);
            return Ok(currentUser);
        }
    }















}

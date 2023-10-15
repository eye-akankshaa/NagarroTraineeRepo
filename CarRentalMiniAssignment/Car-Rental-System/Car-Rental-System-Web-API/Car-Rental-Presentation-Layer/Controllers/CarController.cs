using Car_Rental_Business_Layer.IRepository;
using Car_Rental_Data_Layer.Data;
using Car_Rental_Data_Layer.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class CarController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ICarRepository _carRepository;
        private readonly CarRentalContext _context;

        public CarController(IConfiguration configuration, ICarRepository carRepository)
        {
            _configuration = configuration;
            _carRepository = carRepository;
        }

        [HttpGet("GetCars")]
        public IActionResult GetCars()
        {
            var products = _carRepository.GetAllCars();
            return Ok(products);
        }

        [HttpPost("AddCar")]
        public IActionResult AddProduct([FromBody] CarEntity car)
        {
            var result = _carRepository.AddCar(car);
            return Ok(result);
        }

        [HttpGet("FindCar/{carId}")]
        public async Task<IActionResult> FindCar(int carId)
        {
            var product = await _carRepository.FindCar(carId);
            if (product == null)
            {
                return NotFound(new { Message = "No such product exist in the database" });
            }

            return Ok(product);
        }




        [HttpDelete("DeleteCar/{vehicleId}")]
        public async Task<IActionResult> DeleteCar(int vehicleId)
        {
            var result = await _carRepository.DeleteCar(vehicleId);

            if (!result)
                return NotFound();
            return Ok(new { Message = "Car Deleted!" });
        }


        [HttpPut("UpdateCarDetails")]
        public async Task<IActionResult> UpdateCar([FromBody] CarEntity updatedCar)
        {
            var result = await _carRepository.UpdateCarDetails(updatedCar);

            if (!result)
                return NotFound(new { Message = "No such car exists in the database" });

            return Ok(new { Message = "Car updated successfully" });
        }











    }


}

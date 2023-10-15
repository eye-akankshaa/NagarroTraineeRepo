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
    public class RentalAgreementController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IAgreementRepository _agreementRepository;
       


        public RentalAgreementController(IConfiguration configuration, IAgreementRepository agreementRepository)
        {
            _configuration = configuration;
            _agreementRepository = agreementRepository;
        }


        [HttpGet("GetAgreementOfUser")]

        public IActionResult GetAgreementsOfUser(int id)
        {
            var agreement =  _agreementRepository.GetAgreementOfUser(id);
            if (agreement == null)
            {
                return NotFound(new { Message = "No such agreement exist in the database" });
            }

            return Ok(agreement);



        }



        
        [HttpGet("GetAgreements")]
        public async Task<IActionResult> GetAgreements(int agreementId)
        {
            var product = await _agreementRepository.GetAgreements(agreementId);
            if (product == null)
            {
                return NotFound(new { Message = "No such product exist in the database" });
            }

            return Ok(product);
        }


        [HttpGet("GetAllAgreement")]

        public IActionResult GetAllAgreements()
        {
            var agreements = _agreementRepository.GetAllAgreements();
            return Ok(agreements);
        }

        
        [HttpPost("AddAgreement")]

        public IActionResult AddAgreement([FromBody] RentalAgreementEntity agreement)
        {
            var result = _agreementRepository.AddAgreement(agreement);
            return Ok(result);
        }


        [HttpDelete("DeleteAgreement/{agreementId}")]
        public async Task<IActionResult> DeleteAgreement(int agreementId)
        {
            var result = await _agreementRepository.DeleteAgreement(agreementId);

            if (!result)
                return NotFound();
            return Ok(new { Message = "Agreement Deleted!" });
        }

        [HttpPut("UpdateAgreementDetails")]
        public async Task<IActionResult> UpdateAgreementDetails([FromBody] RentalAgreementEntity updatedAgreement)
        {
            var result = await _agreementRepository.UpdateAgreementDetails(updatedAgreement);

            if (!result)
                return NotFound(new { Message = "No such agreement exists in the database" });

            return Ok(new { Message = "agreement updated successfully" });
        }







    }

}
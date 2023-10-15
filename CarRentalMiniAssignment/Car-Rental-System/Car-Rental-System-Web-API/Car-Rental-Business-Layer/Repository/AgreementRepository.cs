using Car_Rental_Business_Layer.IRepository;
using Car_Rental_Data_Layer.Data;
using Car_Rental_Data_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Business_Layer.Repository
{
    public class AgreementRepository:IAgreementRepository
    {
        public readonly CarRentalContext _context;
        public AgreementRepository(CarRentalContext context)
        {
            _context = context;
        }


        
       

        public List<RentalAgreementEntity> GetAgreementOfUser(int userId)
        {
            List<RentalAgreementEntity> agreements = _context.Agreement.Where(x => x.UserId == userId).ToList();
            return agreements;

        }
        public List<RentalAgreementEntity> GetAllAgreements()
        {
            
            var agreements = _context.Agreement.ToList();
            return agreements;

        }

        public int AddAgreement(RentalAgreementEntity agreement)
        {
            var result = _context.Agreement.Where(u => u.AgreementID == agreement.AgreementID).FirstOrDefault();
            if (result != null)
            {
                return (0);
            }
            _context.Agreement.Add(agreement);
            _context.SaveChanges();
            return (agreement.AgreementID);
        }

        public async Task<bool> DeleteAgreement(int agreementId)
        {
            var agreement = await _context.Agreement.FindAsync(agreementId);
            if (agreement== null)
                return false;
            _context.Agreement.Remove(agreement);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAgreementDetails(RentalAgreementEntity updatedAgreement)
        {
            var agreement = await _context.Agreement.FindAsync(updatedAgreement.AgreementID);


            if (agreement == null)
                return false;


            agreement.UserId = updatedAgreement.UserId;
            agreement.StartDate = updatedAgreement.StartDate;
            agreement.EndDate = updatedAgreement.EndDate;
            agreement.TotalPrice = updatedAgreement.TotalPrice;
            agreement.RentalDuration = updatedAgreement.RentalDuration;
            agreement.isReturnRequired = updatedAgreement.isReturnRequired;
            


            await _context.SaveChangesAsync();



            return true;
        }

        public async Task<RentalAgreementEntity> GetAgreements(int agreementId)
        {
            return await _context.Agreement.FindAsync(agreementId);
        }
    }
}

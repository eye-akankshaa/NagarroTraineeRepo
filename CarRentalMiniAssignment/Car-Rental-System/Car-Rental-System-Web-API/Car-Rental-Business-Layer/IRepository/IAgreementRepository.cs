using Car_Rental_Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Business_Layer.IRepository
{
    public interface IAgreementRepository
    {
        List<RentalAgreementEntity> GetAgreementOfUser(int userId);
        List<RentalAgreementEntity> GetAllAgreements();
        int AddAgreement(RentalAgreementEntity agreement);
        Task<RentalAgreementEntity> GetAgreements(int agreementId);

        Task<bool> DeleteAgreement(int agreementId);
        Task<bool> UpdateAgreementDetails(RentalAgreementEntity updatedAgreement);


    }
}

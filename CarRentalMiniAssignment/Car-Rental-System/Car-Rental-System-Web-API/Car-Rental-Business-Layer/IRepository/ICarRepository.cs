using Car_Rental_Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Business_Layer.IRepository
{
    public interface ICarRepository
    {
        List<CarEntity> GetAllCars();
        string AddCar(CarEntity car);
        Task<CarEntity> FindCar(int carId);

        Task<bool> DeleteCar(int carId);
        Task<bool> UpdateCarDetails(CarEntity updatedCar);
    }
}

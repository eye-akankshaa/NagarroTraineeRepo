using Car_Rental_Business_Layer.IRepository;
using Car_Rental_Data_Layer.Data;
using Car_Rental_Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Business_Layer.Repository
{
    public class CarRepository : ICarRepository
    {
        public readonly CarRentalContext _context;
        public CarRepository(CarRentalContext context)
        {
            _context = context;
        }

        public async Task<CarEntity> FindCar(int vehicleId)
        {
            return await _context.Car.FindAsync(vehicleId);
        }

        public List<CarEntity> GetAllCars()
        {

            //var results = _context.Car.Where(u => u.AvailabilityStatus == true).ToList();
            var results = _context.Car.ToList();
            return results;
        }


        public string AddCar( CarEntity car)
        {
            var result = _context.Car.Where(u => u.VehicleId == car.VehicleId).FirstOrDefault();
            if (result != null)
            {
                return ("Already Exist");
            }
            _context.Car.Add(car);
            _context.SaveChanges();
            return ("Success");
        }
        public async Task<bool> DeleteCar(int carId)
        {
            var car = await _context.Car.FindAsync(carId);
            if (car == null)
                return false;
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCarDetails(CarEntity updatedCar)
        {
            var car = await _context.Car.FindAsync(updatedCar.VehicleId);


            if (car == null)
                return false;

            car.Maker = updatedCar.Maker;
            car.Model = updatedCar.Model;
            car.RentalPrice = updatedCar.RentalPrice;
            car.AvailabilityStatus = updatedCar.AvailabilityStatus;


            await _context.SaveChangesAsync();



            return true;
        }

    }
}
using Car_Rental_Data_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Data_Layer.Data
{

    public class CarRentalContext : DbContext
    {
        public CarRentalContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<CarEntity> Car { get; set; }
        public DbSet<RentalAgreementEntity> Agreement { get; set; }
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    UserId = 1,
                    Email = "admin1@gmail.com",
                    Password = "admin1@111",
                    Phone = 2345678909,
                    isAdmin = true,
                    Name = "Admin1"
                },
                new UserEntity
                {
                    UserId = 2,
                    Email = "admin2@gmail.com",
                    Password = "admin2@222",
                    Phone = 1234567896,
                    isAdmin = true,
                    Name = "Admin2"
                },
                new UserEntity
                {
                    UserId = 3,
                    Email = "akansha@gmail.com",
                    Password = "akansha@3198",
                    Phone = 1234567896,
                    isAdmin = false,
                    Name = "Akansha"
                },

                 new UserEntity
                 {
                     UserId = 4,
                     Email = "shubhi@gmail.com",
                     Password = "shubhi@0868",
                     Phone = 1234567896,
                     isAdmin = false,
                     Name = "Shubhi"
                 },

                  new UserEntity
                   {
                       UserId = 5,
                       Email = "abha@gmail.com",
                       Password = "abha@0868",
                       Phone = 1234567896,
                       isAdmin = false,
                       Name = "Abha"
                  }
                );



            modelBuilder.Entity<CarEntity>().HasData(
                new CarEntity
                {
                    VehicleId=1,
                    Maker="Hyundai",
                    Model="I-20",
                    RentalPrice=2000,
                    AvailabilityStatus=true,
                },
                new CarEntity
                {
                    VehicleId = 2,
                    Maker = "Hyundai",
                    Model = "Verna",
                    RentalPrice = 3000,
                    AvailabilityStatus = true,

                },
                new CarEntity
                {
                    VehicleId = 3,
                    Maker = "Maruti Suzuki",
                    Model = "Dezire",
                    RentalPrice = 2000,
                    AvailabilityStatus = true,

                },

                 new CarEntity
                 {
                     VehicleId = 4,
                     Maker = "Tata",
                     Model = "Nexon",
                     RentalPrice = 4000,
                     AvailabilityStatus = true,
                 },

                  new CarEntity
                  {
                      VehicleId = 5,
                      Maker = "Tata",
                      Model = "Altroz",
                      RentalPrice = 2000,
                      AvailabilityStatus = true,
                  }


                );
        }
    }

}

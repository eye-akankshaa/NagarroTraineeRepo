using Grocery_App_Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Grocery_App_Data_Access_Layer.Data
{
    public class Grocery_Context : DbContext
    {
        public Grocery_Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<RegisterEntity> Registers { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CartEntity> Carts { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterEntity>().HasData(
                new RegisterEntity
                {
                    RegisterId = 3,
                    Email = "admin1@gmail.com",
                    Password = "admin1@123456",
                    Phone = 2345678909,
                    isAdmin = true,
                    Name = "Admin1"
                },
                new RegisterEntity
                {
                    RegisterId = 4,
                    Email = "admin2@gmail.com",
                    Password = "admin2@123457",
                    Phone = 1234567896,
                    isAdmin = true,
                    Name = "Admin2"
                }, 
                new RegisterEntity
                {
                    RegisterId = 5,
                    Email = "admin3@gmail.com",
                    Password = "admin3@123455",
                    Phone = 1234567896,
                    isAdmin = true,
                    Name = "Admin3"
                }
                );
        }
    }


}

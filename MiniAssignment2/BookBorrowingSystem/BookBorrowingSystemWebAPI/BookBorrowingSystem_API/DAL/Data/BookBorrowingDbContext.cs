using BookBorrowingSharedLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingDataLayer.Data
{
    public class BookBorrowingDbContext: DbContext
    {
        public BookBorrowingDbContext(DbContextOptions<BookBorrowingDbContext> options) : base(options)
        {

        }
        public DbSet<UserModel> User { get; set; }
        public DbSet<BookModel> Book { get; set; }
       




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            


            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    UserId = 1,
                    Name = "Akansha",
                    Username = "akansha1@gmail.com",
                    Password = "akansha1@111",
                    Tokens_Available=3,
                    
                },
                new UserModel
                {
                    UserId = 2,
                    Name = "Shubhi",
                    Username = "shubhi1@gmail.com",
                    Password = "shubhi1@111",
                    Tokens_Available = 3,
                   
                },
                new UserModel
                {
                    UserId = 3,
                    Name = "Rashi",
                    Username = "rashi1@gmail.com",
                    Password = "rashi1@111",
                    Tokens_Available = 3,
                  
                },

                 new UserModel
                 {
                     UserId = 4,
                     Name = "Ashi",
                    Username = "ashi1@gmail.com",
                     Password = "ashi1@111",
                     Tokens_Available = 3,
                   
                 }

                 
                );



            

              
        }
    }
}

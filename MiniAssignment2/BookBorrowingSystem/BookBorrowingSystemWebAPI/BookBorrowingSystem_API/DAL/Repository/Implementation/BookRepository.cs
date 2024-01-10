using BookBorrowingDataLayer.Data;
using BookBorrowingSharedLayer.Models;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Implementation
{
    public class BookRepository :IBookRepository
    {
        private readonly BookBorrowingDbContext dbContext;

        public BookRepository(BookBorrowingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       

        public async Task<BookModel> CreateAsync(BookModel bookDetails)
        {
            await dbContext.Book.AddAsync(bookDetails);

            await dbContext.SaveChangesAsync();

            return bookDetails;
        }

       

        public async Task<IEnumerable<BookModel>> GetAllBooksAsync()
        {
            return await dbContext.Book.ToListAsync();
        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            return await dbContext.Book.FirstOrDefaultAsync(p => p.BookId == id);
        }

       
        public async Task UpdateBookAsync(BookModel updatedbook)
        {
            dbContext.Book.Update(updatedbook);
            await dbContext.SaveChangesAsync();
        }


    }
}

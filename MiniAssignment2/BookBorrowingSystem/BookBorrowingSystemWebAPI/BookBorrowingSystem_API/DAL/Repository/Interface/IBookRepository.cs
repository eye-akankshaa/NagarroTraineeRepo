using BookBorrowingSharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IBookRepository
    {
        Task<BookModel> CreateAsync(BookModel bookDetails);
        Task<IEnumerable<BookModel>> GetAllBooksAsync();

        Task UpdateBookAsync(BookModel updatedbook);

        Task<BookModel> GetBookByIdAsync(int id);

        


    }
}

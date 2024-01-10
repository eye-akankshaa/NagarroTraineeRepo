using BookBorrowingSharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IBookService
    {
        Task<BookModel> CreateAsync(BookModel bookDetails);
        Task<IEnumerable<BookModel>> GetAllBooksAsync();
        Task UpdateBookAsync(BookModel updatedBook);
        Task<BookModel> GetBookByIdAsync(int id);

        


    }
}

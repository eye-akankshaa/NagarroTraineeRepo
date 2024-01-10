using BookBorrowingSharedLayer.Models;
using DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public Task<BookModel> CreateAsync(BookModel bookDetails)
        {
            return bookRepository.CreateAsync(bookDetails);
        }
        public Task<IEnumerable<BookModel>> GetAllBooksAsync()
        {
            return bookRepository.GetAllBooksAsync();
        }

        public Task<BookModel> GetBookByIdAsync(int id)
        {
            return bookRepository.GetBookByIdAsync(id);
        }

        

        public Task UpdateBookAsync(BookModel updatedbook)
        {
            return bookRepository.UpdateBookAsync(updatedbook);
        }



    }
}

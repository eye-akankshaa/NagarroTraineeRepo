using BookBorrowingSharedLayer.Models;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        /// <summary>
        /// used to addbook
        /// </summary>
        /// <param name="postBook"></param>
        /// <returns></returns>

        [Authorize]
        [HttpPost("Addbooks")]
        public async Task<IActionResult> AddBook(BookModel postBook)
        {
            try
            {
                var bookDetail = new BookModel
                {
                    
                    Name = postBook.Name,
                    Rating = postBook.Rating,
                    Author = postBook.Author,
                    Genre = postBook.Genre,
                    Is_Book_Available = true,
                    Description = postBook.Description,
                    Lent_By_User_id = postBook.Lent_By_User_id,
                    Currently_Borrowed_By_User_id = postBook.Currently_Borrowed_By_User_id
                };

                await bookService.CreateAsync(bookDetail);

                return Ok(bookDetail);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }



        }

        /// <summary>
        /// used to get all the books
        /// </summary>
        /// <returns></returns>


        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var books = await bookService.GetAllBooksAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }

        /// <summary>
        /// used to get a book by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        [Authorize]
        [HttpGet("FindBook/{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            try
            {
                var book = await bookService.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }


        /// <summary>
        /// used to update a book
        /// </summary>
        /// <param name="id"></param>
         /// <param name="updatedbook"></param>
        /// <returns></returns>


        [Authorize]
        
        [HttpPut("UpdateBook/{id}")]
       
        public async Task<IActionResult> UpdateBook([FromRoute] int id, BookModel updatedbook)
        {
            try
            {
                var book = await bookService.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }

                book.Name = updatedbook.Name;
                book.Rating = updatedbook.Rating;
                book.Author = updatedbook.Author;
                book.Genre = updatedbook.Genre;
                book.Is_Book_Available = updatedbook.Is_Book_Available;
                book.Description = updatedbook.Description;
                book.Lent_By_User_id = updatedbook.Lent_By_User_id;
                book.Currently_Borrowed_By_User_id = updatedbook.Currently_Borrowed_By_User_id;

                await bookService.UpdateBookAsync(book);
                return Ok(book);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

       
    }
}

using BookReadingEvent.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvent.Data.DataUnitOfWork
{
    public class ContextUnitOfWork : IContextUnitOfWork
    {
        private BookReadingEventContext _bookContext;
        private readonly DbContextOptions<BookReadingEventContext> options;

        public ContextUnitOfWork(BookReadingEventContext bookContext)
        {
            _bookContext = bookContext;
        }



        public BookReadingEventContext BookContext
        {
            get
            {
                return _bookContext ??= _bookContext ?? new BookReadingEventContext(options);
            }
        }

        public async Task SaveAsync()
        {
            await _bookContext.SaveChangesAsync();
        }
    }
}

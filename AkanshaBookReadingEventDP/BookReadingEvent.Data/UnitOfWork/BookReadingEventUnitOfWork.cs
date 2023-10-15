using BookReadingEvent.Data.Data;
using BookReadingEvent.Data.DataUnitOfWork;
using BookReadingEvent.Data.Repository;
using BookReadingEvent.Domain.InterfaceRepository;
using BookReadingEvent.Domain.UnitOfWorkInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvent.Data.UnitOfWork
{
    public class BookReadingEventUnitOfWork :IBookReadingEventUnitOfWork
    {
        
        private readonly IUserService _userService;
        private readonly IContextUnitOfWork _contextUnitOfWork;
        private IBookReadingEventRepository _bookRepository;

        public BookReadingEventUnitOfWork(IContextUnitOfWork contextUnitOfWork, IUserService userService)
        {
            _contextUnitOfWork = contextUnitOfWork;
            _userService = userService;
        }

        public IBookReadingEventRepository BookReadingEvent
        {
            get
            {
                return _bookRepository ??= _bookRepository ?? new BookReadingEventRepository(_contextUnitOfWork, _userService);
            }
        }

        public async Task Save()
        {
            await _contextUnitOfWork.SaveAsync();
        }
    }
}

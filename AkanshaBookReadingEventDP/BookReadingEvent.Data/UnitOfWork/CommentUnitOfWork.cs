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
    public class CommentUnitOfWork : ICommentUnitOfWork
    {
        
        private readonly IContextUnitOfWork _contextUnitOfWork;
        private ICommentRepository _commentRepository;

        public CommentUnitOfWork(IContextUnitOfWork contextUnitOfWork)
        {
            _contextUnitOfWork = contextUnitOfWork;
        }
       
        public ICommentRepository Comment
        {
            get
            {
                return _commentRepository ??= _commentRepository ?? new CommentRepository(_contextUnitOfWork);
            }
        }

        public async Task Save()
        {
            await _contextUnitOfWork.SaveAsync();
        }
    }
}

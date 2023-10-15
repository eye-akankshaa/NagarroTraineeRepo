using BookReadingEvent.Data.Data;
using BookReadingEvent.Data.DataUnitOfWork;
using BookReadingEvent.Domain.Entities;
using BookReadingEvent.Domain.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvent.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
       
        private readonly IContextUnitOfWork _contextUnitOfWork;
        public CommentRepository(IContextUnitOfWork contextUnitOfWork)
        {
            _contextUnitOfWork = contextUnitOfWork;
        }
       
        public async Task<int> PostComment(CommentEntity newComment)
        {
            await _contextUnitOfWork.BookContext.Comments.AddAsync(newComment);
            await _contextUnitOfWork.SaveAsync();
            return newComment.Id;
        }

    }
}

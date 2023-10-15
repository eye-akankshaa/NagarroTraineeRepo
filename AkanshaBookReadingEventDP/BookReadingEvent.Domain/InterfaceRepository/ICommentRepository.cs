using BookReadingEvent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvent.Domain.InterfaceRepository
{
    public interface ICommentRepository
    {
        Task<int> PostComment(CommentEntity newComment);
    }
}

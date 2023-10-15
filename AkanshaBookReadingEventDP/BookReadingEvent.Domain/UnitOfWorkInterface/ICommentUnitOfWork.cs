using BookReadingEvent.Domain.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvent.Domain.UnitOfWorkInterface
{
   public interface ICommentUnitOfWork
    {
        ICommentRepository Comment { get; }

        Task Save();
    }
}

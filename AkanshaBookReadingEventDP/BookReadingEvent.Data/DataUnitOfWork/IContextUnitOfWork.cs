using BookReadingEvent.Data.Data;
using System.Threading.Tasks;

namespace BookReadingEvent.Data.DataUnitOfWork
{
    public interface IContextUnitOfWork
    {
        BookReadingEventContext BookContext { get; }

        Task SaveAsync();
    }
}
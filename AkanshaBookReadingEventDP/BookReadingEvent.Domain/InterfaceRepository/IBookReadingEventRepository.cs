using BookReadingEvent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvent.Domain.InterfaceRepository
{
    public interface IBookReadingEventRepository
    {
        Task<int> CreateEvent(EventEntity model);
        Task<List<EventEntity>> GetAllEvents();
        Task<EventEntity> GetEventDetailsById(int Id);
        Task<List<CommentEntity>> GetAllCommentsById(int id);
        Task<List<EventEntity>> EventsByCreatedBY(string createdBy);
        Task<int> EditEvent(EventEntity newmodel, int id);

    }
}

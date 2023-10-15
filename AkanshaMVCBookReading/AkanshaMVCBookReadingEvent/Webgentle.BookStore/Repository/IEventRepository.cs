using System.Collections.Generic;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public interface IEventRepository
    {
        Task<int> AddNewEvent(EventModel model);
        Task<List<EventModel>> EventsInvitedTo();
        Task<List<EventModel>> GetAllEvents();
        Task<EventModel> GetEventById(int id);

        Task <EventModel>UpdateEvent(EventModel book);
        
    }
}
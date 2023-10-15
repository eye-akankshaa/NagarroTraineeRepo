using BusinessLogicLayer_BLL_.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer_BLL_.Services
{
    public interface IEventService
    {
        Task<int> CreateEvent(EventDTO model);
        Task<List<EventDTO>> GetAllEvents();
        Task<EventDTO> EventDetailsById(int id);
        Task<List<CommentDTO>> GetAllCommentsById(int id);
        Task<List<EventDTO>> GetEventByCreatedBy(string createdBy);
        Task<int> EditEvent(EventDTO newmodel, int id);


    }
}
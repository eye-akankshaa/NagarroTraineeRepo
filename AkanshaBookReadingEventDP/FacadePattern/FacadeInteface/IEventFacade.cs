using BusinessLogicLayer_BLL_.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.FacadeInteface
{
    public interface IEventFacade
    {
        Task<int> CreateEvent(EventDTO model);
        Task<List<EventDTO>> GetAllEvents();
        Task<EventDTO> EventsDetails(int id);
        Task<List<CommentDTO>> GetAllComments(int id);
        Task<List<EventDTO>> MyEvents(string createdBy);
        Task<int> EditEvent(EventDTO newmodel, int id);
    }
}

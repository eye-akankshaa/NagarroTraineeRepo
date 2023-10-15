using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer_BLL_.DataTransferObjects;
using BusinessLogicLayer_BLL_.Services;
using FacadePattern.FacadeInteface;
namespace FacadePattern.FacadePattern
{
    public class EventFacade : IEventFacade
    {
        private readonly IEventService _eventService;

        public EventFacade(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<int> CreateEvent(EventDTO model)
        {
            var result = await _eventService.CreateEvent(model);
            return result;

        }

        public async Task<int> EditEvent(EventDTO newmodel, int id)
        {
            var result = await _eventService.EditEvent(newmodel, id);
            return result;
        }

        public async Task<List<CommentDTO>> GetAllComments(int id)
        {
            var result = await _eventService.GetAllCommentsById(id);
            return result;

        }

        public async Task<List<EventDTO>> GetAllEvents()
        {
            var result = await _eventService.GetAllEvents();
            return result;
        }

        public async Task<EventDTO> EventsDetails(int id)
        {
            var result = await _eventService.EventDetailsById(id);
            return result;
        }

        public async Task<List<EventDTO>> MyEvents(string createdBy)
        {
            var result = await _eventService.GetEventByCreatedBy(createdBy);
            return result;

        }
    }
}

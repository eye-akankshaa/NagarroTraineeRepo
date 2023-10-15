using BusinessLogicLayer_BLL_.DataTransferObjects;
using BusinessLogicLayer_BLL_.Services;
using FacadePattern.FacadeInteface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.FacadePattern
{
    public class Facade : IFacade
    {
        private readonly ICommentFacade commentFacade;
        private readonly IEventFacade eventFacade;

        private readonly ICommentService _commentService;
        private readonly IEventService _eventService;

        public Facade(ICommentService commentService,IEventService eventService)
        {
            _eventService = eventService;
            _commentService = commentService;

            commentFacade = new CommentFacade(_commentService);
            eventFacade = new EventFacade(_eventService);

            
        }

        public async Task<int> CreateEvent(EventDTO model)
        {
            var result = await eventFacade.CreateEvent(model);
            return result;
        }

        public async Task<List<EventDTO>> GetAllEvents()
        {
            var result = await eventFacade.GetAllEvents();
            return result;
        }
        public async Task<EventDTO> EventDetails(int id)
        {
            var result = await eventFacade.EventsDetails(id);
            return result;
        }

        public async Task<List<CommentDTO>> GetAllComments(int id)
        {
            var result = await eventFacade.GetAllComments(id);
            return result;
        }
        public async Task<List<EventDTO>> MyEvents(string createdBy)
        {
            var result = await eventFacade.MyEvents(createdBy);
            return result;
        }
        public async Task<int> EditEvent(EventDTO newModel, int id)
        {
            var result = await eventFacade.EditEvent(newModel, id);
            return result;
        }

        public async Task<int> Comment(CommentDTO model)
        {
            var result = await commentFacade.Comment(model);
            return result;
        }
    }
}

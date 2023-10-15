using AutoMapper;
using BookReadingEvent.Domain.Entities;
using BookReadingEvent.Domain.InterfaceRepository;
using BookReadingEvent.Domain.UnitOfWorkInterface;
using BusinessLogicLayer_BLL_.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer_BLL_.Services
{
    public class EventService : IEventService
    {
        
        private readonly IUserService _userService;
        private readonly IBookReadingEventUnitOfWork _bookReadingEventUnitOfWork;
        public EventService(IBookReadingEventUnitOfWork bookReadingEventUnitOfWork, IUserService userService)
        {
            
            _bookReadingEventUnitOfWork = bookReadingEventUnitOfWork;
            _userService = userService;
        }
        public async Task<int> CreateEvent(EventDTO model)
        {
            var newEvent = new EventEntity()
            {
                Id = model.Id,
                Title = model.Title,
                Date = model.Date,
                StartTime = model.StartTime,
                Location = model.Location,
                Description = model.Description,
                OtherDetails = model.OtherDetails,
                Duration = model.Duration,
                Organiser = model.Organiser,
                EventType = model.EventType,
                Invitees = model.Invitees,
                CreatedBy = _userService.GetUserID()
            };
            await _bookReadingEventUnitOfWork.BookReadingEvent.CreateEvent(newEvent);

            return newEvent.Id;
        }

        public async Task<List<EventDTO>> GetAllEvents()
        {
            List<EventDTO> eventListDTO = new List<EventDTO>();

            var newList = await _bookReadingEventUnitOfWork.BookReadingEvent.GetAllEvents();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventEntity, EventDTO>());
            var mapper = config.CreateMapper();
            eventListDTO = mapper.Map<List<EventEntity>, List<EventDTO>>(newList);
            return eventListDTO;
        }

        public async Task<EventDTO> EventDetailsById(int id)
        { 
            EventEntity EventData = await _bookReadingEventUnitOfWork.BookReadingEvent.GetEventDetailsById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventEntity, EventDTO>());
            var mapper = config.CreateMapper();
            EventDTO EventDataDTO = mapper.Map<EventEntity, EventDTO>(EventData);
            return EventDataDTO;
        }

        public async Task<List<CommentDTO>> GetAllCommentsById(int id)
        {
            List<CommentDTO> eventCommentListDTO = new List<CommentDTO>();

            var newCommentList = await _bookReadingEventUnitOfWork.BookReadingEvent.GetAllCommentsById(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentEntity, CommentDTO>());
            var mapper = config.CreateMapper();
            eventCommentListDTO = mapper.Map<List<CommentEntity>, List<CommentDTO>>(newCommentList);
            return eventCommentListDTO;
        }


        public async Task<List<EventDTO>> GetEventByCreatedBy(string createdBy)
        {
            List<EventDTO> eventListDTO = new List<EventDTO>();

            var myEventList = await _bookReadingEventUnitOfWork.BookReadingEvent.EventsByCreatedBY(createdBy);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventEntity, EventDTO>());
            var mapper = config.CreateMapper();
            eventListDTO = mapper.Map<List<EventEntity>, List<EventDTO>>(myEventList);
            return eventListDTO;
          
        }

        public async Task<int> EditEvent(EventDTO model,int id)
        {
            var editEvent = new EventEntity()
            {
                Id = model.Id,
                Title = model.Title,
                Date = model.Date,
                StartTime = model.StartTime,
                Location = model.Location,
                Description = model.Description,
                OtherDetails = model.OtherDetails,
                Duration = model.Duration,
                Organiser = model.Organiser,
                EventType = model.EventType,
                Invitees = model.Invitees,
                CreatedBy = _userService.GetUserID()
            };
            await _bookReadingEventUnitOfWork.BookReadingEvent.EditEvent(editEvent,id);

            return editEvent.Id;
        }
    }
}



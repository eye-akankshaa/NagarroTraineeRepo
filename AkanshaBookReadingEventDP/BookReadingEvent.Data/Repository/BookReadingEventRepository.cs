using BookReadingEvent.Data.Data;
using BookReadingEvent.Data.DataUnitOfWork;
using BookReadingEvent.Domain.Entities;
using BookReadingEvent.Domain.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvent.Data.Repository
{    
    public class BookReadingEventRepository :IBookReadingEventRepository
    {
       
        private readonly IContextUnitOfWork _contextUnitOfWork;
        private readonly IUserService _userService;

        public BookReadingEventRepository(IContextUnitOfWork contextUnitOfWork, IUserService userService)
        {
            _contextUnitOfWork = contextUnitOfWork;
            _userService = userService;
        }

        public async Task<int> CreateEvent(EventEntity newEvent)
        {

            await _contextUnitOfWork.BookContext.Events.AddAsync(newEvent);
            await _contextUnitOfWork.SaveAsync();
            return newEvent.Id;
        }

        public async Task<List<EventEntity>> GetAllEvents()
        {
            return await _contextUnitOfWork.BookContext.Events.ToListAsync();
        }

        public async Task<EventEntity> GetEventDetailsById(int Id)
        {
            return await _contextUnitOfWork.BookContext.Events.FindAsync(Id);

        }

        public async Task<List<CommentEntity>> GetAllCommentsById(int id)
        {

            return await _contextUnitOfWork.BookContext.Comments.Where(eventModel=>eventModel.EventId==id ).ToListAsync();
        }

       public async Task<List<EventEntity>> EventsByCreatedBY(string createdBy)
        {
            return await _contextUnitOfWork.BookContext.Events.Where(eventModel => eventModel.CreatedBy == createdBy).ToListAsync();
        }

        public async Task<int> EditEvent(EventEntity newmodel, int id)
        {
            var result = await _contextUnitOfWork.BookContext.Events.FindAsync(id);

            result.Title = newmodel.Title;
            result.Date = newmodel.Date;
            result.Location = newmodel.Location;
            result.StartTime = newmodel.StartTime;
            result.EventType = newmodel.EventType;
            result.Duration = newmodel.Duration;
            result.Description = newmodel.Description;
            result.OtherDetails = newmodel.OtherDetails;
            result.Organiser = newmodel.Organiser;
            result.Invitees = newmodel.Invitees;
                  
            await _contextUnitOfWork.SaveAsync();
           
            return result.Id;
        }

       
    }
}

using BookEvents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Webgentle.BookStore.Data;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EventStoreContext _context = null;
        public EventRepository(EventStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewEvent(EventModel model)
        {
            var newEvent = new Events()
            {
                Title = model.Title,
                Description = model.Description,
                Location = model.Location,
                Duration = model.Duration,
                Date = model.Date,
                startTime = model.startTime,
                eventType = model.eventType,
                invitedTo = model.invitedTo,
                CreatedBy=model.CreatedBy,
                OtherDetails=model.OtherDetails

            };
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            return newEvent.Id;

        }
        public async Task<List<EventModel>> GetAllEvents()

        {
            var events = new List<EventModel>();
            var allevents = await _context.Events.ToListAsync();
            if (allevents?.Any() == true)
            {
                foreach (var bookevent in allevents)
                {
                    events.Add(new EventModel()
                    {
                        Id = bookevent.Id,
                        Title = bookevent.Title,
                        Description = bookevent.Description,
                        Location = bookevent.Location,
                        Duration = bookevent.Duration,
                        Date = bookevent.Date,
                        startTime = bookevent.startTime,
                        eventType = bookevent.eventType,
                        invitedTo = bookevent.invitedTo,
                        CreatedBy = bookevent.CreatedBy,
                        OtherDetails = bookevent.OtherDetails


                    });
                }
            }
            return events;
        }

       

        public async Task<List<EventModel>> EventsInvitedTo()

        {
            var events = new List<EventModel>();
            var allevents = await _context.Events.ToListAsync();
            if (allevents?.Any() == true)
            {
                foreach (var bookevent in allevents)
                {
                    events.Add(new EventModel()
                    {
                        Id = bookevent.Id,
                        Title = bookevent.Title,
                        Description = bookevent.Description,
                        Location = bookevent.Location,
                        Duration = bookevent.Duration,
                        Date = bookevent.Date,
                        startTime = bookevent.startTime,
                        eventType = bookevent.eventType,
                        invitedTo = bookevent.invitedTo,
                        CreatedBy = bookevent.CreatedBy,
                        OtherDetails = bookevent.OtherDetails


                    });
                }
            }
            return events;
        }

        public async Task<EventModel> GetEventById(int id)
        {
            var bookevent = await _context.Events.FindAsync(id);
            if (bookevent != null)
            {
                var eventDetails = new EventModel()
                {
                    Id = bookevent.Id,
                    Title = bookevent.Title,
                    Description = bookevent.Description,
                    Location = bookevent.Location,
                    Duration = bookevent.Duration,
                    Date = bookevent.Date,
                    startTime = bookevent.startTime,
                    eventType = bookevent.eventType,
                    invitedTo = bookevent.invitedTo,
                    CreatedBy = bookevent.CreatedBy,
                    OtherDetails = bookevent.OtherDetails
                };
                return eventDetails;
            }
            return null;
        }

        public async Task<EventModel> UpdateEvent(EventModel book)
        {
            var bookevent = _context.Events.SingleOrDefault(b => b.Id == book.Id);

            if (bookevent != null)
            {
                bookevent.Title = book.Title;
                bookevent.Date = book.Date;
                bookevent.Description = book.Description;
                bookevent.Location = book.Location;
                bookevent.eventType = book.eventType;
                bookevent.invitedTo = book.invitedTo;
                bookevent.startTime = book.startTime;
                bookevent.CreatedBy = book.CreatedBy;
                bookevent.OtherDetails = book.OtherDetails;

                await _context.SaveChangesAsync();
            }

            return book;
        }


      
    }
}

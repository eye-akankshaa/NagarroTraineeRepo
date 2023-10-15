using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Webgentle.BookStore.Data;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Controllers
{
  
    public class EventController : Controller
    {
        private readonly IEventRepository _bookRepository = null;
        private readonly ILogger<EventController> _logger;

        

        public EventController(IEventRepository bookRepository, ILogger<EventController> logger)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task<ViewResult> GetAllEvents()
        {
            var data = await _bookRepository.GetAllEvents();
            _logger.LogInformation("The GetAllEvents page has been accessed");
            return View(data);
        }

        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetEvent(int id)
        {
            _logger.LogInformation("The getevent page has been accessed");
            var data = await _bookRepository.GetEventById(id);

            return View(data);
        }


        




        [Authorize]
        public ViewResult AddNewEvent( bool isSuccess =false)
        {
            ViewBag.IsSuccess = isSuccess;
            _logger.LogInformation("The addnewevent page has been accessed");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEvent(EventModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewEvent(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewEvent), new { isSuccess = true });
                }
            }
            ViewBag.IsSuccess = false;
            _logger.LogInformation("The AddNewEvent page has been accessed");
            return View();
        }

        [HttpGet]
        [Authorize]

        [Route("book-update/{id}", Name = "bookUpdateRoute")]
        public async Task<IActionResult> EditEvent(int id)
        {
            var data = await _bookRepository.GetEventById(id);
            _logger.LogInformation($"The EditEvent page has been accessed for event {id}");
            return View(data);
        }

        [HttpPost]
        [Authorize]

        [Route("book-update/{id}", Name = "bookUpdateRoute")]

        public async Task<IActionResult> EditEvent(int id,EventModel bookModel)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.UpdateEvent(bookModel);
                _logger.LogInformation($"Event {bookModel.Id} has been updated");
                return RedirectToAction(nameof(GetAllEvents));
            }
            _logger.LogInformation($"Invalid model state when attempting to update event {bookModel.Id}");
            return View(bookModel);
        }


        [Authorize]
        public async Task<ViewResult> EventsInvitedTo()
        {
            //
            var data = await _bookRepository.EventsInvitedTo();
            _logger.LogInformation("The EventsInvitedTo page has been accessed");
            return View(data);
        }

        
    }
}
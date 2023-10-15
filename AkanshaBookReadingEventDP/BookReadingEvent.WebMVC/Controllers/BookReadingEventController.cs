using BookReadingEvent.WebMVC.Models;
using BusinessLogicLayer_BLL_.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer_BLL_.DataTransferObjects;
using BookReadingEvent.Domain.InterfaceRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using FacadePattern.FacadeFactoryInterface;
using FacadePattern.FacadeInteface;
using BookReadingEvent.WebMVC.Filter;

namespace BookReadingEvent.WebMVC.Controllers
{
    [ExceptionHandlerViaLogging]
    public class BookReadingEventController : Controller
    {
       
        private readonly IFacadeFactory _facadeFacatory;
        private readonly IFacade _facade;
        private readonly IUserService _userService;
        public BookReadingEventController(IFacadeFactory facadeFacatory, IFacade facade, IUserService userService)
        {
            _facadeFacatory = facadeFacatory;
            _facade = facade;
            _userService = userService;
        }

        [Authorize]
        
        [Route("CreateEvent")]
        
        public ViewResult CreateEvent()
        { 
            return View();
        }

        [Authorize]
        [Route("CreateEvent")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventViewModel eventModel)
        {
            if (ModelState.IsValid)
            {
                var newEvent = new EventDTO()                
                {
                    Id = eventModel.Id,
                    Title = eventModel.Title,
                    Date = eventModel.Date,
                    StartTime = eventModel.StartTime,
                    Location = eventModel.Location,
                    Description = eventModel.Description,
                    OtherDetails=eventModel.OtherDetails,
                    Duration = eventModel.Duration,
                    Organiser = eventModel.Organiser,
                    EventType = eventModel.EventType,
                    Invitees = eventModel.Invitees,
                    CreatedBy = _userService.GetUserID()
                };
              
               var result = await _facade.CreateEvent(newEvent);
                if (result > 0)
                {
                    return RedirectToAction(nameof(CreateEvent));
                }
               
            }
            return View();

        }
        
        
        public async Task<IActionResult> EventDetails(int id)
        {         
            //Model Mapping
            EventViewModel data = new EventViewModel();
            var eventModelDTO = await _facade.EventDetails(id);          
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, EventViewModel>());
            var mapper = config.CreateMapper();
            data = mapper.Map<EventDTO, EventViewModel>(eventModelDTO);
           
            //Comment Mapping
            List<CommentViewModel> AllComments = new List<CommentViewModel>();
            var AllCommentsDTO = await _facade.GetAllComments(id);
            var config1 = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>());
            var mapper1 = config1.CreateMapper();
            AllComments = mapper1.Map<List<CommentDTO>, List<CommentViewModel>>(AllCommentsDTO);

            data.Comments = AllComments;
            //After adding comment check data is null or not
            if (data == null)
            {
                return RedirectToAction("EventDetails");
            }
            return View(data);
            


        }
        
        [Authorize]
        public async Task<ActionResult> MyEvents()
        {
            var createdBy = _userService.GetUserID();
           
            List<EventDTO> EventListDTO = await _facade.MyEvents(createdBy);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, EventViewModel>());
            var mapper = config.CreateMapper();
            List<EventViewModel> myEvents = mapper.Map<List<EventDTO>, List<EventViewModel>>(EventListDTO);
            myEvents.Reverse();
            return View("MyEvents", myEvents);
        }

        [Authorize]
        public async Task<ViewResult> EditEvent(int id, bool isSuccess = false)
        {
           // var data = await _eventService.EventDetailsById(id);
            EventViewModel data = new EventViewModel();
            var eventModelDTO = await _facade.EventDetails(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, EventViewModel>());
            var mapper = config.CreateMapper();
            data = mapper.Map<EventDTO, EventViewModel>(eventModelDTO);

            ViewBag.IsSuccess = isSuccess;
            return View(data);
        }

        /// <summary>
        /// Controller used to Edit the Events By using event id
        /// </summary>
        /// <param name="bookmodel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditEvent(EventViewModel eventModel, int id)
        {
            if (ModelState.IsValid)
            {
                var editEvent = new EventDTO()
                {
                    Id = eventModel.Id,
                    Title = eventModel.Title,
                    Date = eventModel.Date,
                    StartTime = eventModel.StartTime,
                    Location = eventModel.Location,
                    Description = eventModel.Description,
                    OtherDetails = eventModel.OtherDetails,
                    Duration = eventModel.Duration,
                    Organiser = eventModel.Organiser,
                    EventType = eventModel.EventType,
                    Invitees = eventModel.Invitees,
                    CreatedBy = _userService.GetUserID()
                };

                var result = await _facade.EditEvent(editEvent,id);
                if (result > 0)
                {
                    return RedirectToAction(nameof(editEvent), new { isSuccess = true });
                }

            }
            return View();

        }
        [Authorize]
        [Route("EventsInvitedTo")]
        public async Task<ViewResult> EventsInvitedTo()
        {
            List<EventViewModel> eventListModel = new List<EventViewModel>();
            var eventList = await _facade.GetAllEvents();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, EventViewModel>());
            var mapper = config.CreateMapper();
            eventListModel = mapper.Map<List<EventDTO>, List<EventViewModel>>(eventList);

            return View(eventListModel);
           
        }
    }
}
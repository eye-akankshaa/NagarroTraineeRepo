using BookReadingEvent.Domain.InterfaceRepository;

using BookReadingEvent.WebMVC.Filter;
using BookReadingEvent.WebMVC.Models;
using BusinessLogicLayer_BLL_.DataTransferObjects;
using BusinessLogicLayer_BLL_.Services;
using FacadePattern.FacadeFactoryInterface;
using FacadePattern.FacadeInteface;
using Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookReadingEvent.WebMVC.Controllers
{
    public class CommentController : Controller
    {
       
        private readonly IFacadeFactory _facadeFacatory;
        private readonly IFacade _facade;
        private readonly IUserService _userService;
        public CommentController(IFacadeFactory facadeFacatory, IFacade facade, IUserService userService)
        {
            _facadeFacatory = facadeFacatory;
            _facade = facade;
            _userService = userService;
        }

        [Route("PostComment")]
        [HttpPost]
        [ExceptionHandlerViaLogging]
        public async Task<IActionResult> PostComment(CommentViewModel commentModel)
        {

            var newComment = new CommentDTO()
            {
                EventId = commentModel.EventId,
                Comment = commentModel.Comment,
                TimeStamp = DateTime.Now,
                UserId = _userService.GetUserID()
            };

             await _facade.Comment(newComment);

            return RedirectToAction("EventDetails", "BookReadingEvent", new { id = newComment.EventId });

        }
    }
}

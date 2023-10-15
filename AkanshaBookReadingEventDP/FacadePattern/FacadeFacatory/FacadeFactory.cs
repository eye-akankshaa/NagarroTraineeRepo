using BusinessLogicLayer_BLL_.Services;
using FacadePattern.FacadeFactoryInterface;
using FacadePattern.FacadeInteface;
using FacadePattern.FacadePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern.FacadeFacatory
{
    public class FacadeFactory :IFacadeFactory
    {
        private readonly IEventService _eventService;
        private readonly ICommentService _commentService;

        public FacadeFactory(IEventService eventService, ICommentService commentService)
        {
            _eventService = eventService;
            _commentService = commentService;
        }
        public IFacade Create()
        {

            IFacade facade = new Facade(_commentService, _eventService);
            return facade;
        }
    }
}

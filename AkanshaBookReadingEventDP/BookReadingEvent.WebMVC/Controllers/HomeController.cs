using AutoMapper;
using BookReadingEvent.WebMVC.Models;
using BusinessLogicLayer_BLL_.DataTransferObjects;
using BusinessLogicLayer_BLL_.Services;
using FacadePattern.FacadeFactoryInterface;
using FacadePattern.FacadeInteface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.WebMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly IFacadeFactory _facadeFacatory;
        private readonly IFacade _facade;        
        public HomeController(IFacadeFactory facadeFacatory, IFacade facade)
        {
            _facadeFacatory = facadeFacatory;
            _facade = facade;     
        }
       
    
        [Route("")]
        public async Task<IActionResult> Index()
        {
            List<EventViewModel> eventListModel = new List<EventViewModel>();
            var eventList = await _facade.GetAllEvents();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO,EventViewModel > ());
            var mapper = config.CreateMapper();
            eventListModel = mapper.Map<List<EventDTO>, List<EventViewModel>>(eventList);
                                   
            return View(eventListModel);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

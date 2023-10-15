using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventRepository _bookRepository = null;

        public HomeController(IEventRepository bookRepository, ILogger<HomeController> logger)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }


        public async Task<ViewResult> Index()
        {
            var data = await _bookRepository.GetAllEvents();
            _logger.LogInformation("The GetAllEvents page has been accessed");
            return View(data);
        }

        [Route("Index-details/{id}", Name = "IndexDetailsRoute")]
        public async Task<ViewResult> Index(int id)
        {
            _logger.LogInformation("The getevent page has been accessed");
            var data = await _bookRepository.GetEventById(id);

            return View(data);
        }
        //public ViewResult Index()
        //{
        //    _logger.LogInformation("The index page has been accessed");
        //    return View();
        //}

        public ViewResult AboutUs()
        {
            _logger.LogInformation("The aboutus page has been accessed");
            return View();

        }

        public ViewResult ContactUs()
        {
            _logger.LogInformation("The contactus page has been accessed");
            return View();
        }
    }
}

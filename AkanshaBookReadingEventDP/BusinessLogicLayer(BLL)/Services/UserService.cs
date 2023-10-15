using BookReadingEvent.Domain.InterfaceRepository;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BusinessLogicLayer_BLL_.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        /// <summary>
        /// Used to get user id of current user
        /// </summary>
        /// <returns></returns>
        public string GetUserID()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }


    }
}

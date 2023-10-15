using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookReadingEvent.WebMVC.Filter
{
    public class ExceptionHandlerViaLogging : ExceptionFilterAttribute,IExceptionFilter
    {
        private readonly ILog ILog;
        public ExceptionHandlerViaLogging()
        {
            ILog = Log.GetInstance;
        }
        
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
            ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            
        }
    }
}

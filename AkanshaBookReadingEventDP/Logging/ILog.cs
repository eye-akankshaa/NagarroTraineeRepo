using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
   public interface ILog
    {
        void LogException(string message);
    }
}

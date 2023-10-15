using FacadePattern.FacadeInteface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern.FacadeFactoryInterface
{
    public interface IFacadeFactory
    {
        IFacade Create();
    }
}

using BusinessLogicLayer_BLL_.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.FacadeInteface
{
    public interface ICommentFacade
    {

        Task<int> Comment(CommentDTO model);



    }
}

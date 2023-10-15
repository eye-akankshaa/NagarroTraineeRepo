using BookReadingEvent.Domain.Entities;
using BookReadingEvent.Domain.InterfaceRepository;
using BookReadingEvent.Domain.UnitOfWorkInterface;
using BusinessLogicLayer_BLL_.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayer_BLL_.Services
{
    public class CommentService : ICommentService
    {
        public readonly ICommentUnitOfWork _commentUnitOfWork;
        private readonly IUserService _userService;

        public CommentService(ICommentUnitOfWork commentUnitOfWork, IUserService userService)
        {
            _commentUnitOfWork = commentUnitOfWork;
            _userService = userService;
        }
              
        public async Task<int> PostComment(CommentDTO model)
        {
            //try
            //{
                var newComment = new CommentEntity()
                {
                    EventId = model.EventId,
                    Comment = model.Comment,
                    TimeStamp = DateTime.Now,
                    UserId = _userService.GetUserID()

                };

                await _commentUnitOfWork.Comment.PostComment(newComment);
                return newComment.Id;
          //  }
            //catch
            //{                
            //    //return 0;
            //}
        }

       
    }
}

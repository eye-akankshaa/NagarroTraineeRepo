using BusinessLogicLayer_BLL_.DataTransferObjects;
using System.Threading.Tasks;

namespace BusinessLogicLayer_BLL_.Services
{
    public interface ICommentService
    {
        Task<int> PostComment(CommentDTO model);
    }
}
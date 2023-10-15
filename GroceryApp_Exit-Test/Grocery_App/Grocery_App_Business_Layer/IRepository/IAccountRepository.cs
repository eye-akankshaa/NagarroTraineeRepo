using Grocery_App_Data_Access_Layer.Entities;

namespace BusinessLogicLayer.Respositories
{
    public interface IRegisterRepository
    {
        string Create(RegisterEntity user);
        RegisterEntity Login(LoginEntity user);

        Task<RegisterEntity> FindCurrentUser(string email);
    }
}

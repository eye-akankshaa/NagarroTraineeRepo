
using BusinessLogicLayer.Respositories;
using DataLayer.IRepository;
using DataLayer.Repository;


//using Grocery_App_Business_Layer.Respositories;
//using Grocery_App_Business_Layer.IRepository;
//using Grocery_App_Business_Layer.Repository;

namespace Grocery_App_Presentation_Layer
{
    public static class RegisterServices
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<IGroceryStoreRepository, GroceryStoreRepository>();
        }
    }
}

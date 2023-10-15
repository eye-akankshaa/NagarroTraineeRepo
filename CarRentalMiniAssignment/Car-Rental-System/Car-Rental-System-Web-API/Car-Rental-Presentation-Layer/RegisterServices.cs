using Car_Rental_Business_Layer.IRepository;
using Car_Rental_Business_Layer.Repository;

namespace Car_Rental_Presentation_Layer
{
    public static class RegisterServices
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IAgreementRepository, AgreementRepository>();

        }
    }
}

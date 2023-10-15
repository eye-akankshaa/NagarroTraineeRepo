using BookReadingEvent.Data.Data;
using BookReadingEvent.Data.DataUnitOfWork;
using BookReadingEvent.Data.Repository;
using BookReadingEvent.Data.UnitOfWork;
using BookReadingEvent.Domain.Entities;
using BookReadingEvent.Domain.InterfaceRepository;
using BookReadingEvent.Domain.UnitOfWorkInterface;
using BusinessLogicLayer_BLL_.Services;
using FacadePattern.FacadeFacatory;
using FacadePattern.FacadeFactoryInterface;
using FacadePattern.FacadeInteface;
using FacadePattern.FacadePattern;
using Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookReadingEvent.WebMVC
{
    public class Startup
    {        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<BookReadingEventContext>(options => options.UseSqlServer("Server=.;Database=BookReading;Integrated Security=true;"));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<BookReadingEventContext>();

            //Configure Password
            services.Configure<IdentityOptions>(Options =>
            {
                Options.Password.RequiredLength = 5;
                Options.Password.RequireDigit = false;
                Options.Password.RequireLowercase = false;
                Options.Password.RequireUppercase = false;
                Options.Password.RequireNonAlphanumeric = true;


            });


            services.AddControllersWithViews();

            //PreProcesor directive to handle the process of debuging          
#if DEBUG
            //Resposible of Runtime Compilation OutPut
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            
            //Data Access Layer
            services.AddScoped<IBookReadingEventRepository, BookReadingEventRepository>();            
            services.AddScoped<IAccountRepository, AccountRepository>();          
            services.AddScoped<ICommentRepository, CommentRepository>();

            //Business Logic Layer
            services.AddScoped<IUserService, UserService>();
             services.AddScoped<IAccountService, AccountService>();          
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IEventService, EventService>();

            //Unit Of Work
            services.AddScoped<IContextUnitOfWork, ContextUnitOfWork>();
            services.AddScoped<IBookReadingEventUnitOfWork, BookReadingEventUnitOfWork>();
            services.AddScoped<IAccountUnitOfWork, AccountUnitOfWork>();
            services.AddScoped<ICommentUnitOfWork, CommentUnitOfWork>();

            //Facade
            services.AddScoped<IFacade, Facade>();
            services.AddScoped<ICommentFacade, CommentFacade>();
            services.AddScoped<IEventFacade, EventFacade>();
            services.AddScoped<IFacadeFactory, FacadeFactory>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

       
    }
}

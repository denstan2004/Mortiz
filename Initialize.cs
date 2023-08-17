using Microsoft.AspNetCore.Cors.Infrastructure;
using Mortiz.DAL.Interfaces;
using Mortiz.DAL.Repositories;
using Mortiz.Domain.Entity;
using Mortiz.Services.Implementation;
using Mortiz.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mortiz
{
    public static class Initialize
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Clothes>, ClothesRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
           // services.AddScoped<IBaseRepository<Order>, OrderRepository>();

        }
        public static void InitializeServices(this IServiceCollection services)
        {
           
            services.AddScoped<IAccountService, AccountService>();
           
        }
    }
}

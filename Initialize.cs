using Mortiz.DAL.Interfaces;
using Mortiz.DAL.Repositories;
using Mortiz.Domain.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mortiz
{
    public static class Initialize
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Clothes>, ClothesRepository>();
        }
    }
}

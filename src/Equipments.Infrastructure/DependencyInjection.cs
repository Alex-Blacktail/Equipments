using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEquipmentsDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EquipmentsDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}

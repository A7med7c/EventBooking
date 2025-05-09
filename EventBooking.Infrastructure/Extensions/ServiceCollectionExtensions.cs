using EventBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventBooking.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var ConnectionString = configuration.GetConnectionString("EventBooking");
        services.AddDbContext<EventBookingDbContext>(options =>
        options.UseSqlServer(ConnectionString)
         .EnableSensitiveDataLogging());
    }
}

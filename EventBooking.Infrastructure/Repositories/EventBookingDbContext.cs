using EventBooking.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Infrastructure.Repositories;

internal class EventBookingDbContext(DbContextOptions<EventBookingDbContext> options) : IdentityDbContext<User>(options)
{

}

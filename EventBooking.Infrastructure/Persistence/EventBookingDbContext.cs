using EventBooking.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Infrastructure.Persistence;

public class EventBookingDbContext(DbContextOptions<EventBookingDbContext> options) : IdentityDbContext<User>(options)
{
    internal DbSet<Event> Events { get; set; }
    internal DbSet<Category> Categories { get; set; }
    internal DbSet<Booking> Bookings { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); 
       
        builder.Entity<User>()
            .HasMany(b => b.Bookings)
            .WithOne()
            .HasForeignKey(u => u.UserId);

        builder.Entity<Category>()
            .HasMany(e => e.Events)
            .WithOne()
            .HasForeignKey(c => c.CategoryId);

        builder.Entity<Event>()
            .HasMany(b => b.Bookings)
            .WithOne()
            .HasForeignKey(e => e.EventId);
    }

}

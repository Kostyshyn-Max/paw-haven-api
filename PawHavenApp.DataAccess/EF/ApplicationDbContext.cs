namespace PawHavenApp.DataAccess.EF;

using Microsoft.EntityFrameworkCore;
using PawHavenApp.DataAccess.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Chat> Chats { get; set; }

    public DbSet<HealthStatus> HealthStatuses { get; set; }

    public DbSet<Message> Messages { get; set; }

    public DbSet<Organisation> Organisations { get; set; }

    public DbSet<PetCard> PetCards { get; set; }

    public DbSet<PetStory> PetStories { get; set; }

    public DbSet<PetType> PetTypes { get; set; }

    public DbSet<Testimonial> Testimonials { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserFavourite> UserFavourites { get; set; }

}
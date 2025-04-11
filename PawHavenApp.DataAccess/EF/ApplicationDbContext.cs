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

    public DbSet<OrganisationCategory> OrganisationCategories { get; set; }

    public DbSet<PetCard> PetCards { get; set; }

    public DbSet<PetPhoto> PetPhotos { get; set; }

    public DbSet<PetStory> PetStories { get; set; }

    public DbSet<PetType> PetTypes { get; set; }

    public DbSet<Testimonial> Testimonials { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserFavourite> UserFavourites { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrganisationCategory>().HasData(DataSeed.GetOrganisationCategories());
        modelBuilder.Entity<HealthStatus>().HasData(DataSeed.GetHealthStatuses());
        modelBuilder.Entity<PetType>().HasData(DataSeed.GetPetTypes());
        modelBuilder.Entity<UserRole>().HasData(DataSeed.GetUserRoles());

        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
    }
}
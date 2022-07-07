using Microsoft.EntityFrameworkCore;
using Person.Core.Entities;

namespace Person.Infastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Male" },
                new Gender { Id = 2, Name = "Female" }
                );
            modelBuilder.Entity<User>(a =>
            {
                a.Property(x => x.FirstName).HasMaxLength(50);
                a.Property(x => x.LastName).HasMaxLength(100);
                a.Property(x => x.PersonalNumber).HasMaxLength(50);
            });
        }
    }
}

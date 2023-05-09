using Microsoft.EntityFrameworkCore;
using JobBoardAPI.Models;

namespace JobBoardAPI.Data
{
    public class ApiDbContext:DbContext
    {
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=JobBoardTestDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Application>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Jobs)
                .WithOne(e => e.Category)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employer>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.ContactEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.ContactPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .HasMany(e => e.Jobs)
                .WithOne(e => e.Employer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Job>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.JobType)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .HasMany(e => e.Applications)
                .WithOne(e => e.Job)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Location>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Jobs)
                .WithOne(e => e.Location)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Skill>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Skill>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.Jobs)
                .WithOne(e => e.Skill)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Applications)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Employers)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

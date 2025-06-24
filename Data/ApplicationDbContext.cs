using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResumeGenerator.Models;

namespace ResumeGenerator.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Resume> Resumes { get; set; }
        public DbSet<EndUser> EndUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تمييز الوراثة
            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("RoleType")
                .HasValue<Admin>("Admin")
                .HasValue<EndUser>("EndUser");

            // تعريف العلاقة بين Resume و EndUser بشكل صريح
            modelBuilder.Entity<Resume>()
                .HasOne(r => r.endUser)
                .WithMany()
                .HasForeignKey(r => r.endUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

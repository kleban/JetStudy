using JetStudy.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JetStudy.Persistence.Context
{
    public class JetStudyContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public JetStudyContext(DbContextOptions<JetStudyContext> options)
            : base(options)
        {
        }
        public DbSet<Course> Courses => Set<Course>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

    }
}
using JetStudy.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JetStudy.Core.Context
{
    public class JetStudyContext : IdentityDbContext
    {
        public JetStudyContext(DbContextOptions<JetStudyContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Certificate> Certificates => Set<Certificate>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<CourseSession> CourseSessions => Set<CourseSession>();
        public DbSet<CourseSessionStatus> CourseSessionStatuses => Set<CourseSessionStatus>();
        public DbSet<CourseSessionType> CourseSessionTypes => Set<CourseSessionType>();
        public DbSet<Lesson> Lessons => Set<Lesson>();
        public DbSet<ParticipationRecord> Participations => Set<ParticipationRecord>();
        public DbSet<ParticipationRecordStatus> ParticipationStatuses => Set<ParticipationRecordStatus>();
        public DbSet<Instructor> Instructors { get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=JetEduDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>()
                .HasOne(x => x.ParticipationRecord)
                .WithOne(x => x.Certificate).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

    }
}
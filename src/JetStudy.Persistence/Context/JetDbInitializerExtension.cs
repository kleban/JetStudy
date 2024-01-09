using JetStudy.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Persistence.Context
{
    public static class JetDbInitializerExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            (Guid admId, Guid stdId, Guid teachId) = seedUsersAndRoles(builder);
            seedCourse(builder, new Guid[] { teachId, admId });
        }
        static void seedCourse(ModelBuilder builder, Guid[] teacherIds)
        {
            builder.Entity<Course>().HasData(
                new Course
                {
                    Id = Guid.NewGuid(),
                    Title = "Аналіз даних для наукових досліджень",
                    ShortDesc = "Курс розглядає методи та інструменти аналізу даних у наукових дослідженнях. Включає в себе збір, очищення і статистичний аналіз даних, щоб підготувати учасників до ефективного проведення наукових досліджень.",
                    DetailedDesc = "Курс \"Аналіз даних для наукових досліджень\" є спеціалізованим навчальним програмою, розробленим для тих, хто цікавиться використанням аналізу даних у наукових дослідженнях. Курс вдосконалює розуміння учасників щодо методів, інструментів і процесів, пов'язаних з обробкою і аналізом даних в контексті наукових досліджень.",
                    Requirements = "Python, R, Jupyter Notebook, Anaconda, RStduio Desktop",
                    OwnerId = teacherIds[0]
                }
                );
            builder.Entity<Course>().HasData(
               new Course
               {
                   Id = Guid.NewGuid(),
                   Title = "Аналіз даних для маркетингу",
                   ShortDesc = "Курс розглядає методи та інструменти аналізу даних у наукових дослідженнях. Включає в себе збір, очищення і статистичний аналіз даних, щоб підготувати учасників до ефективного проведення наукових досліджень.",
                   DetailedDesc = "Курс \"Аналіз даних для наукових досліджень\" є спеціалізованим навчальним програмою, розробленим для тих, хто цікавиться використанням аналізу даних у наукових дослідженнях. Курс вдосконалює розуміння учасників щодо методів, інструментів і процесів, пов'язаних з обробкою і аналізом даних в контексті наукових досліджень.",
                   Requirements = "Python, R, Jupyter Notebook, Anaconda, RStduio Desktop",
                   OwnerId = teacherIds[1]
               }
               );
        }
        static (Guid, Guid, Guid) seedUsersAndRoles(ModelBuilder builder)
        {
            var ADMIN_ROLE_ID = Guid.NewGuid();
            var STUDENT_ROLE_ID = Guid.NewGuid();
            var TEACHER_ROLE_ID = Guid.NewGuid();

            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid> { Id = ADMIN_ROLE_ID, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<Guid> { Id = STUDENT_ROLE_ID, Name = "Student", NormalizedName = "STUDENT" },
                new IdentityRole<Guid> { Id = TEACHER_ROLE_ID, Name = "Teacher", NormalizedName = "TEACHER" }
                );

            var ADMIN_ID = Guid.NewGuid();
            var STUDENT_ID = Guid.NewGuid();
            var TEACHER_ID = Guid.NewGuid();

            var admin = new User
            {
                Id = ADMIN_ID,
                DateOfBirth = DateTime.Now.AddYears(25),
                UserName = "admin@jetstudy.com",
                Email = "admin@jetstudy.com",
                FirstName = "Ivan",
                EmailConfirmed = true,
                LastName = "Petrenko",
                NormalizedEmail = "ADMIN@JETSTUDY.COM",
                NormalizedUserName = "ADMIN@JETSTUDY.COM"
            };

            var student = new User
            {
                Id = STUDENT_ID,
                DateOfBirth = DateTime.Now.AddYears(23),
                UserName = "std@jetstudy.com",
                Email = "std@jetstudy.com",
                FirstName = "Andriy",
                EmailConfirmed = true,
                LastName = "Petrenko",
                NormalizedEmail = "STD@JETSTUDY.COM",
                NormalizedUserName = "STD@JETSTUDY.COM"
            };

            var teacher = new User
            {
                Id = TEACHER_ID,
                DateOfBirth = DateTime.Now.AddYears(21),
                UserName = "teacher@jetstudy.com",
                Email = "teacher@jetstudy.com",
                FirstName = "Olena",
                LastName = "Petrenko",
                EmailConfirmed = true,
                NormalizedEmail = "TEACHER@JETSTUDY.COM",
                NormalizedUserName = "TEACHER@JETSTUDY.COM"
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin$pass");
            student.PasswordHash = hasher.HashPassword(student, "student$pass");
            teacher.PasswordHash = hasher.HashPassword(teacher, "teacher$pass");

            builder.Entity<User>().HasData(admin, student, teacher);

            builder.Entity<IdentityUserRole<Guid>>().HasData(

                new IdentityUserRole<Guid>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = TEACHER_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = TEACHER_ROLE_ID,
                    UserId = TEACHER_ID
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = TEACHER_ROLE_ID,
                    UserId = STUDENT_ID
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = STUDENT_ROLE_ID,
                    UserId = STUDENT_ID
                });
            return (ADMIN_ID, STUDENT_ID, TEACHER_ID);
        }
    }
}

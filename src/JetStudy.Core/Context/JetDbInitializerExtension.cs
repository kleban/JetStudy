using JetStudy.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Core.Context
{
    public static class JetDbInitializerExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            (string admId, string stdId, string teachId) = seedUsersAndRoles(builder);
            seedSessionTypeStatus(builder);
            seedCourse(builder, new string[] {teachId, admId});
            seedSessions(builder);
        }

        private static void seedSessionTypeStatus(ModelBuilder builder)
        {
            builder.Entity<CourseSessionType>().HasData(
                new CourseSessionType
                {
                    Id = 1,
                    Title = "Онлайн"
                },
                new CourseSessionType
                {
                    Id = 2,
                    Title = "Офлайн"
                },
                new CourseSessionType
                {
                    Id = 3,
                    Title = "Змішана (онлайн + офлайн)"
                }
                );
            builder.Entity<CourseSessionStatus>().HasData(
                new CourseSessionStatus
                {
                    Id = 2,
                    Title = "Йде набір"
                },
                new CourseSessionStatus
                {
                    Id = 1,
                    Title = "Чорновик"
                },
                new CourseSessionStatus
                {
                    Id = 3,
                    Title = "Набір завершено"
                },
                new CourseSessionStatus
                {
                    Id = 4,
                    Title = "У процесі"
                },
                new CourseSessionStatus
                {
                    Id = 5,
                    Title = "Завершений"
                },
                new CourseSessionStatus
                {
                    Id = 6,
                    Title = "Відмінений"
                }
                );
        }

        private static void seedSessions(ModelBuilder builder)
        {
            builder.Entity<CourseSession>().HasData(
                new CourseSession
                {
                    Id = 1,
                    Title = "Аналіз даних для наукових досліджень",
                    CourseId = 1,
                    StatusId = 1,
                    TypeId = 3,
                    Start = new DateTime(2023, 10, 15),
                    End = new DateTime(2023, 10, 17),
                    
                }
                );
        }
        static void seedCourse(ModelBuilder builder, string[] teacherIds)
        {
            builder.Entity<Course>().HasData(
                new Course { 
                    Id = 1,
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
                   Id = 2,
                   Title = "Аналіз даних для маркетингу",
                   ShortDesc = "Курс розглядає методи та інструменти аналізу даних у наукових дослідженнях. Включає в себе збір, очищення і статистичний аналіз даних, щоб підготувати учасників до ефективного проведення наукових досліджень.",
                   DetailedDesc = "Курс \"Аналіз даних для наукових досліджень\" є спеціалізованим навчальним програмою, розробленим для тих, хто цікавиться використанням аналізу даних у наукових дослідженнях. Курс вдосконалює розуміння учасників щодо методів, інструментів і процесів, пов'язаних з обробкою і аналізом даних в контексті наукових досліджень.",
                   Requirements = "Python, R, Jupyter Notebook, Anaconda, RStduio Desktop",
                   OwnerId = teacherIds[1]
               }
               );
        }
        static (string, string, string) seedUsersAndRoles(ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string STUDENT_ROLE_ID = Guid.NewGuid().ToString();
            string TEACHER_ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = ADMIN_ROLE_ID, Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole { Id = STUDENT_ROLE_ID, Name = "Student", NormalizedName = "STUDENT" },
                new IdentityRole { Id = TEACHER_ROLE_ID, Name = "Teacher", NormalizedName = "TEACHER" }
                );

            string ADMIN_ID = Guid.NewGuid().ToString();
            string STUDENT_ID = Guid.NewGuid().ToString();
            string TEACHER_ID = Guid.NewGuid().ToString();

            var admin = new User
            {
                Id = ADMIN_ID,
                DateOfBirth = DateTime.Now.AddYears(25),
                UserName = "admin@jetstudy.com",
                Email = "admin@jetstudy.com",
                FirstName = "Ivan",
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
                NormalizedEmail = "TEACHER@JETSTUDY.COM",
                NormalizedUserName = "TEACHER@JETSTUDY.COM"
           };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin$pass");
            student.PasswordHash = hasher.HashPassword(student, "student$pass");
            teacher.PasswordHash = hasher.HashPassword(teacher, "teacher$pass");

            builder.Entity<User>().HasData(admin, student, teacher);

            builder.Entity<IdentityUserRole<string>>().HasData(
                
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = TEACHER_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = TEACHER_ROLE_ID,
                    UserId = TEACHER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = TEACHER_ROLE_ID,
                    UserId = STUDENT_ID
                }                ,
                new IdentityUserRole<string>
                {
                    RoleId = STUDENT_ROLE_ID,
                    UserId = STUDENT_ID
                });
            return (ADMIN_ID, STUDENT_ID, TEACHER_ID);
        }
    }
}

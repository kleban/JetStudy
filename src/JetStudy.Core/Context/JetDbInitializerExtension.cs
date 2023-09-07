using JetStudy.Core.Entities;
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
            seedSessionTypeStatus(builder);
            seedCourse(builder);
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
                    End = new DateTime(2023, 10, 17)                    
                }
                );
        }

        static void seedCourse(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                new Course { 
                    Id = 1,
                    Title = "Аналіз даних для наукових досліджень",
                    ShortDesc = "Курс розглядає методи та інструменти аналізу даних у наукових дослідженнях. Включає в себе збір, очищення і статистичний аналіз даних, щоб підготувати учасників до ефективного проведення наукових досліджень.",
                    DetailedDesc = "Курс \"Аналіз даних для наукових досліджень\" є спеціалізованим навчальним програмою, розробленим для тих, хто цікавиться використанням аналізу даних у наукових дослідженнях. Курс вдосконалює розуміння учасників щодо методів, інструментів і процесів, пов'язаних з обробкою і аналізом даних в контексті наукових досліджень.",
                    Requirements = "Python, R, Jupyter Notebook, Anaconda, RStduio Desktop"
                }
                );
        }
    }
}

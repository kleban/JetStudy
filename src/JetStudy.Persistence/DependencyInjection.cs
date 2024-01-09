using JetStudy.Application.Repositories;
using JetStudy.Persistence.Context;
using JetStudy.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("JetStudyConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<JetStudyContext>(options =>
                options.UseSqlServer(connectionString));

             /*Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(a => a.Name.EndsWith("Repository") && !a.IsAbstract && !a.IsInterface)
                .ToList()
                .ForEach(types => services.AddScoped(types));*/

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

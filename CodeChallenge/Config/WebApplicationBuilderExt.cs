using CodeChallenge.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CodeChallenge.Config
{
    public static class WebApplicationBuilderExt
    {
        private static readonly string DB_EMPLOYEE = "EmployeeDB";
        private static readonly string DB_COMPENSATION = "CompensationDB";
        public static void UseEmployeeDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<EmployeeContext>(options =>
            {
                options.UseInMemoryDatabase(DB_EMPLOYEE);
            });
        }
        public static void UseCompensationDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<CompensationContext>(options =>
            {
                options.UseInMemoryDatabase(DB_COMPENSATION);
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Schedule.Infrastracture.EF;

public static class DependencyInjection
{
    public static void AddMSSQLAppDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}

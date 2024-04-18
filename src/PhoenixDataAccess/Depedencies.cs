using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoenixDataAccess.Models;

namespace PhoenixDataAccess;

public static class Depedencies
{
    public static void ConfigurationService(IConfiguration configuration, IServiceCollection services){
        services.AddDbContext<PhoenixContext>(
            options=>options.UseSqlServer(configuration.GetConnectionString("PhoenixConnection"))
        );
    }
}

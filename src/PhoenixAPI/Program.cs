using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PhoenixBusiness;
using PhoenixDataAccess;

namespace PhoenixAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                policy  =>{
                    policy.WithOrigins("http://localhost:5252").AllowAnyHeader().AllowAnyMethod();
            });
        });

        IConfiguration configuration = builder.Configuration;
        IServiceCollection services = builder.Services;
        Depedencies.ConfigurationService(configuration, services);
        services.AddControllers();
        // untuk Interface, repository dan servise
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<AuthService>();
        services.AddScoped<AdminService>();
        services.AddScoped<AuthorizeService>();
        services.AddScoped<IGuestRepository, GuestRepository>();
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<InventoryService>();
        services.AddScoped<IRoomInventoryRepository, RoomInventoryRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<RoomInventoryService>();
        services.AddScoped<IRoomServicesRepository, RoomServicesRepository>();
        services.AddScoped<RsService>();
        //auntentication
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options=>{
                options.TokenValidationParameters = new TokenValidationParameters(){
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value)
                    ),
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });
    
        var app = builder.Build();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors(MyAllowSpecificOrigins);
        app.MapControllers();

        app.Run();
    }
}

using PhoenixBusiness;
using PhoenixDataAccess.Models;

namespace PhoenixWeb;

public static class ConfigurationServiceBusiness
{
    public static IServiceCollection AddBusinessService(this IServiceCollection services){
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<AdminService>();
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<InventoryService>();
        services.AddScoped<IGuestRepository, GuestRepository>();
        services.AddScoped<AuthService>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IReservationRepository, RservationRepository>();
        services.AddScoped<RoomsService>();
        services.AddScoped<IRoomInventoryRepository, RoomInventoryRepository>();
        services.AddScoped<IRoomServicesRepository, RoomServicesRepository>();
        services.AddScoped<RoomServicesService>();
        services.AddScoped<IReservationRepository, RservationRepository>();
        services.AddScoped<ReservationService>();
        return services;
    }
}

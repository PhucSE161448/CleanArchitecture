using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Persistence.DBContext;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace CleanArchitecture.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CADBContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
        });
        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        services.AddScoped<ILeaveTypeRepository,LeaveTypeRepository>();
        services.AddScoped<ILeaveRequestRepository,LeaveRequestRepository>();
        services.AddScoped<ILeaveAllocationRepository,LeaveAllocationRepository>();
        return services;
    }
}

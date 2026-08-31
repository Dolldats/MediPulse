using MediPulse.Application.Interfaces.Services;
using MediPulse.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MediPulse.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientServices, PatientServices>();
            services.AddScoped<IDepartmentServices, DepartmentServices>();

            return services;
        }
    }
}

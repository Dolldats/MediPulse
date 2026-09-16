using MediPulse.Domain.Entities;
namespace MediPulse.Application.Interfaces.Repositories
{
    public interface IDoctorRepositories
    {
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task<Doctor?> GetDoctorByIdAsync(int id);
        Task CreateDoctorAsync(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(Doctor doctor);
        Task SaveChangesAsync();
    }
}

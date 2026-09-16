using MediPulse.Application.DTOs.Doctor;
namespace MediPulse.Application.Interfaces.Services
{
    public interface IDoctorServices
    {
        Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync();
        Task<DoctorResponseDto?> GetDoctorByIdAsync(int id);
        Task<DoctorResponseDto> CreateDoctorAsync(CreateDoctorDto dto);
        Task<DoctorResponseDto?> UpdateDoctorAsync(int id, UpdateDoctorDto dto);
        Task<bool> DeleteDoctorAsync(int id);
    }
}

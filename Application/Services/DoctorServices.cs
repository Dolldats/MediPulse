using MediPulse.Application.DTOs.Doctor;
using MediPulse.Application.Interfaces.Repositories;
using MediPulse.Application.Interfaces.Services;
using MediPulse.Domain.Entities;

namespace MediPulse.Application.Services
{
    public class DoctorServices : IDoctorServices
    {
        private readonly IDoctorRepositories _repositories;

        public DoctorServices(IDoctorRepositories repositories)
        {
            _repositories = repositories;
        }

        public async Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync()
        {
            var doctors = await _repositories.GetAllDoctorsAsync();
            return doctors.Select(Map);
        }

        public async Task<DoctorResponseDto?> GetDoctorByIdAsync(int id)
        {
            var doctor = await _repositories.GetDoctorByIdAsync(id);
            return doctor is null ? null : Map(doctor);
        }

        public async Task<DoctorResponseDto> CreateDoctorAsync(CreateDoctorDto dto)
        {
            var doctor = new Doctor
            {
                Name = dto.Name.Trim(),
                Specialty = dto.Specialty.Trim(),
                DepartmentId = dto.DepartmentId
            };

            await _repositories.CreateDoctorAsync(doctor);
            await _repositories.SaveChangesAsync();
            return Map((await _repositories.GetDoctorByIdAsync(doctor.Id))!);
        }

        public async Task<DoctorResponseDto?> UpdateDoctorAsync(int id, UpdateDoctorDto dto)
        {
            var doctor = await _repositories.GetDoctorByIdAsync(id);
            if (doctor is null)
            {
                return null;
            }

            doctor.Name = dto.Name.Trim();
            doctor.Specialty = dto.Specialty.Trim();
            doctor.DepartmentId = dto.DepartmentId;

            _repositories.UpdateDoctor(doctor);
            await _repositories.SaveChangesAsync();
            return Map((await _repositories.GetDoctorByIdAsync(id))!);
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var doctor = await _repositories.GetDoctorByIdAsync(id);
            if (doctor is null)
            {
                return false;
            }

            _repositories.DeleteDoctor(doctor);
            await _repositories.SaveChangesAsync();
            return true;
        }

        private static DoctorResponseDto Map(Doctor doctor)
        {
            return new DoctorResponseDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Specialty = doctor.Specialty,
                DepartmentId = doctor.DepartmentId,
                DepartmentName = doctor.Department?.Name ?? string.Empty
            };
        }
    }
}

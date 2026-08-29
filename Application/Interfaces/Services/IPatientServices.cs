using MediPulse.Application.DTOs.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPulse.Application.Interfaces.Services
{
    public interface IPatientServices
    {
        Task<IEnumerable<PatientDto>> GetAllPatientAsync();
        Task<PatientDto?> GetPatientByIdAsync(int id);
        Task<PatientDto> CreatePatientAsync(CreatePatientDto dto);
        Task<PatientDto?> UpdatePatientAsync(int id, UpdatePatientDto dto);
        Task<bool> DeletePatientAsync(int id);
    }
}

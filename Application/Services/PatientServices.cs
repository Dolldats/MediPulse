using MediPulse.Application.DTOs.Patients;
using MediPulse.Application.Interfaces.Repositories;
using MediPulse.Application.Interfaces.Services;
using MediPulse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPulse.Application.Services
{
    public class PatientServices : IPatientServices
    {
        private readonly IPatientRepositories _patientRepositories;

        public PatientServices(IPatientRepositories patientRepositories)
        {
            _patientRepositories = patientRepositories;
        }

        public async Task<PatientDto> CreatePatientAsync(CreatePatientDto dto)
        {
            var existingPatient = await _patientRepositories.GetPatientByEmailAsync(dto.Email);

            if (existingPatient != null)
            {
                throw new InvalidOperationException("A Patient with this Email already exists.");
            }

            var patient = new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Address = dto.Address,
                BloodGroup = dto.BloodGroup,
                EmergencyContact = dto.EmergencyContact,
                CreatedAt = DateTime.UtcNow,
            };

            await _patientRepositories.AddAsync(patient);
            await _patientRepositories.SaveChangesAsync();

            return TakeToPatientDto(patient);
        }

        private static PatientDto TakeToPatientDto(Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth= patient.DateOfBirth,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                Address = patient.Address,
                BloodGroup = patient.BloodGroup,
                EmergencyContact= patient.EmergencyContact,
                CreatedAt = patient.CreatedAt,
            };
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _patientRepositories.GetPatientByIdAsync(id);

            if (patient == null)
            {
                return false;
            }

            _patientRepositories.Delete(patient);
            await _patientRepositories.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientAsync()
        {
            var patients = await _patientRepositories.GetAllPatientsAsync();

            return patients.Select(TakeToPatientDto);
        }

        public async Task<PatientDto?> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepositories.GetPatientByIdAsync(id);

            if (patient == null)
            {
                return null;
            }

            return TakeToPatientDto(patient);
        }

        public async Task<PatientDto?> UpdatePatientAsync(int id, UpdatePatientDto dto)
        {
            var patient = await _patientRepositories.GetPatientByIdAsync(id);

            if (patient == null)
            {
                return null;
            }

            var existingPatient = await _patientRepositories.GetPatientByEmailAsync(dto.Email);
            if (existingPatient != null && existingPatient.Id != id)
            {
                throw new InvalidOperationException("A Patient with this Email already exists.");
            }

            patient.FirstName = dto.FirstName;
            patient.LastName = dto.LastName;
            patient.DateOfBirth = dto.DateOfBirth;
            patient.Gender = dto.Gender;
            patient.PhoneNumber = dto.PhoneNumber;
            patient.Email = dto.Email;
            patient.Address = dto.Address;
            patient.BloodGroup = dto.BloodGroup;
            patient.EmergencyContact = dto.EmergencyContact;

            _patientRepositories.Update(patient);
            await _patientRepositories.SaveChangesAsync();

            return TakeToPatientDto(patient);
        }
    }
}

using MediPulse.Application.Interfaces.Repositories;
using MediPulse.Domain.Entities;
using MediPulse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPulse.Infrastructure.Repositories
{
    public class PatientRepositories : IPatientRepositories
    {
        private readonly MediPulseDbContext _context;

        public PatientRepositories(MediPulseDbContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }

        public void DeleteAsync(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Patient?> GetPatientByEmailAsync(string email)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(Patient patient)
        {
             _context.Patients.Update(patient);
        }
    }
}

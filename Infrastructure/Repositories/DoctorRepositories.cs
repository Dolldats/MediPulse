using MediPulse.Application.Interfaces.Repositories;
using MediPulse.Domain.Entities;
using MediPulse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace MediPulse.Infrastructure.Repositories;

public class DoctorRepositories(MediPulseDbContext context) : IDoctorRepositories
{
    public async Task<List<Doctor>> GetAllDoctorsAsync() => await context.Doctors.Include(d => d.Department).AsNoTracking().ToListAsync();
    public async Task<Doctor?> GetDoctorByIdAsync(int id) => await context.Doctors.Include(d => d.Department).FirstOrDefaultAsync(d => d.Id == id);
    public async Task CreateDoctorAsync(Doctor doctor) => await context.Doctors.AddAsync(doctor);
    public void UpdateDoctor(Doctor doctor) => context.Doctors.Update(doctor);
    public void DeleteDoctor(Doctor doctor) => context.Doctors.Remove(doctor);
    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}

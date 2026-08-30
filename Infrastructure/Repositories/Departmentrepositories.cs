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
    internal class Departmentrepositories : IDepartmentRepositories
    {
        private readonly MediPulseDbContext _context;

        public Departmentrepositories(MediPulseDbContext context)
        {
            _context = context;
        }

        public async Task CreateDepartmentAsync(Department department)
        {
           await _context.Departments.AddAsync(department);
        }

        public void DeleteDepartmentAsync(Department department)
        {
            _context.Departments.Remove(department);
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }
    }
}

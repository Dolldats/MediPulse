using MediPulse.Application.DTOs.Department;
using MediPulse.Application.Interfaces.Services;
using MediPulse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPulse.Application.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        public Task<Department> CreateDepartmentAsync(CreateDepartmentDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDepartmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Department?> GetDepartmentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Department?> UpdateDepartmentAsync(int id, UpdateDepartmentDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

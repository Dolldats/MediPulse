using MediPulse.Application.DTOs.Department;
using MediPulse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPulse.Application.Interfaces.Services
{
    public interface IDepartmentServices
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department> CreateDepartmentAsync(CreateDepartmentDto dto);
        Task<Department?> UpdateDepartmentAsync(int id, UpdateDepartmentDto dto);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}

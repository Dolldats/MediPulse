using MediPulse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPulse.Application.Interfaces.Repositories
{
    public interface IDepartmentRepositories
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department?> GetDepartmentByNameAsync(string name);
        Task CreateDepartmentAsync(Department department);
        void UpdateDepartmentAsync(Department department);
        void DeleteDepartmentAsync(Department department);
        Task SaveChangesAsync();
    }
}

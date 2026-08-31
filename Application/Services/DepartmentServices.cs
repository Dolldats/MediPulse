using MediPulse.Application.DTOs.Department;
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
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepositories _departmentRepositories;

        public DepartmentServices(IDepartmentRepositories departmentRepositories)
        {
            _departmentRepositories = departmentRepositories;
        }
        public async Task<Department> CreateDepartmentAsync(CreateDepartmentDto dto)
        {
            var existingDepartment = await _departmentRepositories.GetDepartmentByNameAsync(dto.Name);

            if(existingDepartment != null)
            {
                throw new InvalidOperationException("Department with this name already exists.");
            }

            var department = new Department
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _departmentRepositories.CreateDepartmentAsync(department);
            await _departmentRepositories.SaveChangesAsync();

            return TakeToDepartmentDto(department);
        }

        private static Department TakeToDepartmentDto(Department department)
        {
            return new Department
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                CreatedAt = department.CreatedAt
            };
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var deleted = await _departmentRepositories.GetDepartmentByIdAsync(id);

            if(deleted == null)
            {
                return false;
            }

            _departmentRepositories.DeleteDepartmentAsync(deleted);
            await _departmentRepositories.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepositories.GetAllDepartmentsAsync();

            return departments.Select(TakeToDepartmentDto);
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepositories.GetDepartmentByIdAsync(id);

            if(department == null)
            {
                return null;
            }

            return TakeToDepartmentDto(department);
        }

        public async Task<Department?> UpdateDepartmentAsync(int id, UpdateDepartmentDto dto)
        {
            var department = await _departmentRepositories.GetDepartmentByIdAsync(id);
            if(department == null)
            {
                return null;
            }

            var existingDepartment = await _departmentRepositories.GetDepartmentByNameAsync(dto.Name);
            if(existingDepartment != null && existingDepartment.Id != id)
            {
                throw new InvalidOperationException("Another department with this name already exists.");
            }

            department.Name = dto.Name;
            department.Description = dto.Description;

            _departmentRepositories.UpdateDepartmentAsync(department);
            await _departmentRepositories.SaveChangesAsync();

            return TakeToDepartmentDto(department);
        }
    }
}

using MediPulse.Application.DTOs.Department;
using MediPulse.Application.Interfaces.Services;
using MediPulse.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediPulse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentServices _departmentServices;
        public DepartmentsController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentServices.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _departmentServices.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDto dto)
        {
            try
            {
                var department = await _departmentServices.CreateDepartmentAsync(dto);

                return CreatedAtAction(
                    nameof(GetDepartmentById),
                    new { id = department.Id },
                    department);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    message = ex.Message,
                });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentDto dto)
        {
            try
            {
                var department = await _departmentServices.UpdateDepartmentAsync(id, dto);

                if (department == null)
                {
                    return NotFound(new
                    {
                        message = "Department not found."
                    });
                }
                return Ok(department);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new
                {
                    message = ex.Message,
                });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleted = await _departmentServices.DeleteDepartmentAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Department not found."
                });
            }

            return NoContent();
        }
    }
}

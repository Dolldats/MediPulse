using MediPulse.Application.DTOs.Doctor;
using MediPulse.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediPulse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorServices _services;

        public DoctorsController(IDoctorServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAllDoctorsAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _services.GetDoctorByIdAsync(id);
            return doctor is null ? NotFound() : Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorDto dto)
        {
            var doctor = await _services.CreateDoctorAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateDoctorDto dto)
        {
            var doctor = await _services.UpdateDoctorAsync(id, dto);
            return doctor is null ? NotFound() : Ok(doctor);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _services.DeleteDoctorAsync(id) ? NoContent() : NotFound();
        }
    }
}

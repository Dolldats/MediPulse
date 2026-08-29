using MediPulse.Application.DTOs.Patients;
using MediPulse.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediPulse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientServices _patientServices;

        public PatientsController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
        {
            var patients = await _patientServices.GetAllPatientAsync();

            return Ok(patients);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PatientDto>> GetById(int id)
        {
            var patient = await _patientServices.GetPatientByIdAsync(id);

            if(patient == null)
            {
                return NotFound("Patient Not Found");
            }

            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult<PatientDto>> Create(CreatePatientDto dto)
        {
            try
            {
                var patient = await _patientServices.CreatePatientAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = patient.Id },
                    patient);
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
        public async Task<ActionResult<PatientDto>> Update(int id, UpdatePatientDto dto)
        {
            try
            {
                var patient = await _patientServices.UpdatePatientAsync(id, dto);

                if (patient == null)
                {
                    return NotFound(new
                    {
                        message = "Patient not found."
                    });
                }
                return Ok(patient);
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
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _patientServices.DeletePatientAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Patient not found."
                });
            }

            return NoContent();
        }
    }
}

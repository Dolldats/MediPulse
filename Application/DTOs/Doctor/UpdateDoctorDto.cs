namespace MediPulse.Application.DTOs.Doctor
{
    public class UpdateDoctorDto
    {
        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}

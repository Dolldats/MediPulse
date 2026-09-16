using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPulse.Application.DTOs.Doctor
{
    public class DoctorResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;

    }
}

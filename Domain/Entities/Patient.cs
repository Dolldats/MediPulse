using MediPulse.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPulse.Domain.Entities
{
    internal class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public int EmergencyContact { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

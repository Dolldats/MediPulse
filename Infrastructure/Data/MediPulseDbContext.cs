using MediPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPulse.Infrastructure.Data
{
    public class MediPulseDbContext : DbContext
    {
        public MediPulseDbContext(DbContextOptions<MediPulseDbContext> options) : base(options) 
        {

        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MediPulseDbContext).Assembly);
        }
    }
}

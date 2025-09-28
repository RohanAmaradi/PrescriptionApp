using Microsoft.EntityFrameworkCore;
using PrescriptionApp.Models;
using System;

namespace PrescriptionApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Prescription> Prescriptions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { PrescriptionId = 1, MedicationName = "Atorvastatin", FillStatus = "New", Cost = 19.99, RequestTime = new DateTime(2025, 1, 1, 9, 0, 0) },
                new Prescription { PrescriptionId = 2, MedicationName = "Lisinopril", FillStatus = "Filled", Cost = 8.50, RequestTime = new DateTime(2025, 2, 15, 14, 30, 0) },
                new Prescription { PrescriptionId = 3, MedicationName = "Metformin", FillStatus = "Pending", Cost = 12.75, RequestTime = new DateTime(2025, 3, 10, 8, 45, 0) }
            );
        }
    }
}
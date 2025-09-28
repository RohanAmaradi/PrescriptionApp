using System;
using System.ComponentModel.DataAnnotations;

namespace PrescriptionApp.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        [Required(ErrorMessage = "Medication Name is required")]
        public string MedicationName { get; set; } = string.Empty;

        [Required]
        public string FillStatus { get; set; } = "New";

        [Required]
        [Range(0.0, 100000.0, ErrorMessage = "Cost must be a positive number")]
        public double Cost { get; set; }

        [Required]
        public DateTime RequestTime { get; set; }
        public string Slug => $"{PrescriptionId}-{MedicationName?.ToLower().Replace(' ', '-')}";
    }
}
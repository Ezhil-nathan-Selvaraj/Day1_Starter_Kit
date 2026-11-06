// Day 2 - Modern .NET 10 DTO - replaces legacy WCF PatientTherapyData
namespace PatientOnLine.Api.Models;

public class PatientTherapyDto
{
    public string PatientId { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;
    public string TherapyType { get; set; } = string.Empty; // PD or HD
    public double DialysateVolume { get; set; }
    public int DwellTimeMinutes { get; set; }
    public string PrescriptionStatus { get; set; } = string.Empty; // Active, Paused, Completed
    public DateTime LastSync { get; set; }
    public string Clinic { get; set; } = string.Empty;
    public string? FhirResourceType => "Observation"; // FHIR readiness - Day 12 lab
}

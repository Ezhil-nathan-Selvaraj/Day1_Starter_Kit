using Microsoft.AspNetCore.Mvc;
using PatientOnLine.Api.Models;

namespace PatientOnLine.Api.Controllers;

[ApiController]
[Route("api/patients/{patientId}/therapy")]
public class TherapyController : ControllerBase
{
    // In-memory store simulating Fresenius PatientOnLine DB
    // In production: Replace with EF Core + Azure SQL (Week 3 lab)
    private static readonly Dictionary<string, PatientTherapyDto> _store = new()
    {
        ["P-1001"] = new() { PatientId="P-1001", PatientName="Test Patient - PD", TherapyType="PD", DialysateVolume=2.0, DwellTimeMinutes=240, PrescriptionStatus="Active", LastSync=DateTime.UtcNow.AddHours(-2), Clinic="Fresenius - Bengaluru" },
        ["P-1002"] = new() { PatientId="P-1002", PatientName="Test Patient - HD", TherapyType="HD", DialysateVolume=4.5, DwellTimeMinutes=180, PrescriptionStatus="Active", LastSync=DateTime.UtcNow.AddHours(-1), Clinic="Fresenius - Berlin" },
    };

    // OLD WCF: GetTherapyData(string patientId)
    // NEW REST: GET /api/patients/P-1001/therapy
    [HttpGet]
    public ActionResult<PatientTherapyDto> GetTherapy(string patientId)
    {
        if (!_store.TryGetValue(patientId, out var data))
            return NotFound(new { message = $"Patient {patientId} not found" });
        return Ok(data);
    }

    // OLD WCF: UpdateTherapyPrescription(PatientTherapyData data)
    // NEW REST: POST /api/patients/P-1001/therapy
    [HttpPost]
    public ActionResult<PatientTherapyDto> UpdateTherapy(string patientId, [FromBody] PatientTherapyDto dto)
    {
        if (dto == null) return BadRequest("Invalid payload");
        dto.PatientId = patientId;
        dto.LastSync = DateTime.UtcNow;
        _store[patientId] = dto;
        // In production: Publish event to Azure Service Bus -> Therapy Monitor consumes
        return CreatedAtAction(nameof(GetTherapy), new { patientId }, dto);
    }

    // NEW: List all - for Therapy Monitor dashboard
    [HttpGet("/api/patients/therapy")]
    public ActionResult<IEnumerable<PatientTherapyDto>> GetAll()
    {
        return Ok(_store.Values.ToList());
    }
}

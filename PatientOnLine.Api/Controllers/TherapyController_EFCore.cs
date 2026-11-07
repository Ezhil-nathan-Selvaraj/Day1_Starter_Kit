// Day 4 - Updated TherapyController with EF Core
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientOnLine.Api.Data;
using PatientOnLine.Api.Models;

namespace PatientOnLine.Api.Controllers;

[ApiController]
[Route("api/patients/{patientId}/therapy")]
public class TherapyController : ControllerBase
{
    private readonly PatientOnLineDbContext _context;
    public TherapyController(PatientOnLineDbContext context) => _context = context;

    // GET /api/patients/P-1001/therapy - now from DB, async (modern .NET)
    [HttpGet]
    public async Task<ActionResult<PatientTherapyDto>> GetTherapy(string patientId)
    {
        var data = await _context.Therapies.FindAsync(patientId);
        if (data == null) return NotFound(new { message = $"Patient {patientId} not found" });
        return Ok(data);
    }

    // POST - now persists to DB
    [HttpPost]
    public async Task<ActionResult<PatientTherapyDto>> UpdateTherapy(string patientId, [FromBody] PatientTherapyDto dto)
    {
        if (dto == null) return BadRequest("Invalid payload");
        dto.PatientId = patientId;
        dto.LastSync = DateTime.UtcNow;

        var existing = await _context.Therapies.FindAsync(patientId);
        if (existing == null) _context.Therapies.Add(dto);
        else _context.Entry(existing).CurrentValues.SetValues(dto);

        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTherapy), new { patientId }, dto);
    }

    [HttpGet("/api/patients/therapy")]
    public async Task<ActionResult<IEnumerable<PatientTherapyDto>>> GetAll()
    {
        return Ok(await _context.Therapies.ToListAsync());
    }
}

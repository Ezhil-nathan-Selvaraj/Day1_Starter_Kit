// DAY 2 TASK - Create .NET 8 Web API
// Command to run tomorrow:
// dotnet new webapi -n PatientOnLine.Api -f net8.0
// Then implement:

// GET /api/patients/{id}/therapy -> returns PatientTherapyData as JSON
// POST /api/patients/{id}/therapy -> updates prescription + publishes event to Azure Service Bus

// Director-level additions:
// - Add Application Insights telemetry
// - Add Azure Key Vault for connection strings
// - Add Clean Architecture: Api -> Application -> Domain -> Infrastructure
// - Add xUnit tests

// Sample modern controller (to be created):
/*
[ApiController]
[Route("api/patients/{patientId}/therapy")]
public class TherapyController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PatientTherapyDto>> GetTherapy(string patientId)
    {
        // Implementation with EF Core + Azure SQL
    }
}
*/

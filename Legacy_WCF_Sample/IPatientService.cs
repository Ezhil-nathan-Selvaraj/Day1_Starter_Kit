// Legacy WCF Style Service - Simulating Fresenius PatientOnLine
// File: IPatientService.cs - WCF Contract (OLD STYLE - .NET 3.5/4.5 era)
using System.ServiceModel;

namespace PatientOnLine.Legacy
{
    [ServiceContract]
    public interface IPatientTherapyService
    {
        [OperationContract]
        PatientTherapyData GetTherapyData(string patientId);

        [OperationContract]
        bool UpdateTherapyPrescription(PatientTherapyData data);
    }

    public class PatientTherapyData
    {
        public string PatientId { get; set; }
        public string TherapyType { get; set; } // PD or HD
        public double DialysateVolume { get; set; }
        public string PrescriptionStatus { get; set; }
        public string LastSync { get; set; }
    }
}

// TODO for Modernization (Director-level thinking):
// 1. Convert ServiceContract -> REST API: GET /api/patients/{id}/therapy
// 2. WCF -> gRPC or REST? Choose REST for external, gRPC for internal microservices
// 3. Add Async, DI, EF Core, Azure Service Bus for events
// 4. Add FHIR mapping: PatientTherapyData -> FHIR Observation

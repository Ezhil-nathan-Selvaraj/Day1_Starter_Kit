// Day 4 - FIXED: Use static dates in HasData, not DateTime.UtcNow
using Microsoft.EntityFrameworkCore;
using PatientOnLine.Api.Models;

namespace PatientOnLine.Api.Data;

public class PatientOnLineDbContext : DbContext
{
    public PatientOnLineDbContext(DbContextOptions<PatientOnLineDbContext> options) : base(options) { }

    public DbSet<PatientTherapyDto> Therapies => Set<PatientTherapyDto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientTherapyDto>(entity =>
        {
            entity.HasKey(e => e.PatientId);
            entity.Property(e => e.PatientId).HasMaxLength(20);
            entity.Property(e => e.PatientName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.TherapyType).HasMaxLength(10).IsRequired();
            entity.Property(e => e.PrescriptionStatus).HasMaxLength(20);
            entity.Property(e => e.Clinic).HasMaxLength(100);

            // FIX: Static dates - NOT DateTime.UtcNow (causes PendingModelChangesWarning)
            var seedDate = new DateTime(2026, 11, 6, 12, 0, 0, DateTimeKind.Utc);
            entity.HasData(
                new PatientTherapyDto { PatientId="P-1001", PatientName="Test Patient - PD", TherapyType="PD", DialysateVolume=2.0, DwellTimeMinutes=240, PrescriptionStatus="Active", LastSync=seedDate, Clinic="Fresenius - Bengaluru" },
                new PatientTherapyDto { PatientId="P-1002", PatientName="Test Patient - HD", TherapyType="HD", DialysateVolume=4.5, DwellTimeMinutes=180, PrescriptionStatus="Active", LastSync=seedDate, Clinic="Fresenius - Berlin" },
                new PatientTherapyDto { PatientId="P-1003", PatientName="Test Patient - PD Home", TherapyType="PD", DialysateVolume=2.5, DwellTimeMinutes=300, PrescriptionStatus="Active", LastSync=seedDate, Clinic="Fresenius - Munich" }
            );
        });
    }
}

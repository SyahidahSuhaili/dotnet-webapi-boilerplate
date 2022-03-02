using Finbuckle.MultiTenant.EntityFrameworkCore;
using FSH.WebApi.Domain.PatientManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.WebApi.Infrastructure.Persistence.Configuration;

public class PatientConfig : IEntityTypeConfiguration<PatientModel>
{
    public void Configure(EntityTypeBuilder<PatientModel> builder)
    {
        builder.IsMultiTenant();

        builder
        .ToTable("Patient", SchemaNames.PatientManagement)
        .IsMultiTenant();

        builder
            .Property(b => b.MedicalRecordNumber)
                .HasMaxLength(20);
    }
}
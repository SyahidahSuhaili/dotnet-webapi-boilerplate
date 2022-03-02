using Finbuckle.MultiTenant.EntityFrameworkCore;
using FSH.WebApi.Domain.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.WebApi.Infrastructure.Persistence.Configuration;

public class AdministrativeSexConfig : IEntityTypeConfiguration<AdministrativeSex>
{
    public void Configure(EntityTypeBuilder<AdministrativeSex> builder)
    {
        builder
            .ToTable("AdministrativeSex", SchemaNames.Lookup)
            .IsMultiTenant();

        builder
            .Property(b => b.Id).IsRequired().HasMaxLength(1);

        builder
            .Property(b => b.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Description)
                .HasMaxLength(200);
    }
}

public class NamePrefixConfig : IEntityTypeConfiguration<NamePrefix>
{
    public void Configure(EntityTypeBuilder<NamePrefix> builder)
    {
        builder
            .ToTable("NamePrefix", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(6);

        builder
            .Property(b => b.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Description)
                .HasMaxLength(200);
    }
}

public class IdentifierTypeConfig : IEntityTypeConfiguration<IdentifierType>
{
    public void Configure(EntityTypeBuilder<IdentifierType> builder)
    {
        builder
            .ToTable("IdentifierType", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(5);

        builder
            .Property(b => b.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Description)
                .HasMaxLength(200);
    }
}

public class ContactModeConfig : IEntityTypeConfiguration<ContactMode>
{
    public void Configure(EntityTypeBuilder<ContactMode> builder)
    {
        builder
            .ToTable("ContactMode", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(3);

        builder
            .Property(b => b.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Description)
                .HasMaxLength(200);
    }
}

public class RaceConfig : IEntityTypeConfiguration<Race>
{
    public void Configure(EntityTypeBuilder<Race> builder)
    {
        builder
            .ToTable("Race", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(7);

        builder
            .Property(b => b.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Description)
                .HasMaxLength(200);
    }
}

public class MaritalStatusConfig : IEntityTypeConfiguration<MaritalStatus>
{
    public void Configure(EntityTypeBuilder<MaritalStatus> builder)
    {
        builder
            .ToTable("MaritalStatus", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(1);

        builder
            .Property(b => b.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Description)
                .HasMaxLength(200);
    }
}

public class ReligionConfig : IEntityTypeConfiguration<Religion>
{
    public void Configure(EntityTypeBuilder<Religion> builder)
    {
        builder
            .ToTable("Religion", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(6);

        builder
            .Property(b => b.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Description)
                .HasMaxLength(200);
    }
}

public class RelationshipConfig : IEntityTypeConfiguration<Relationship>
{
    public void Configure(EntityTypeBuilder<Relationship> builder)
    {
        builder
            .ToTable("Relationship", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(6);

        builder
            .Property(b => b.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Description)
                .HasMaxLength(200);
    }
}

public class LanguageConfig : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder
            .ToTable("Language", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(6);

        builder
            .Property(b => b.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Description)
                .HasMaxLength(200);
    }
}


public class InActiveStatusConfig : IEntityTypeConfiguration<InActiveStatus>
{
    public void Configure(EntityTypeBuilder<InActiveStatus> builder)
    {
        builder
            .ToTable("InActiveStatus", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(2);

        builder
            .Property(b => b.Description)
                .HasMaxLength(50);
    }
}

public class InActiveReasonConfig : IEntityTypeConfiguration<InActiveReason>
{
    public void Configure(EntityTypeBuilder<InActiveReason> builder)
    {
        builder
            .ToTable("InActiveReason", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(3);

        builder
            .Property(b => b.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Description)
                .HasMaxLength(200);
    }
}

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder
            .ToTable("Country", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(3);

        builder
            .Property(b => b.Name)
                .HasMaxLength(100);

        builder
            .Property(p => p.TwoLettersIsoCode)
                .HasMaxLength(2);

        builder
            .Property(p => p.ThreeLettersIsoCode)
                .HasMaxLength(3);
        builder
            .Property(p => p.NumericIsoCode)
                .HasMaxLength(3);
    }
}

public class NationalityConfig : IEntityTypeConfiguration<Nationality>
{
    public void Configure(EntityTypeBuilder<Nationality> builder)
    {
        builder
            .ToTable("Nationality", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(6);
    }
}

public class EducationLevelConfig : IEntityTypeConfiguration<EducationLevel>
{
    public void Configure(EntityTypeBuilder<EducationLevel> builder)
    {
        builder
            .ToTable("EducationLevel", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(6);

        builder
            .Property(p => p.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Description)
                .HasMaxLength(200);
    }
}

public class FacilityConfig : IEntityTypeConfiguration<Facility>
{
    public void Configure(EntityTypeBuilder<Facility> builder)
    {
        builder
            .ToTable("Facility", SchemaNames.Lookup)
            .IsMultiTenant();

        builder.Property(b => b.Id).IsRequired().HasMaxLength(7);

        builder
            .Property(p => p.Name)
                .HasMaxLength(50);

        builder
            .Property(p => p.Name)
                .HasMaxLength(200);


    }
}

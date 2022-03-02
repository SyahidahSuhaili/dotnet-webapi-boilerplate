using Finbuckle.MultiTenant;
using FSH.WebApi.Application.Common.Events;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Catalog;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Domain.Public;
using FSH.WebApi.Domain.PatientManagement;
using FSH.WebApi.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FSH.WebApi.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(currentTenant, options, currentUser, serializer, dbSettings, events)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<AdministrativeSex> AdministrativeSex => Set<AdministrativeSex>();
    public DbSet<NamePrefix> NamePrefixes => Set<NamePrefix>();
    public DbSet<IdentifierType> IdentifierTypes => Set<IdentifierType>();
    public DbSet<ContactMode> ContactModes => Set<ContactMode>();
    public DbSet<Race> Races => Set<Race>();
    public DbSet<MaritalStatus> MaritalStatus => Set<MaritalStatus>();
    public DbSet<Religion> Religions => Set<Religion>();
    public DbSet<Relationship> Relationships => Set<Relationship>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<InActiveStatus> InActiveStatus => Set<InActiveStatus>();
    public DbSet<InActiveReason> InActiveReasons => Set<InActiveReason>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Nationality> Nationalities => Set<Nationality>();
    public DbSet<EducationLevel> EducationLevels => Set<EducationLevel>();
    public DbSet<Facility> Facilities => Set<Facility>();
    public DbSet<PersonModel> Persons => Set<PersonModel>();
    public DbSet<PatientModel> Patients => Set<PatientModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);
    }
}
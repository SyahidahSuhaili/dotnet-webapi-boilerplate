using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class FacilitySeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<FacilitySeeder> _logger;

    public FacilitySeeder(ISerializerService serializerService, ILogger<FacilitySeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Facilities.Any())
        {
            _logger.LogInformation("Started to Seed Facilities.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string facilityData = await File.ReadAllTextAsync(path + "/Lookup/FacilitySeeder.json", cancellationToken);
            var facilities = _serializerService.Deserialize<List<Facility>>(facilityData);

            if (facilities != null)
            {
                foreach (var facility in facilities)
                {
                    await _db.Facilities.AddAsync(facility, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Facilities.");
        }
    }
}
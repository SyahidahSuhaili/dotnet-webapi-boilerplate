using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class RaceSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<RaceSeeder> _logger;

    public RaceSeeder(ISerializerService serializerService, ILogger<RaceSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Races.Any())
        {
            _logger.LogInformation("Started to Seed Race.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string raceData = await File.ReadAllTextAsync(path + "/Lookup/RaceSeeder.json", cancellationToken);
            var races = _serializerService.Deserialize<List<Race>>(raceData);

            if (races != null)
            {
                foreach (var race in races)
                {
                    await _db.Races.AddAsync(race, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Race.");
        }
    }
}
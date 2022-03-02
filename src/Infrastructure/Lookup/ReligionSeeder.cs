using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class ReligionSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<ReligionSeeder> _logger;

    public ReligionSeeder(ISerializerService serializerService, ILogger<ReligionSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Religions.Any())
        {
            _logger.LogInformation("Started to Seed Religion.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string religionData = await File.ReadAllTextAsync(path + "/Lookup/ReligionSeeder.json", cancellationToken);
            var religions = _serializerService.Deserialize<List<Religion>>(religionData);

            if (religions != null)
            {
                foreach (var religion in religions)
                {
                    await _db.Religions.AddAsync(religion, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Religion.");
        }
    }
}
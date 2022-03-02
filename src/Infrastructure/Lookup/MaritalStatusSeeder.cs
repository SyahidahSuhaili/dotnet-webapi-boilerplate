using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class MaritalStatusSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<MaritalStatusSeeder> _logger;

    public MaritalStatusSeeder(ISerializerService serializerService, ILogger<MaritalStatusSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.MaritalStatus.Any())
        {
            _logger.LogInformation("Started to Seed MaritalStatus.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string maritalStatusData = await File.ReadAllTextAsync(path + "/Lookup/MaritalStatusSeeder.json", cancellationToken);
            var maritalStatusColl = _serializerService.Deserialize<List<MaritalStatus>>(maritalStatusData);

            if (maritalStatusColl != null)
            {
                foreach (var maritalStatus in maritalStatusColl)
                {
                    await _db.MaritalStatus.AddAsync(maritalStatus, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded MaritalStatus.");
        }
    }
}

using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class NamePrefixSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<NamePrefixSeeder> _logger;

    public NamePrefixSeeder(ISerializerService serializerService, ILogger<NamePrefixSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.NamePrefixes.Any())
        {
            _logger.LogInformation("Started to Seed NamePrefix.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string namePrefixData = await File.ReadAllTextAsync(path + "/Lookup/NamePrefixSeeder.json", cancellationToken);
            var namePrefixes = _serializerService.Deserialize<List<NamePrefix>>(namePrefixData);

            if (namePrefixes != null)
            {
                foreach (var namePrefix in namePrefixes)
                {
                    await _db.NamePrefixes.AddAsync(namePrefix, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded NamePrefix.");
        }
    }
}
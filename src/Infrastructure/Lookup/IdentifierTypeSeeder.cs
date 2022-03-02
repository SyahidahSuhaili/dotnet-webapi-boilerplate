using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class IdentifierTypeSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<IdentifierTypeSeeder> _logger;

    public IdentifierTypeSeeder(ISerializerService serializerService, ILogger<IdentifierTypeSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.IdentifierTypes.Any())
        {
            _logger.LogInformation("Started to Seed IdentifierTypes.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string identifierTypeData = await File.ReadAllTextAsync(path + "/Lookup/IdentifierTypeSeeder.json", cancellationToken);
            var identifierTypes = _serializerService.Deserialize<List<IdentifierType>>(identifierTypeData);

            if (identifierTypes != null)
            {
                foreach (var identifierType in identifierTypes)
                {
                    await _db.IdentifierTypes.AddAsync(identifierType, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded IdentifierTypes.");
        }
    }
}
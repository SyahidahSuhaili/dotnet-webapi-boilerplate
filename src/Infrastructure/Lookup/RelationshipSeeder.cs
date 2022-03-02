using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class RelationshipSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<RelationshipSeeder> _logger;

    public RelationshipSeeder(ISerializerService serializerService, ILogger<RelationshipSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Relationships.Any())
        {
            _logger.LogInformation("Started to Seed Relationship.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string relationshipsData = await File.ReadAllTextAsync(path + "/Lookup/RelationshipSeeder.json", cancellationToken);
            var relationships = _serializerService.Deserialize<List<Relationship>>(relationshipsData);

            if (relationships != null)
            {
                foreach (var relationship in relationships)
                {
                    await _db.Relationships.AddAsync(relationship, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Relationship.");
        }
    }
}
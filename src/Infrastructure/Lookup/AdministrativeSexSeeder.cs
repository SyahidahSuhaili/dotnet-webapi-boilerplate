using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class AdministrativeSexSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<AdministrativeSexSeeder> _logger;

    public AdministrativeSexSeeder(ISerializerService serializerService, ILogger<AdministrativeSexSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.AdministrativeSex.Any())
        {
            _logger.LogInformation("Started to Seed AdministrativeSex.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string administrativeSexData = await File.ReadAllTextAsync(path + "/Lookup/AdministrativeSexSeeder.json", cancellationToken);
            var administrativeSexes = _serializerService.Deserialize<List<AdministrativeSex>>(administrativeSexData);

            if (administrativeSexes != null)
            {
                foreach (var administrativeSex in administrativeSexes)
                {
                    await _db.AdministrativeSex.AddAsync(administrativeSex, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded AdministrativeSex.");
        }
    }
}
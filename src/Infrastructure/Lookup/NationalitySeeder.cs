using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class NationalitySeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<NationalitySeeder> _logger;

    public NationalitySeeder(ISerializerService serializerService, ILogger<NationalitySeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Nationalities.Any())
        {
            _logger.LogInformation("Started to Seed Nationality.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string nationalityData = await File.ReadAllTextAsync(path + "/Lookup/NationalitySeeder.json", cancellationToken);
            var nationalities = _serializerService.Deserialize<List<Nationality>>(nationalityData);

            if (nationalities != null)
            {
                foreach (var nationality in nationalities)
                {
                    await _db.Nationalities.AddAsync(nationality, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Nationality.");
        }
    }
}
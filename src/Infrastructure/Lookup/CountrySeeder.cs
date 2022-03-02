using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class CountrySeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<CountrySeeder> _logger;

    public CountrySeeder(ISerializerService serializerService, ILogger<CountrySeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Countries.Any())
        {
            _logger.LogInformation("Started to Seed Country.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string countryData = await File.ReadAllTextAsync(path + "/Lookup/CountrySeeder.json", cancellationToken);
            var countries = _serializerService.Deserialize<List<Country>>(countryData);

            if (countryData != null)
            {
                foreach (var country in countries)
                {
                    await _db.Countries.AddAsync(country, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Country.");
        }
    }
}
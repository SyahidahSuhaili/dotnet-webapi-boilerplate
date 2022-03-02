using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class LanguageSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<LanguageSeeder> _logger;

    public LanguageSeeder(ISerializerService serializerService, ILogger<LanguageSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Languages.Any())
        {
            _logger.LogInformation("Started to Seed Language.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string languageData = await File.ReadAllTextAsync(path + "/Lookup/LanguageSeeder.json", cancellationToken);
            var languages = _serializerService.Deserialize<List<Language>>(languageData);

            if (languages != null)
            {
                foreach (var language in languages)
                {
                    await _db.Languages.AddAsync(language, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Language.");
        }
    }
}
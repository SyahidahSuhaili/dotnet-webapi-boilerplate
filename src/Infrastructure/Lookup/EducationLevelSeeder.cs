using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class EducationLevelSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<EducationLevelSeeder> _logger;

    public EducationLevelSeeder(ISerializerService serializerService, ILogger<EducationLevelSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.EducationLevels.Any())
        {
            _logger.LogInformation("Started to Seed EducationLevel.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string educationLevelData = await File.ReadAllTextAsync(path + "/Lookup/EducationLevelSeeder.json", cancellationToken);
            var educationLevels = _serializerService.Deserialize<List<EducationLevel>>(educationLevelData);

            if (educationLevels != null)
            {
                foreach (var educationLevel in educationLevels)
                {
                    await _db.EducationLevels.AddAsync(educationLevel, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded EducationLevel.");
        }
    }
}
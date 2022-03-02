using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class _InActiveStatusSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<_InActiveStatusSeeder> _logger;

    public _InActiveStatusSeeder(ISerializerService serializerService, ILogger<_InActiveStatusSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.InActiveStatus.Any())
        {
            _logger.LogInformation("Started to Seed InActiveStatus.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string inActiveStatusData = await File.ReadAllTextAsync(path + "/Lookup/InActiveStatusSeeder.json", cancellationToken);
            var inActiveStatus = _serializerService.Deserialize<List<InActiveStatus>>(inActiveStatusData);

            if (inActiveStatus != null)
            {
                foreach (var _inActiveStatus in inActiveStatus)
                {
                    await _db.InActiveStatus.AddAsync(_inActiveStatus, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded InActiveStatus.");
        }
    }
}

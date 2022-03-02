using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class InActiveReasonSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<InActiveReasonSeeder> _logger;

    public InActiveReasonSeeder(ISerializerService serializerService, ILogger<InActiveReasonSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.InActiveReasons.Any())
        {
            _logger.LogInformation("Started to Seed InActiveReason.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string inActiveReasonData = await File.ReadAllTextAsync(path + "/Lookup/InActiveReasonSeeder.json", cancellationToken);
            var inActiveReasons = _serializerService.Deserialize<List<InActiveReason>>(inActiveReasonData);

            if (inActiveReasons != null)
            {
                foreach (var inActiveReason in inActiveReasons)
                {
                    await _db.InActiveReasons.AddAsync(inActiveReason, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded InActiveReason.");
        }
    }
}

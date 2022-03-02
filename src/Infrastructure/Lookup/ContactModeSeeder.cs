using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Lookup;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Lookup;

public class ContactModeSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<ContactModeSeeder> _logger;

    public ContactModeSeeder(ISerializerService serializerService, ILogger<ContactModeSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;

        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.ContactModes.Any())
        {
            _logger.LogInformation("Started to Seed ContactMode.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string contactModeData = await File.ReadAllTextAsync(path + "/Lookup/ContactModeSeeder.json", cancellationToken);
            var contactModes = _serializerService.Deserialize<List<ContactMode>>(contactModeData);

            if (contactModes != null)
            {
                foreach (var contactMode in contactModes)
                {
                    await _db.ContactModes.AddAsync(contactMode, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded ContactMode.");
        }
    }
}
namespace FSH.WebApi.Host.Controllers.Public;
public class CreatePatientCommand : IRequest<Guid>
{
    public string NamePrefixId { get; set; } = default!;
    public string? FamilyName { get; set; }
    public string GivenName { get; set; } = default!;
    public string? Suffix { get; set; }
    public DateTime DOB { get; set; }
    public string AdministrativeSexId { get; set; } = default!;
    public string RaceId { get; set; } = default!;
    public string LanguageId { get; set; } = default!;
    public string ReligionId { get; set; } = default!;
    public string MaritalStatusId { get; set; } = default!;
    public string NationalityId { get; set; } = default!;
    public string CitizenId { get; set; } = default!;
    public string EducationLevelId { get; set; } = default!;
    public string? PhotoPath { get; set; }
    public string InActiveStatusId { get; set; } = default!;
    public string InActiveReasonId { get; set; } = default!;
    public DateTime? DeceasedDateTime { get; set; }
    public string? DeceasedFacility { get; set; }
    public string? DeceasedEncounter { get; set; }
}

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<PersonModel> _repository;

    public CreatePatientCommandHandler(IRepositoryWithEvents<PersonModel> repository) => _repository = repository;

    public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var person = new PersonModel(request.NamePrefixId, request.FamilyName, request.GivenName, request.Suffix, request.DOB, request.AdministrativeSexId, request.RaceId, request.LanguageId, request.ReligionId, request.MaritalStatusId, request.NationalityId, request.CitizenId, request.EducationLevelId, request.PhotoPath, request.InActiveStatusId, request.InActiveReasonId, request.DeceasedDateTime, request.DeceasedFacility, request.DeceasedEncounter);
        await _repository.AddAsync(person, cancellationToken);
        return person.Id;
    }
}
////https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-application-layer-implementation-web-api
////
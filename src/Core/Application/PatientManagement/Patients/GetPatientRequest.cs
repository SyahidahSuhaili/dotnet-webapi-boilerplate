namespace FSH.WebApi.Application.Public.People;
public class GetPatientRequest : IRequest<PatientDto>
{
    public Guid Id { get; set; }

    public GetPatientRequest(Guid id) => Id = id;
}

public class PatientByIdSpec : Specification<PersonModel, PatientDto>, ISingleResultSpecification
{
    public PatientByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetPersonRequestHandler : IRequestHandler<GetPatientRequest, PatientDto>
{
    private readonly IRepository<PersonModel> _repository;
    private readonly IStringLocalizer<GetPersonRequestHandler> _localizer;

    public GetPersonRequestHandler(IRepository<PersonModel> repository, IStringLocalizer<GetPersonRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<PatientDto> Handle(GetPatientRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<PersonModel, PatientDto>)new PatientByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Person.notfound"], request.Id));
}
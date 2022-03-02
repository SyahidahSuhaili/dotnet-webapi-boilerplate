namespace FSH.WebApi.Application.Public.People;

public class SearchPatientsRequest : PaginationFilter, IRequest<PaginationResponse<PatientDto>>
{
}

public class PatientsBySearchRequestSpec : EntitiesByPaginationFilterSpec<PersonModel, PatientDto>
{
    public PatientsBySearchRequestSpec(SearchPatientsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.GivenName, !request.HasOrderBy());
}

public class SearchBrandsRequestHandler : IRequestHandler<SearchPatientsRequest, PaginationResponse<PatientDto>>
{
    private readonly IReadRepository<PersonModel> _repository;

    public SearchBrandsRequestHandler(IReadRepository<PersonModel> repository) => _repository = repository;

    public async Task<PaginationResponse<PatientDto>> Handle(SearchPatientsRequest request, CancellationToken cancellationToken)
    {
        var spec = new PatientsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<PatientDto>(list, count, request.PageNumber, request.PageSize);
    }
}
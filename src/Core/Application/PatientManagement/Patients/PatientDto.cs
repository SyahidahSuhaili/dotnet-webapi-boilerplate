using FSH.WebApi.Domain.Public;
namespace FSH.WebApi.Application.Public.People;
public class PatientDto : IDto
{
    public Guid Id { get; set; }
    public string MedicalRecordNumber { get; set; } = default!;
    public PersonModel? Person { get; set; }
}

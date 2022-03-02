using FSH.WebApi.Domain.Public;

namespace FSH.WebApi.Domain.PatientManagement;

public class PatientModel : AuditableEntity, IAggregateRoot
{
    public string MedicalRecordNumber { get; set; }
    public Guid? PersonId { get; set; }
    public virtual PersonModel Person { get; private set; } = default!;
    public PatientModel(string medicalRecordNumber, Guid? personId )
    {
        MedicalRecordNumber = medicalRecordNumber;
        PersonId = personId;
    }
}

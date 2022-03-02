namespace FSH.WebApi.Domain.Common.Contracts;

public abstract class AuditableLookupEntity : AuditableLookupEntity<StringIdType>
{
}

public abstract class AuditableLookupEntity<T> : BaseEntityForLookup<T>, ILookupEntity, IAuditableEntity, ISoftDelete
{
    public int? Sequence { get; set; }
    public bool IsDefaultIndicator { get; set; }
    public bool IsSystemIndicator { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; private set; }
    public string CreatedAt { get; set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public string? LastModifiedAt { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
    public string? DeletedAt { get; set; }

    protected AuditableLookupEntity()
    {
        CreatedOn = DateTime.UtcNow;
        LastModifiedOn = DateTime.UtcNow;
    }
}

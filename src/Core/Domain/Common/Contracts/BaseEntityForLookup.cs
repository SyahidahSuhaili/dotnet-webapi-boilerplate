using System.ComponentModel.DataAnnotations.Schema;

namespace FSH.WebApi.Domain.Common.Contracts;

public abstract class BaseEntityForLookup : BaseEntityForLookup<DefaultIdType>
{
}

public abstract class BaseEntityForLookup<TId>
{
    public string Id { get; set; } = default!;
    [NotMapped]
    public List<DomainEvent> DomainEvents { get; } = new();
}
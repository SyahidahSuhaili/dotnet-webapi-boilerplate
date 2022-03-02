namespace FSH.WebApi.Domain.Lookup;

public class InActiveReason : AuditableLookupEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string InActiveStatusId { get; private set; }
    public virtual InActiveStatus InActiveStatus { get; private set; } = default!;
    public InActiveReason(string name, string? description, string inActiveStatusId)
    {
        Name = name;
        Description = description;
        InActiveStatusId = inActiveStatusId;
    }

    public InActiveReason Update(string name, string? description, string inActiveStatusId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (inActiveStatusId is not null && InActiveStatusId?.Equals(inActiveStatusId) is not true) InActiveStatusId = inActiveStatusId;
        return this;
    }
}
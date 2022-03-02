namespace FSH.WebApi.Domain.Lookup;

public class NamePrefix : AuditableLookupEntity, IAggregateRoot
{
    public string AdministrativeSexId { get; private set; }
    public virtual AdministrativeSex AdministrativeSex { get; private set; } = default!;
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public NamePrefix(string administrativeSexId, string name, string? description)
    {
        AdministrativeSexId = administrativeSexId;
        Name = name;
        Description = description;
    }

    public NamePrefix Update(string administrativeSexId, string name, string? description)
    {
        if (administrativeSexId is not null && AdministrativeSexId?.Equals(administrativeSexId) is not true) AdministrativeSexId = administrativeSexId;
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}
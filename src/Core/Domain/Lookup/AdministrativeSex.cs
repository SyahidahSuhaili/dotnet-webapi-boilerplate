﻿namespace FSH.WebApi.Domain.Lookup;

public class AdministrativeSex : AuditableLookupEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public AdministrativeSex(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public AdministrativeSex Update(string name, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}
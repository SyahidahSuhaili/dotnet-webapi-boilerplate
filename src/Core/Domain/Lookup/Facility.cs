﻿namespace FSH.WebApi.Domain.Lookup;

public class Facility : AuditableLookupEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Facility(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public Facility Update(string name, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}


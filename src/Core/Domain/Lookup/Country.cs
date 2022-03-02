namespace FSH.WebApi.Domain.Lookup;

public class Country : AuditableLookupEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? TwoLettersIsoCode { get; set; }
    public string? ThreeLettersIsoCode { get; set; }
    public string? NumericIsoCode { get; set; }
    public Country(string name,string? twoLettersIsoCode,string? threeLettersIsoCode,string? numericIsoCode)
    {
        Name = name;
        TwoLettersIsoCode = twoLettersIsoCode;
        ThreeLettersIsoCode = threeLettersIsoCode;
        NumericIsoCode = numericIsoCode;
    }

    public Country Update(string name,string? twoLettersIsoCode,string? threeLettersIsoCode,string? numericIsoCode)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (twoLettersIsoCode is not null && TwoLettersIsoCode?.Equals(twoLettersIsoCode) is not true) TwoLettersIsoCode = twoLettersIsoCode;
        if (threeLettersIsoCode is not null && ThreeLettersIsoCode?.Equals(threeLettersIsoCode) is not true) ThreeLettersIsoCode = threeLettersIsoCode;
        if (numericIsoCode is not null && NumericIsoCode?.Equals(numericIsoCode) is not true) NumericIsoCode = numericIsoCode;
        return this;
    }
}
namespace FSH.WebApi.Domain.Common.Contracts;

public interface ILookupEntity
{
    public int? Sequence { get; set; }
    public bool IsDefaultIndicator { get; set; }
    public bool IsSystemIndicator { get; set; }
}

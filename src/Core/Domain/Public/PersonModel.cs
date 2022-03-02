using FSH.WebApi.Domain.Lookup;
namespace FSH.WebApi.Domain.Public;

public class PersonModel : AuditableEntity, IAggregateRoot
{
    public string NamePrefixId { get; set; } = default!;
    public virtual NamePrefix NamePrefix { get; private set; } = default!;
    public string? FamilyName { get; set; }
    public string GivenName { get; set; } = default!;
    public string? Suffix { get; set; }
    public DateTime DOB { get; set; }
    public string AdministrativeSexId { get; set; }
    public virtual AdministrativeSex AdministrativeSex { get; private set; } = default!;

    public string RaceId { get; set; } = default!;

    public virtual Race Race { get; private set; } = default!;
    public string LanguageId { get; set; } = default!;
    public virtual Language Language { get; private set; } = default!;

    public string ReligionId { get; set; } = default!;
    public virtual Religion Religion { get; private set; } = default!;
    public string MaritalStatusId { get; set; } = default!;
    public virtual MaritalStatus MaritalStatus { get; private set; } = default!;
    public string NationalityId { get; set; } = default!;
    public virtual Nationality Nationality { get; private set; } = default!;
    public string CitizenId { get; set; } = default!;
    public virtual Nationality Citizen { get; private set; } = default!;
    public string EducationLevelId { get; set; } = default!;
    public virtual EducationLevel EducationLevel { get; private set; } = default!;
    public string? PhotoPath { get; set; }
    public string InActiveStatusId { get; set; } = default!;
    public virtual InActiveStatus InActiveStatus { get; private set; } = default!;
    public string InActiveReasonId { get; set; } = default!;
    public virtual InActiveReason InactiveReason { get; private set; } = default!;
    public DateTime? DeceasedDateTime { get; set; }
    public string? DeceasedFacility { get; set; }
    public string? DeceasedEncounter { get; set; }
    public PersonModel(string namePrefixId, string? familyName, string givenName, string? suffix, DateTime dOB, string administrativeSexId, string raceId, string languageId, string religionId, string maritalStatusId, string nationalityId, string citizenId, string educationLevelId, string? photoPath, string inActiveStatusId, string inActiveReasonId, DateTime? deceasedDateTime, string? deceasedFacility, string? deceasedEncounter)
    {
        NamePrefixId = namePrefixId;
        FamilyName = familyName;
        GivenName = givenName;
        Suffix = suffix;
        DOB = dOB;
        AdministrativeSexId = administrativeSexId;

        RaceId = raceId;
        LanguageId = languageId;
        ReligionId = religionId;
        MaritalStatusId = maritalStatusId;
        NationalityId = nationalityId;
        CitizenId = citizenId;
        EducationLevelId = educationLevelId;
        PhotoPath = photoPath;
        InActiveStatusId = inActiveStatusId;
        InActiveReasonId = inActiveReasonId;
        DeceasedDateTime = deceasedDateTime;
        DeceasedFacility = deceasedFacility;
        DeceasedEncounter = deceasedEncounter;

    }

    public PersonModel Update(string namePrefixId, string? familyName, string givenName, string? suffix, DateTime dOB, string administrativeSexId, string raceId, string languageId, string religionId, string maritalStatusId, string nationalityId, string citizenId, string educationLevelId, string? photoPath, string inActiveStatusId, string inActiveReasonId, DateTime? deceasedDateTime, string? deceasedFacility, string? deceasedEncounter)
    {
        if (namePrefixId is not null && NamePrefixId?.Equals(namePrefixId) is not true) NamePrefixId = namePrefixId;
        if (familyName is not null && FamilyName?.Equals(familyName) is not true) FamilyName = familyName;
        if (givenName is not null && GivenName?.Equals(givenName) is not true) GivenName = givenName;
        if (suffix is not null && Suffix?.Equals(suffix) is not true) Suffix = suffix;
        DOB = dOB;
        if (administrativeSexId is not null && AdministrativeSexId?.Equals(administrativeSexId) is not true) AdministrativeSexId = administrativeSexId;

        if (raceId is not null && RaceId?.Equals(raceId) is not true) RaceId = raceId;
        if (languageId is not null && LanguageId?.Equals(languageId) is not true) LanguageId = languageId;
        if (religionId is not null && ReligionId?.Equals(religionId) is not true) ReligionId = religionId;
        if (maritalStatusId is not null && MaritalStatusId?.Equals(maritalStatusId) is not true) MaritalStatusId = maritalStatusId;
        if (nationalityId is not null && NationalityId?.Equals(nationalityId) is not true) NationalityId = nationalityId;
        if (citizenId is not null && CitizenId?.Equals(citizenId) is not true) CitizenId = citizenId;
        if (educationLevelId is not null && EducationLevelId?.Equals(educationLevelId) is not true) EducationLevelId = educationLevelId;
        if (photoPath is not null && PhotoPath?.Equals(photoPath) is not true) PhotoPath = photoPath;
        if (inActiveStatusId is not null && InActiveStatusId?.Equals(inActiveStatusId) is not true) InActiveStatusId = inActiveStatusId;
        if (inActiveReasonId is not null && InActiveReasonId?.Equals(inActiveReasonId) is not true) InActiveReasonId = inActiveReasonId;
        if (deceasedDateTime is not null && DeceasedDateTime?.Equals(deceasedDateTime) is not true) DeceasedDateTime = deceasedDateTime;
        if (deceasedFacility is not null && DeceasedFacility?.Equals(deceasedFacility) is not true) DeceasedFacility = deceasedFacility;
        if (deceasedEncounter is not null && DeceasedEncounter?.Equals(deceasedEncounter) is not true) DeceasedEncounter = deceasedEncounter;

        return this;
    }
}
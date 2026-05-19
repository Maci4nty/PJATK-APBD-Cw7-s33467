namespace APBDCW07.DTOs;

public record ManufacturerResponse(
    int Id,
    string Abbreviation,
    string FullName,
    object FoundationDate
    );
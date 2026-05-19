namespace APBDCW07.DTOs;

public record PCDetailsResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PCComponentsResponse> Components
    );
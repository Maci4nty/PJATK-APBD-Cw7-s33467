namespace APBDCW07.DTOs;

public record ComponentResponse(
    string Code,
    string Name,
    string Description,
    ManufacturerResponse Manufacturer,
    ComponentTypeResponse Type
    );
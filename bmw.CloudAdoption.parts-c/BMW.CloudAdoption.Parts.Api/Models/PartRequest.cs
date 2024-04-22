namespace BMW.CloudAdoption.Parts.Api.Models;

public record PartRequest(
    string PartNumber,
    string PartString,
    UnitType UnitType,
    bool Assembled,
    Status Status,
    int GrossWeight,
    int NetWeight,
    WeightUnit WeightUnit,
    PlantRequest Plant,
    SupplierRequest Supplier);

public record PlantRequest(string Id, string UnloadPoint);
public record SupplierRequest(string Id, string Name);
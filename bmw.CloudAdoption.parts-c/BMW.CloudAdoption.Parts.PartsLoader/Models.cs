namespace BMW.CloudAdoption.Parts.PartsLoader;

public record PartRequest(
    string PartNumber,
    string PartString,
    UnitType UnitType,
    bool Assembled,
    Status Status,
    int GrossWeight,
    int NetWeight,
    string WeightUnit,
    PlantRequest Plant,
    SupplierRequest Supplier);
   
public record PlantRequest(string Id, string UnloadPoint);

public record SupplierRequest(string Id, string Name);

public enum UnitType
{
    SINGLE_PIECE,
    SMALL_BOX,
    LARGE_BOX
}

public enum Status
{
    NEW, 
    VALID, 
    DISCONTINUED
}
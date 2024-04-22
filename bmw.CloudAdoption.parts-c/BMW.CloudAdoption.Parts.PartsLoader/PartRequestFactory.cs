namespace BMW.CloudAdoption.Parts.PartsLoader;

public static class PartRequestFactory
{
    public static List<PartRequest> GeneratePartRequests(int count)
    {
        var rnd = new Random(Random.Shared.Next());
        var requests = new List<PartRequest>();
        
        for (var index = 0; index < count; index++)
        {
            var plantId = rnd.Next(1, 9);
            var supplierId = rnd.Next(1, 9);

            var plantRequest = new PlantRequest($"plant-{plantId}", $"point-{rnd.Next(1, 9)}");
            var supplierRequest = new SupplierRequest($"S{supplierId}", $"supplier-{supplierId}");

            var partRequest = new PartRequest(
                $"part-{rnd.Next(1, 999):D3}",
                $"{rnd.Next(1, 99999):D5}",
                rnd.OneOf(UnitType.LARGE_BOX, UnitType.SMALL_BOX, UnitType.SINGLE_PIECE),
                rnd.OneOf(true, false),
                rnd.OneOf(Status.NEW, Status.VALID, Status.DISCONTINUED),
                rnd.Next(11, 20),
                rnd.Next(1, 10),
                rnd.OneOf("g", "kg"),
                plantRequest,
                supplierRequest);

            requests.Add(partRequest);
        }

        return requests;
    }
}

public static class Extensions
{
    public static T OneOf<T>(this Random @this, params T[] values)
    {
        return values[@this.Next(values.Length)];
    }
}
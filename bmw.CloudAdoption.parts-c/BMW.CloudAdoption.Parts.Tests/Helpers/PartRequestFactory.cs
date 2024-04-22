using BMW.CloudAdoption.Parts.Api.Enums;
using BMW.CloudAdoption.Parts.Api.Models;

namespace BMW.CloudAdoption.Parts.Tests.Helpers;

public static class PartRequestFactory
{
    public static List<PartRequest> GeneratePartRequests(int count)
    {
        var rnd = new Random(Random.Shared.Next());
        var requests = new List<PartRequest>();

        for (var index = 0; index < count; index++)
        {
            var partNumber = rnd.Next(1, 9999999);
            var plantId = rnd.Next(1, 9);
            var supplierId = rnd.Next(1, 9);

            var plantRequest = new PlantRequest($"pid-{plantId}", $"unload-point-{rnd.Next(1, 9)}");
            var supplierRequest = new SupplierRequest($"sid-{supplierId}", $"supplier-{supplierId}");

            var partRequest = new PartRequest(
                $"{partNumber:D7}01",
                $"part-{rnd.Next(1, 99999):D5}",
                rnd.OneOf(UnitType.LARGE_BOX, UnitType.SMALL_BOX, UnitType.SINGLE_PIECE),
                rnd.OneOf(true, false),
                Status.NEW,
                rnd.Next(11, 20),
                rnd.Next(1, 10),
                rnd.OneOf(Enum.GetValues<WeightUnit>()),
                plantRequest,
                supplierRequest);

            requests.Add(partRequest);
        }

        return requests;
    }
}
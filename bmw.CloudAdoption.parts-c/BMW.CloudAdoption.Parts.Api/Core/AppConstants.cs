using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace BMW.CloudAdoption.Parts.Api.Core;

public static class AppConstants
{
    public static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        Converters = { new StringEnumConverter() },
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
}
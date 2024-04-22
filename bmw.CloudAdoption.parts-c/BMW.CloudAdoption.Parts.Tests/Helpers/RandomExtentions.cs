namespace BMW.CloudAdoption.Parts.Tests.Helpers;

public static class Extensions
{
    public static T OneOf<T>(this Random @this, params T[] values)
    {
        return values[@this.Next(values.Length)];
    }
}
using System.Collections.Concurrent;
namespace BMW.CloudAdoption.Parts.Api.Repositories;

public class PartsCacheConcurrentDictionary : ConcurrentDictionary<string, PartRequest> { }

public class PartsCacheRepository : IPartsRepository
{
    private readonly PartsCacheConcurrentDictionary _partCollection;

    public PartsCacheRepository(PartsCacheConcurrentDictionary partCollection)
    {
        _partCollection = partCollection;
    }

    public Task<PartRequest?> GetAsync(string partNumber)
    {
        _partCollection.TryGetValue(partNumber, out var part);
        return Task.FromResult(part);
    }

    public Task<IEnumerable<PartRequest>> GetAllAsync()
    {
        var parts = _partCollection.Values.ToList();
        return Task.FromResult(parts.AsEnumerable());
    }

    public Task AddOrUpdateAsync(PartRequest part)
    {
        _partCollection.AddOrUpdate(part.PartNumber, (_) => part, (_, _) => part);
        return Task.CompletedTask;
    }
    
    public Task DeleteAsync(string partNumber)
    {
        _partCollection.Remove(partNumber, out _);
        return Task.CompletedTask;
    }
}
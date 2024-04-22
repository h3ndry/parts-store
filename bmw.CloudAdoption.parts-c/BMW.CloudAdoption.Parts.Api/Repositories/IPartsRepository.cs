namespace BMW.CloudAdoption.Parts.Api.Repositories;

public interface IPartsRepository
{
    Task<PartRequest?> GetAsync(string partNumber);
    Task<IEnumerable<PartRequest>> GetAllAsync();
    Task AddOrUpdateAsync(PartRequest part);
    Task DeleteAsync(string partNumber);
}
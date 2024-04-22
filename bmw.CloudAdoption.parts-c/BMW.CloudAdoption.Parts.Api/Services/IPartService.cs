namespace BMW.CloudAdoption.Parts.Api.Services;

public interface IPartService
{
    Task<IEnumerable<PartRequest>> GetAllAsync();
    Task<PartRequest?> GetAsync(string partNumber);
    Task<bool> CreateAsync(PartRequest part);
    Task<bool> UpdateAsync(PartRequest part);
    Task<bool> DeleteAsync(string partNumber);
}
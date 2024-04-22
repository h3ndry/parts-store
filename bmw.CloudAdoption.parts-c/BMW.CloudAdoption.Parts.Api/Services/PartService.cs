namespace BMW.CloudAdoption.Parts.Api.Services;

public class PartService : IPartService
{
    private readonly PartsProducer _kafkaPartProducer;
    private readonly IPartsRepository _partsRepository;

    public PartService(PartsProducer kafkaPartProducer, IPartsRepository partsRepository)
    {
        _kafkaPartProducer = kafkaPartProducer;
        _partsRepository = partsRepository;
    }

    public async Task<IEnumerable<PartRequest>> GetAllAsync()
    {
        var parts = await _partsRepository.GetAllAsync();
        return parts;
    }

    public async Task<PartRequest?> GetAsync(string partNumber)
    {
        var part = await _partsRepository.GetAsync(partNumber);
        return part;
    }

    public async Task<bool> CreateAsync(PartRequest partRequest)
    {
        var currentPart = await _partsRepository.GetAsync(partRequest.PartNumber);
        if (currentPart is not null)
            throw new Exception($"A Part with PartNumber {partRequest.PartNumber} already exists");
        
        _kafkaPartProducer.Produce(partRequest.PartNumber, partRequest);
        return true;
    }

    public async Task<bool> UpdateAsync(PartRequest partRequest)
    {
        var currentPart = await _partsRepository.GetAsync(partRequest.PartNumber);
        if (currentPart is null)
            return false;
        
        _kafkaPartProducer.Produce(currentPart.PartNumber, partRequest);
        return true;
    }

    public async Task<bool> DeleteAsync(string partNumber)
    {
        var currentPart = await _partsRepository.GetAsync(partNumber);
        if (currentPart is null || currentPart.Status == Status.DISCONTINUED)
            return false;

        _kafkaPartProducer.Produce(partNumber, null);
        return true;
    }
}
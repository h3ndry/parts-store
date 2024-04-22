namespace BMW.CloudAdoption.Parts.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartController : ControllerBase
{
    private readonly IPartService _partService;

    public PartController(IPartService partsService)
    {
        _partService = partsService;
    }
  
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PartRequest>>> Get()
    {
        return Ok(await _partService.GetAllAsync());
    }
    
    [HttpGet("{partNumber}")]
    public async Task<ActionResult<PartRequest>> Get(string partNumber)
    {
        var part = await _partService.GetAsync(partNumber);
        if (part is null)
            return NotFound();

        return Ok(part);
    }
  
    [HttpPost]
    public async Task<IActionResult> Post(PartRequest part)
    {
        await _partService.CreateAsync(part);
        return Accepted();
    }
   
    [HttpPut("{partNumber}")]
    public async Task<IActionResult> Put(PartRequest part)
    {
        var updated = await _partService.UpdateAsync(part);
        return updated ? Accepted() : NotFound();
    }
    
    [HttpDelete("{partNumber}")]
    public async Task<ActionResult> Delete(string partNumber)
    {
        var deleted = await _partService.DeleteAsync(partNumber);
        return deleted ? Ok() : NotFound(StatusCode(400));
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MTDotNetCore.RestApiWithNLayer.Features.DreamDictionary;

[Route("api/[controller]")]
[ApiController]
public class DreamDictionaryController : ControllerBase
{
    private readonly string _jsonFileName = "dataDreamDictionary.json";
    private async Task<DreamDictionary> GetDataAsync()
    {
        string jsonData = await System.IO.File.ReadAllTextAsync(_jsonFileName);
        var model = JsonConvert.DeserializeObject<DreamDictionary>(jsonData);
        return model;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var model = await GetDataAsync();
        return Ok(model);
    }

    [HttpGet("header")]
    public async Task<IActionResult> GetDreamHeader()
    {
        var model = await GetDataAsync();
        return Ok(model.BlogHeader);
    }

    [HttpGet("header/{headerId}")]
    public async Task<IActionResult> GetDreamHeader(int headerId)
    {
        var model = await GetDataAsync();
        var dreamHeader = model.BlogHeader.FirstOrDefault(x => x.BlogId == headerId);

        if (dreamHeader is null) return NotFound($"No data found for Id: {headerId}");

        return Ok(dreamHeader);
    }

    [HttpGet("details/{headerId}")]
    public async Task<IActionResult> GetDreamDetails(int headerId)
    {
        var model = await GetDataAsync();
        var lst = model.BlogDetail.Where(x => x.BlogId == headerId);
        if (lst.Count() == 0) return NotFound($"No data found for headerId {headerId}");

        return Ok(lst);
    }

    [HttpGet("details/{headerId}/{detailId}")]
    public async Task<IActionResult> GetDreamDetails(int headerId, int detailId)
    {
        var model = await GetDataAsync();

        var dreamHeader = model.BlogHeader.FirstOrDefault(x => x.BlogId == headerId);
        if (dreamHeader is null) return NotFound($"No data found for headerId: {headerId}");

        var dreamDetails = model.BlogDetail.FirstOrDefault(x => x.BlogId == headerId && x.BlogDetailId == detailId);
        if (dreamDetails is null) return NotFound($"No data found for detailsId {detailId}");

        return Ok(dreamDetails);
    }
}


public class DreamDictionary
{
    public Blogheader[] BlogHeader { get; set; }
    public Blogdetail[] BlogDetail { get; set; }
}

public class Blogheader
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
}

public class Blogdetail
{
    public int BlogDetailId { get; set; }
    public int BlogId { get; set; }
    public string BlogContent { get; set; }
}


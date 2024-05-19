using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MTDotNetCore.RestApiWithNLayer.Features.DreamDictionary;

[Route("api/[controller]")]
[ApiController]
public class DreamDictionaryController : ControllerBase
{
    private async Task<DreamDictionary> GetDataAsync()
    {
        string jsonData = await System.IO.File.ReadAllTextAsync("DreamDictionary.json");
        var model = JsonConvert.DeserializeObject<DreamDictionary>(jsonData);
        return model;
    }

    [HttpGet("header")]
    public async Task<IActionResult> GetDreamHeader()
    {
        var model = await GetDataAsync();
        return Ok(model.BlogHeader);
    }

    [HttpGet("details/{headerId}/{detailId}")]
    public async Task<IActionResult> GetDreamDetails(int headerId, int detailId)
    {
        var model = await GetDataAsync();

        var dreamDetails = model.BlogDetail.FirstOrDefault(x=> x.BlogId == headerId && x.BlogDetailId == detailId);
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


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MTDotNetCore.RestApiWithNLayer.Features.MyanmarProverbs;

[Route("api/[controller]")]
[ApiController]
public class MyanmarProverbsController : ControllerBase
{
    private readonly string _myanmarProverbsJsonUrl = "https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json";

    private readonly string _jsonFileName = "dataMyanmarProverbs.json";

    private async Task<MyanmarProverbs> GetDataFromApiAsync()
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(_myanmarProverbsJsonUrl);
        if (!response.IsSuccessStatusCode) return null;

        string jsonStr = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<MyanmarProverbs>(jsonStr);
        return model;
    }

    private async Task<MyanmarProverbs> GetDataFromJsonFile()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync(_jsonFileName);
        var model = JsonConvert.DeserializeObject<MyanmarProverbs>(jsonStr);
        return model;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var model = await GetDataFromApiAsync();
        return Ok(model.Tbl_MMProverbsTitle);
    }

    [HttpGet("titleName")]
    public async Task<IActionResult> Get(string titleName)
    {
        var model = await GetDataFromJsonFile();
        var item = model.Tbl_MMProverbsTitle.Where(x => x.TitleName == titleName).FirstOrDefault();
        if (item is null) return NotFound($"No data found for proverb title : {titleName}");

        int titleId = item.TitleId;
        var lst = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);
        return Ok(lst);
    }

    [HttpGet("titleId")]
    public async Task<IActionResult> GetProverTitleOnly(int titleId)
    {
        var model = await GetDataFromJsonFile();
        var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);

        List<Tbl_MmproverbsHead> lst = result.Select(x => new Tbl_MmproverbsHead
        {
            TitleId = x.TitleId,
            ProverbId = x.ProverbId,
            ProverbName = x.ProverbName

        }).ToList();

        return Ok(lst);
    }
}

public class MyanmarProverbs
{
    public Tbl_MmproverbsTitle[] Tbl_MMProverbsTitle { get; set; }
    public Tbl_Mmproverbs[] Tbl_MMProverbs { get; set; }
}

public class Tbl_MmproverbsTitle
{
    public int TitleId { get; set; }
    public string TitleName { get; set; }
}

public class Tbl_Mmproverbs
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
    public string ProverbDesp { get; set; }
}

public class Tbl_MmproverbsHead
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
}

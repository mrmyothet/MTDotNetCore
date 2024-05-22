using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MTDotNetCore.RestApiWithNLayer.Features.MyanmarProverbs;

[Route("api/[controller]")]
[ApiController]
public class MyanmarProverbsController : ControllerBase
{
    private async Task<MyanmarProverbs> GetDataFromApiAsync()
    {
        string myanmarProverbsJsonUrl = "https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json";

        HttpClient client = new HttpClient();
        var response = await client.GetAsync(myanmarProverbsJsonUrl);
        if(response.IsSuccessStatusCode) 
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<MyanmarProverbs>(jsonStr);
            return model;
        }
        return null;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var model = await GetDataFromApiAsync();
        return Ok(model.Tbl_MMProverbsTitle);
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

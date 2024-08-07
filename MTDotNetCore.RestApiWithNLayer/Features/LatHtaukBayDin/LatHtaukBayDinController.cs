﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTDotNetCore.RestApiWithNLayer.Features.LatHtaukBayDin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatHtaukBayDinController : ControllerBase
    {
        private readonly string _jsonFileName = "dataLatHtaukBayDin.json";
        private async Task<LatHtaukBayDin> GetDataAsync()
        {
            var jsonData = await System.IO.File.ReadAllTextAsync(_jsonFileName);
            var model = JsonConvert.DeserializeObject<LatHtaukBayDin>(jsonData);
            return model;
        }

        // End Point - api/LatHtaukBayDin/questions
        [HttpGet("questions")]
        public async Task<IActionResult> Questions()
        {
            var model = await GetDataAsync();
            return Ok(model.questions);
        }

        [HttpGet("number")]
        public async Task<IActionResult> NumberList()
        {
            var model = await GetDataAsync();
            return Ok(model.numberList);
        }

        [HttpGet("{questionNo}/{answerNo}")]
        public async Task<IActionResult> Answer(int questionNo, int answerNo)
        {
            var model = await GetDataAsync();
            var result = model.answers.FirstOrDefault(x => x.questionNo == questionNo && x.answerNo == answerNo);
            return Ok(result);
        }
    }


    public class LatHtaukBayDin
    {
        public Question[] questions { get; set; }
        public Answer[] answers { get; set; }
        public string[] numberList { get; set; }
    }

    public class Question
    {
        public int questionNo { get; set; }
        public string questionName { get; set; }
    }

    public class Answer
    {
        public int questionNo { get; set; }
        public int answerNo { get; set; }
        public string answerResult { get; set; }
    }

}

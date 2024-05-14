using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDotNetCore.ConsoleAppHttpClientExamples
{
    internal class HttpClientExamples
    {
        private readonly HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:7233") };
        private readonly string _blogEndpoint = "/api/blog";

        public async void RunAsync()
        {
            //ReadAsync().Wait();
            await ReadAsync();
        }

        private async Task ReadAsync()
        {
            var response = await _httpClient.GetAsync(_blogEndpoint);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();

                List<BlogObject> lst = JsonConvert.DeserializeObject<List<BlogObject>>(jsonStr)!;
                foreach (var item in lst)
                {
                    //Console.WriteLine(JsonConvert.SerializeObject(item));

                    Console.WriteLine($"Title => {item.BlogTitle}");
                    Console.WriteLine($"Author => {item.BlogAuthor}");
                    Console.WriteLine($"Content => {item.BlogContent}");
                    await Console.Out.WriteLineAsync("==========");
                }
            }
        }
    }
}

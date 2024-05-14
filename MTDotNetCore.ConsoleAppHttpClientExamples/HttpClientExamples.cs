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

        public async Task RunAsync()
        {
            // await ReadAsync();

            //await EditAsync(1);
            //await EditAsync(100);

            await DeleteAsync(100);
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

        private async Task EditAsync(int id)
        {
            var item = await FindByIdAsync(id);

            if (item is null)
            {
                await Console.Out.WriteLineAsync("Data Not Found");
                return;
            }

            Console.WriteLine(JsonConvert.SerializeObject(item));

            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
        }

        private async Task DeleteAsync(int id)
        {
            var item = await FindByIdAsync(id);

            if (item is null)
            {
                await Console.Out.WriteLineAsync($"Data Not Found for the Id:{id}");
                return;
            }

            var response = await _httpClient.DeleteAsync($"{_blogEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                // other process 
                // continue ...
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                // error message 
                // break
            }
            
        }

        private async Task<BlogObject?> FindByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_blogEndpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();

                BlogObject item = JsonConvert.DeserializeObject<BlogObject>(jsonStr)!;
                return item;
            }

            return null;
        }
    }
}

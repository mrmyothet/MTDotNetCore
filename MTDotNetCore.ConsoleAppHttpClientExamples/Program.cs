Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();
var response = await client.GetAsync("https://localhost:7233/api/blog");

if (response.IsSuccessStatusCode)
{
    string jsonStr = await response.Content.ReadAsStringAsync();
    Console.WriteLine(jsonStr);
}

Console.ReadLine();
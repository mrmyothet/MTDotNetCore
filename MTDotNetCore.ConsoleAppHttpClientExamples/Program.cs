using MTDotNetCore.ConsoleAppHttpClientExamples;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");

HttpClientExamples httpClientExample = new HttpClientExamples();
httpClientExample.RunAsync();

Console.ReadLine();

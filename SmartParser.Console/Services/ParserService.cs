namespace SmartParser.Console.Service;

using System.Text.Json;
using System;



public class ParserService
{
    public async Task<List<NewsItem>> ParseNewsAsync()
    {
        try
        {
            Console.WriteLine("Starting parsing...");
            using var client = new HttpClient();
            var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            Console.WriteLine($"Response received, length: {response.Length}");

            var news = JsonSerializer.Deserialize<List<NewsItem>>(response);
            Console.WriteLine($"Deserialized {news?.Count ?? 0} items");

            return news ?? new List<NewsItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<NewsItem>();
        }
    }
}
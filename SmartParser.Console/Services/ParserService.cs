namespace SmartParser.Console.Service;

using System.Text.Json;
using System;

public class ParserService
{
    private readonly HttpClient _client;

    public ParserService(HttpClient client) => _client = client;

    public async Task<List<NewsItem>> ParseNewsAsync()
    {
        try
        {
            Console.WriteLine("Starting parsing...");
            var response = await _client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

            var filteredNews = JsonSerializer.Deserialize<List<NewsItem>>(response)?
                .Where(n => !string.IsNullOrEmpty(n.Title)) // отфильтровать пустые заголовки
                .Where(n => n.Title.Length > 5)             // заголовки длиннее 5 символов  
                .Take(20)                                   // взять первые 20
                .ToList() ?? new List<NewsItem>();

            return filteredNews ?? new List<NewsItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<NewsItem>();
        }
    }

    public string CategorizeNews(NewsItem news)
    {
        return news.Title.ToLower() switch
        {
            string t when t.Contains("error") => "Error",
            string t when t.Contains("update") => "Update",
            string t when t.Contains("new") => "New Feature",
            _ => "General"
        };
    }
}
using System.Text.Json;

namespace SmartParser.Console.Service;

public class ParserService
{
    public async Task<List<NewsItem>> ParseNewsAsync()
    {
        try
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

            var news = JsonSerializer.Deserialize<List<NewsItem>>(response);
            return news ?? new List<NewsItem>();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error parsing news: {ex.Message}");
            throw;
        }
    }
}
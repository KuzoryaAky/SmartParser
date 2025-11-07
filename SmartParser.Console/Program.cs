using SmartParser.Console.Service;

var parser = new ParserService();
var news = await parser.ParseNewsAsync();

Console.WriteLine($"Parsed {news.Count} news items");

// Вывод первых 3 новостей для проверки
foreach (var item in news.Take(3))
{
    Console.WriteLine($"Title: {item.Title}");
    Console.WriteLine($"Body: {item.Body?.Substring(0, Math.Min(50, item.Body.Length))}...");
    Console.WriteLine("---");
}

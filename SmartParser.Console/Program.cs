using SmartParser.Console.Service;

var parser = new ParserService();
var news = await parser.ParseNewsAsync();

Console.WriteLine($"Parsed {news.Count} news items");
Console.WriteLine();

// Вывод первых 3 новостей для проверки
foreach (var item in news.Take(3))
{
    var category = parser.CategorizeNews(item);

    Console.WriteLine($"{category}");
    Console.WriteLine($"Title: {item.Title}");
    Console.WriteLine($"Body: {item.Body?.Substring(0, Math.Min(50, item.Body.Length))}...");
    Console.WriteLine($"ID: {item.Id}| User: {item.UserId}");
    Console.WriteLine("---\n");
}

var categories = news.Select(parser.CategorizeNews);
Console.WriteLine("\nStatistics:");
foreach (var cat in categories.Distinct())
{
    var count = categories.Count(c => c == cat);
    Console.WriteLine($"{cat}: {count} items");
}

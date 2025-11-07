
using System.Text.Json.Serialization;

public record NewsItem
{
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = string.Empty;

    [JsonPropertyName("body")]
    public string Body { get; init; } = string.Empty;
    public DateTime PublishedDate { get; init; }
}

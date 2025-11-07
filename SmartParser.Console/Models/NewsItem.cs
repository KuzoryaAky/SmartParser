
using System.Text.Json.Serialization;

public record NewsItem
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = string.Empty;

    [JsonPropertyName("body")]
    public string Body { get; init; } = string.Empty;
    [JsonPropertyName("userId")]
    public int UserId { get; init; }
    public DateTime PublishedDate { get; init; }
}

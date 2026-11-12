using System.Text.Json;
using System.Text.Json.Serialization;

record GitHubEvent(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("payload")] JsonElement Payload
);

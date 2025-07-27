using System.Text.Json.Serialization;

namespace PersonalProjectsCore.Strava;

public class StravaMap
{
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("summary_polyline")] public string? SummaryPolyline { get; set; }

    [JsonPropertyName("resource_state")] public int ResourceState { get; set; }
}
using System.Text.Json.Serialization;

namespace PersonalProjectsCore.Strava;

public class StravaAthleteReference
{
    public long Id { get; set; }

    [JsonPropertyName("resource_state")] public int ResourceState { get; set; }
}
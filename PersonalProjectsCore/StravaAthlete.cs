using System.Text.Json.Serialization;

namespace PersonalProjectsCore;

public class StravaAthlete
{
    public long Id { get; set; }
    public string Username { get; set; }

    [JsonPropertyName("resource_state")] public int ResourceState { get; set; }

    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Bio { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Sex { get; set; }
    public bool Premium { get; set; }
    public bool Summit { get; set; }

    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("badge_type_id")] public int BadgeTypeId { get; set; }

    public double Weight { get; set; }

    [JsonPropertyName("profile_medium")] public string ProfileMedium { get; set; }

    public string Profile { get; set; }
    public object Friend { get; set; }
    public object Follower { get; set; }
}
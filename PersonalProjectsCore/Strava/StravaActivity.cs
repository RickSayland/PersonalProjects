using System.Text.Json.Serialization;

namespace PersonalProjectsCore.Strava;

public class StravaActivity
{
    [JsonPropertyName("resource_state")]
    public int ResourceState { get; set; }

    public StravaAthleteReference Athlete { get; set; } = new();

    public string Name { get; set; } = string.Empty;

    public double Distance { get; set; }

    [JsonPropertyName("moving_time")]
    public int MovingTime { get; set; }

    [JsonPropertyName("elapsed_time")]
    public int ElapsedTime { get; set; }

    [JsonPropertyName("total_elevation_gain")]
    public double TotalElevationGain { get; set; }

    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("sport_type")]
    public string SportType { get; set; } = string.Empty;

    [JsonPropertyName("workout_type")]
    public int? WorkoutType { get; set; }

    public long Id { get; set; }

    [JsonPropertyName("external_id")]
    public string ExternalId { get; set; } = string.Empty;

    [JsonPropertyName("upload_id")]
    public long UploadId { get; set; }

    [JsonPropertyName("start_date")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("start_date_local")]
    public DateTime StartDateLocal { get; set; }

    public string Timezone { get; set; } = string.Empty;

    [JsonPropertyName("utc_offset")]
    public int UtcOffset { get; set; }

    [JsonPropertyName("start_latlng")]
    public double[]? StartLatLng { get; set; }

    [JsonPropertyName("end_latlng")]
    public double[]? EndLatLng { get; set; }

    [JsonPropertyName("location_city")]
    public string? LocationCity { get; set; }

    [JsonPropertyName("location_state")]
    public string? LocationState { get; set; }

    [JsonPropertyName("location_country")]
    public string? LocationCountry { get; set; }

    [JsonPropertyName("achievement_count")]
    public int AchievementCount { get; set; }

    [JsonPropertyName("kudos_count")]
    public int KudosCount { get; set; }

    [JsonPropertyName("comment_count")]
    public int CommentCount { get; set; }

    [JsonPropertyName("athlete_count")]
    public int AthleteCount { get; set; }

    [JsonPropertyName("photo_count")]
    public int PhotoCount { get; set; }

    public StravaMap Map { get; set; } = new();

    public bool Trainer { get; set; }

    public bool Commute { get; set; }

    public bool Manual { get; set; }

    [JsonPropertyName("private")]
    public bool Private { get; set; }

    public bool Flagged { get; set; }

    [JsonPropertyName("gear_id")]
    public string GearId { get; set; } = string.Empty;

    [JsonPropertyName("from_accepted_tag")]
    public bool FromAcceptedTag { get; set; }

    [JsonPropertyName("average_speed")]
    public double AverageSpeed { get; set; }

    [JsonPropertyName("max_speed")]
    public double MaxSpeed { get; set; }

    [JsonPropertyName("average_cadence")]
    public double? AverageCadence { get; set; }

    [JsonPropertyName("average_watts")]
    public double? AverageWatts { get; set; }

    [JsonPropertyName("weighted_average_watts")]
    public int? WeightedAverageWatts { get; set; }

    public double? Kilojoules { get; set; }

    [JsonPropertyName("device_watts")]
    public bool DeviceWatts { get; set; }

    [JsonPropertyName("has_heartrate")]
    public bool HasHeartrate { get; set; }

    [JsonPropertyName("average_heartrate")]
    public double? AverageHeartrate { get; set; }

    [JsonPropertyName("max_heartrate")]
    public int? MaxHeartrate { get; set; }

    [JsonPropertyName("max_watts")]
    public int? MaxWatts { get; set; }

    [JsonPropertyName("pr_count")]
    public int PrCount { get; set; }

    [JsonPropertyName("total_photo_count")]
    public int TotalPhotoCount { get; set; }

    [JsonPropertyName("has_kudoed")]
    public bool HasKudoed { get; set; }

    [JsonPropertyName("suffer_score")]
    public int? SufferScore { get; set; }
}
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PersonalProjectsCore;

namespace PersonalProjectsAPI.Endpoints;

public static class StravaEndpoints
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static void MapStravaEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/strava", async (HttpClient http, [FromQuery] string accessToken) =>
            {
                if (string.IsNullOrWhiteSpace(accessToken))
                {
                    return Results.BadRequest(new { Error = "Access token is required." });
                }

                var request = new HttpRequestMessage(HttpMethod.Get, "https://www.strava.com/api/v3/athlete");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = await http.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    return Results.Problem($"Strava API request failed with status {response.StatusCode}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var athlete = JsonSerializer.Deserialize<StravaAthlete>(json, JsonOptions);
                return Results.Ok(athlete);
            })
            .WithName("GetStravaAthlete")
            .WithOpenApi();
    }
}
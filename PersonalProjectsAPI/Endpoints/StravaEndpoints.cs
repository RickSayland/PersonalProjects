using PersonalProjectsAPI.Services;

namespace PersonalProjectsAPI.Endpoints;

public static class StravaEndpoints
{
    public static void MapStravaEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/strava/athlete", async (StravaService stravaService) =>
            {
                var athlete = await stravaService.GetAthleteAsync();
                return athlete is not null
                    ? Results.Ok(athlete)
                    : Results.Problem("Strava API request failed");
            })
            .WithName("GetStravaAthlete")
            .WithOpenApi();
        
        app.MapGet("/strava/activities", async (StravaService stravaService) =>
            {
                var activities = await stravaService.GetActivitiesAsync();
                return Results.Ok(activities);
            })
            .WithName("GetStravaActivities")
            .WithOpenApi();
        
    }
}
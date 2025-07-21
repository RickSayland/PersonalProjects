using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using com.strava.api.Authentication;
using com.strava.api.Segments;
using PersonalProjectsCore;
using stravaApi = com.strava.api;

namespace PersonalProjectsAPI.Services;

public class StravaService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
{
    public async Task<StravaAthlete?> GetAthleteAsync()
    {
        var request = BuildRequest("athlete");
        
        var response = await httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            return null;
        
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<StravaAthlete>(json, jsonOptions);
    }
    
    public async Task<List<ActivitySummary>> GetActivitiesAsync()
    {
        var apiInstance = new stravaApi.Clients.ActivityClient(new StravaAuth());
        
        try
        {
            var activities = await apiInstance.GetActivitiesAsync(DateTime.Now.AddDays(-30), DateTime.Now, 56, 56);
            return activities;
        }
        catch (Exception e)
        {
            Debug.Print("Exception when calling ActivitiesApi.getLoggedInAthleteActivities: " + e.Message );
        }
        
        return [];
    }

    private HttpRequestMessage BuildRequest(string endpoint)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.strava.com/api/v3/{endpoint}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "c59ea5c0772d684839de9c051ae8fc6996159feb");
        return request;
    }
}

public class StravaAuth : IAuthentication
{
    public string AccessToken { get; set; } = Environment.GetEnvironmentVariable("STRAVA_ACCESS_TOKEN") ?? string.Empty;
}
using System.Text.Json;
using PersonalProjectsAPI.Endpoints;
using PersonalProjectsAPI.Services;

namespace PersonalProjectsAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton(new JsonSerializerOptions(JsonSerializerDefaults.Web));
        builder.Services.AddHttpClient<StravaService>();
        
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:5173") // Vite default dev server
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapWeatherForecastEndpoints();
        app.MapUraniumEndpoints();
        app.MapStravaEndpoints();

        app.Run();
    }
}
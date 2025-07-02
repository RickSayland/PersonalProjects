namespace PersonalProjectsAPI.Endpoints;

public static class UraniumEndpoints
{
    public static void MapUraniumEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/uranium", (double initialAmount, double halfLife, double elapsedTime) =>
            {
                double remaining = CalculateRemainingFraction(initialAmount, halfLife, elapsedTime);
                return Results.Ok(new
                {
                    InitialAmount = initialAmount,
                    HalfLife = halfLife,
                    ElapsedTime = elapsedTime,
                    RemainingAmount = remaining
                });
            })
            .WithName("GetUranium")
            .WithOpenApi();
    }

    private static double CalculateRemainingFraction(double initialAmount, double halfLife, double elapsedTime)
    {
        // remaining = initial * (1/2)^(elapsedTime / halfLife)
        return initialAmount * Math.Pow(0.5, elapsedTime / halfLife);
    }
}
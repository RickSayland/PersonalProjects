import { useEffect, useState } from "react";

interface WeatherForecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

export default function Weather() {
    const [forecasts, setForecasts] = useState<WeatherForecast[] | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        fetch("https://localhost:44363/weatherforecast")
            .then((res) => {
                if (!res.ok) throw new Error(`API returned ${res.status}`);
                return res.json();
            })
            .then(setForecasts)
            .catch((err) => {
                if (err instanceof TypeError && err.message === "Failed to fetch") {
                    setError("Backend is unreachable. Is the API running?");
                } else {
                    setError("An unexpected error occurred: " + err.message);
                }
            })
            .finally(() => setLoading(false));
    }, []);

    if (loading) return <p className="text-gray-500">Loading...</p>;
    if (error) return <p className="text-red-500">Error: {error}</p>;

    return (
        <div>
            <h1 className="text-2xl font-bold mb-4">Weather Forecast</h1>
            <table className="min-w-full bg-white dark:bg-gray-900 border border-gray-300 dark:border-gray-700 rounded">
                <thead className="bg-gray-100 dark:bg-gray-800">
                <tr>
                    <th className="text-left px-4 py-2">Date</th>
                    <th className="text-left px-4 py-2">Summary</th>
                    <th className="text-left px-4 py-2">°C</th>
                    <th className="text-left px-4 py-2">°F</th>
                </tr>
                </thead>
                <tbody>
                {forecasts?.map((forecast) => (
                    <tr key={forecast.date} className="border-t border-gray-200 dark:border-gray-700">
                        <td className="px-4 py-2">{forecast.date}</td>
                        <td className="px-4 py-2">{forecast.summary}</td>
                        <td className="px-4 py-2">{forecast.temperatureC}</td>
                        <td className="px-4 py-2">{forecast.temperatureF}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}
// This code fetches weather data from a .NET API and displays it in a styled table.
import { useFetch } from "~/hooks/useFetch";

interface WeatherForecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

export default function Weather() {
    const {
        data: forecasts,
        loading,
        error,
    } = useFetch<WeatherForecast[]>("https://localhost:44363/weatherforecast");

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
                    <tr
                        key={forecast.date}
                        className="border-t border-gray-200 dark:border-gray-700"
                    >
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

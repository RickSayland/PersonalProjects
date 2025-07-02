import { useFetch } from "~/hooks/useFetch";
import '~/styles/weather.css';

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

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error}</p>;

    return (
        <div>
            <h1>Weather Forecast</h1>
            <table>
                <thead>
                <tr>
                    <th>Date</th>
                    <th>Summary</th>
                    <th>°C</th>
                    <th>°F</th>
                </tr>
                </thead>
                <tbody>
                {forecasts?.map((forecast) => (
                    <tr key={forecast.date}>
                        <td>{forecast.date}</td>
                        <td>{forecast.summary}</td>
                        <td>{forecast.temperatureC}</td>
                        <td>{forecast.temperatureF}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}

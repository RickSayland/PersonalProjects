import { useFetch } from "~/hooks/useFetch";
import '~/styles/Strava.css';

type StravaAthlete = {
  id: number;
  username: string;
  resource_state: number;
  firstname: string;
  lastname: string;
  bio: string;
  city: string;
  state: string;
  country: string | null;
  sex: string;
  premium: boolean;
  summit: boolean;
  created_at: string;
  updated_at: string;
  badge_type_id: number;
  weight: number;
  profile_medium: string;
  profile: string;
  friend: any;
  follower: any;
};

export default function Running() {
  const { data: athlete, loading, error } = useFetch<StravaAthlete>("https://localhost:44363/strava", { cache: true });

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  if (!athlete) return null;

  return (
      <div className="strava-container">
        <h1>Strava Profile</h1>
        <div className="strava-card">
          <img className="strava-avatar" src={athlete.profile} alt="Profile" />
          <div className="strava-details">
            <h2>{athlete.firstname} {athlete.lastname}</h2>
            <p className="username">@{athlete.username}</p>
            <p>{athlete.city}, {athlete.state}</p>
            {athlete.bio && <p className="bio">"{athlete.bio}"</p>}

            <table className="strava-table">
              <tbody>
              <tr><td>Gender:</td><td>{athlete.sex}</td></tr>
              <tr><td>Weight:</td><td>{athlete.weight.toFixed(1)} kg</td></tr>
              <tr><td>Premium:</td><td>{athlete.premium ? 'Yes' : 'No'}</td></tr>
              <tr><td>Summit:</td><td>{athlete.summit ? 'Yes' : 'No'}</td></tr>
              <tr><td>Joined:</td><td>{new Date(athlete.created_at).toLocaleDateString()}</td></tr>
              <tr><td>Updated:</td><td>{new Date(athlete.updated_at).toLocaleDateString()}</td></tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
  );
}

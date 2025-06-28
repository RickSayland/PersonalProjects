import { useEffect, useState } from "react";

interface UseFetchResult<T> {
    data: T | null;
    loading: boolean;
    error: string | null;
}

export function useFetch<T>(url: string): UseFetchResult<T> {
    const [data, setData] = useState<T | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        let cancelled = false;

        fetch(url)
            .then((res) => {
                if (!res.ok) throw new Error(`Request failed: ${res.status}`);
                return res.json();
            })
            .then((json) => {
                if (!cancelled) setData(json);
            })
            .catch((err) => {
                if (!cancelled) {
                    const isNetworkError =
                        err instanceof TypeError && err.message === "Failed to fetch";
                    setError(
                        isNetworkError
                            ? "Could not connect to the server. Is the API running?"
                            : err.message
                    );
                }
            })
            .finally(() => {
                if (!cancelled) setLoading(false);
            });

        return () => {
            cancelled = true;
        };
    }, [url]);

    return { data, loading, error };
}

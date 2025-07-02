import { useEffect, useState } from "react";

interface UseFetchResult<T> {
    data: T | null;
    loading: boolean;
    error: string | null;
}

// Global cache store (simple memory cache)
const fetchCache: Record<string, any> = {};

interface UseFetchOptions {
    cache?: boolean;
}

export function useFetch<T>(url: string, options?: UseFetchOptions): UseFetchResult<T> {
    const [data, setData] = useState<T | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        let cancelled = false;

        const fetchData = async () => {
            const shouldUseCache = options?.cache;
            if (shouldUseCache && fetchCache[url]) {
                setData(fetchCache[url]);
                setLoading(false);
                return;
            }

            try {
                const res = await fetch(url);
                if (!res.ok) throw new Error(`Request failed: ${res.status}`);
                const json = await res.json();
                if (!cancelled) {
                    if (shouldUseCache) {
                        fetchCache[url] = json;
                    }
                    setData(json);
                }
            } catch (err: unknown) {
                if (!cancelled) {
                    if (err instanceof Error) {
                        const isNetworkError =
                            err.message === "Failed to fetch";
                        setError(
                            isNetworkError
                                ? "Could not connect to the server. Is the API running?"
                                : err.message
                        );
                    } else {
                        setError("An unknown error occurred.");
                    }
                }
            } finally {
                if (!cancelled) setLoading(false);
            }
        };

        fetchData();

        return () => {
            cancelled = true;
        };
    }, [url, options?.cache]);

    return { data, loading, error };
}

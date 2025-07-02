import {
    isRouteErrorResponse,
    Links,
    Meta,
    NavLink,
    Outlet,
    Scripts,
    ScrollRestoration,
} from "react-router";

import type { Route } from "./+types/root";
import "./app.css";

export const links: Route.LinksFunction = () => [
    { rel: "preconnect", href: "https://fonts.googleapis.com" },
    {
        rel: "preconnect",
        href: "https://fonts.gstatic.com",
        crossOrigin: "anonymous",
    },
    {
        rel: "stylesheet",
        href: "https://fonts.googleapis.com/css2?family=Inter:ital,wght@0,100..900;1,100..900&display=swap",
    },
];

export function Layout({ children }: { children: React.ReactNode }) {
    return (
        <html lang="en">
        <head>
            <meta charSet="utf-8" />
            <meta name="viewport" content="width=device-width, initial-scale=1" />
            <Meta />
            <Links />
        </head>
        <body>
        {children}
        <ScrollRestoration />
        <Scripts />
        </body>
        </html>
    );
}

export default function App() {
    return (
        <div className="app-layout">
            <aside className="sidebar">
                <h2 className="sidebar-title">🛠 My Apps</h2>
                <nav className="nav-links">
                    <NavItem to="/" label="🏠 Home" />
                    <NavItem to="/dna" label="🧬 DNA" />
                    <NavItem to="/running" label="🏃‍♂️️ Running" />
                    <NavItem to="/uranium" label="⚛️ Uranium" />
                    <NavItem to="/weather" label="☁️ Weather" />
                </nav>
            </aside>

            <main className="main-content">
                <Outlet />
            </main>
        </div>
    );
}

function NavItem({ to, label }: { to: string; label: string }) {
    return (
        <NavLink
            to={to}
            end
            className={({ isActive }) =>
                `nav-item${isActive ? " active" : ""}`
            }
        >
            {label}
        </NavLink>
    );
}

export function ErrorBoundary({ error }: Route.ErrorBoundaryProps) {
    let message = "Oops!";
    let details = "An unexpected error occurred.";
    let stack: string | undefined;

    if (isRouteErrorResponse(error)) {
        message = error.status === 404 ? "404" : "Error";
        details =
            error.status === 404
                ? "The requested page could not be found."
                : error.statusText || details;
    } else if (import.meta.env.DEV && error && error instanceof Error) {
        details = error.message;
        stack = error.stack;
    }

    return (
        <main className="error-boundary">
            <h1>{message}</h1>
            <p>{details}</p>
            {stack && (
                <pre>
          <code>{stack}</code>
        </pre>
            )}
        </main>
    );
}

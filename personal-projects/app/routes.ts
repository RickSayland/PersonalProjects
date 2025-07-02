import {type RouteConfig, index, route} from "@react-router/dev/routes";
export default [
    index("routes/home.tsx"),
    route("dna", "routes/dna.tsx"),
    route("running", "routes/running.tsx"),
    route("uranium", "routes/uranium.tsx"),
    route("weather", "routes/weather.tsx"),
] satisfies RouteConfig;
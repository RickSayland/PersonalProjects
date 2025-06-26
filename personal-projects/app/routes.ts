import {type RouteConfig, index, route} from "@react-router/dev/routes";
export default [
    index("routes/home.tsx"),
    route("weather", "routes/weather.tsx"),
    route("uranium", "routes/uranium.tsx"),
    route("dna", "routes/dna.tsx"),
] satisfies RouteConfig;
import axios from "axios";

export const api = axios.create({
    baseURL: "http://localhost:5247/api",
    withCredentials: true,
    headers: {
        "Content-Type": "application/json"
    }
});
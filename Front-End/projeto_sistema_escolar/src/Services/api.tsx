import axios from "axios";

const api = axios.create({
    baseURL: 'https://localhost:7081'
});

export default api;
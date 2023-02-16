import axios from "axios";

const api = axios.create({
    baseURL: 'https://localhost:7101'
});

export default api;
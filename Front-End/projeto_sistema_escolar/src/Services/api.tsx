import axios from "axios";

const instancia = axios.create({
    baseURL: 'https://localhost:7181'
});

export default instancia;
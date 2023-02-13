import axios from "axios";

const instancia = axios.create({
    baseURL: 'https://localhost:7181',
    timeout: 30000,
    headers: {'Access-Control-Allow-Headers': 'foobar'}
  });

export default instancia;
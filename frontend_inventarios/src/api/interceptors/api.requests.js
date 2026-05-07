import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5139'
});

export default API;
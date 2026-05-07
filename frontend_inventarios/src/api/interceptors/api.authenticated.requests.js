import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5139'
});

API.interceptors.request.use(config=>{
    const authToken = localStorage.getItem('token');
    if(authToken) {
        config.headers.Authorization = `Bearer ${authToken}`
    }
    return config;
});
API.interceptors.response.use(
    response=>response,
    error =>{
        const status = error.response ? error.response.status : null;
        if( status == 401) {
            localStorage.clear()
            location.reload();
        }

        return Promise.reject(error);
    }
)

export default API;
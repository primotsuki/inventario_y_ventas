import api from '../interceptors/api.requests';

export const loginUser =  (user) =>{
    return api.post('/authentication/login', {
        email: user.email,
        password: user.password 
    })
}
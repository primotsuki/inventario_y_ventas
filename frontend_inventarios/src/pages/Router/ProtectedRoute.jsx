import { Route, Navigate } from 'react-router-dom';
import React from 'react';

const ProtectedRoute = ({children}) => {
    const token = localStorage.getItem('token');
    if (!!!token) {
        return <Navigate to="/auth/login" replace />;
    } else {
        return <React.Fragment>
        {children}
        </React.Fragment>
    }
}

export default ProtectedRoute;
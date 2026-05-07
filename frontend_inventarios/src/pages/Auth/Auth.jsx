import { Outlet } from "react-router-dom";
import './auth.scss';
const Auth = () => {

    return (
        <div className="main-auth-view">
            <div className="left-banner">
            </div>
            <Outlet />
        </div>
    )
}

export default Auth;
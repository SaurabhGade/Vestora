import {
    Navigate,
    Outlet
} from "react-router-dom";

import { useAuth } from "./AuthContext";

export default function ProtectedRoute() {

    const {
        user,
        isAuthenticated,
        loading
    } = useAuth();
    
    if (loading) {
        return (
            <div>
                Checking authentication...
            </div>
        );
    }

    if (!isAuthenticated) {
        const AUTH_BASE_URL = import.meta.env.VITE_AUTH_BASE_URL
        window.location.href =
            `${AUTH_BASE_URL}/Login`;

        return null;
    }

    return <Outlet />;
}
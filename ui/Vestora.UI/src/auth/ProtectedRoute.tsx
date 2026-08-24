import {
    Navigate,
    Outlet
} from "react-router-dom";

import { useAuth } from "./AuthContext";

export default function ProtectedRoute() {

    const {
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
        const AUTH_BASE_URL = import.meta.env.VITE_AUTH_BASE_URL;

        if (AUTH_BASE_URL) {
            return (
                <Navigate
                    to={`${AUTH_BASE_URL}/Login`}
                    replace
                />
            );
        }

        return <div>Authentication required.</div>;
    }

    return <Outlet />;
}
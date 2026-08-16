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

        window.location.href =
            "http://localhost:5227/Login";

        return null;
    }

    return <Outlet />;
}
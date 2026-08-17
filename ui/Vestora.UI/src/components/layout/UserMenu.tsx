import { useEffect } from "react";
import { useAuth } from "../../auth/AuthContext";

export default function UserMenu() {
  const handleLogout = () => {
    window.location.href =
      "http://localhost:5227/Logout";
  };

  const {user, loading, isAuthenticated} = useAuth();

  const handleProfile = () => {
    console.log("Profile page coming later");
  };
  useEffect(() => {
    if(!isAuthenticated){
      handleLogout();
    }
  }, [])

  return (
    <div className="user-menu">

      <div className="user-menu-header">

        <div className="avatar avatar-large">
          {user?.firstName?.charAt(0).toUpperCase()}
        </div>

        <div>

          <div className="user-menu-name">
            {user?.firstName}
          </div>

          <div className="user-menu-email">
            {user?.email}
          </div>

        </div>

      </div>

      <div className="user-menu-divider" />

      <button
        className="user-menu-item"
        onClick={handleProfile}
      >
        <span>◉</span>
        Profile & account
      </button>

      <button
        className="user-menu-item user-menu-logout"
        onClick={handleLogout}
      >
        <span>↪</span>
        Sign out
      </button>

    </div>
  );
}
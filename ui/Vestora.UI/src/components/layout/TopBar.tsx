import { useState } from "react";
import UserMenu from "./UserMenu";
import { useAuth } from "../../auth/AuthContext";
import Breadcrumb from "./Breadcrumb";

export interface CurrentUser {
  userId: string;
  email: string;
  firstName: string;
  authenticated: boolean;
}

interface AuthContextType {
  user: CurrentUser | null;
  loading: boolean;
  isAuthenticated: boolean;
}

interface TopBarProps {
  onMenuClick: () => void;
}

export default function TopBar({ onMenuClick }: TopBarProps) {
  const [userMenuOpen, setUserMenuOpen] = useState(false);
  const userContext: AuthContextType | undefined = useAuth();

  return (
    <header className="topbar">
      <div className="topbar-left">
        <button
          className="menu-toggle"
          onClick={onMenuClick}
          aria-label="Toggle sidebar"
        >
          ☰
        </button>
        <div className="pt-2">
          <Breadcrumb />
        </div>
      </div>

      <div className="topbar-right">
        <button
          className="user-profile-button"
          onClick={() => setUserMenuOpen(!userMenuOpen)}
        >
          <div className="avatar">
            {userContext.user?.firstName?.charAt(0)?.toUpperCase() ?? "X"}
          </div>

          <div className="user-summary">
            <span className="user-name">{userContext.user?.firstName}</span>

            <span className="user-role">Investor</span>
          </div>

          <span className="profile-arrow">▾</span>
        </button>

        {userMenuOpen && <UserMenu />}
      </div>
    </header>
  );
}

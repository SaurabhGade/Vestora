import { useState } from "react";
import UserMenu from "./UserMenu";

interface TopBarProps {
  onMenuClick: () => void;
}

export default function TopBar({
  onMenuClick
}: TopBarProps) {

  const [userMenuOpen, setUserMenuOpen] =
    useState(false);

  return (
    <header className="topbar">

      <button
        className="menu-toggle"
        onClick={onMenuClick}
        aria-label="Toggle sidebar"
      >
        ☰
      </button>

      <div className="topbar-right">

        <button
          className="user-profile-button"
          onClick={() =>
            setUserMenuOpen(!userMenuOpen)
          }
        >

          <div className="avatar">
            S
          </div>

          <div className="user-summary">

            <span className="user-name">
              Saurabh Gade
            </span>

            <span className="user-role">
              Investor
            </span>

          </div>

          <span className="profile-arrow">
            ▾
          </span>

        </button>

        {userMenuOpen && (
          <UserMenu />
        )}

      </div>

    </header>
  );
}
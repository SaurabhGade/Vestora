import { Navigate, NavLink, useNavigate } from "react-router-dom";
import ConfigServices from "../../services/ConfigServices";
import type { MenuItem } from "../../services/ConfigServices";
import { useEffect, useState } from "react";
import AppConstants from "../../AppConstants";
interface SidebarProps {
  isOpen: boolean;
  menuItems: MenuItem[];
}

export default function Sidebar({ isOpen, menuItems }: SidebarProps) {
  const navigate = useNavigate();
  const handleClickOnVestora = () => {
    // Navigate to dashboard
    navigate("/")
  };
  return (
    <aside className={isOpen ? "sidebar" : "sidebar sidebar-collapsed"}>
      <div className="sidebar-brand">
        <button onClick={handleClickOnVestora} className="flex">
          <div className="brand-mark">V</div>
          {isOpen && <span className="brand-name pt-1">VESTORA</span>}
        </button>
      </div>

      <nav className="sidebar-menu">
        {menuItems?.map((item) => {
          const iconKey = item.icon as keyof typeof AppConstants.MenuIcons;
          const icon =
            AppConstants.MenuIcons[iconKey] ?? AppConstants.MenuIcons.market;

          return (
            <NavLink
              key={item.menuId}
              to={item.route.startsWith("/") ? item.route : `/${item.route}`}
              className={({ isActive }) =>
                isActive ? "menu-item menu-item-active" : "menu-item"
              }
            >
              <span className="menu-icon">{icon}</span>

              {isOpen && <span>{item.name}</span>}
            </NavLink>
          );
        })}
      </nav>

      <div className="sidebar-bottom">
        {isOpen && <span className="sidebar-version">Vestora · v0.1</span>}
      </div>
    </aside>
  );
}

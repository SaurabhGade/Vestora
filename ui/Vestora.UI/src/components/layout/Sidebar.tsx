import { NavLink } from "react-router-dom";
import ConfigServices from "../../services/ConfigServices";
import type { MenuItem } from "../../services/ConfigServices";
import { useEffect, useState } from "react";
import AppConstants from "../../AppConstants"
interface SidebarProps {
  isOpen: boolean;
}

export default function Sidebar({ isOpen }: SidebarProps) {
  const [menuItems, setMenuItems] = useState<MenuItem[]>();
  const getMenuItems = () => {
    const successCB = (response: MenuItem[]) => {
      setMenuItems(response);
    }
    const errorCB = () => {
      console.error("failed to fetch menu list");
    }
    ConfigServices.getMenu({}, successCB, errorCB);
  }

  useEffect(() => {
    getMenuItems();
  }, [])
  return (
    <aside
      className={
        isOpen
          ? "sidebar"
          : "sidebar sidebar-collapsed"
      }
    >

      <div className="sidebar-brand">

        <div className="brand-mark">
          V
        </div>

        {isOpen && (
          <span className="brand-name">
            VESTORA
          </span>
        )}

      </div>

      <nav className="sidebar-menu">

        {menuItems?.map(item => (

          <NavLink
            key={item.menuId}
            to={item.route}
            className={({ isActive }) =>
              isActive
                ? "menu-item menu-item-active"
                : "menu-item"
            }
          >

            <span className="menu-icon">
              {AppConstants.MenuIcons[item.icon]}
            </span>

            {isOpen && (
              <span>
                {item.name}
              </span>
            )}

          </NavLink>

        ))}

      </nav>

      <div className="sidebar-bottom">

        {isOpen && (
          <span className="sidebar-version">
            Vestora · v0.1
          </span>
        )}

      </div>

    </aside>
  );
}
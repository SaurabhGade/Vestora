import { NavLink } from "react-router-dom";
import { menuItems } from "../../config/menuConfig";

interface SidebarProps {
  isOpen: boolean;
}

export default function Sidebar({
  isOpen
}: SidebarProps) {

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

        {menuItems.map(item => (

          <NavLink
            key={item.id}
            to={item.path}
            className={({ isActive }) =>
              isActive
                ? "menu-item menu-item-active"
                : "menu-item"
            }
          >

            <span className="menu-icon">
              {item.icon}
            </span>

            {isOpen && (
              <span>
                {item.label}
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
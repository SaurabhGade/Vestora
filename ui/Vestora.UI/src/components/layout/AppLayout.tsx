import { useEffect, useState } from "react";
import { Outlet } from "react-router-dom";

import Sidebar from "./Sidebar";
import TopBar from "./TopBar";
import ConfigServices, { type MenuItem } from "../../services/ConfigServices";

export default function AppLayout() {
  const [sidebarOpen, setSidebarOpen] = useState(true);
  const [menuItems, setMenuItems] = useState<MenuItem[]>([]);
    const getMenuItems = () => {
      const successCB = (response: MenuItem[]) => {
        setMenuItems(response);
      };
      const errorCB = () => {
        console.error("failed to fetch menu list");
      };
      ConfigServices.getMenu({}, successCB, errorCB);
    };
  
    useEffect(() => {
      getMenuItems();
    }, []);

  return (
    <div className="app-shell">
      <Sidebar isOpen={sidebarOpen} menuItems={menuItems} />

      <div
        className={
          sidebarOpen ? "app-content" : "app-content app-content-collapsed"
        }
      >
        <TopBar onMenuClick={() => setSidebarOpen(!sidebarOpen)} />

        <main className="page-content">
          <Outlet />
        </main>
      </div>
    </div>
  );
}

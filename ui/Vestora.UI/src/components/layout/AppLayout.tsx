import { useState } from "react";
import { Outlet } from "react-router-dom";

import Sidebar from "./Sidebar";
import TopBar from "./TopBar";

export default function AppLayout() {

  const [sidebarOpen, setSidebarOpen] = useState(true);

  return (
    <div className="app-shell">

      <Sidebar
        isOpen={sidebarOpen}
      />

      <div
        className={
          sidebarOpen
            ? "app-content"
            : "app-content app-content-collapsed"
        }
      >

        <TopBar
          onMenuClick={() =>
            setSidebarOpen(!sidebarOpen)
          }
        />

        <main className="page-content">
          <Outlet />
        </main>

      </div>

    </div>
  );
}
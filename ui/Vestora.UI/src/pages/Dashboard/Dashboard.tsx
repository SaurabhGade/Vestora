import { useEffect } from "react";

import { DashboardServices } from "./DashboardServices";

export default function Dashboard() {

  useEffect(() => {

    const successCB = (response: any) => {
      console.log("User:", response);
    };

    const errorCB = (error: unknown) => {
      console.error(
        "Failed to get user:",
        error
      );
    };

    DashboardServices.getUser( {}, successCB, errorCB);

  }, []);

  return (
    <div>
      Dashboard
    </div>
  );
}
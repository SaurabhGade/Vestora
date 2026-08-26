import {
  BrowserRouter,
  Route,
  Routes
} from "react-router-dom";

import { AuthProvider } from "./auth/AuthContext";
import ProtectedRoute from "./auth/ProtectedRoute";

import AppLayout from "./components/layout/AppLayout";
import Dashboard from "./pages/Dashboard/Dashboard";
import routeConstants from "./routes/routeConstants"
import Market from "./pages/Market/Market";
import IPO from "./pages/IPO/IPO";
import Watchlist from "./pages/Watchlist/Watchlist";
import Portfolio from "./pages/Portfolio/Portfolio";
import Risk from "./pages/Risk/Risk";
import SecurityDetails from "./pages/Market/SecurityDetails";

function App() {

  return (
    <BrowserRouter>

      <AuthProvider>
        <Routes>
          <Route element={<ProtectedRoute />}>
            <Route element={<AppLayout />}>

              <Route path="/" element={<Dashboard />} />
              <Route path={routeConstants.market.marketTable} element={<Market />} />
              <Route path={routeConstants.IPO.IPO} element={<IPO/>} />
              <Route path={routeConstants.Watchlist.Watchlist} element={<Watchlist/>} />
              <Route path={routeConstants.Portfolio.Portfolio} element={<Portfolio/>} />
              <Route path={routeConstants.Risk.Risk} element={<Risk/>} />
              <Route path={routeConstants.market.securityDetails} element={<SecurityDetails />} />
            </Route>

          </Route>

        </Routes>

      </AuthProvider>

    </BrowserRouter>
  );
}

export default App;
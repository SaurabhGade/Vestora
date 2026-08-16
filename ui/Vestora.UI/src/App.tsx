import {
  BrowserRouter,
  Route,
  Routes
} from "react-router-dom";

import { AuthProvider } from "./auth/AuthContext";
import ProtectedRoute from "./auth/ProtectedRoute";

import Dashboard from "./pages/Dashboard/Dashboard";

function App() {

  return (

    <BrowserRouter>
      <AuthProvider>
        <Routes>
          <Route
            element={<ProtectedRoute />}
          >
            <Route
              path="/"
              element={<Dashboard />}
            />
          </Route>
        </Routes>
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
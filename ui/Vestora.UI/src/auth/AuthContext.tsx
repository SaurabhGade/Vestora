import {
  createContext,
  useContext,
  useEffect,
  useState,
  type ReactNode
} from "react";

import axios from "axios";

import {
  getCurrentUser,
  type CurrentUser
} from "../api/authApi";

interface AuthContextType {
  user: CurrentUser | null;
  loading: boolean;
  isAuthenticated: boolean;
}

const AuthContext = createContext<AuthContextType | undefined>(
  undefined
);

interface AuthProviderProps {
  children: ReactNode;
}

export function AuthProvider({
  children
}: AuthProviderProps) {

  const [user, setUser] =
    useState<CurrentUser | null>(null);

  const [loading, setLoading] =
    useState(true);

  useEffect(() => {

    const checkAuthentication =
      async () => {

        try {

          const currentUser =
            await getCurrentUser();

          setUser(currentUser);

        } catch (error) {

          if (
            axios.isAxiosError(error) &&
            error.response?.status === 401
          ) {
            setUser(null);
          } else {
            console.error(
              "Authentication check failed:",
              error
            );

            setUser(null);
          }

        } finally {

          setLoading(false);

        }
      };

    checkAuthentication();

  }, []);

  return (
    <AuthContext.Provider
      value={{
        user,
        loading,
        isAuthenticated: user !== null
      }}
    >
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {

  const context =
    useContext(AuthContext);

  if (!context) {
    throw new Error(
      "useAuth must be used inside AuthProvider"
    );
  }

  return context;
}
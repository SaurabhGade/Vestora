import { api } from "./client";

export interface CurrentUser {
    userId: string;
    email: string;
    firstName: string;
    authenticated: boolean;
}

export const getCurrentUser = async (): Promise<CurrentUser> => {
    const response = await api.get<CurrentUser>("/auth/me");

    return response.data;
};
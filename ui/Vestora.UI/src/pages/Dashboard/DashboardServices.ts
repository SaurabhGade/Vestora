import { api } from "../../api/client";
import { API_URL } from "../../api/apiUrl";
import type { GetUserRequest } from "./DashboardTypes";

export const DashboardServices = {

  getUser: (request: GetUserRequest, successCB: (response: GetUserResponse) => void, errorCB: (error: any) => void) => {
    api.get(
      API_URL.DASHBOARD.GET_USER,
      {
        params: request
      }
    ).then(response => {
      successCB(response.data);
    }).catch(error => {
      errorCB(error);
    });
  },

};
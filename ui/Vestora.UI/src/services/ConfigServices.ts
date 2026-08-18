import axios from "axios";
import { API_URL } from "../api/apiUrl";
import { api } from "../api/client";

export interface MenuItem {
  menuId: number;
  key: string;
  name: string;
  route: string;
  icon: string;
  displayOrder: number;
}

export const ConfigServices = {

  getMenu: (request: any, successCB: (response: MenuItem[]) => void, errorCB: (error: any) => void) => {
    api.get(
      API_URL.CONFIG.MENU,
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

export default ConfigServices;
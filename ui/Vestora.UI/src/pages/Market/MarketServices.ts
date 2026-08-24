import { API_URL } from "../../api/apiUrl";

import type {
  BaseResponseDTO,
  GetSecuritiesRequestDTO,
  GetSecuritiesResponseDTO,
} from "./MarketTypes";
import { api } from "../../api/client";

type SuccessCB = (
  response: GetSecuritiesResponseDTO
) => void;

type ErrorCB = (
  error: unknown
) => void;

const MarketServices = {

  getSecurities: (request: GetSecuritiesRequestDTO, successCB: SuccessCB, errorCB: ErrorCB): void => {
    api.post<BaseResponseDTO<GetSecuritiesResponseDTO>>(
      API_URL.MARKET.GET_SECURITIES,
      request,
      {
        withCredentials: true,
      }
    ).then(response => {
        const data = response.data;
        if (data.isSuccess && data.response) {
          successCB(data.response);
          return;
        }
        errorCB(data.error ??
        {
          code: "UNKNOWN_ERROR",
          message:
            "Failed to retrieve securities."
        }
        );
      }).catch(error => {
        errorCB(error);
      });
  },
};

export default MarketServices;
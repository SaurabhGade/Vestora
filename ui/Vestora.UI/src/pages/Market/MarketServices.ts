import { API_URL } from "../../api/apiUrl";

import type {
  BaseResponseDTO,
  GetSecuritiesRequestDTO,
  GetSecuritiesResponseDTO,
} from "./MarketTypes";
import { api } from "../../api/client";

type SuccessCB = (
  response: any
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
  getSecurity: (
    request: any,
    successCB: any,
    errorCB: ErrorCB
  ): void => {

    api.post<BaseResponseDTO<any>>(
      API_URL.MARKET.GET_SECURITY,
      request,
      {
        withCredentials: true,
      }
    )
      .then(response => {

        const data = response.data;

        if (data.isSuccess && data.response) {
          successCB(data.response);
          return;
        }

        errorCB(
          data.error ?? {
            code: "UNKNOWN_ERROR",
            message: "Failed to retrieve security."
          }
        );
      })
      .catch(error => {
        errorCB(error);
      });
  },
  getMarketData: (
    request: any,
    successCB: (
      response: any
    ) => void,
    errorCB: ErrorCB
  ): void => {

    api.post<BaseResponseDTO<any>>(
      API_URL.MARKET.GET_MARKET_DATA,
      request,
      {
        withCredentials: true,
      }
    )
      .then(response => {

        const data = response.data;

        if (data.isSuccess && data.response) {
          successCB(data.response);
          return;
        }

        errorCB(
          data.error ?? {
            code: "UNKNOWN_ERROR",
            message: "Failed to retrieve market data."
          }
        );
      })
      .catch(error => {
        errorCB(error);
      });
  },

};

export default MarketServices;
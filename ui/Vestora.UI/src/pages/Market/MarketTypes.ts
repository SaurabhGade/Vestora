export interface BaseRequestDTO {
    sessionObject?: SessionObjectDTO;
}

export interface SessionObjectDTO {
    userId?: number;
    username?: string;
    email?: string;
}

export interface BaseResponseDTO<T> {
    isSuccess: boolean;
    response: T | null;
    error: APIErrorDTO | null;
}

export interface APIErrorDTO {
    code: string;
    message: string;
}

export interface GetSecuritiesRequestDTO
    extends BaseRequestDTO {
    search?: string;
    page: number;
    pageSize: number;
}

export interface SecurityDTO {
    securityId: number;
    symbol: string;
    companyName: string;
    isin?: string;
    exchange: string;
    securityType: string;
    sector?: string;
    industry?: string;
    isActive: boolean;
}

export interface GetSecuritiesResponseDTO {
    items: SecurityDTO[];
    totalCount: number;
    page: number;
    pageSize: number;
    totalPages: number;
}

export interface GetSecurityRequestDTO
  extends BaseRequestDTO {
  securityId: number;
}

export interface GetSecurityResponseDTO {
  security: SecurityDTO;
}

export interface GetMarketDataRequestDTO
  extends BaseRequestDTO {
  securityId: number;
  fromDate?: string;
  toDate?: string;
}

export interface MarketDataDTO {
  tradeDate: string;
  openPrice?: number;
  highPrice?: number;
  lowPrice?: number;
  closePrice?: number;
  adjustedClosePrice?: number;
  previousClosePrice?: number;
  volume?: number;
  valueTraded?: number;
  changeValue?: number;
  changePercent?: number;
}

export interface GetMarketDataResponseDTO {
  securityId: number;
  items: MarketDataDTO[];
}
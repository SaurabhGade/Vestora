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
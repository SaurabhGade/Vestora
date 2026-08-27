import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useLocation } from "react-router-dom";

import MarketServices from "./MarketServices";

import type {
  GetMarketDataResponseDTO,
  GetSecurityResponseDTO,
  MarketDataDTO,
  SecurityDTO,
} from "./MarketTypes";
import DataTable from "react-data-table-component";

function SecurityDetails() {
  const { securityId } = useParams<{ securityId: string }>();
  const location = useLocation();
  const [security, setSecurity] = useState<SecurityDTO | null>(
    location.state?.securityDetails,
  );

  const [marketData, setMarketData] = useState<MarketDataDTO[]>([]);

  const [loading, setLoading] = useState(true);

  const [error, setError] = useState<string | null>(null);

  if (!securityId) {
    setError("Security ID is missing.");
    setLoading(false);
    return;
  }

  const id = Number(securityId);

  const GetMarketData = () => {
    setLoading(true);
    const successCB = (response: GetMarketDataResponseDTO) => {
      setLoading(false);
      setMarketData(response.items);
    };

    const errorCB = (error: unknown) => {
      console.error("Failed to load market data:", error);

      setError(
        error instanceof Error ? error.message : "Failed to load market data.",
      );
      setLoading(false);
    };

    MarketServices.getMarketData(
      {
        securityId: id,
      },
      successCB,
      errorCB,
    );
  };

  const columns = [
    {
      name: "Date",
      selector: (row: MarketDataDTO) => row.tradeDate,
      sortable: true,
    },
    {
      name: "Open",
      selector: (row: MarketDataDTO) => row.openPrice,
      sortable: true,
    },
    {
      name: "High",
      selector: (row: MarketDataDTO) => row.highPrice,
      sortable: true,
    },
    {
      name: "Low",
      selector: (row: MarketDataDTO) => row.lowPrice,
      sortable: true,
    },
    {
      name: "Close",
      selector: (row: MarketDataDTO) => row.closePrice,
      sortable: true,
    },
    {
      name: "Volume",
      selector: (row: MarketDataDTO) => row.volume,
      sortable: true,
    },
  ];

  useEffect(() => {
    if (!Number.isInteger(id) || id <= 0) {
      setError("Invalid security ID.");
      setLoading(false);
      return;
    }
    GetMarketData();
  }, []);

  if (loading) {
    return <div className="p-6">Loading security...</div>;
  }

  if (error) {
    return (
      <div
        className="
        m-6
        rounded-lg
        border
        border-red-200
        bg-red-50
        p-4
        text-red-700
      "
      >
        {error}
      </div>
    );
  }

  if (!security) {
    return <div className="p-6">Security not found.</div>;
  }

  const latest =
    marketData.length > 0 ? marketData[marketData.length - 1] : null;

  return (
    <div className="min-h-screen bg-[#071321] p-6">
      {/* Header */}
      <div className="mb-6">
        <div className="flex items-center gap-3">
          <h1 className="text-2xl font-semibold text-slate-100">
            {security.companyName}
          </h1>

          <span className="rounded-md bg-slate-100 px-2.5 py-1 text-sm font-medium text-slate-700">
            {security.symbol}
          </span>
        </div>

        <div className="mt-2 flex items-center gap-3 text-sm text-slate-400">
          <span>{security.exchange}</span>
          <span className="text-slate-600">•</span>
          <span>{security.securityType}</span>
          <span className="text-slate-600">•</span>
          <span>{security.sector}</span>
        </div>
      </div>

      {/* Latest Price */}
      {latest && (
        <div className="mb-6 rounded-xl border p-6 shadow-sm">
          <div className="text-sm font-medium ">Latest Close</div>

          <div className="mt-2 text-3xl font-semibold tracking-tight">
            ₹{latest.closePrice?.toLocaleString()}
          </div>

          <div
            className={`mt-2 text-sm font-medium ${
              latest.changePercent == null
                ? "text-white"
                : latest.changePercent > 0
                  ? "text-emerald-600"
                  : latest.changePercent < 0
                    ? "text-red-600"
                    : "text-slate-500"
            }`}
          >
            {latest.changePercent != null
              ? `${latest.changePercent > 0 ? "+" : ""}${latest.changePercent}%`
              : "-"}
          </div>
        </div>
      )}

      <div className="mb-6 grid grid-cols-1 gap-4 md:grid-cols-3">
        {/* ISIN */}
        <div className="rounded-xl border  p-5 shadow-sm">
          <div className="text-sm font-medium ">ISIN</div>

          <div className="mt-2 font-medium ">
            {security.isin ?? "-"}
          </div>
        </div>

        {/* Sector */}
        <div className="rounded-xl border p-5 shadow-sm">
          <div className="text-sm font-medium">Sector</div>

          <div className="mt-2 font-medium ">
            {security.sector ?? "-"}
          </div>
        </div>

        {/* Industry */}
        <div className="rounded-xl border p-5 shadow-sm">
          <div className="text-sm font-medium ">Industry</div>

          <div className="mt-2 font-medium">
            {security.industry ?? "-"}
          </div>
        </div>
      </div>

      <div className="rounded-xl borde shadow-sm">
        <h2 className="text-lg font-bold ">
          Market Data
        </h2>

        <div className="overflow-hidden">
          <DataTable
            className="dt-data-table"
            columns={columns}
            data={marketData}
            pointerOnHover
          />
        </div>
      </div>
    </div>
  );
}

export default SecurityDetails;

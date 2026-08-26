import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

import MarketServices from "./MarketServices";

import type {
  GetMarketDataResponseDTO,
  GetSecurityResponseDTO,
  MarketDataDTO,
  SecurityDTO,
} from "./MarketTypes";

function SecurityDetails() {
  const { securityId } = useParams<{ securityId: string }>();

  const [security, setSecurity] = useState<SecurityDTO | null>(null);

  const [marketData, setMarketData] = useState<MarketDataDTO[]>([]);

  const [loading, setLoading] = useState(true);

  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!securityId) {
      setError("Security ID is missing.");
      setLoading(false);
      return;
    }

    const id = Number(securityId);

    if (!Number.isInteger(id) || id <= 0) {
      setError("Invalid security ID.");
      setLoading(false);
      return;
    }

    const getSecuritySuccessCB = (response: GetSecurityResponseDTO) => {
      setSecurity(response.security);
    };

    const getSecurityErrorCB = (error: unknown) => {
      console.error("Failed to load security:", error);

      setError(
        error instanceof Error ? error.message : "Failed to load security.",
      );
    };

    MarketServices.getSecurity(
      {
        securityId: id,
      },
      getSecuritySuccessCB,
      getSecurityErrorCB,
    );
    const getMarketDataSuccessCB = (response: GetMarketDataResponseDTO) => {
      setMarketData(response.items);
    };

    const getMarketDataErrorCB = (error: unknown) => {
      console.error("Failed to load market data:", error);

      setError(
        error instanceof Error ? error.message : "Failed to load market data.",
      );
    };

    MarketServices.getMarketData(
      {
        securityId: id,
      },
      getMarketDataSuccessCB,
      getMarketDataErrorCB,
    );
  }, [securityId]);

  useEffect(() => {
    if (security || error) {
      setLoading(false);
    }
  }, [security, error]);

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
    <div className="p-6">
      {/* Header */}

      <div className="mb-6">
        <div
          className="
          flex
          items-center
          gap-3
        "
        >
          <h1
            className="
            text-2xl
            font-semibold
            text-gray-900
          "
          >
            {security.companyName}
          </h1>

          <span
            className="
            rounded-md
            bg-gray-100
            px-2
            py-1
            text-sm
            font-medium
            text-gray-700
          "
          >
            {security.symbol}
          </span>
        </div>

        <div
          className="
          mt-2
          flex
          gap-3
          text-sm
          text-gray-500
        "
        >
          <span>{security.exchange}</span>
          <span>•</span>
          <span>{security.securityType}</span>
          <span>•</span>
          <span>{security.sector}</span>
        </div>
      </div>

      {/* Current price */}

      {latest && (
        <div
          className="
          mb-6
          rounded-xl
          border
          border-gray-200
          bg-white
          p-6
          shadow-sm
        "
        >
          <div
            className="
            text-sm
            text-gray-500
          "
          >
            Latest Close
          </div>

          <div
            className="
            mt-2
            text-3xl
            font-semibold
            text-gray-900
          "
          >
            ₹{latest.closePrice?.toLocaleString()}
          </div>

          <div
            className="
            mt-2
            text-sm
          "
          >
            {latest.changePercent != null
              ? `${latest.changePercent > 0 ? "+" : ""}${latest.changePercent}%`
              : "-"}
          </div>
        </div>
      )}

      {/* Security information */}

      <div
        className="
        mb-6
        grid
        grid-cols-1
        gap-4
        md:grid-cols-3
      "
      >
        <div
          className="
          rounded-xl
          border
          border-gray-200
          bg-white
          p-5
        "
        >
          <div className="text-sm text-gray-500">ISIN</div>

          <div
            className="
            mt-2
            font-medium
            text-gray-900
          "
          >
            {security.isin ?? "-"}
          </div>
        </div>

        <div
          className="
          rounded-xl
          border
          border-gray-200
          bg-white
          p-5
        "
        >
          <div className="text-sm text-gray-500">Sector</div>

          <div
            className="
            mt-2
            font-medium
            text-gray-900
          "
          >
            {security.sector ?? "-"}
          </div>
        </div>

        <div
          className="
          rounded-xl
          border
          border-gray-200
          bg-white
          p-5
        "
        >
          <div className="text-sm text-gray-500">Industry</div>

          <div
            className="
            mt-2
            font-medium
            text-gray-900
          "
          >
            {security.industry ?? "-"}
          </div>
        </div>
      </div>

      {/* Market data */}

      <div
        className="
        rounded-xl
        border
        border-gray-200
        bg-white
        p-6
      "
      >
        <h2
          className="
          text-lg
          font-semibold
          text-gray-900
        "
        >
          Market Data
        </h2>

        <div
          className="
          mt-4
          overflow-x-auto
        "
        >
          <table
            className="
            w-full
            text-left
            text-sm
          "
          >
            <thead>
              <tr
                className="
                border-b
                border-gray-200
                text-gray-500
              "
              >
                <th className="px-4 py-3">Date</th>
                <th className="px-4 py-3">Open</th>
                <th className="px-4 py-3">High</th>
                <th className="px-4 py-3">Low</th>
                <th className="px-4 py-3">Close</th>
                <th className="px-4 py-3">Volume</th>
              </tr>
            </thead>

            <tbody>
              {marketData.map((data) => (
                <tr
                  key={data.tradeDate}
                  className="
                    border-b
                    border-gray-100
                  "
                >
                  <td className="px-4 py-3">{data.tradeDate}</td>

                  <td className="px-4 py-3">{data.openPrice ?? "-"}</td>

                  <td className="px-4 py-3">{data.highPrice ?? "-"}</td>

                  <td className="px-4 py-3">{data.lowPrice ?? "-"}</td>

                  <td
                    className="
                    px-4
                    py-3
                    font-medium
                  "
                  >
                    {data.closePrice ?? "-"}
                  </td>

                  <td className="px-4 py-3">
                    {data.volume?.toLocaleString() ?? "-"}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

export default SecurityDetails;

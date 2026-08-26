import { useEffect, useState } from "react";

import MarketServices from "./MarketServices";

import type { GetSecuritiesResponseDTO, SecurityDTO } from "./MarketTypes";
import DataTable from "react-data-table-component";
import { useNavigate } from "react-router-dom";

export default function Market() {
  const [search, setSearch] = useState("");
  const navigate = useNavigate();

  const [securities, setSecurities] = useState<SecurityDTO[]>([]);

  const [loading, setLoading] = useState(false);

  const [error, setError] = useState<string | null>(null);

  const getSecurities = () => {
    setLoading(true);
    setError(null);

    const successCB = (response: GetSecuritiesResponseDTO) => {
      setSecurities(response.items);
      setLoading(false);
    };
    const errorCB = (error: unknown) => {
      console.error("Failed to load securities:", error);
      setError(
        error instanceof Error ? error.message : "Failed to load securities.",
      );
      setLoading(false);
    };

    MarketServices.getSecurities(
      { search, page: 1, pageSize: 25 },
      successCB,
      errorCB,
    );
  };

  const columns = [
    {
      name: "Name",
      selector: (row: SecurityDTO) => row.companyName,
      sortable: true,
    },
    {
      name: "Symbol",
      selector: (row: SecurityDTO) => row.symbol,
      sortable: true,
    },
    { name: "ISIN", selector: (row: SecurityDTO) => row.isin, sortable: true },
    {
      name: "Security Type",
      selector: (row: SecurityDTO) => row.securityType,
      sortable: true,
    },
    {
      name: "Sector",
      selector: (row: SecurityDTO) => row.sector,
      sortable: true,
    },
    {
      name: "Industry",
      selector: (row: SecurityDTO) => row.industry,
      sortable: true,
    },
    {
      name: "Is Active",
      selector: (row: SecurityDTO) => (row.isActive ? "Active" : "In Active"),
      sortable: true,
    },
  ];

  useEffect(() => {
    getSecurities();
  }, []);

  return (
    <div>
      {loading && <p>Loading securities...</p>}
      {error && <p>{error}</p>}
      <DataTable
        className="dt-data-table"
        columns={columns}
        data={securities}
        onRowClicked={(row) => {
          navigate(`/market/security/${row.securityId}`);
        }}
        pointerOnHover
      />
    </div>
  );
}

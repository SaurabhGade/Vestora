**While build new setup following commands**


**Pull postgres image from docker**

`bash`
 docker compose up -d


**Migrate schema into database**
`bash`
dotnet ef database update \
 --project dal/Vestora.DAL \
 --startup-project auth/Vestora.Auth



 ** FLOW Backend **
 Vestora/
│
├── api/
│   └── Vestora.Api/
│       └── Controllers/
│           ├── DashboardController.cs
│           ├── IPOController.cs
│           ├── StockController.cs
│           └── PortfolioController.cs
│
├── bo/
│   └── Vestora.BO/
│       ├── Dashboard/
│       │   ├── IDashboardBO.cs
│       │   └── DashboardBO.cs
│       ├── IPO/
│       ├── Stock/
│       └── Portfolio/
│
├── dal/
│   └── Vestora.DAL/
│       ├── Dashboard/
│       │   ├── IDashboardDAL.cs
│       │   └── DashboardDAL.cs
│       ├── IPO/
│       ├── Stock/
│       └── Portfolio/
│
└── dto/
    └── Vestora.DTO/
        ├── Common/
        │   └── SessionObjectDTO.cs
        ├── Dashboard/
        │   ├── GetUserRequestDTO.cs
        │   └── GetUserResponseDTO.cs
        ├── IPO/
        ├── Stock/
        └── Portfolio/


** Flow UI **

ui/Vestora.UI/src/
│
├── api/
│   ├── client.ts
│   └── apiUrl.ts
│
├── auth/
│   ├── AuthContext.tsx
│   └── ProtectedRoute.tsx
│
├── pages/
│   ├── Dashboard/
│   │   ├── Dashboard.tsx
│   │   ├── DashboardServices.ts
│   │   └── DashboardTypes.ts
│   │
│   ├── IPO/
│   │   ├── IPO.tsx
│   │   ├── IPOServices.ts
│   │   └── IPOTypes.ts
│   │
│   ├── Stock/
│   ├── Portfolio/
│   ├── Watchlist/
│   └── Risk/
│
└── App.tsx




┌──────────────────────────────────────────────────────────────────────┐
│ VESTORA                                      Saurabh Gade  ▾          │
├──────────────┬───────────────────────────────────────────────────────┤
│              │                                                       │
│  ◈ Vestora   │  Good morning, Saurabh                               │
│              │  Here's your investment overview                     │
│  Dashboard   │                                                       │
│              │  ┌────────────┐ ┌────────────┐ ┌────────────┐        │
│  Markets     │  │ Portfolio  │ │ Today's    │ │ Available  │        │
│  IPOs        │  │ ₹0.00      │ │ P&L        │ │ Funds      │        │
│  Watchlist   │  │            │ │ ₹0.00      │ │ ₹0.00      │        │
│  Portfolio   │  └────────────┘ └────────────┘ └────────────┘        │
│  Risk        │                                                       │
│              │  Market Overview                                     │
│  ──────────  │  ┌───────────────────────────────────────────────┐  │
│  Settings    │  │ NIFTY 50     24,718.60    +0.42%              │  │
│              │  │ SENSEX      80,437.20    +0.31%              │  │
│              │  └───────────────────────────────────────────────┘  │
│              │                                                       │
│              │  Watchlist                          Upcoming IPOs    │
│              │  ┌──────────────────────┐          ┌──────────────┐ │
│              │  │ RELIANCE    ₹...     │          │ Company A    │ │
│              │  │ TCS         ₹...     │          │ Company B    │ │
│              │  └──────────────────────┘          └──────────────┘ │
└──────────────┴───────────────────────────────────────────────────────┘
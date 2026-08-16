import { useAuth } from "../../auth/AuthContext";

export default function Dashboard() {

  const { user } = useAuth();

  return (
    <div className="dashboard">

      <section className="dashboard-heading">

        <div>

          <p className="eyebrow">
            INVESTMENT OVERVIEW
          </p>

          <h1>
            Good morning, {user?.firstName}
          </h1>

          <p className="dashboard-subtitle">
            Here's what's happening with
            your investments.
          </p>

        </div>

      </section>

      <section className="metrics-grid">

        <div className="metric-card">
          <span>Portfolio value</span>
          <strong>₹0.00</strong>
          <small>No holdings yet</small>
        </div>

        <div className="metric-card">
          <span>Today's P&amp;L</span>
          <strong>₹0.00</strong>
          <small>0.00%</small>
        </div>

        <div className="metric-card">
          <span>Available funds</span>
          <strong>₹0.00</strong>
          <small>Ready to invest</small>
        </div>

        <div className="metric-card">
          <span>Risk score</span>
          <strong>—</strong>
          <small>Complete your profile</small>
        </div>

      </section>

      <section className="dashboard-grid">

        <div className="dashboard-panel market-panel">

          <div className="panel-header">
            <div>
              <h2>Market overview</h2>
              <span>
                Indian markets
              </span>
            </div>
          </div>

          <div className="market-list">

            <div className="market-row">
              <span>NIFTY 50</span>
              <strong>24,718.60</strong>
              <span className="positive">
                +0.42%
              </span>
            </div>

            <div className="market-row">
              <span>SENSEX</span>
              <strong>80,437.20</strong>
              <span className="positive">
                +0.31%
              </span>
            </div>

            <div className="market-row">
              <span>BANK NIFTY</span>
              <strong>55,240.10</strong>
              <span className="negative">
                -0.18%
              </span>
            </div>

          </div>

        </div>

        <div className="dashboard-panel">

          <div className="panel-header">

            <div>
              <h2>Watchlist</h2>
              <span>
                Your tracked stocks
              </span>
            </div>

            <button className="panel-link">
              View all
            </button>

          </div>

          <div className="empty-state">

            <div className="empty-icon">
              ☆
            </div>

            <p>
              Your watchlist is empty
            </p>

            <span>
              Add stocks to track them here.
            </span>

          </div>

        </div>

      </section>

      <section className="dashboard-panel">

        <div className="panel-header">

          <div>
            <h2>Upcoming IPOs</h2>
            <span>
              Opportunities worth watching
            </span>
          </div>

          <button className="panel-link">
            View all
          </button>

        </div>

        <div className="empty-state horizontal">

          <div className="empty-icon">
            ▣
          </div>

          <div>
            <p>
              IPO data will appear here
            </p>

            <span>
              We'll connect this to the IPO
              module later.
            </span>
          </div>

        </div>
        <div className="rounded-xl bg-slate-900 p-6">
          <h1 className="text-3xl font-bold text-blue-400">
            Vestora
          </h1>

          <p className="mt-2 text-slate-400">
            Tailwind is working.
          </p>

          <button className="mt-4 rounded-lg bg-blue-600 px-5 py-2 text-white hover:bg-blue-500">
            Test
          </button>
        </div>

      </section>

    </div>
  );
}
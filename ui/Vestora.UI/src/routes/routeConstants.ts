import Portfolio from "../pages/Portfolio/Portfolio";

const routeConstants = {
  home: "/",
  dashboard: "/dashboard",
  market: {
    marketTable: "/market",
    securityDetails: "/market/security/:securityId",
  },
  IPO: {
    IPO: "/ipo",
  }, 
  Portfolio: {
    Portfolio: "/portfolio"
  }, 
  Watchlist: {
    Watchlist: "/watchlist"
  },
  Risk: {
    Risk: "/risk"
  }
};

export default routeConstants;
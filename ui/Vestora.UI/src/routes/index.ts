import { lazy } from "react"
import routeConstants from './routeConstants'
import IPO from "../pages/IPO/IPO";
import Watchlist from "../pages/Watchlist/Watchlist";
import Portfolio from "../pages/Portfolio/Portfolio";
import Risk from "../pages/Risk/Risk";
import SecurityDetails from "../pages/Market/SecurityDetails";
import type { AppRoute } from "./types";
const Market = lazy(() => import('../pages/Market/Market'))
const coreRoutes: AppRoute[] = [
  {
    path: routeConstants.market.marketTable,
    breadcrumb: "Market",
    component: Market,
    accessMenu: "",
  },

  {
    path: routeConstants.market.securityDetails,

    breadcrumb: (location) =>
      location.state?.security?.symbol ??
      "Security",

    parent:
      routeConstants.market.marketTable,

    component: SecurityDetails,

    accessMenu: "",
  },

  {
    path: routeConstants.IPO.IPO,
    breadcrumb: "IPO",
    component: IPO,
    accessMenu: "",
  },

  {
    path: routeConstants.Watchlist.Watchlist,
    breadcrumb: "Watchlist",
    component: Watchlist,
    accessMenu: "",
  },

  {
    path: routeConstants.Portfolio.Portfolio,
    breadcrumb: "Portfolio",
    component: Portfolio,
    accessMenu: "",
  },

  {
    path: routeConstants.Risk.Risk,
    breadcrumb: "Risk",
    component: Risk,
    accessMenu: "",
  },
];

const routes = [...coreRoutes];
export default routes;
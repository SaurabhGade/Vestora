import { lazy } from "react"
import routeConstants from './routeConstants'
const Market = lazy(() => import('../../src/pages/Market/Markets'))
const coreRoutes = [
  {
    path: routeConstants.market.marketTable,
    breadcrumb: 'Market',
    component: Market,
    accessMenu: '',
  },
]

const routes = [...coreRoutes];
export default routes;
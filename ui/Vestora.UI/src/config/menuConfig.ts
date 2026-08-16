export interface MenuItem {
    id: string;
    key?: string;
    label: string;
    icon: string;
    path: string;
}

export const menuItems: MenuItem[] = [
    {
        id: "dashboard",
        label: "Dashboard",
        icon: "⌂",
        path: "/"
    },
    {
        id: "markets",
        key: "MENU_MARKETS",
        label: "Markets",
        icon: "◈",
        path: "/markets"
    },
    {
        id: "ipo",
        key: "MENU_IPO",
        label: "IPOs",
        icon: "▣",
        path: "/ipo"
    },
    {
        id: "watchlist",
        key: "MENU_WATCHLIST",
        label: "Watchlist",
        icon: "☆",
        path: "/watchlist"
    },
    {
        id: "portfolio",
        key: "MENU_PORTFOLIO",
        label: "Portfolio",
        icon: "◫",
        path: "/portfolio"
    },
    {
        id: "risk",
        key: "MENU_RISK",
        label: "Risk",
        icon: "△",
        path: "/risk"
    }
];
import { Link, matchPath, useLocation } from "react-router-dom";

import routes from "../../routes";

export default function Breadcrumb() {
  const location = useLocation();

  const currentRoute = routes.find((route) =>
    matchPath(
      {
        path: route.path,
        end: true,
      },
      location.pathname,
    ),
  );

  if (!currentRoute) {
    return null;
  }

  const items = [];

  /*
   * Parent
   */
  if (currentRoute.parent) {
    const parentRoute = routes.find(
      (route) => route.path === currentRoute.parent,
    );

    if (parentRoute) {
      const parentLabel =
        typeof parentRoute.breadcrumb === "function"
          ? parentRoute.breadcrumb(location)
          : parentRoute.breadcrumb;

      items.push({
        label: parentLabel,
        path: parentRoute.path,
      });
    }
  }

  /*
   * Current
   */
  const currentLabel =
    typeof currentRoute.breadcrumb === "function"
      ? currentRoute.breadcrumb(location)
      : currentRoute.breadcrumb;

  items.push({
    label: currentLabel,
  });

  return (
    <nav
      aria-label="Breadcrumb"
      className="
        flex
        gap-2
        px-6
        py-5
        text-sm
      "
    >
      {items.map((item, index) => {
        const isLast = index === items.length - 1;

        return (
          <div
            key={`${item.label}-${index}`}
            className="
              flex
              items-start
              gap-2
            "
          >
            {!isLast && item.path ? (
              <Link
                to={item.path}
                className="
                  text-slate-400
                  hover:text-slate-100
                "
              >
                {item.label}
              </Link>
            ) : (
              <span
                className="
                text-slate-200
              "
              >
                {item.label}
              </span>
            )}

            {!isLast && (
              <span
                className="
                text-slate-600
              "
              >
                /
              </span>
            )}
          </div>
        );
      })}
    </nav>
  );
}

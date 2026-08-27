import type { ComponentType } from "react";
import type { Location } from "react-router-dom";

export interface AppRoute {
  path: string;

  breadcrumb:
  | string
  | ((location: Location) => string);

  parent?: string;

  component: ComponentType;

  accessMenu: string;
}
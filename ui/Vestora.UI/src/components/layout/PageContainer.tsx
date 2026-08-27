import type { ReactNode } from "react";

interface PageContainerProps {
  children: ReactNode;
  className?: string;
}

export default function PageContainer({
  children,
  className = "",
}: PageContainerProps) {
  return (
    <main className={`min-h-full ${className}`}>
      <div className="p-6">{children}</div>
    </main>
  );
}

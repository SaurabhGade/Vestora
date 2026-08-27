interface StatCardProps {
  label: string;
  value: string | number;
}

export default function StatCard({ label, value }: StatCardProps) {
  return (
    <div
      className="
            rounded-xl
            border
            border-slate-700
            bg-slate-900/40
            p-5
        "
    >
      <div
        className="
                text-sm
                text-slate-400
            "
      >
        {label}
      </div>

      <div
        className="
                mt-2
                text-base
                font-medium
                text-slate-100
            "
      >
        {value}
      </div>
    </div>
  );
}

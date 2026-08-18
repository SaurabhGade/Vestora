const AUTH_URL =  import.meta.env.VITE_AUTH_BASE_URL;
const UI_URL =  import.meta.env.VITE_API_BASE_URL;

function App() {
  const loginUrl = `${AUTH_URL}/Login?returnUrl=${encodeURIComponent(UI_URL)}`;

  return (
    <div>
      <h1>Vestora</h1>

      <a href={loginUrl}>Login</a>
    </div>
  );
}

export default App;

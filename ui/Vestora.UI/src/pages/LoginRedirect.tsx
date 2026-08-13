const AUTH_URL = "http://localhost:5227";
const UI_URL = "http://localhost:5173";

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

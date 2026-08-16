export default function UserMenu() {

  const handleLogout = () => {
    window.location.href =
      "http://localhost:5227/Logout";
  };

  const handleProfile = () => {
    console.log("Profile page coming later");
  };

  return (
    <div className="user-menu">

      <div className="user-menu-header">

        <div className="avatar avatar-large">
          S
        </div>

        <div>

          <div className="user-menu-name">
            Saurabh Gade
          </div>

          <div className="user-menu-email">
            gadesaurabh3@gmail.com
          </div>

        </div>

      </div>

      <div className="user-menu-divider" />

      <button
        className="user-menu-item"
        onClick={handleProfile}
      >
        <span>◉</span>
        Profile & account
      </button>

      <button
        className="user-menu-item user-menu-logout"
        onClick={handleLogout}
      >
        <span>↪</span>
        Sign out
      </button>

    </div>
  );
}
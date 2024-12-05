import { useLocation, useNavigate } from "react-router-dom";

function NavBar() {
  return (
    <nav className="fixed top-0 left-0 w-full flex items-center justify-center bg-green-600 p-4 z-50">
      <div className="flex items-center">
        <img
          src="/logo.png"
          alt="logo icon"
          className="h-20 w-auto sm:h-12 sm:w-auto mr-4"
        />
        <h2 className="text-xl font-semibold text-white font-sans">
          Databased DDI System
        </h2>
      </div>
    </nav>
  );
}

export default NavBar;

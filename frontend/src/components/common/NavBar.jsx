import { useLocation, Link } from "react-router-dom";

function NavBar() {
  const location = useLocation();
  const isAdmin = location.pathname.startsWith("/admin");

  return (
    <nav className="fixed top-0 left-0 w-full flex items-center justify-between bg-green-600 p-4 z-50">
      <div className="flex-1 flex justify-center items-center">
        <img
          src="/logo.png"
          alt="logo icon"
          className="h-20 w-auto sm:h-12 sm:w-auto mr-4"
        />
        <h2 className="text-xl font-semibold text-white font-sans">
          Databased DDI System
        </h2>
      </div>
      <div className="flex justify-end space-x-4">
        <Link
          to={isAdmin ? "/" : "/admin"}
          className="bg-white text-black py-2 px-6 rounded-full hover:bg-gray-200"
        >
          {isAdmin ? "NORMAL MODE" : "ADMIN MODE"}
        </Link>
      </div>
    </nav>
  );
}

export default NavBar;

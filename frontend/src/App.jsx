import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { HelmetProvider, Helmet } from "react-helmet-async";
import NavBar from "./components/common/NavBar";
import SearchBar from "./components/search/SearchBar";
import ApiTest from "./components/ApiTest";
import AdminMode from "./pages/AdminMode";
import AdminCreate from "./pages/AdminCreate";
import AdminManage from "./pages/AdminManage";

function App() {
  return (
    <HelmetProvider>
      <Router>
        <Helmet>
          <title>DDI system</title>
          <meta content="Drug Interaction Checker" />
          <link rel="icon" href="/logo.png" />
        </Helmet>
        <NavBar />
        <main className="flex justify-center pt-28">
          <Routes>
            <Route
              path="/"
              element={
                <div className="w-1/3">
                  <SearchBar />
                </div>
              }
            />
            <Route path="/api-test" element={<ApiTest />} />
            <Route path="/admin" element={<AdminMode />} />
            <Route path="/admin/create" element={<AdminCreate />} />
            <Route path="/admin/manage" element={<AdminManage />} />
          </Routes>
        </main>
      </Router>
    </HelmetProvider>
  );
}

export default App;

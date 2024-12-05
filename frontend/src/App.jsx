import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { HelmetProvider, Helmet } from "react-helmet-async";
import NavBar from "./components/NavBar";
import SearchBar from "./components/SearchBar";
import ApiTest from "./components/ApiTest";

function App() {
  return (
    <HelmetProvider>
      <Router>
        <Helmet>
          <title>DDI system</title>
          <meta content="Find friends with similar interests at Zewail City" />
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
          </Routes>
        </main>
      </Router>
    </HelmetProvider>
  );
}

export default App;

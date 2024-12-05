import { useState } from "react";

function ApiTest() {
  const [message, setMessage] = useState("");
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  const fetchMessage = async () => {
    setIsLoading(true);
    setError(null);
    try {
      const response = await fetch("http://localhost:5227/api/apitest");
      const data = await response.json();
      setMessage(data.message);
    } catch (err) {
      setError("Failed to fetch message");
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">API Test Page</h1>
      <button
        onClick={fetchMessage}
        className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
        disabled={isLoading}
      >
        {isLoading ? "Loading..." : "Fetch Message"}
      </button>

      {error && <p className="text-red-500 mt-4">{error}</p>}
      {message && <p className="mt-4 text-lg">{message}</p>}
    </div>
  );
}

export default ApiTest;

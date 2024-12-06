import { useState } from "react";

function SearchBar() {
  const [searchInput, setSearchInput] = useState("");
  const [items, setItems] = useState([]);
  const [error, setError] = useState("");
  const [results, setResults] = useState([]); // Added results state

  const handleSubmit = (e) => {
    e.preventDefault();
    if (searchInput.trim()) {
      if (items.length >= 2) {
        setError("Maximum 2 items allowed!");
        setTimeout(() => setError(""), 3000);
        return;
      }
      setItems([...items, searchInput]);
      setSearchInput("");
    }
  };

  const handleDelete = (index) => {
    setItems(items.filter((_, i) => i !== index));
    setError("");
  };

  // TODO: HANDLE THE SEARCH HERE
  const handleSearch = async () => {
    if (items.length > 0) {
      try {
        const queryString = encodeURIComponent(items.join("+"));
        const response = await fetch(`/api/search?query=${queryString}`);
        if (!response.ok) {
          throw new Error("Search failed");
        }
        const data = await response.json();
        setResults(data);
        console.log(data);
      } catch (error) {
        console.error("Error fetching data:", error);
        setError("Search failed. Please try again.");
      }
    } else {
      setError("Please add at least one item to search");
      setTimeout(() => setError(""), 3000);
    }
  };

  return (
    <div className="mb-4">
      <label htmlFor="search" className="block text-gray-700 font-medium mb-2">
        Search Bar
      </label>
      <form onSubmit={handleSubmit} className="flex">
        <input
          type="search"
          id="search"
          value={searchInput}
          onChange={(e) => setSearchInput(e.target.value)}
          placeholder="search for a medicine (max 2 items)"
          className="w-full px-4 py-2 border rounded-full focus:ring-2 focus:ring-blue-500 focus:outline-none"
        />
        <button
          type="button"
          onClick={handleSearch}
          className="ml-2 px-4 py-2 bg-blue-500 text-white rounded-full hover:bg-blue-600 focus:outline-none"
        >
          Search
        </button>
      </form>
      {error && <p className="text-red-500 text-sm mt-2">{error}</p>}
      <ul className="mt-4 space-y-2">
        {items.map((item, index) => (
          <li
            key={index}
            onClick={() => handleDelete(index)}
            className="px-4 py-2 bg-gray-50 rounded-lg shadow-sm hover:bg-gray-100 cursor-pointer flex justify-between items-center"
          >
            <span>{item}</span>
            <span className="text-red-500">×</span>
          </li>
        ))}
      </ul>
      {results.length > 0 && (
        <div className="mt-4">
          <h3 className="text-lg font-semibold mb-2">Search Results:</h3>
          <ul>
            {results.map((result, index) => (
              <li key={index} className="bg-gray-100 p-2 rounded mb-2">
                {JSON.stringify(result)}
              </li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
}

export default SearchBar;

import { useState, useEffect } from "react";

function SearchBar() {
  const [searchInput, setSearchInput] = useState("");
  const [items, setItems] = useState([]);
  const [error, setError] = useState("");

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

  return (
    <div className="mb-4">
      <label htmlFor="search" className="block text-gray-700 font-medium mb-2">
        Search Bar
      </label>
      <form onSubmit={handleSubmit}>
        <input
          type="search"
          id="search"
          value={searchInput}
          onChange={(e) => setSearchInput(e.target.value)}
          placeholder="search for a medicine (max 2 items)"
          className="w-full px-4 py-2 border rounded-full focus:ring-2 focus:ring-blue-500 focus:outline-none"
        />
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
    </div>
  );
}

export default SearchBar;

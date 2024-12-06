import React from "react";

const AdminCreate = () => {
  return (
    <div className="w-full max-w-4xl mx-auto p-6 bg-white shadow-md rounded-lg">
      <h1 className="text-2xl font-bold mb-6">Create New Item</h1>
      <div className="bg-gray-100 p-4 rounded">
        <p>Placeholder for create item functionality</p>
        <form className="mt-4">
          <div className="mb-4">
            <label className="block text-gray-700 text-sm font-bold mb-2">
              Item Name
              <input
                type="text"
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                placeholder="Enter item name"
              />
            </label>
          </div>
          <button
            type="submit"
            className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
          >
            Create Item
          </button>
        </form>
      </div>
    </div>
  );
};

export default AdminCreate;

import React from "react";

const AdminManage = () => {
  return (
    <div className="w-full max-w-4xl mx-auto p-6 bg-white shadow-md rounded-lg">
      <h1 className="text-2xl font-bold mb-6">Manage Items</h1>
      <div className="bg-gray-100 p-4 rounded">
        <p>Placeholder for item management functionality</p>
        <table className="w-full mt-4 border-collapse">
          <thead>
            <tr className="bg-green-200">
              <th className="border p-2">ID</th>
              <th className="border p-2">Name</th>
              <th className="border p-2">Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td className="border p-2 text-center">1</td>
              <td className="border p-2 text-center">please send help</td>
              <td className="border p-2 text-center">
                <button className="bg-blue-500 text-white px-2 py-1 rounded mr-2">
                  Edit
                </button>
                <button className="bg-red-500 text-white px-2 py-1 rounded">
                  Delete
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default AdminManage;

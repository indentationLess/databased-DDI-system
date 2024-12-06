import React, { useState } from "react";

const AdminCreate = () => {
  const [drugData, setDrugData] = useState({
    Name: "",
    GenericName: "",
    BrandName: "",
    DosageForm: "",
    Strength: "",
    DrugCategoryID: "",
    created_at: "",
  });

  const [categories] = useState([
    { id: 1, name: "Antibiotic" },
    { id: 2, name: "Antiviral" },
    // Add more categories as needed
  ]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setDrugData({ ...drugData, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Drug Data Submitted:", drugData);
  };

  return (
    <div className="w-full max-w-4xl mx-auto p-6 bg-white shadow-md rounded-lg">
      <h1 className="text-2xl font-bold mb-6">Create New Drug</h1>
      <form
        onSubmit={handleSubmit}
        className="grid grid-cols-1 md:grid-cols-2 gap-6"
      >
        <div>
          <label className="block text-gray-700 font-bold mb-1">Name</label>
          <input
            type="text"
            name="Name"
            value={drugData.Name}
            onChange={handleInputChange}
            className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
            required
          />
        </div>

        <div>
          <label className="block text-gray-700 font-bold mb-1">
            Generic Name
          </label>
          <input
            type="text"
            name="GenericName"
            value={drugData.GenericName}
            onChange={handleInputChange}
            className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
          />
        </div>

        <div>
          <label className="block text-gray-700 font-bold mb-1">
            Brand Name
          </label>
          <input
            type="text"
            name="BrandName"
            value={drugData.BrandName}
            onChange={handleInputChange}
            className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
          />
        </div>

        <div>
          <label className="block text-gray-700 font-bold mb-1">
            Dosage Form
          </label>
          <input
            type="text"
            name="DosageForm"
            value={drugData.DosageForm}
            onChange={handleInputChange}
            className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
          />
        </div>

        <div>
          <label className="block text-gray-700 font-bold mb-1">Strength</label>
          <input
            type="text"
            name="Strength"
            value={drugData.Strength}
            onChange={handleInputChange}
            className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
          />
        </div>

        <div>
          <label className="block text-gray-700 font-bold mb-1">
            Drug Category
          </label>
          <select
            name="DrugCategoryID"
            value={drugData.DrugCategoryID}
            onChange={handleInputChange}
            className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
            required
          >
            <option value="" disabled>
              Select Category
            </option>
            {categories.map((category) => (
              <option key={category.id} value={category.id}>
                {category.name}
              </option>
            ))}
          </select>
        </div>

        <div>
          <label className="block text-gray-700 font-bold mb-1">
            Created At
          </label>
          <input
            type="datetime-local"
            name="created_at"
            value={drugData.created_at}
            onChange={handleInputChange}
            className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
          />
        </div>

        <div className="col-span-full">
          <button
            type="submit"
            className="w-full bg-green-600 text-white py-2 rounded-lg hover:bg-green-700"
          >
            Create Drug
          </button>
        </div>
      </form>
    </div>
  );
};

export default AdminCreate;

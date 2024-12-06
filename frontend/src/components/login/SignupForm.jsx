import { useState } from "react";

function SignupForm() {
  const [userType, setUserType] = useState("user");
  const [firstName, setFirstName] = useState("");
  const [middleName, setMiddleName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [address, setAddress] = useState({
    street: "",
    city: "",
    state: "",
    zipCode: "",
  });
  const [specialty, setSpecialty] = useState("");

  const handleAddressChange = (e) => {
    setAddress({ ...address, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Form submitted!");
    console.log("User Type:", userType);
    console.log("First Name:", firstName);
    console.log("Middle Name:", middleName);
    console.log("Last Name:", lastName);
    console.log("Email:", email);
    console.log("Password:", password);
    console.log("Address:", address);
    if (userType === "admin") {
      console.log("Specialty:", specialty);
    }
  };

  return (
    <div className="bg-white p-6 rounded-lg shadow-sm max-w-4xl mx-auto">
      <form onSubmit={handleSubmit}>
        <h1 className="text-2xl font-bold mb-6 text-center">Sign Up</h1>

        {/* User Type Selection */}
        <div className="mb-4">
          <div className="flex justify-center gap-8">
            <label className="flex items-center">
              <input
                type="radio"
                value="user"
                checked={userType === "user"}
                onChange={(e) => setUserType(e.target.value)}
                className="mr-2"
              />
              Patient
            </label>
            <label className="flex items-center">
              <input
                type="radio"
                value="admin"
                checked={userType === "admin"}
                onChange={(e) => setUserType(e.target.value)}
                className="mr-2"
              />
              Healthcare Provider
            </label>
          </div>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <div>
            <label className="block text-gray-700 mb-1">First Name</label>
            <input
              type="text"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
              className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
              required
            />
          </div>
          <div>
            <label className="block text-gray-700 mb-1">Middle Name</label>
            <input
              type="text"
              value={middleName}
              onChange={(e) => setMiddleName(e.target.value)}
              className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
            />
          </div>
          <div>
            <label className="block text-gray-700 mb-1">Last Name</label>
            <input
              type="text"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
              className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
              required
            />
          </div>

          <div>
            <label className="block text-gray-700 mb-1">Street Address</label>
            <input
              type="text"
              name="street"
              value={address.street}
              onChange={handleAddressChange}
              className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
              required
            />
          </div>
          <div>
            <label className="block text-gray-700 mb-1">City</label>
            <input
              type="text"
              name="city"
              value={address.city}
              onChange={handleAddressChange}
              className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
              required
            />
          </div>
          <div>
            <label className="block text-gray-700 mb-1">State</label>
            <input
              type="text"
              name="state"
              value={address.state}
              onChange={handleAddressChange}
              className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
              required
            />
          </div>
          <div>
            <label className="block text-gray-700 mb-1">Zip Code</label>
            <input
              type="text"
              name="zipCode"
              value={address.zipCode}
              onChange={handleAddressChange}
              className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
              required
            />
          </div>

          {userType === "admin" && (
            <div>
              <label className="block text-gray-700 mb-1">Specialty</label>
              <input
                type="text"
                value={specialty}
                onChange={(e) => setSpecialty(e.target.value)}
                className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
                required
              />
            </div>
          )}

          <div>
            <label className="block text-gray-700 mb-1">Email</label>
            <input
              type="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
              required
            />
          </div>
          <div>
            <label className="block text-gray-700 mb-1">Password</label>
            <input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
              required
            />
          </div>
        </div>

        <button
          type="submit"
          className="mt-6 w-full bg-green-600 text-white py-2 rounded-lg hover:bg-green-700"
        >
          Sign Up
        </button>
      </form>
    </div>
  );
}

export default SignupForm;

import { useState } from "react";

function SignupForm() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [userType, setUserType] = useState("user");

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Form submitted!");
    console.log("Email:", email);
    console.log("Password:", password);
    console.log("User Type:", userType);
  };

  return (
    <div className="bg-white p-6 rounded-lg shadow-sm">
      <form onSubmit={handleSubmit}>
        <h1 className="text-2xl font-bold mb-4">Get Started</h1>

        <div className="mb-3">
          <label className="block text-gray-700 mb-1">Email</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
            required
          />
        </div>

        <div className="mb-3">
          <label className="block text-gray-700 mb-1">Password</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
            required
          />
        </div>

        <div className="mb-4">
          <label className="block text-gray-700 mb-1">User Type</label>
          <div className="flex gap-4">
            <label className="flex items-center">
              <input
                type="radio"
                value="user"
                checked={userType === "user"}
                onChange={(e) => setUserType(e.target.value)}
                className="mr-2"
              />
              User
            </label>
            <label className="flex items-center">
              <input
                type="radio"
                value="admin"
                checked={userType === "admin"}
                onChange={(e) => setUserType(e.target.value)}
                className="mr-2"
              />
              Admin
            </label>
          </div>
        </div>

        <button
          type="submit"
          className="w-full bg-green-600 text-white py-2 rounded-lg hover:bg-green-700"
        >
          Sign Up
        </button>
      </form>
    </div>
  );
}

export default SignupForm;

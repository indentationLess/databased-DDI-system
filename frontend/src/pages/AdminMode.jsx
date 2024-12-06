import { Link } from "react-router-dom";

const AdminMode = () => (
  <div className="w-full max-w-4xl mx-auto">
    <h1 className="text-2xl font-bold mb-6">Admin Dashboard</h1>
    <div className="grid grid-cols-2 gap-4">
      <Link
        to="/admin/create"
        className="p-4 bg-green-100 rounded-lg hover:bg-green-200 text-center"
      >
        Create Item
      </Link>
      <Link
        to="/admin/manage"
        className="p-4 bg-green-100 rounded-lg hover:bg-green-200 text-center"
      >
        Manage Items
      </Link>
    </div>
  </div>
);

export default AdminMode;

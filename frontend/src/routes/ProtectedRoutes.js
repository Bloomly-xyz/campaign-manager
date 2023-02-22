import { Navigate, Outlet } from "react-router-dom";

const ProtectedRoutes = ({ isLoggedIn }) => {
	
	
	

	return isLoggedIn ? (
		<Outlet/>
	) : (
		<Navigate to="/login" />
	);
};

export default ProtectedRoutes;
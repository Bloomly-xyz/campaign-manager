import "./App.css";
import ConnectWallet from "./pages/ConnectWallet";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import ProtectedRoutes from "./routes/ProtectedRoutes";
import NFTListing from "./pages/NFTListing";
import NotFoundPage from "./pages/NotFoundPage";
import AuthLayout from "./components/common/layouts/AuthLayout";
import DashboardLayout from "./components/common/layouts/DashboardLayout";
import Drafts from "./pages/Drafts";
import Settings from "./pages/Settings";
import {  useSelector } from "react-redux";
import CreateCampaign from "./pages/CreateCampaign";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import ClaimUtilityLayout from "./components/common/layouts/ClaimUtilityLayout";
import ClaimUtility from "./pages/ClaimUtility";
import NotFoundLayout from "./components/common/layouts/NotFoundLayout";
import OopsPage from "./pages/OopsPage";
import NftCampaignDetail from "./pages/NftCampaignDetail";
import Loader from "./helpers/toast-component/Loader";
function App() {
  const { isLoggedIn } = useSelector((state) => state.user);
 
  return (
    <>
    <Loader />
      <ToastContainer autoClose={15000}/>
      <BrowserRouter>
        <Routes>
          <Route element={<AuthLayout />}>
            <Route element={<Navigate to="login" />} path="/" />
            <Route element={<ConnectWallet />} path="/login" />
          </Route>

          <Route element={<ProtectedRoutes isLoggedIn={isLoggedIn} />}>
            <Route element={<DashboardLayout />}>
              <Route element={<NFTListing />} path="/nft-campaigns" />
              <Route element={<NftCampaignDetail />} path="/campaign-detail/:id" />

              <Route element={<CreateCampaign />} path="/create-NFT-campaign" />
              <Route element={<Drafts />} path="/drafts" />
              <Route element={<Settings />} path="/settings" />
            </Route>
          </Route>
          <Route element={<ClaimUtilityLayout />}>
            <Route element={<ClaimUtility />} path="/claim-utility/:id" />
          </Route>
          <Route element={<NotFoundLayout />}>
            <Route path="/oops" element={<OopsPage />} />
            <Route path="*" element={<NotFoundPage />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;

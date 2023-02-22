import React from "react";
import { useDispatch } from "react-redux";
import { Link } from "react-router-dom";
import { menuItems } from "../../../constants/sidebar-menu-constants/sidebar-menu-constants";
import useBloctoAuthHook from "../../../cutome-Hooks/useBloctoAuthHook";
import { logout } from "../../../redux/slices/user/userSlice";
import images from "./../../../constants/images-constants/images";
import MenuItem from "./sidebar-menus-component/MenuItem";

const Sidebar = () => {
  const dispatch=useDispatch();
  const {logOutBlocto}=useBloctoAuthHook()
  const logOutHandler=()=>{
    logOutBlocto();
    dispatch(logout());
  }
  return (
    <>
    
      <div className="flex flex-col fixed top-0 left-0   h-full min-h-screen  w-60 bg-[#12221A] pr-6 pt-10 rounded-r-2xl bg-[url('/src/assets/images/sidebar-after-icon.svg')] bg-no-repeat bg-contain bg-bottom">
        <div className="mb-10 text-center">
         <Link to="/nft-campaigns"> <img className="inline-block" src={images.DashboardLogo} alt="logo" /></Link>
        </div>
        <nav className="relative flex flex-col grow">
          <ul className="grow">
            {menuItems.map((menu, index) => (
              <MenuItem key={index} menu={menu} />
            ))}
          </ul>
          <div className="relative ">
          <Link to={"/login"} onClick={logOutHandler} className={`   flex items-center   py-3 px-6 hover:bg-[#A5F33C]/25 rounded-r-lg  hover:before:top-0 hover:before:left-0 hover:before:absolute hover:before:h-full hover:before:w-1 hover:before:bg-[#A5F33C] hover:before:rounded-r`}>
              <img className="inline mr-4" src={images.LogoutIcon} alt="icon" />
              <span className="text-sm font-bold text-white">Logout</span>
            </Link>
            </div>
         
           
        
        </nav>
      </div>

     
     
    </>
  );
};

export default Sidebar;

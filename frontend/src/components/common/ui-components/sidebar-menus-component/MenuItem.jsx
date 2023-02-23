import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { setMenuSelected } from "../../../../redux/slices/sidebar-menu/sidebarMenuSlice";

const MenuItem = (props) => {
  const dispatch = useDispatch();
  const { menuSelected } = useSelector((state) => state.sidebar);
  const { menu } = props;
  return (
    <>
      <li
        onClick={() => {
          if(menu.value ===2 || menu.value === 3)return
          dispatch(setMenuSelected(menu.value));
        }}
        className={`${
          menu.value === menuSelected && "bg-[#A5F33C]/25 menu-selected-before"} ${(menu.value ===2 || menu.value === 3 )&& 'cursor-not-allowed ' }
         mb-6 relative py-3 px-6 hover:bg-[#A5F33C]/25 rounded-r-lg  hover:before:top-0 hover:before:left-0 hover:before:absolute hover:before:h-full hover:before:w-1 hover:before:bg-[#A5F33C] hover:before:rounded-r`}
      >
        <Link to={(menu.value === 2 || menu.value === 3) ? "#" : menu.url} className={`flex items-center ${(menu.value === 2 || menu.value === 3) && 'cursor-not-allowed ' } `} >
          <img className="inline mr-4" src={menu.icon} alt="icon" />
          <span className="text-sm font-bold text-white">{menu.title}</span>
        </Link>
      </li>
    </>
  );
};

export default MenuItem;

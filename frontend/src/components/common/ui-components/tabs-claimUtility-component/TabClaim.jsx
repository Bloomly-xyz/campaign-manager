import React from "react";


const TabClaim = (props) => {
  const { openTab, setOpenTab, value, children } = props;
  return (
    <>
      
        <div
         
          onClick={() => setOpenTab(value)}
          className={` mr-3  text-center px-8 py-2 inline-block rounded-t   cursor-pointer   text-base font-semibold  border    ${
            openTab === value ? "bg-[#A5F33C]/10 text-white border-[#A5F33C]  border-b-0" : "bg-[#1E1E1E] text-white border-white/25 "
          } `}
        >
          {children}
        </div>
      
    </>
  );
};

export default TabClaim;

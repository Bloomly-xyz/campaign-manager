import React from "react";


const Tab = (props) => {
  const { openTab, setOpenTab, value, children } = props;
  return (
    <>
      
        <div
          onClick={() => setOpenTab(value)}
          className={`${value===3 || value===4 ? "pointer-events-none cursor-not-allowed":" cursor-pointer "} mr-3  text-center px-8 py-2 inline-block rounded-t     text-base font-semibold  border-0    ${
            openTab === value ? "bg-[#213E28] text-white " : "bg-[#FFFFFF] text-[#12221A]"
          } `}
        >
          {children}
        </div>
      
    </>
  );
};

export default Tab;

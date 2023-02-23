import React from "react";

const TabBodyClaim = ({ children ,physical, digital, experimental }) => {
  return (
    <>
      <div className={`relative block w-full bg-[#1E1E1E] ${(physical || digital || experimental) && 'p-6'}   border border-solid rounded-lg rounded-tl-none border-white/25` }>
        {children}
      </div>
    </>
  );
};

export default TabBodyClaim;

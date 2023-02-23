import React from "react";

const TabBody = ({ children }) => {
  return (
    <>
      <div className="relative block w-full bg-white p-6 border border-solid rounded-lg rounded-tl-none border-white/25 min-h-[calc(100vh-386px)]">
        {children}
      </div>
    </>
  );
};

export default TabBody;

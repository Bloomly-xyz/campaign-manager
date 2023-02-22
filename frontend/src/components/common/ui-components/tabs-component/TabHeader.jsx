import React from "react";

const TabHeader = ({ children }) => {
  return (
    <>
      
        <div className="flex">
          <ul className="flex ">{children}</ul>
      </div>
    </>
  );
};

export default TabHeader;

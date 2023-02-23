import React from "react";

const TabComponent = ({ children }) => {
  return (
    <>
      <div className="container relative z-10 block overflow-hidden">{children}</div>
    </>
  );
};

export default TabComponent;

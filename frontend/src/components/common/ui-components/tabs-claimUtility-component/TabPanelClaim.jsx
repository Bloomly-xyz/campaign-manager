import React from "react";

const TabPanelClaim = (props) => {
    const {openTab ,value ,children} = props
  return (
    <>
      <div className={openTab === value ? "block" : "hidden"}>
        {children}
        
      </div>
    </>
  );
};

export default TabPanelClaim;

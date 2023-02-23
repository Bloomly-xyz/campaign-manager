import React from "react";

const TabPanel = (props) => {
    const {openTab ,value ,children} = props
  return (
    <>
      <div className={openTab === value ? "block" : "hidden"}>
        {children}
        
      </div>
    </>
  );
};

export default TabPanel;

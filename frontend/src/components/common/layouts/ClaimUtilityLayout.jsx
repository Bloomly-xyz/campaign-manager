import React from "react";
import { Outlet } from "react-router-dom";
import ClaimUtilityFooter from "../../claim-utility-components/ClaimUtilityComponents/ClaimUtilityFooter";

import ClaimUtilityHeader from "../../claim-utility-components/ClaimUtilityComponents/ClaimUtilityHeader";

const ClaimUtilityLayout = () => {
  return (
    <>
      <main className="relative min-h-screen font-manrope">
        <div className="   relative overflow-hidden min-h-screen bg-no-repeat bg-[length:100%_100%] bg-center bg-[url('/src/assets/images/claim-utility-bg.png')]">
          <div className="xl:container xl:px-16  sm-md:max-w-[1150px] px-4 md-lg:px-16 m-auto  z-[1px] relative  ">
            <ClaimUtilityHeader />
            <div className="min-h-[calc(100vh-215px)]">
              <Outlet />
            </div>

            <ClaimUtilityFooter />
          </div>
        </div>
      </main>
    </>
  );
};

export default ClaimUtilityLayout;

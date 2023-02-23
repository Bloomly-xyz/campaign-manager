import React from "react";
import { Outlet } from "react-router-dom";
import AuthRightContent from "./../../auth-component/AuthRightContent";

const AuthLayout = () => {
  return (
    <>
      <main className="min-h-screen relative font-manrope">
        <div className="flex justify-center items-center relative overflow-hidden min-h-screen bg-no-repeat bg-[length:100%_100%] bg-center bg-[url('/src/assets/images/login-bg.png')]">
          <div className="xl:container  sm-md:max-w-[1150px] px-4 md-lg:px-16 m-auto  z-[1px] relative  ">
            <div className="grid grid-cols-2 gap-2 min-h-[calc(100vh-192px)]">
              <Outlet />

              <AuthRightContent />
            </div>
          </div>
        </div>
      </main>
    </>
  );
};

export default AuthLayout;

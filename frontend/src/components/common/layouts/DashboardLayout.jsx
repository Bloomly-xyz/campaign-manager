import React from "react";
import { Outlet } from "react-router";
import Sidebar from "../ui-components/Sidebar";

const DashboardLayout = () => {
  return (
    <>
      <main className="relative min-h-screen font-manrope">
        <div className=" relative overflow-hidden min-h-screen bg-no-repeat bg-[length:100%_100%] bg-center bg-[url('/src/assets/images/dashboard-bg.png')]">
          <div className="flex w-full">
            <div className="h-screen">
              <Sidebar />
            </div>
            <div className="flex-auto px-10 ml-60">
             
              <Outlet />
            </div>
          </div>
        </div>
      </main>
    </>
  );
};

export default DashboardLayout;

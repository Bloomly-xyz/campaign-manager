import { Tooltip } from "@material-tailwind/react";
import React from "react";

const TabClaim = (props) => {
  const { openTab, setOpenTab, value, children, tooltip } = props;
  return (
    <>
      {tooltip ? (
        <Tooltip
          className="text-[#12221A] px-4 py-1 rounded bg-white   max-w-[200px] relative z-50"
          offset={10}
          placement={"top-center"}
          content={"coming soon "}
        >
           <div
          //  onClick={() => setOpenTab(value)}
            className={`  cursor-not-allowed   mr-3  text-center px-8 py-2 inline-block rounded-t      text-base font-semibold  border    ${
              openTab === value
                ? "bg-[#1E1E1E] text-white border-white/25"
                : "bg-[#1E1E1E] text-white border-white/25 "
            } `}
          >
            {children}
          </div>
        </Tooltip>
      ) : (
        <>
          <div
            onClick={() => setOpenTab(value)}
            className={` mr-3  text-center px-8 py-2 inline-block rounded-t   cursor-pointer   text-base font-semibold  border    ${
              openTab === value
                ? "bg-[#A5F33C]/10 text-white border-[#A5F33C]  border-b-0"
                : "bg-[#1E1E1E] text-white border-white/25 "
            } `}
          >
            {children}
          </div>
        </>
      )}
    </>
  );
};

export default TabClaim;

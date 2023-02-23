import React from "react";
import Countdown, { zeroPad } from "react-countdown";
import { useNavigate } from "react-router-dom";

const ClaimUtilityTimer = (props) => {
  const navigate = useNavigate();
  const {timeInMilliSeconds} = props;
  const renderer = ({ days, hours, minutes, seconds, completed }) => {
    if (completed) {
        // Render a completed state
        navigate("/oops");
    } else {
        // Render a countdown
        return (
          <>
          <div className="px-4 py-2 border border-[#A4B1A7]/25 rounded-[19px] inline-block mr-4 ">
          <div className="flex flex-col justify-center ">
            <span className="text-center min-w-[36px] min-h-[36px] text-2xl font-bold text-white">
            {zeroPad(days)}
            </span>
            <span className="text-base font-normal text-center text-white/70 ">
              Days
            </span>
          </div>
        </div>
        <div className="px-4 py-2 border border-[#A4B1A7]/25 rounded-[19px] inline-block mr-4 ">
          <div className="flex flex-col justify-center ">
            <span className="text-center min-w-[36px] min-h-[36px] text-2xl font-bold text-white">
            {zeroPad(hours)}
            </span>
            <span className="text-base font-normal text-center text-white/70 ">
              Hrs
            </span>
          </div>
        </div>
        <div className="px-4 py-2 border border-[#A4B1A7]/25 rounded-[19px] inline-block mr-4 ">
          <div className="flex flex-col justify-center ">
            <span className="text-center min-w-[36px] min-h-[36px] text-2xl font-bold text-white">
            {zeroPad(minutes)}
            </span>
            <span className="text-base font-normal text-center text-white/70 ">
              Min
            </span>
          </div>
        </div>
        <div className="px-4 py-2 border border-[#A4B1A7]/25 rounded-[19px] inline-block ">
          <div className="flex flex-col justify-center ">
            <span className="text-center min-w-[36px] min-h-[36px] text-2xl font-bold text-white">
            {zeroPad(seconds)}
            </span>
            <span className="text-base font-normal text-center text-white/70 ">
              Sec
            </span>
          </div>
        </div>
        </>
        );
    }
};
  return (
    <>
     
      <Countdown
            date={timeInMilliSeconds - new Date().getUTCMilliseconds()}
            renderer={renderer}
        />
      
    </>
  );
};

export default ClaimUtilityTimer;

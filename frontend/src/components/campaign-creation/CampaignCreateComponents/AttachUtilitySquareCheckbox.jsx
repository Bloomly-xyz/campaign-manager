import React from "react";

const AttachUtilitySquareCheckbox = (props) => {
  const { checkedIcon, label, checked } = props;
  return (
    <>
      <label className={`flex items-center justify-start  `}>
        <div className={`flex items-center justify-center flex-shrink-0 w-5 h-5 mr-2 ${checked ? 'bg-[#A5F33C]' :'bg-white'} ${checked ? '' : 'border-[#213E28]'}  rounded border-2   focus-within:border-[#A5F33C]`}>
          <input type="checkbox" checked={checked} className="absolute opacity-0" />

        {checked && <img src={checkedIcon} alt="icon" /> }  
        </div>
        <div className="text-[#12221A] text-base font-extrabold capitalize">
          {label}
        </div>
      </label>
    </>
  );
};

export default AttachUtilitySquareCheckbox;

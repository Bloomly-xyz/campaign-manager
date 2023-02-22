import React from "react";
import images from "../../../../constants/images-constants/images";

const CustomCheckbox = (props) => {
  const { isChecked, value, onChange, label ,disable ,comingSoon } = props;
  return (
    <>
      <label className={`flex items-center justify-start ${disable ? ' cursor-not-allowed ' : 'cursor-pointer'} `}>
        <div className="flex items-center justify-center flex-shrink-0 w-5 h-5 mr-2 bg-white border-2 border-[#213E28] rounded-full focus-within:border-[#213E28]">
          <input
            type="checkbox"
            onChange={onChange}
            className="absolute opacity-0"
          />
          {isChecked === value && (
            <img src={images.RadioCheckedIcon} alt="icon" />
          )}
        </div>
        <div className="text-[#12221A] text-base font-bold capitalize">{label}</div> 
        {comingSoon && <span className="text-white text-xs  px-1 py-[2px]  bg-[#213E28] font-extrabold rounded-full ml-2">Coming Soon</span>}
      </label>
    </>
  );
};

export default CustomCheckbox;

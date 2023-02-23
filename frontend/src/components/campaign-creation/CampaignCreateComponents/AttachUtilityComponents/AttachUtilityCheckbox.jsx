import React from "react";
import images from "../../../../constants/images-constants/images";
import stringTruncate from './../../../../helpers/StringTruncate';

const AttachUtilityCheckbox = (props) => {
  const { data, selectedUtility, onChange } = props;
  return (
    <>
      <label className={` cursor-pointer ${data?.type !== 'Physical' ? "pointer-events-none cursor-not-allowed" : ""}`}>
        <div className={`relative inline-flex items-center flex-col p-4  ${selectedUtility?.value === data.value ? 'bg-[#213E28]' :'bg-[#F8F8F8]'}  max-w-[191px] rounded-3xl mr-3 mb-6`} >
          <div className={`absolute left-6 top-6`}>
            <input
              type={"checkbox"}
              onChange={() =>onChange(data)}
              className={`hidden `}
            />
            {selectedUtility?.value === data.value && (
              <img
                className="w-5 h-5 bg-[#A5F33C] rounded"
                src={images.CheckboxCheckedIcon}
                alt="icon"
              />
            )}
          </div>

          <div className="text-center">
            <img className="inline" src={(selectedUtility?.value === 2  && data.title === 'Merch') ? images.MerchIconWhite  : data.image} alt="icon" />
            <h4 className={` ${ selectedUtility?.value === data.value ? 'text-white':'text-[#12221A]'  } text-base font-extrabold mb-1`}>
              {data.title}
            </h4>
            <p className={`text-xs ${ selectedUtility?.value === data.value ? 'text-white/70':'text-[#12221A]/70'   } text-ellipsis h-[32px] w-[160px] `}>{stringTruncate(data.description ,50)   }</p>
          </div>
        </div>
      </label>
    </>
  );
};

export default AttachUtilityCheckbox;

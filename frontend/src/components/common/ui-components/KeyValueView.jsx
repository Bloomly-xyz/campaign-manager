import React from "react";

const KeyValueView = (props) => {
  const{title ,value ,styleValue} = props;
  return (
    <>
      <div className={`${styleValue}`}>
        <p className="text-[#12221A]/70 text-xs">
          {title}
        </p>
        <h4 className="text-base text-[#12221A] font-medium">
          {value}
        </h4>
      </div>
    </>
  );
};

export default KeyValueView;

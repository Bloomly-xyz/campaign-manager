import React from "react";

const PhysicalClaimUtility = (props) => {
  const{physicalClaimUtilityData} = props;

  return (
    <>
      <div>
        <h3 className="mb-2 text-base font-extrabold text-white">{physicalClaimUtilityData?.name ?? '-'} </h3>
        <p className="text-base text-white/70">
          {physicalClaimUtilityData?.description ?? '-'}
        </p>
      </div>
    </>
  );
};

export default PhysicalClaimUtility;

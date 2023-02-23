import moment from "moment";
import React from "react";

import KeyValueView from "../../common/ui-components/KeyValueView";

const Confirmation = (props) => {
  const { campaignCreationData ,setOpenUtilityForm, setActiveStep ,file,nftContractData,nextBtnClickHandler ,cancelBtnClickHandler } = props;
  const { PhysicalUtilityData } = campaignCreationData?.AttachUtility || {};


  return (
    <>
      <div className="p-6 bg-white rounded-3xl">
        <div className="grid grid-cols-2 gap-4 ">
          <div className="max-w-[526px] ">
            <h3 className="text-[#12221A] text-2xl font-extrabold mb-8">
              Contract Details
            </h3>
            <div className="flex mb-8">
              <KeyValueView
                title={"Address Containing Your NFT Contract"}
                value={nftContractData?.contractAddress}
                styleValue={"mr-6"}
              />
              <KeyValueView title={"Selected Contract"} value={nftContractData?.contractName} />
            </div>
            <div className="mb-8">
              <KeyValueView
                title={"Storage Path Your NFT Collection Uses"}
                value={nftContractData?.contractStoragePath}
              />
            </div>
            <div className="mb-8">
              <KeyValueView
                title={"Collection Public Path"}
                value={nftContractData?.collectionPublicPath}
              />
            </div>
            <div>
              <h3 className="text-[#12221A] text-2xl font-extrabold mb-8">
                Community Targeting
              </h3>
              <div className="flex mb-8">
                <KeyValueView
                  title={"Target "}
                  value={"Selected Collection"}
                  styleValue={"mr-6 min-w-[170px]"}
                />
                <KeyValueView
                  title={"Type of Target"}
                  value={"Full Collection"}
                />
              </div>
            </div>
          </div>
        </div>
        <div className="grid grid-cols-2 gap-4 ">
          <div className="max-w-[526px]">
            <div className="max-w-[390px]">
              <h3 className="text-[#12221A] text-2xl font-extrabold mb-8">
                Utility
              </h3>
              <div className="flex mb-8">
                <KeyValueView
                  title={"Name"}
                  value={PhysicalUtilityData?.name ?? "-"}
                  styleValue={"mr-6 min-w-[170px]"}
                />
                <KeyValueView
                  title={"Item/Category"}
                  value={PhysicalUtilityData?.category?.value ?? "-"}
                />
              </div>
              <div className="flex mb-8">
                <KeyValueView
                  title={"Cost Per Unit"}
                  value={PhysicalUtilityData?.costPerUnit ?? "-"}
                  styleValue={"mr-6 min-w-[170px]"}
                />
                <KeyValueView
                  title={"Location"}
                  value={PhysicalUtilityData?.country?.value ?? "-"}
                />
              </div>
              <div className="flex mb-8">
                <KeyValueView
                  title={"Provider"}
                  value={PhysicalUtilityData?.provider ?? "-"}
                  styleValue={"mr-6 min-w-[170px]"}
                />
                <KeyValueView
                  title={"Courier/Shipping Partner"}
                  value={PhysicalUtilityData?.shippingPartner?.value ?? "-"}
                />
              </div>
              <div className="mb-8 ">
                <KeyValueView
                  title={"Expiry Date"}
                  value={
                    PhysicalUtilityData?.expirydate
                      ? moment(PhysicalUtilityData?.expirydate).format("MMMM D, YYYY")
                      : "-"
                  }
                />
              </div>
              <div className="mb-8 ">
                <KeyValueView
                  title={"Description "}
                  value={PhysicalUtilityData?.description ?? "-"}
                />
              </div>
            </div>
          </div>

          <div>
            <div className="flex flex-col overflow-hidden items-center bg-[#12221A]/[0.02] justify-center max-w-[460px] max-h-[412px]  text-white  border-2 p-8 border-[#12221A]/10 border-solid rounded-xl w-full min-h-[96px] h-full">
              <img src={file} alt="icon" className='max-h-[330px]' />
            </div>
          </div>
        </div>
        <div className="grid grid-cols-2 gap-4 ">
            <div className="max-w-[526px] ">
              <div className="flex ">
                <button
                  className="mr-6 btn-secondary "
                  onClick={() => {
                    setActiveStep(3)
                    setOpenUtilityForm(true )
                  }}
                >
                  Back
                </button>
                <button  className=" btn-primary" onClick={()=>nextBtnClickHandler(4)}>
                Submit
                </button>
              </div>
            </div>
            <div className="flex justify-end">
              <button className="text-[#12221A] text-base font-semibold" onClick={cancelBtnClickHandler}>
                Cancel
              </button>
            </div>
          </div>
      </div>
    </>
  );
};

export default Confirmation;

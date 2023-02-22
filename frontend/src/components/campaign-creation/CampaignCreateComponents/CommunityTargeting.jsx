import React , { useEffect }  from "react";
import images from "../../../constants/images-constants/images";
import CustomCheckbox from "../../common/ui-components/form-ui/CustomCheckbox";
import AttachUtilitySquareCheckbox from "./AttachUtilitySquareCheckbox";

const CommunityTargeting = (props) => {
  const {
    selectCollection,
    handleChangeCollection,
    setSteps,
    steps,
    setActiveStep,
    nextBtnClickHandler,
    setNFTContractData
  } = props;

  const handleBack =() => {
   
    setActiveStep(1)
  }
  useEffect(() => {
    let obj={
      CommunityTargeting:"FullCollection"
    }
    setNFTContractData(prevState => ({
      ...prevState,
      campaignJson: JSON.stringify(obj),
    }));
   
  }, [])
  
  return (
    <>
      <div className="p-6 bg-white rounded-3xl">
        <div className="grid grid-cols-2 gap-4 ">
          <div className="max-w-[526px] ">
            <h3 className="text-[#12221A] text-2xl font-extrabold mb-3">
              Community Targeting
            </h3>
            <p className="text-[#12221A]/70 text-xs font-medium mb-6">
              Define who in the community is eligible to claim your utility.
            </p>
            {/** select collection section */}
            <div className="flex justify-between mb-10">
              <CustomCheckbox
                isChecked={selectCollection}
                value={1}
                onChange={() => {
                  handleChangeCollection(1);
                }}
                label={"Full Collection"}
              />
              <CustomCheckbox
                isChecked={selectCollection}
                value={2}
                onChange={() => {
                  handleChangeCollection(2);
                }}
                label={"Selected Collection"}
                comingSoon={true}
              />
            </div>
          </div>
        </div>
        {selectCollection === 1 && (
          <>
            <div className="grid grid-cols-2 gap-4 ">
              <div className="max-w-[526px] ">
                <div className="flex ">
                  <button className="mr-6 btn-secondary " onClick={handleBack}>
                    Back
                  </button>
                  <button
                    className=" btn-primary"
                    onClick={()=>nextBtnClickHandler(2)}
                  >
                    Next
                  </button>
                </div>
              </div>
              <div className="flex justify-end">
                <button className="text-[#12221A] text-base font-semibold">
                  Cancel
                </button>
              </div>
            </div>
          </>
        )}

        {selectCollection === 2 && (
          <>
            <div className="bg-[#F3F4F4] p-4 max-w-[494px] mt-6 rounded-lg mb-6">
              <div className="flex justify-between">
                <div>
                  <AttachUtilitySquareCheckbox
                    checkedIcon={images.CustomCheckedIcon}
                    label={"Specific to User"}
                    checked={true}
                  />

                  <div className="py-4 border border-b-[1px] border-[#9e9f9fd9]/50 border-t-0 border-l-0 border-r-0">
                    <span className="text-[#12221A]/70 text-xs mb-4 inline-block">
                      Specific to User
                    </span>
                    <div className="flex">
                      <div className="mr-3">
                        <span className="bg-white text-[#12221A] rounded-full px-1">
                          0x22bD...BA4B
                          <img
                            src={images.CloseIconSm}
                            alt="icon"
                            className="inline ml-1"
                          />
                        </span>
                      </div>
                      <div className="mr-3">
                        <span className="bg-white text-[#12221A] rounded-full px-1">
                          0x87FD...KJ54
                          <img
                            src={images.CloseIconSm}
                            alt="icon"
                            className="inline ml-1"
                          />
                        </span>
                      </div>
                      <div className="mr-3">
                        <span className="bg-white text-[#12221A] rounded-full px-1">
                          0x2298...BS34
                          <img
                            src={images.CloseIconSm}
                            alt="icon"
                            className="inline ml-1"
                          />
                        </span>
                      </div>
                    </div>
                  </div>
                </div>
                <div>
                  <img src={images.ChevronUp} alt="icon" />
                </div>
              </div>
            </div>
            <div className="bg-[#F3F4F4] p-4 max-w-[494px] mt-6 rounded-lg mb-6">
              <div className="flex justify-between">
                <div>
                  <AttachUtilitySquareCheckbox
                    checkedIcon={images.CustomCheckedIcon}
                    label={"Allowlist"}
                    checked={false}
                  />
                </div>
                <div>
                  <img src={images.ChevronDown} alt="icon" />
                </div>
              </div>
            </div>
            <div className="bg-[#F3F4F4] p-4 max-w-[494px] mt-6 rounded-lg mb-6">
              <div className="flex justify-between">
                <div>
                  <AttachUtilitySquareCheckbox
                    checkedIcon={images.CustomCheckedIcon}
                    label={"Properties"}
                    checked={false}
                  />
                </div>
                <div>
                  <img src={images.ChevronDown} alt="icon" />
                </div>
              </div>
            </div>
            <div className="bg-[#F3F4F4] p-4 max-w-[494px] mt-6 rounded-lg mb-6">
              <div className="flex justify-between">
                <div>
                  <AttachUtilitySquareCheckbox
                    checkedIcon={images.CustomCheckedIcon}
                    label={"Multi NFT Holder"}
                    checked={false}
                  />
                </div>
                <div>
                  <img src={images.ChevronDown} alt="icon" />
                </div>
              </div>
            </div>
            <div className="bg-[#F3F4F4] p-4 max-w-[494px] mt-6 rounded-lg mb-6">
              <div className="flex justify-between">
                <div>
                  <AttachUtilitySquareCheckbox
                    checkedIcon={images.CustomCheckedIcon}
                    label={"Specific to Amount Time Holder "}
                    checked={false}
                  />
                </div>
                <div>
                  <img src={images.ChevronDown} alt="icon" />
                </div>
              </div>
            </div>
            <div className="bg-[#F3F4F4] p-4 max-w-[494px] mt-6 rounded-lg mb-10">
              <div className="flex justify-between">
                <div>
                  <AttachUtilitySquareCheckbox
                    checkedIcon={images.CustomCheckedIcon}
                    label={"Exclude Address "}
                    checked={false}
                  />
                </div>
                <div>
                  <img src={images.ChevronDown} alt="icon" />
                </div>
              </div>
            </div>
            <div className="grid grid-cols-2 gap-4 ">
              <div className="max-w-[526px] ">
                <div className="flex ">
                  <button disabled={true} className="mr-6 btn-secondary ">
                    Back
                  </button>
                  <button disabled={true} className=" btn-primary">
                    Next
                  </button>
                </div>
              </div>
              <div className="flex justify-end">
                <button className="text-[#12221A] text-base font-semibold">
                  Cancel
                </button>
              </div>
            </div>
          </>
        )}
      </div>
    </>
  );
};

export default CommunityTargeting;

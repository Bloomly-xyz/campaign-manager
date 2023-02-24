import React, { useEffect, useState } from "react";
import ClaimUtilityTimer from "./ClaimUtilityComponents/ClaimUtilityTimer";
import {
  TabComponentClaim,
  TabHeaderClaim,
  TabPanelClaim,
  TabBodyClaim,
  TabClaim,
} from "../../components/common/ui-components/tabs-claimUtility-component/tabsClaim";
import PhysicalClaimUtility from "./ClaimUtilityComponents/PhysicalClaimUtility";
import DigitalClaimUtility from "./ClaimUtilityComponents/DigitalClaimUtility";
import ExperientailClaimUtility from "./ClaimUtilityComponents/ExperientailClaimUtility";
import images from "../../constants/images-constants/images";
import ClaimModal from "../common/modal-layout/ClaimModal";
import ClaimUtilityModal from "../modals-components/ClaimUtilityModal";
import AlertModalContent from "../modals-components/AlertModalContent";
import ClaimUtilityService from "../../services/claimUtility.service";
import { useDispatch, useSelector } from "react-redux";
import { setLoader } from "../../redux/slices/loading/loaderSlice";
import moment from "moment";
import { useNavigate, useParams } from "react-router-dom";
import Toast from "../../helpers/toast-component/Toast";

const ClaimUtilityContent = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const { id } = useParams();
  const { adminInfo } = useSelector((state) => state.user);
  const [openTab, setOpenTab] = useState(1);
  const [openClaimModal, setOpenClaimModal] = useState(false);
  const [openAlertModal, setOpenAlertModal] = useState(false);
  const [claimedUtility, setClaimedUtility] = useState(false)
  const [alertMessageContent, setAlertMessageContent] = useState({
    status: "",
    message: "",
    description: "",
    closeBtnText: "",
  });

  const [campaignData, setCampaignData] = useState({});
  const [campaignUtilitiesData, setCampaignUtilitiesData] = useState([]);

  const handleClaimForm = () => {
    if (!claimedUtility)
      setOpenClaimModal(true);
  };
  const handleClose = () => {
    setOpenAlertModal(false);
    getCampaignData();
  };

  useEffect(() => {
    getCampaignData();

    //eslint-disable-next-line
  }, [id]);

  const checkEndDate = (endDate) => {
    const currentMomentDate=moment()?.utc();
    const endMomentDate=moment(endDate)?.utc();
   if(moment(endMomentDate).isBefore(currentMomentDate))
      navigate("/oops");
  };

  const getCampaignData = () => {
    dispatch(setLoader(true));
    // pass the dynamic campaign Uuid
    ClaimUtilityService.getClaimUtilityData(id)
      .then((response) => {
        dispatch(setLoader(false));
        if (response?.statusCode === 200) {
           checkEndDate(response?.payload?.campaignEndDate);
          setCampaignData(response?.payload);
          checkIfClaimedAlready(response?.payload?.id, response?.payload?.userId)
          if (response?.payload?.campaignUtilities?.length > 0) {
            const data = response?.payload?.campaignUtilities;

            data?.forEach((data, pageIndex) => {
              if (data?.campaignUtilityJson) {
                let campaignUtilityObjectData = JSON.parse(
                  data?.campaignUtilityJson
                );
                setCampaignUtilitiesData([                  
                  campaignUtilityObjectData
                ]);
              }
            });
          }
        }
      })
      .catch((error) => {
        dispatch(setLoader(false));
        // Toast(
        //   error?.response?.data?.message ?? "something went wrong",
        //   "error"
        // );
       navigate("/oops");
      });
  };
  const checkIfClaimedAlready = (campaign_Id, userId) => {
    let payload = {
      userId: userId,
      campaignId: campaign_Id
    }
    ClaimUtilityService.getClaimUtility(payload).then((resp) => {
      if (resp?.payload) {
        setClaimedUtility(!resp?.payload)
      }
    }).catch((errpr) => {
      setClaimedUtility(true)
      dispatch(setLoader(false));
    })
  }

  return (
    <>
      <div className="grid grid-cols-2">
        <div className="mt-10">
          <h2 className="text-white text-[32px] capitalize   font-extrabold mb-6 ">
            {campaignData?.campaignName ?? "-"}
          </h2>
          <span className="mb-2 text-base font-normal text-white">
            {campaignData?.campaignStartDate &&
              campaignData?.campaignEndDate && (
                <>
                  {`  ${moment(campaignData?.campaignStartDate).format(
                    " MMM DD"
                  )} to ${moment(campaignData?.campaignEndDate).format(
                    " MMM DD"
                  )}`}
                </>
              )}
          </span>
          {campaignData?.campaignEndDate && (
            <div className="mt-2 mb-10">
              <ClaimUtilityTimer
                timeInMilliSeconds={moment
                  .utc(campaignData?.campaignEndDate)
                  .valueOf()}
              />
            </div>
          )}

          <div className="mb-10">
            <button
              className={` ${claimedUtility && 'cursor-not-allowed border border-[#A5F33C] bg-[#000000] hover:bg-[#000000] text-white disabled:bg-black  hover:bg-black focus:bg-black active:bg-black'} btn-primary  max-w-[238px] `}
              disabled={claimedUtility}
              onClick={handleClaimForm}
            >
              {claimedUtility && <img className="inline mr-2" src={images.ClaimedCheckedIcon} alt='icon' />}
              {`${claimedUtility ? 'Claimed' : 'Claim Utilty'}`}
            </button>
          </div>
          <div className="mb-10 mr-8">
            <TabComponentClaim>
              <TabHeaderClaim>
                {/* {campaignData?.physical && ( */}
                  <TabClaim openTab={openTab} setOpenTab={setOpenTab} value={1}>
                    Physical Utility
                  </TabClaim>
                {/* )} */}
                {/* {campaignData?.digital && ( */}
                  <TabClaim openTab={openTab} setOpenTab={setOpenTab} value={2} tooltip={true}>
                    Digital Utility
                  </TabClaim>
                {/* )} */}
                {/* {campaignData?.experencial && ( */}
                  <TabClaim openTab={openTab} setOpenTab={setOpenTab} value={3} tooltip={true}>
                    Experiential Utility
                  </TabClaim>
                {/* )} */}
              </TabHeaderClaim>

              {campaignUtilitiesData?.map((data, index) => (
                <>
                  <TabBodyClaim
                    physical={campaignData?.physical}
                    digital={campaignData?.digital}
                    experimental={campaignData?.experencial}
                  >
                    {campaignData?.physical && (
                      <TabPanelClaim openTab={openTab} value={1}>
                        <PhysicalClaimUtility physicalClaimUtilityData={data} />
                      </TabPanelClaim>
                    )}
                    {campaignData?.digital && (
                      <TabPanelClaim openTab={openTab} value={2}>
                        <DigitalClaimUtility DigitalClaimUtilityData={data} />
                      </TabPanelClaim>
                    )}
                    {campaignData?.experencial && (
                      <TabPanelClaim openTab={openTab} value={3}>
                        <ExperientailClaimUtility
                          ExperientailClaimUtilityData={data}
                        />
                      </TabPanelClaim>
                    )}
                  </TabBodyClaim>
                </>
              ))}

              {/* <TabPanelClaim openTab={openTab} value={2}>
                  <DigitalClaimUtility />
                </TabPanelClaim>
                <TabPanelClaim openTab={openTab} value={3}>
                  <ExperientailClaimUtility />
                </TabPanelClaim>
              </TabBodyClaim> */}
            </TabComponentClaim>
          </div>
        </div>
        <div className="text-center  max-h-[570px] p-10 overflow-hidden">
          <img className="inline max-w-[400px] max-h-[360px]" src={ campaignUtilitiesData?.[0]?.filePath} alt="icon" />
        </div>
      </div>
      {openClaimModal && (
        <ClaimModal
          openModal={openClaimModal}
          closeModal={setOpenClaimModal}
          children={
            <ClaimUtilityModal
              setAlertMessageContent={setAlertMessageContent}
              setOpenClaimModal={setOpenClaimModal}
              setOpenAlertModal={setOpenAlertModal}
              campaignData={campaignData}
            />
          }
          modal_Id="claim-utility-modal"
          mwidth={"532px"}
        />
      )}
      {openAlertModal && (
        <ClaimModal
          openModal={openAlertModal}
          closeModal={setOpenAlertModal}
          children={
            <AlertModalContent
              alertMessageContent={alertMessageContent}
              handleClose={handleClose}
            />
          }
          modal_Id="claim-utility-modal"
          mwidth={"532px"}
        />
      )}
    </>
  );
};

export default ClaimUtilityContent;

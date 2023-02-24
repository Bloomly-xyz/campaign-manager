import { yupResolver } from "@hookform/resolvers/yup";
import React from "react";
import { useForm } from "react-hook-form";
import { claimUtilitySchema } from "../../utils/validationSchema/ClaimUtilitySchema";
import CloseViewIcon from "../common/ui-components/CloseViewIcon";
import ClaimInputField from "./../common/ui-components/form-ui/ClaimInputField";
import ClaimUtilityService from './../../services/claimUtility.service';
import { useDispatch } from 'react-redux';
import { setLoader } from "../../redux/slices/loading/loaderSlice";
import Toast from "../../helpers/toast-component/Toast";
import BlockChainTx from "../../BlockChainTx/BlockChainTx";
import BlockChainErrorsHandler from "../../helpers/BlockChainErrorsHandler";
import images from "../../constants/images-constants/images";
import { Tooltip } from "@material-tailwind/react";

const ClaimUtilityModal = (props) => {
  const dispatch = useDispatch();
  const { setOpenClaimModal, setOpenAlertModal, setAlertMessageContent ,campaignData } =
    props;
    //console.log(JSON?.parse(campaignData?.blockChainJson))
  const {
    register,
    handleSubmit,

    // reset,
    formState: { errors, isDirty, isValid },
  } = useForm({
    resolver: yupResolver(claimUtilitySchema),
    mode: "all",
  });
  const handleCloseModal = () => {
    setOpenClaimModal(false);
  };
  const handleClaimUtility =async (values) => {
    dispatch(setLoader(true));
    let parsedClaimObj=JSON?.parse(campaignData?.blockChainJson);
    let claimObj={
      id:parsedClaimObj?.utilityTx?.data?.utilityId,
      collectionPublicPath:campaignData?.collectionPublicPath
    }
    const claimResp=await BlockChainTx?.claimUtilityTx(claimObj);
    if(!claimResp?.error){
    ClaimUtilityService.CreateClaimUtility(values ,campaignData?.id ,campaignData?.userId ,claimResp?.message?.txId)
    .then(response => {
      dispatch(setLoader(false))
      if(response?.statusCode === 200){
        setOpenClaimModal(false);
        setOpenAlertModal(true);
        setAlertMessageContent({
          status: "success",
          message: "Thank you for claiming your utility",
          closeBtnText:'Close demo',
          description:
            "Your journey into ongoing and managed NFT utility begins here! Creators and brands may continue to empower community members with additional utility and rewards.",
        });

      }
    })
    .catch(error => {
      dispatch(setLoader(false))
      Toast(error?.response?.data?.message ?? 'something went wrong',"error")
    })
  }
  else{
    dispatch(setLoader(false));
    setOpenClaimModal(false);
    let defaultErrMsg =
            "Error while claiming utility";
          let errDescription = BlockChainErrorsHandler(
            claimResp?.message,
            defaultErrMsg
          );
      Toast(errDescription,"error")
  }

    
    
   
  };
  return (
    <>
      <div className="relative">
        <CloseViewIcon claim={true} handleClose={handleCloseModal} />
        <div>
          <h2 className="mb-4 text-2xl font-bold text-white">Claim Utility </h2>
          <form onSubmit={handleSubmit(handleClaimUtility)}>
            <div className="mb-6">
              <ClaimInputField
                type="text"
                label="Name*"
                register={register}
                name="name"
                placeholder={""}
              />
              <p className="mt-1 text-xs text-red-600">
                {errors?.name?.message}
              </p>
            </div>
            <div className="mb-6">
              <ClaimInputField
                type="text"
                label="Email Address*"
                register={register}
                name="emailAddress"
                placeholder={""}
              />
              <p className="mt-1 text-xs text-red-600">
                {errors?.emailAddress?.message}
              </p>
            </div>
            <div className="mb-6">
              <ClaimInputField
                type="text"
                label="Shipping Address*"
                register={register}
                name="shippingAddress"
                placeholder={""}
              />
              <p className="mt-1 text-xs text-red-600">
                {errors?.shippingAddress?.message}
              </p>
            </div>
            <div className="mb-6">
              <ClaimInputField
                type="text"
                label="Phone Number*"
                register={register}
                name="phoneNumber"
                placeholder={""}
              />
              <p className="mt-1 text-xs text-red-600">
                {errors?.phoneNumber?.message}
              </p>
            </div>
            <div className="mb-10">
              <ClaimInputField
                type="text"
                label="other*"
                register={register}
                name="other"
                placeholder={""}
              />
              <p className="mt-1 text-xs text-red-600">
                {errors?.other?.message}
              </p>
            </div>
            <Tooltip 
          className="text-[#12221A] px-4 py-1 rounded bg-white   max-w-[200px] relative z-50"
          offset={10}
          placement={"top-center"}
          content={"coming soon "}
        >
            <div className="mb-10 inline-flex items-center ">
              <img className="mr-[6px] opacity-[0.7]" src={images.AddMoreIcon} alt="addFieldsIcons"/>
              <p className="text-white text-xs  w-full  font-medium bg-transparent  ">Add More Field</p>
            </div>
            </Tooltip>
            <button disabled={!isDirty || !isValid} className="btn-primary">
              Submit
            </button>
          </form>
        </div>
      </div>
    </>
  );
};

export default ClaimUtilityModal;
